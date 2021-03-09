using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PCPW2
{
    public partial class Form1 : Form
    {
        private const string cfgPath = "config.json";
        Config cfg;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cfg = ConfigIO.ReadFromFile(cfgPath);

            if (cfg == null)
            {
                ShowErrorMessage("config file can not be read");
                cfg = new Config();
            }

            //sync config values with UI
            tbDataPath.Text = cfg.saveFilePath;
            tbLink.Text = cfg.link;
        }

        private async void BtnPull_Click(object sender, EventArgs e)
        {
            // Get config values from UI
            if (cfg.link != tbLink.Text) cfg.link = tbLink.Text;
            if (cfg.saveFilePath != tbLink.Text) cfg.saveFilePath = tbDataPath.Text;

            // Save configuration to file
            if (!ConfigIO.SaveToFIle(cfg, cfgPath))
            {
                ShowErrorMessage("Can`t save config");
            }

            // Parse products
            Parser parser = new Parser();
            List<ParsedProduct>  products = await parser.ParseLink(cfg.link);

            // If parse error
            if (products == null)
            {
                ShowErrorMessage("Data doesn`t parsed!");
                return;
            }

            //write data to csv file
            if (!DataWriter.WriteToFIle(products, cfg.saveFilePath) && cfg.saveFilePath == "")
            {
                ShowErrorMessage("Folder doesn't choosen");
            }

        }

        private void BtnChooseDataPath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tbDataPath.Text = folderBrowserDialog1.SelectedPath + "\\PriceData.csv";
                cfg.saveFilePath = tbDataPath.Text;
                ConfigIO.SaveToFIle(cfg, cfgPath);
            }
        }

        private void ShowErrorMessage(string error)
        {
            MessageBox.Show($"Error: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
