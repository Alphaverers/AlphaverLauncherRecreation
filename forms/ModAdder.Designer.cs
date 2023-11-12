namespace AlphaverLauncherRecreation.forms
{
    partial class ModAdder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModAdder));
            this.versionBox = new System.Windows.Forms.ComboBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.selectJarButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // versionBox
            // 
            this.versionBox.AutoCompleteCustomSource.AddRange(new string[] {
            "v1605_unrpreview2",
            "v1605_preview",
            "lilypad_qa",
            "ext1605_20"});
            this.versionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.versionBox.FormattingEnabled = true;
            this.versionBox.Items.AddRange(new object[] {
            "ext1605_20",
            "lilypad_qa",
            "v1605_preview",
            "v1605_unrpreview2"});
            this.versionBox.Location = new System.Drawing.Point(355, 103);
            this.versionBox.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.versionBox.Name = "versionBox";
            this.versionBox.Size = new System.Drawing.Size(277, 37);
            this.versionBox.TabIndex = 0;
            //this.versionBox.SelectedIndexChanged += new System.EventHandler(this.versionBox_SelectedIndexChanged);
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(355, 239);
            this.nameBox.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(277, 35);
            this.nameBox.TabIndex = 1;
            // 
            // selectJarButton
            // 
            this.selectJarButton.Location = new System.Drawing.Point(210, 350);
            this.selectJarButton.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.selectJarButton.Name = "selectJarButton";
            this.selectJarButton.Size = new System.Drawing.Size(427, 80);
            this.selectJarButton.TabIndex = 2;
            this.selectJarButton.Text = "Browse .jar";
            this.selectJarButton.UseVisualStyleBackColor = true;
            this.selectJarButton.Click += new System.EventHandler(this.selectJarButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(210, 522);
            this.saveButton.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(427, 116);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(203, 103);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Version";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 245);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mod Name";
            // 
            // ModAdder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AlphaverLauncherRecreation.Properties.Resources.dirt;
            this.ClientSize = new System.Drawing.Size(873, 790);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.selectJarButton);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.versionBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.Name = "ModAdder";
            this.Text = "Mod Adder";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox versionBox;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Button selectJarButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}