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
        Config cfg = new Config();
        ConfigIO cfgIO = new ConfigIO();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!cfgIO.ReadFromFile(cfg, cfgPath))
            {
                MessageBox.Show("Error: config file can not be read", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            tbDataPath.Text = cfg.saveFilePath;
            tbLink.Text = cfg.link;

        }

        private void btnPull_Click(object sender, EventArgs e)
        {
            if (cfg.link != tbLink.Text) cfg.link = tbLink.Text;
            if (cfg.saveFilePath != tbLink.Text) cfg.saveFilePath = tbDataPath.Text;
            cfgIO.SaveToFIle(cfg, cfgPath);
        }

        private void btnChooseDataPath_Click(object sender, EventArgs e)
        {

        }
    }
}
