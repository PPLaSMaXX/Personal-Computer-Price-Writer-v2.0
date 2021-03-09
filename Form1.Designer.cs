
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
            this.btnPull = new System.Windows.Forms.Button();
            this.btnChooseDataPath = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDataPath = new System.Windows.Forms.TextBox();
            this.tbLink = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // btnPull
            // 
            this.btnPull.Location = new System.Drawing.Point(12, 60);
            this.btnPull.Name = "btnPull";
            this.btnPull.Size = new System.Drawing.Size(262, 23);
            this.btnPull.TabIndex = 0;
            this.btnPull.Text = "Pull";
            this.btnPull.UseVisualStyleBackColor = true;
            this.btnPull.Click += new System.EventHandler(this.BtnPull_Click);
            // 
            // btnChooseDataPath
            // 
            this.btnChooseDataPath.Location = new System.Drawing.Point(206, 32);
            this.btnChooseDataPath.Name = "btnChooseDataPath";
            this.btnChooseDataPath.Size = new System.Drawing.Size(68, 23);
            this.btnChooseDataPath.TabIndex = 1;
            this.btnChooseDataPath.Text = "Choose ";
            this.btnChooseDataPath.UseVisualStyleBackColor = true;
            this.btnChooseDataPath.Click += new System.EventHandler(this.BtnChooseDataPath_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Link";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Data Folder";
            // 
            // tbDataPath
            // 
            this.tbDataPath.Location = new System.Drawing.Point(100, 32);
            this.tbDataPath.Name = "tbDataPath";
            this.tbDataPath.Size = new System.Drawing.Size(100, 22);
            this.tbDataPath.TabIndex = 4;
            // 
            // tbLink
            // 
            this.tbLink.Location = new System.Drawing.Point(100, 4);
            this.tbLink.Name = "tbLink";
            this.tbLink.Size = new System.Drawing.Size(174, 22);
            this.tbLink.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 98);
            this.Controls.Add(this.tbLink);
            this.Controls.Add(this.tbDataPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnChooseDataPath);
            this.Controls.Add(this.btnPull);
            this.MaximumSize = new System.Drawing.Size(300, 145);
            this.MinimumSize = new System.Drawing.Size(300, 145);
            this.Name = "Form1";
            this.Text = "PCPW v2";
            this.Load += new System.EventHandler(this.Form1_Load);
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
    }
}

