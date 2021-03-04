using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PCPW2
{
    public partial class Form1 : Form
    {
        private const string cfgPath = "config.json";
        Config cfg;
        ConfigIO cfgIO = new ConfigIO();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cfg = cfgIO.ReadFromFile(cfg, cfgPath);
            if (cfg == null)
            {
                ShowErrorMessage("config file can not be read");
            }

            tbDataPath.Text = cfg.saveFilePath;
            tbLink.Text = cfg.link;
        }

        private async void btnPull_Click(object sender, EventArgs e)
        {
            DataWriter dataWriter = new DataWriter();
            Parser parser = new Parser();
            List<ParsedProduct> products;

            if (cfg.link != tbLink.Text) cfg.link = tbLink.Text;
            if (cfg.saveFilePath != tbLink.Text) cfg.saveFilePath = tbDataPath.Text;
            if (!cfgIO.SaveToFIle(cfg, cfgPath))
            {
                ShowErrorMessage("Can`t save config");
            }

            products = await parser.ParseLink(cfg.link);
            if (products == null)
            {
                ShowErrorMessage("Data doesn`t parsed!");
                return;
            }

            if (!dataWriter.WriteToFIle(products, cfg.saveFilePath) && cfg.saveFilePath == "")
            {
                ShowErrorMessage("Folder doesn't choosen");
            }

        }

        private void btnChooseDataPath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tbDataPath.Text = folderBrowserDialog1.SelectedPath + "\\PriceData.csv";
                cfg.saveFilePath = tbDataPath.Text;
                cfgIO.SaveToFIle(cfg, cfgPath);
            }
        }

        private void ShowErrorMessage(string error)
        {
            MessageBox.Show($"Error: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
