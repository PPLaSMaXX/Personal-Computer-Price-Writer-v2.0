
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
            this.cboPresetSelector = new System.Windows.Forms.ComboBox();
            this.btnSavePreset = new System.Windows.Forms.Button();
            this.btnDeletePreset = new System.Windows.Forms.Button();
            this.btnPullAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPull
            // 
            this.btnPull.Location = new System.Drawing.Point(13, 154);
            this.btnPull.Margin = new System.Windows.Forms.Padding(2);
            this.btnPull.Name = "btnPull";
            this.btnPull.Size = new System.Drawing.Size(128, 22);
            this.btnPull.TabIndex = 0;
            this.btnPull.Text = "Pull This";
            this.btnPull.UseVisualStyleBackColor = true;
            this.btnPull.Click += new System.EventHandler(this.BtnPull_Click);
            // 
            // btnChooseDataPath
            // 
            this.btnChooseDataPath.Location = new System.Drawing.Point(224, 104);
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
            this.label1.Location = new System.Drawing.Point(10, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Link";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 88);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Data Folder";
            // 
            // tbDataPath
            // 
            this.tbDataPath.Location = new System.Drawing.Point(12, 105);
            this.tbDataPath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 0);
            this.tbDataPath.Name = "tbDataPath";
            this.tbDataPath.Size = new System.Drawing.Size(209, 20);
            this.tbDataPath.TabIndex = 4;
            // 
            // tbLink
            // 
            this.tbLink.Location = new System.Drawing.Point(12, 60);
            this.tbLink.Margin = new System.Windows.Forms.Padding(2, 2, 2, 0);
            this.tbLink.Name = "tbLink";
            this.tbLink.Size = new System.Drawing.Size(265, 20);
            this.tbLink.TabIndex = 5;
            // 
            // bootCheckBox
            // 
            this.bootCheckBox.AutoSize = true;
            this.bootCheckBox.Location = new System.Drawing.Point(200, 128);
            this.bootCheckBox.Name = "bootCheckBox";
            this.bootCheckBox.Size = new System.Drawing.Size(77, 19);
            this.bootCheckBox.TabIndex = 6;
            this.bootCheckBox.Text = "Autoboot";
            this.bootCheckBox.UseVisualStyleBackColor = true;
            this.bootCheckBox.CheckedChanged += new System.EventHandler(this.bootCheckBox_CheckedChanged);
            // 
            // cboPresetSelector
            // 
            this.cboPresetSelector.FormattingEnabled = true;
            this.cboPresetSelector.Location = new System.Drawing.Point(11, 12);
            this.cboPresetSelector.Name = "cboPresetSelector";
            this.cboPresetSelector.Size = new System.Drawing.Size(266, 21);
            this.cboPresetSelector.TabIndex = 7;
            this.cboPresetSelector.SelectedIndexChanged += new System.EventHandler(this.cboPresetSelector_SelectedIndexChanged);
            // 
            // btnSavePreset
            // 
            this.btnSavePreset.Location = new System.Drawing.Point(13, 127);
            this.btnSavePreset.Margin = new System.Windows.Forms.Padding(2);
            this.btnSavePreset.Name = "btnSavePreset";
            this.btnSavePreset.Size = new System.Drawing.Size(82, 22);
            this.btnSavePreset.TabIndex = 8;
            this.btnSavePreset.Text = "Save";
            this.btnSavePreset.UseVisualStyleBackColor = true;
            this.btnSavePreset.Click += new System.EventHandler(this.btnSavePreset_Click);
            // 
            // btnDeletePreset
            // 
            this.btnDeletePreset.Location = new System.Drawing.Point(103, 127);
            this.btnDeletePreset.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeletePreset.Name = "btnDeletePreset";
            this.btnDeletePreset.Size = new System.Drawing.Size(82, 22);
            this.btnDeletePreset.TabIndex = 9;
            this.btnDeletePreset.Text = "Delete";
            this.btnDeletePreset.UseVisualStyleBackColor = true;
            this.btnDeletePreset.Click += new System.EventHandler(this.btnDeletePreset_Click);
            // 
            // btnPullAll
            // 
            this.btnPullAll.Location = new System.Drawing.Point(151, 153);
            this.btnPullAll.Margin = new System.Windows.Forms.Padding(2);
            this.btnPullAll.Name = "btnPullAll";
            this.btnPullAll.Size = new System.Drawing.Size(126, 22);
            this.btnPullAll.TabIndex = 10;
            this.btnPullAll.Text = "Pull All";
            this.btnPullAll.UseVisualStyleBackColor = true;
            this.btnPullAll.Click += new System.EventHandler(this.btnPullAll_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 183);
            this.Controls.Add(this.btnPullAll);
            this.Controls.Add(this.btnDeletePreset);
            this.Controls.Add(this.btnSavePreset);
            this.Controls.Add(this.cboPresetSelector);
            this.Controls.Add(this.bootCheckBox);
            this.Controls.Add(this.tbLink);
            this.Controls.Add(this.tbDataPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnChooseDataPath);
            this.Controls.Add(this.btnPull);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(305, 230);
            this.MinimumSize = new System.Drawing.Size(305, 230);
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
        private System.Windows.Forms.ComboBox cboPresetSelector;
        private System.Windows.Forms.Button btnSavePreset;
        private System.Windows.Forms.Button btnDeletePreset;
        private System.Windows.Forms.Button btnPullAll;
    }
}

