using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCPW2
{
    public partial class Form1 : Form
    {
        private string cfgPath = AppDomain.CurrentDomain.BaseDirectory + "config.json";
        Config cfg;

        public Form1()
        {
            // Reading cfg
            cfg = ConfigIO.ReadFromFile(cfgPath);

            InitializeComponent();

            if (cfg == null)
            {
                ShowErrorMessage("config file can not be read");
                cfg = new Config();
            }
            else
            {
                // Sync config values with UI
                tbDataPath.Text = cfg.saveFilePath.Replace("\\PriceData.csv", "");
                tbLink.Text = cfg.link;
            }

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
                tbDataPath.Text = folderBrowserDialog1.SelectedPath;
                cfg.saveFilePath = tbDataPath.Text + "\\PriceData.csv";
                ConfigIO.SaveToFile(cfg, cfgPath);
            }
        }

        private async Task<bool> Pull()
        {
            btnPull.Enabled = false;
            btnChooseDataPath.Enabled = false;

            // Get config values from UI
            if (cfg.link != tbLink.Text) cfg.link = tbLink.Text;
            if (cfg.saveFilePath.Replace("\\PriceData.csv", "") != tbDataPath.Text) cfg.saveFilePath = tbDataPath.Text;

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

            btnChooseDataPath.Enabled = true;
            btnPull.Enabled = true;

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

        private void BootControl(bool isAutoBoot)
        {
            RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (isAutoBoot == true)
            {
                // Adding to boot using register
                if (reg.GetValue("PCPW2") == null)
                {
                    reg.SetValue("PCPW2", Application.ExecutablePath + " --silent");
                    ShowErrorMessage("EN");
                }
            }
            else
            {
                if (reg.GetValue("PCPW2") != null)
                {
                    reg.DeleteValue("PCPW2");
                    ShowErrorMessage("DIS");
                }
            }
        }

        private void ShowErrorMessage(string errorText)
        {
            MessageBox.Show($"Error: {errorText}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void bootCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            BootControl(bootCheckBox.Checked);
        }
    }
}