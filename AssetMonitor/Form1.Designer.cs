namespace AssetMonitor
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
            this.loginstatDataGrid = new System.Windows.Forms.DataGridView();
            this.commandListComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.assetNumberTextBox = new System.Windows.Forms.TextBox();
            this.checkAssetsButton = new System.Windows.Forms.Button();
            this.databaseFileSelectButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dbLocationTextBox = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.loginIdTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.assetIdTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.loginstatDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // loginstatDataGrid
            // 
            this.loginstatDataGrid.AllowUserToAddRows = false;
            this.loginstatDataGrid.AllowUserToDeleteRows = false;
            this.loginstatDataGrid.AllowUserToOrderColumns = true;
            this.loginstatDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loginstatDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.loginstatDataGrid.Location = new System.Drawing.Point(29, 168);
            this.loginstatDataGrid.Name = "loginstatDataGrid";
            this.loginstatDataGrid.ReadOnly = true;
            this.loginstatDataGrid.Size = new System.Drawing.Size(545, 305);
            this.loginstatDataGrid.TabIndex = 0;
            // 
            // commandListComboBox
            // 
            this.commandListComboBox.FormattingEnabled = true;
            this.commandListComboBox.Items.AddRange(new object[] {
            "List all assets",
            "List all users of asset",
            "List missing assets"});
            this.commandListComboBox.Location = new System.Drawing.Point(30, 37);
            this.commandListComboBox.Name = "commandListComboBox";
            this.commandListComboBox.Size = new System.Drawing.Size(121, 21);
            this.commandListComboBox.TabIndex = 1;
            this.commandListComboBox.SelectionChangeCommitted += new System.EventHandler(this.CommandListComboBox_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sql command to execute";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(471, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Asset number";
            // 
            // assetNumberTextBox
            // 
            this.assetNumberTextBox.Enabled = false;
            this.assetNumberTextBox.Location = new System.Drawing.Point(474, 38);
            this.assetNumberTextBox.Name = "assetNumberTextBox";
            this.assetNumberTextBox.Size = new System.Drawing.Size(100, 20);
            this.assetNumberTextBox.TabIndex = 4;
            // 
            // checkAssetsButton
            // 
            this.checkAssetsButton.Enabled = false;
            this.checkAssetsButton.Location = new System.Drawing.Point(474, 94);
            this.checkAssetsButton.Name = "checkAssetsButton";
            this.checkAssetsButton.Size = new System.Drawing.Size(100, 23);
            this.checkAssetsButton.TabIndex = 5;
            this.checkAssetsButton.Text = "Check assets";
            this.checkAssetsButton.UseVisualStyleBackColor = true;
            this.checkAssetsButton.Click += new System.EventHandler(this.CheckAssetsButton_Click);
            // 
            // databaseFileSelectButton
            // 
            this.databaseFileSelectButton.Location = new System.Drawing.Point(29, 91);
            this.databaseFileSelectButton.Name = "databaseFileSelectButton";
            this.databaseFileSelectButton.Size = new System.Drawing.Size(128, 23);
            this.databaseFileSelectButton.TabIndex = 6;
            this.databaseFileSelectButton.Text = "Select database file";
            this.databaseFileSelectButton.UseVisualStyleBackColor = true;
            this.databaseFileSelectButton.Click += new System.EventHandler(this.DatabaseFileSelectButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Database file to monitor assets in";
            // 
            // dbLocationTextBox
            // 
            this.dbLocationTextBox.Enabled = false;
            this.dbLocationTextBox.Location = new System.Drawing.Point(174, 94);
            this.dbLocationTextBox.Name = "dbLocationTextBox";
            this.dbLocationTextBox.Size = new System.Drawing.Size(245, 20);
            this.dbLocationTextBox.TabIndex = 8;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // loginIdTextBox
            // 
            this.loginIdTextBox.Location = new System.Drawing.Point(86, 142);
            this.loginIdTextBox.Name = "loginIdTextBox";
            this.loginIdTextBox.Size = new System.Drawing.Size(71, 20);
            this.loginIdTextBox.TabIndex = 9;
            this.loginIdTextBox.TextChanged += new System.EventHandler(this.LoginIdTextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Login ID :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(171, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Asset ID :";
            // 
            // assetIdTextBox
            // 
            this.assetIdTextBox.Location = new System.Drawing.Point(230, 142);
            this.assetIdTextBox.Name = "assetIdTextBox";
            this.assetIdTextBox.Size = new System.Drawing.Size(188, 20);
            this.assetIdTextBox.TabIndex = 12;
            this.assetIdTextBox.TextChanged += new System.EventHandler(this.AssetIdTextBox_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 504);
            this.Controls.Add(this.assetIdTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.loginIdTextBox);
            this.Controls.Add(this.dbLocationTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.databaseFileSelectButton);
            this.Controls.Add(this.checkAssetsButton);
            this.Controls.Add(this.assetNumberTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.commandListComboBox);
            this.Controls.Add(this.loginstatDataGrid);
            this.Name = "Form1";
            this.Text = "Gem. Veere Asset Monitor";
            ((System.ComponentModel.ISupportInitialize)(this.loginstatDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView loginstatDataGrid;
        private System.Windows.Forms.ComboBox commandListComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox assetNumberTextBox;
        private System.Windows.Forms.Button checkAssetsButton;
        private System.Windows.Forms.Button databaseFileSelectButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox dbLocationTextBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox loginIdTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox assetIdTextBox;
    }
}

