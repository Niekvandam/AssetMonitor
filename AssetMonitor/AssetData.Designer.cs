namespace AssetMonitor
{
    partial class AssetData
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
            this.closeButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.assetUserTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxAssetNotFound = new System.Windows.Forms.Label();
            this.assetDescriptionTextBox = new System.Windows.Forms.RichTextBox();
            this.assetDescriptionLabel = new System.Windows.Forms.Label();
            this.assetNumberLabel = new System.Windows.Forms.Label();
            this.SerialNumberLabel = new System.Windows.Forms.Label();
            this.assetStatusLabel = new System.Windows.Forms.Label();
            this.assetNumberTextBox = new System.Windows.Forms.TextBox();
            this.serialNumberTextBox = new System.Windows.Forms.TextBox();
            this.assetStatusTextBox = new System.Windows.Forms.TextBox();
            this.localUserTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.userStatusTextBox = new System.Windows.Forms.TextBox();
            this.personnelNumberTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.assetComments = new System.Windows.Forms.Label();
            this.commentsTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(493, 255);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 5;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.personnelNumberTextBox);
            this.groupBox1.Controls.Add(this.userStatusTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.localUserTextBox);
            this.groupBox1.Controls.Add(this.assetStatusTextBox);
            this.groupBox1.Controls.Add(this.serialNumberTextBox);
            this.groupBox1.Controls.Add(this.assetNumberTextBox);
            this.groupBox1.Controls.Add(this.assetStatusLabel);
            this.groupBox1.Controls.Add(this.SerialNumberLabel);
            this.groupBox1.Controls.Add(this.assetNumberLabel);
            this.groupBox1.Controls.Add(this.assetDescriptionLabel);
            this.groupBox1.Controls.Add(this.assetComments);
            this.groupBox1.Controls.Add(this.assetDescriptionTextBox);
            this.groupBox1.Controls.Add(this.commentsTextBox);
            this.groupBox1.Controls.Add(this.assetUserTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(554, 237);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Clientele data of asset:";
            // 
            // assetUserTextBox
            // 
            this.assetUserTextBox.Enabled = false;
            this.assetUserTextBox.Location = new System.Drawing.Point(10, 38);
            this.assetUserTextBox.Name = "assetUserTextBox";
            this.assetUserTextBox.Size = new System.Drawing.Size(111, 20);
            this.assetUserTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Asset User (clientele)";
            // 
            // textBoxAssetNotFound
            // 
            this.textBoxAssetNotFound.AutoSize = true;
            this.textBoxAssetNotFound.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAssetNotFound.ForeColor = System.Drawing.Color.Red;
            this.textBoxAssetNotFound.Location = new System.Drawing.Point(12, 255);
            this.textBoxAssetNotFound.Name = "textBoxAssetNotFound";
            this.textBoxAssetNotFound.Size = new System.Drawing.Size(433, 22);
            this.textBoxAssetNotFound.TabIndex = 6;
            this.textBoxAssetNotFound.Text = "Warning: given asset is not present in Clientele";
            this.textBoxAssetNotFound.Visible = false;
            // 
            // assetDescriptionTextBox
            // 
            this.assetDescriptionTextBox.Location = new System.Drawing.Point(276, 43);
            this.assetDescriptionTextBox.Name = "assetDescriptionTextBox";
            this.assetDescriptionTextBox.ReadOnly = true;
            this.assetDescriptionTextBox.Size = new System.Drawing.Size(272, 36);
            this.assetDescriptionTextBox.TabIndex = 12;
            this.assetDescriptionTextBox.Text = "";
            // 
            // assetDescriptionLabel
            // 
            this.assetDescriptionLabel.AutoSize = true;
            this.assetDescriptionLabel.Location = new System.Drawing.Point(273, 20);
            this.assetDescriptionLabel.Name = "assetDescriptionLabel";
            this.assetDescriptionLabel.Size = new System.Drawing.Size(60, 13);
            this.assetDescriptionLabel.TabIndex = 14;
            this.assetDescriptionLabel.Text = "Description";
            // 
            // assetNumberLabel
            // 
            this.assetNumberLabel.AutoSize = true;
            this.assetNumberLabel.Location = new System.Drawing.Point(7, 148);
            this.assetNumberLabel.Name = "assetNumberLabel";
            this.assetNumberLabel.Size = new System.Drawing.Size(73, 13);
            this.assetNumberLabel.TabIndex = 15;
            this.assetNumberLabel.Text = "Asset Number";
            // 
            // SerialNumberLabel
            // 
            this.SerialNumberLabel.AutoSize = true;
            this.SerialNumberLabel.Location = new System.Drawing.Point(10, 187);
            this.SerialNumberLabel.Name = "SerialNumberLabel";
            this.SerialNumberLabel.Size = new System.Drawing.Size(70, 13);
            this.SerialNumberLabel.TabIndex = 16;
            this.SerialNumberLabel.Text = "SerialNumber";
            // 
            // assetStatusLabel
            // 
            this.assetStatusLabel.AutoSize = true;
            this.assetStatusLabel.Location = new System.Drawing.Point(10, 109);
            this.assetStatusLabel.Name = "assetStatusLabel";
            this.assetStatusLabel.Size = new System.Drawing.Size(66, 13);
            this.assetStatusLabel.TabIndex = 17;
            this.assetStatusLabel.Text = "Asset Status";
            // 
            // assetNumberTextBox
            // 
            this.assetNumberTextBox.Enabled = false;
            this.assetNumberTextBox.Location = new System.Drawing.Point(10, 164);
            this.assetNumberTextBox.Name = "assetNumberTextBox";
            this.assetNumberTextBox.Size = new System.Drawing.Size(237, 20);
            this.assetNumberTextBox.TabIndex = 18;
            // 
            // serialNumberTextBox
            // 
            this.serialNumberTextBox.Enabled = false;
            this.serialNumberTextBox.Location = new System.Drawing.Point(10, 203);
            this.serialNumberTextBox.Name = "serialNumberTextBox";
            this.serialNumberTextBox.Size = new System.Drawing.Size(237, 20);
            this.serialNumberTextBox.TabIndex = 19;
            // 
            // assetStatusTextBox
            // 
            this.assetStatusTextBox.Enabled = false;
            this.assetStatusTextBox.Location = new System.Drawing.Point(10, 125);
            this.assetStatusTextBox.Name = "assetStatusTextBox";
            this.assetStatusTextBox.Size = new System.Drawing.Size(237, 20);
            this.assetStatusTextBox.TabIndex = 20;
            // 
            // localUserTextBox
            // 
            this.localUserTextBox.Enabled = false;
            this.localUserTextBox.Location = new System.Drawing.Point(153, 38);
            this.localUserTextBox.Name = "localUserTextBox";
            this.localUserTextBox.Size = new System.Drawing.Size(94, 20);
            this.localUserTextBox.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Last User (local)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "User status";
            // 
            // userStatusTextBox
            // 
            this.userStatusTextBox.Enabled = false;
            this.userStatusTextBox.Location = new System.Drawing.Point(10, 82);
            this.userStatusTextBox.Name = "userStatusTextBox";
            this.userStatusTextBox.Size = new System.Drawing.Size(111, 20);
            this.userStatusTextBox.TabIndex = 24;
            // 
            // personnelNumberTextBox
            // 
            this.personnelNumberTextBox.Enabled = false;
            this.personnelNumberTextBox.Location = new System.Drawing.Point(153, 81);
            this.personnelNumberTextBox.Name = "personnelNumberTextBox";
            this.personnelNumberTextBox.Size = new System.Drawing.Size(94, 20);
            this.personnelNumberTextBox.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(153, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Personnel Number";
            // 
            // assetComments
            // 
            this.assetComments.AutoSize = true;
            this.assetComments.Location = new System.Drawing.Point(273, 89);
            this.assetComments.Name = "assetComments";
            this.assetComments.Size = new System.Drawing.Size(56, 13);
            this.assetComments.TabIndex = 13;
            this.assetComments.Text = "Comments";
            // 
            // commentsTextBox
            // 
            this.commentsTextBox.Location = new System.Drawing.Point(276, 109);
            this.commentsTextBox.Name = "commentsTextBox";
            this.commentsTextBox.ReadOnly = true;
            this.commentsTextBox.Size = new System.Drawing.Size(272, 114);
            this.commentsTextBox.TabIndex = 11;
            this.commentsTextBox.Text = "";
            // 
            // AssetData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 289);
            this.Controls.Add(this.textBoxAssetNotFound);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "AssetData";
            this.Text = "Data of asset: ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox assetUserTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label textBoxAssetNotFound;
        private System.Windows.Forms.Label assetDescriptionLabel;
        private System.Windows.Forms.RichTextBox assetDescriptionTextBox;
        private System.Windows.Forms.TextBox assetStatusTextBox;
        private System.Windows.Forms.TextBox serialNumberTextBox;
        private System.Windows.Forms.TextBox assetNumberTextBox;
        private System.Windows.Forms.Label assetStatusLabel;
        private System.Windows.Forms.Label SerialNumberLabel;
        private System.Windows.Forms.Label assetNumberLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox localUserTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox personnelNumberTextBox;
        private System.Windows.Forms.TextBox userStatusTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label assetComments;
        private System.Windows.Forms.RichTextBox commentsTextBox;
    }
}