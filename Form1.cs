using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Threading.Tasks;

namespace PCPW2
{
    public partial class Form1 : Form
    {
        private const string cfgPath = "config.json";
        Config cfg;

        public Form1()
        {
            // Checking and adding to boot
            AddToBoot();

            // Reading cfg
            cfg = ConfigIO.ReadFromFile(cfgPath);

            if (cfg == null)
            {
                ShowErrorMessage("config file can not be read");
                cfg = new Config();
            }

            InitializeComponent();

            // Sync config values with UI
            tbDataPath.Text = cfg.saveFilePath;
            tbLink.Text = cfg.link;

            // Checking arguments
            if (IsSilenceLaunch())
            {
                LaunchOnSilentMode();
            }
            
        }

        private async void BtnPull_Click(object sender, EventArgs e)
        {
            await Pull();
        }

        private void BtnChooseDataPath_Click(object sender, EventArgs e)
        {
            // Adding file saving path
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tbDataPath.Text = folderBrowserDialog1.SelectedPath + "\\PriceData.csv";
                cfg.saveFilePath = tbDataPath.Text;
                ConfigIO.SaveToFile(cfg, cfgPath);
            }
        }

        private async Task<bool> Pull()
        {
            // Get config values from UI
            if (cfg.link != tbLink.Text) cfg.link = tbLink.Text;
            if (cfg.saveFilePath != tbLink.Text) cfg.saveFilePath = tbDataPath.Text;

            // Save configuration to file
            if (!ConfigIO.SaveToFile(cfg, cfgPath))
            {
                ShowErrorMessage("Can`t save config");
                return false;
            }

            // Parse products
            Parser parser = new Parser();
            List<ParsedProduct> products = await parser.ParseLink(cfg.link);

            // If parse error
            if (products == null)
            {
                ShowErrorMessage("Data doesn`t parsed!");
                return false;
            }

            // Write data to csv file
            if (!DataWriter.WriteToFIle(products, cfg.saveFilePath) && cfg.saveFilePath == "")
            {
                ShowErrorMessage("Folder doesn't chosen");
                return false;
            }

            MessageBox.Show("Success", "OK!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        private async void LaunchOnSilentMode()
        {
            // Hiding the form
            this.Visible = false;
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;

            // Parse
            await Pull();

            // Close form
            this.Close();
        }

        private bool IsSilenceLaunch()
        {
            // Cheking the arguments
            string[] arguments = Environment.GetCommandLineArgs();
			
            if (arguments.Contains("--silent")) 
			{
				return true;
			}
            else 
			{
				return false;
			}
        }

        private void AddToBoot()
        {
            // Adding to boot using register
            RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (reg.GetValue("PCPW") != null)
            {
                reg.SetValue("PCPW", Application.ExecutablePath + " --silent");
            }

        }

        private void ShowErrorMessage(string error)
        {
            MessageBox.Show($"Error: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

