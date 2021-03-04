using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                MessageBox.Show("Error: config file can not be read", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            tbDataPath.Text = cfg.saveFilePath;
            tbLink.Text = cfg.link;

        }

        private async void btnPull_Click(object sender, EventArgs e)
        {
            Parser parser = new Parser();
            List<ParsedProduct> products = new List<ParsedProduct>();

            if (cfg.link != tbLink.Text) cfg.link = tbLink.Text;
            if (cfg.saveFilePath != tbLink.Text) cfg.saveFilePath = tbDataPath.Text;
            cfgIO.SaveToFIle(cfg, cfgPath);

            products = await parser.ParseLink(cfg.link);
            if(products == null)
            {
                MessageBox.Show("Error: Data doesn`t Parsed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnChooseDataPath_Click(object sender, EventArgs e)
        {

        }
    }
}
