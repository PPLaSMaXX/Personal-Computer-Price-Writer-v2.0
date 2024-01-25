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
        private string jsonPath = AppDomain.CurrentDomain.BaseDirectory + "config.json";
        List<Preset> presets = new List<Preset>();
        int SelectedPresetIndex = 0;
        public Form1()
        {
            // Reading cfg
            presets = JsonIO.ReadFromFile(jsonPath);

            InitializeComponent();

            if (presets == null || presets.Count == 0)
            {
                ShowErrorMessage("config file can not be read");
            }
            else
            {
                // Sync json values with UI
                tbDataPath.Text = presets[SelectedPresetIndex].saveFilePath.Replace("\\PriceData.csv", "");
                tbLink.Text = presets[SelectedPresetIndex].link;
                cboPresetSelector.Items.AddRange(presets.Select(x => x.Name).ToArray());
                cboPresetSelector.SelectedIndex = 0;
            }

            // Checking arguments
            if (IsSilenceLaunch())
            {
                LaunchOnSilentMode();
            }
        }

        private async void BtnPull_Click(object sender, EventArgs e)
        {
            btnPull.Enabled = false;
            btnChooseDataPath.Enabled = false;
            btnDeletePreset.Enabled = false;
            btnPullAll.Enabled = false;
            btnSavePreset.Enabled = false;
            cboPresetSelector.Enabled = false;

            await Pull();

            btnPull.Enabled = true;
            btnChooseDataPath.Enabled = true;
            btnDeletePreset.Enabled = true;
            btnPullAll.Enabled = true;
            btnSavePreset.Enabled = true;
            cboPresetSelector.Enabled = true;
        }

        private void BtnChooseDataPath_Click(object sender, EventArgs e)
        {
            // Adding file saving path
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tbDataPath.Text = folderBrowserDialog1.SelectedPath;
                JsonIO.SaveToFile(presets, jsonPath);
            }
        }

        private async Task<bool> Pull()
        {               
            // Save configuration to file
            if (!JsonIO.SaveToFile(presets, jsonPath))
            {
                ShowErrorMessage("Can`t save config");
                return false;
            }

            // Parse products
            Parser parser = new Parser();
            List<ParsedProduct> products = await parser.ParseLink(tbLink.Text);

            // If parse error
            if (products == null)
            {
                ShowErrorMessage("Data doesn`t parsed!");
                return false;
            }

            // Write data to csv file
            if (!DataWriter.WriteToFIle(products, tbDataPath.Text) && tbDataPath.Text == "")
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

        private void BootControl(bool isAutoBoot)
        {
            RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (isAutoBoot == true)
            {
                // Adding to boot using register
                if (reg.GetValue("PCPW2") == null)
                {
                    reg.SetValue("PCPW2", Application.ExecutablePath + " --silent");
                }
            }
            else
            {
                if (reg.GetValue("PCPW2") != null)
                {
                    reg.DeleteValue("PCPW2");
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

        private void cboPresetSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedPresetIndex = cboPresetSelector.SelectedIndex;
            tbDataPath.Text = presets[SelectedPresetIndex].saveFilePath.Replace("\\PriceData.csv", "");
            tbLink.Text = presets[SelectedPresetIndex].link;
        }

        private void btnSavePreset_Click(object sender, EventArgs e)
        {
            string name = ShowDialog("Enter the name of your preset", "hella fun");
            presets.Add(new Preset(name, tbLink.Text, tbDataPath.Text));
            JsonIO.SaveToFile(presets, jsonPath);
            cboPresetSelector.Items.Clear();
            cboPresetSelector.Items.AddRange(presets.Select(x => x.Name).ToArray());
            cboPresetSelector.SelectedIndex = cboPresetSelector.Items.Count - 1;
        }

        private void btnDeletePreset_Click(object sender, EventArgs e)
        {
            presets.RemoveAt(SelectedPresetIndex);
            JsonIO.SaveToFile(presets,jsonPath);
            cboPresetSelector.Text = "";
            cboPresetSelector.Items.Clear();
            cboPresetSelector.Items.AddRange(presets.Select(x => x.Name).ToArray());
            if(SelectedPresetIndex - 1 >= 0)
            {
                SelectedPresetIndex -= 1;
                cboPresetSelector.SelectedIndex = SelectedPresetIndex;
            }
        }

        private void btnPullAll_Click(object sender, EventArgs e)
        {

        }

        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text, AutoSize = true };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}