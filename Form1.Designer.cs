
namespace PCPW2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnPull = new System.Windows.Forms.Button();
            this.btnChooseDataPath = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDataPath = new System.Windows.Forms.TextBox();
            this.tbLink = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.bootCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnPull
            // 
            this.btnPull.Location = new System.Drawing.Point(11, 90);
            this.btnPull.Margin = new System.Windows.Forms.Padding(2);
            this.btnPull.Name = "btnPull";
            this.btnPull.Size = new System.Drawing.Size(210, 22);
            this.btnPull.TabIndex = 0;
            this.btnPull.Text = "Pull";
            this.btnPull.UseVisualStyleBackColor = true;
            this.btnPull.Click += new System.EventHandler(this.BtnPull_Click);
            // 
            // btnChooseDataPath
            // 
            this.btnChooseDataPath.Location = new System.Drawing.Point(224, 66);
            this.btnChooseDataPath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnChooseDataPath.Name = "btnChooseDataPath";
            this.btnChooseDataPath.Size = new System.Drawing.Size(53, 22);
            this.btnChooseDataPath.TabIndex = 1;
            this.btnChooseDataPath.Text = "Choose ";
            this.btnChooseDataPath.UseVisualStyleBackColor = true;
            this.btnChooseDataPath.Click += new System.EventHandler(this.BtnChooseDataPath_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Link";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Data Folder";
            // 
            // tbDataPath
            // 
            this.tbDataPath.Location = new System.Drawing.Point(12, 67);
            this.tbDataPath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 0);
            this.tbDataPath.Name = "tbDataPath";
            this.tbDataPath.Size = new System.Drawing.Size(209, 20);
            this.tbDataPath.TabIndex = 4;
            // 
            // tbLink
            // 
            this.tbLink.Location = new System.Drawing.Point(12, 22);
            this.tbLink.Margin = new System.Windows.Forms.Padding(2, 2, 2, 0);
            this.tbLink.Name = "tbLink";
            this.tbLink.Size = new System.Drawing.Size(265, 20);
            this.tbLink.TabIndex = 5;
            // 
            // bootCheckBox
            // 
            this.bootCheckBox.AutoSize = true;
            this.bootCheckBox.Location = new System.Drawing.Point(224, 91);
            this.bootCheckBox.Name = "bootCheckBox";
            this.bootCheckBox.Size = new System.Drawing.Size(69, 17);
            this.bootCheckBox.TabIndex = 6;
            this.bootCheckBox.Text = "Autoboot";
            this.bootCheckBox.UseVisualStyleBackColor = true;
            this.bootCheckBox.CheckedChanged += new System.EventHandler(this.bootCheckBox_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 122);
            this.Controls.Add(this.bootCheckBox);
            this.Controls.Add(this.tbLink);
            this.Controls.Add(this.tbDataPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnChooseDataPath);
            this.Controls.Add(this.btnPull);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(305, 161);
            this.MinimumSize = new System.Drawing.Size(305, 161);
            this.Name = "Form1";
            this.Text = "PCPW v2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPull;
        private System.Windows.Forms.Button btnChooseDataPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDataPath;
        private System.Windows.Forms.TextBox tbLink;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckBox bootCheckBox;
    }
}

