namespace AssetMonitor
{
    partial class AssetMonitor
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.beforeRadioButton = new System.Windows.Forms.RadioButton();
            this.afterRadioButton = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.settingsGroupBox = new System.Windows.Forms.GroupBox();
            this.dataSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.dateFilteringGroupBox = new System.Windows.Forms.GroupBox();
            this.dataGridGroupBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.loginstatDataGrid)).BeginInit();
            this.settingsGroupBox.SuspendLayout();
            this.dataSettingsGroupBox.SuspendLayout();
            this.dateFilteringGroupBox.SuspendLayout();
            this.dataGridGroupBox.SuspendLayout();
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
            this.loginstatDataGrid.Location = new System.Drawing.Point(6, 45);
            this.loginstatDataGrid.Name = "loginstatDataGrid";
            this.loginstatDataGrid.ReadOnly = true;
            this.loginstatDataGrid.Size = new System.Drawing.Size(572, 294);
            this.loginstatDataGrid.TabIndex = 0;
            this.loginstatDataGrid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LoginstatDataGrid_CellContentDoubleClick);
            // 
            // commandListComboBox
            // 
            this.commandListComboBox.FormattingEnabled = true;
            this.commandListComboBox.Items.AddRange(new object[] {
            "List all assets",
            "List all users of asset",
            "List missing assets",
            "List all assets with date check"});
            this.commandListComboBox.Location = new System.Drawing.Point(6, 30);
            this.commandListComboBox.Name = "commandListComboBox";
            this.commandListComboBox.Size = new System.Drawing.Size(216, 21);
            this.commandListComboBox.TabIndex = 1;
            this.commandListComboBox.SelectionChangeCommitted += new System.EventHandler(this.CommandListComboBox_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sql command to execute";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(282, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Asset number";
            // 
            // assetNumberTextBox
            // 
            this.assetNumberTextBox.Enabled = false;
            this.assetNumberTextBox.Location = new System.Drawing.Point(282, 31);
            this.assetNumberTextBox.Name = "assetNumberTextBox";
            this.assetNumberTextBox.Size = new System.Drawing.Size(71, 20);
            this.assetNumberTextBox.TabIndex = 4;
            // 
            // checkAssetsButton
            // 
            this.checkAssetsButton.Enabled = false;
            this.checkAssetsButton.Location = new System.Drawing.Point(395, 106);
            this.checkAssetsButton.Name = "checkAssetsButton";
            this.checkAssetsButton.Size = new System.Drawing.Size(167, 42);
            this.checkAssetsButton.TabIndex = 5;
            this.checkAssetsButton.Text = "Check assets";
            this.checkAssetsButton.UseVisualStyleBackColor = true;
            this.checkAssetsButton.Click += new System.EventHandler(this.CheckAssetsButton_Click);
            // 
            // databaseFileSelectButton
            // 
            this.databaseFileSelectButton.Location = new System.Drawing.Point(6, 98);
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
            this.label3.Location = new System.Drawing.Point(6, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Database file to monitor assets in";
            // 
            // dbLocationTextBox
            // 
            this.dbLocationTextBox.Enabled = false;
            this.dbLocationTextBox.Location = new System.Drawing.Point(140, 100);
            this.dbLocationTextBox.Name = "dbLocationTextBox";
            this.dbLocationTextBox.Size = new System.Drawing.Size(213, 20);
            this.dbLocationTextBox.TabIndex = 8;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // loginIdTextBox
            // 
            this.loginIdTextBox.Enabled = false;
            this.loginIdTextBox.Location = new System.Drawing.Point(77, 19);
            this.loginIdTextBox.Name = "loginIdTextBox";
            this.loginIdTextBox.Size = new System.Drawing.Size(71, 20);
            this.loginIdTextBox.TabIndex = 9;
            this.loginIdTextBox.TextChanged += new System.EventHandler(this.LoginIdTextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Login ID :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(162, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Asset ID :";
            // 
            // assetIdTextBox
            // 
            this.assetIdTextBox.Enabled = false;
            this.assetIdTextBox.Location = new System.Drawing.Point(221, 19);
            this.assetIdTextBox.Name = "assetIdTextBox";
            this.assetIdTextBox.Size = new System.Drawing.Size(71, 20);
            this.assetIdTextBox.TabIndex = 12;
            this.assetIdTextBox.TextChanged += new System.EventHandler(this.AssetIdTextBox_TextChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(6, 19);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(155, 20);
            this.dateTimePicker1.TabIndex = 13;
            // 
            // beforeRadioButton
            // 
            this.beforeRadioButton.AutoSize = true;
            this.beforeRadioButton.Location = new System.Drawing.Point(23, 59);
            this.beforeRadioButton.Name = "beforeRadioButton";
            this.beforeRadioButton.Size = new System.Drawing.Size(55, 17);
            this.beforeRadioButton.TabIndex = 15;
            this.beforeRadioButton.TabStop = true;
            this.beforeRadioButton.Text = "before";
            this.beforeRadioButton.UseVisualStyleBackColor = true;
            // 
            // afterRadioButton
            // 
            this.afterRadioButton.AutoSize = true;
            this.afterRadioButton.Location = new System.Drawing.Point(99, 58);
            this.afterRadioButton.Name = "afterRadioButton";
            this.afterRadioButton.Size = new System.Drawing.Size(46, 17);
            this.afterRadioButton.TabIndex = 16;
            this.afterRadioButton.TabStop = true;
            this.afterRadioButton.Text = "after";
            this.afterRadioButton.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "show before or after date";
            // 
            // settingsGroupBox
            // 
            this.settingsGroupBox.Controls.Add(this.dataSettingsGroupBox);
            this.settingsGroupBox.Controls.Add(this.dateFilteringGroupBox);
            this.settingsGroupBox.Controls.Add(this.checkAssetsButton);
            this.settingsGroupBox.Location = new System.Drawing.Point(12, 12);
            this.settingsGroupBox.Name = "settingsGroupBox";
            this.settingsGroupBox.Size = new System.Drawing.Size(584, 156);
            this.settingsGroupBox.TabIndex = 18;
            this.settingsGroupBox.TabStop = false;
            this.settingsGroupBox.Enter += new System.EventHandler(this.GroupBox1_Enter);
            // 
            // dataSettingsGroupBox
            // 
            this.dataSettingsGroupBox.Controls.Add(this.databaseFileSelectButton);
            this.dataSettingsGroupBox.Controls.Add(this.dbLocationTextBox);
            this.dataSettingsGroupBox.Controls.Add(this.label2);
            this.dataSettingsGroupBox.Controls.Add(this.label1);
            this.dataSettingsGroupBox.Controls.Add(this.assetNumberTextBox);
            this.dataSettingsGroupBox.Controls.Add(this.label3);
            this.dataSettingsGroupBox.Controls.Add(this.commandListComboBox);
            this.dataSettingsGroupBox.Location = new System.Drawing.Point(6, 19);
            this.dataSettingsGroupBox.Name = "dataSettingsGroupBox";
            this.dataSettingsGroupBox.Size = new System.Drawing.Size(383, 129);
            this.dataSettingsGroupBox.TabIndex = 19;
            this.dataSettingsGroupBox.TabStop = false;
            this.dataSettingsGroupBox.Text = "Data retrieval settings";
            // 
            // dateFilteringGroupBox
            // 
            this.dateFilteringGroupBox.Controls.Add(this.dateTimePicker1);
            this.dateFilteringGroupBox.Controls.Add(this.afterRadioButton);
            this.dateFilteringGroupBox.Controls.Add(this.label7);
            this.dateFilteringGroupBox.Controls.Add(this.beforeRadioButton);
            this.dateFilteringGroupBox.Enabled = false;
            this.dateFilteringGroupBox.Location = new System.Drawing.Point(395, 19);
            this.dateFilteringGroupBox.Name = "dateFilteringGroupBox";
            this.dateFilteringGroupBox.Size = new System.Drawing.Size(167, 81);
            this.dateFilteringGroupBox.TabIndex = 18;
            this.dateFilteringGroupBox.TabStop = false;
            this.dateFilteringGroupBox.Text = "Date filtering (not functional)";
            // 
            // dataGridGroupBox
            // 
            this.dataGridGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridGroupBox.Controls.Add(this.loginstatDataGrid);
            this.dataGridGroupBox.Controls.Add(this.assetIdTextBox);
            this.dataGridGroupBox.Controls.Add(this.loginIdTextBox);
            this.dataGridGroupBox.Controls.Add(this.label5);
            this.dataGridGroupBox.Controls.Add(this.label4);
            this.dataGridGroupBox.Location = new System.Drawing.Point(12, 174);
            this.dataGridGroupBox.Name = "dataGridGroupBox";
            this.dataGridGroupBox.Size = new System.Drawing.Size(584, 345);
            this.dataGridGroupBox.TabIndex = 19;
            this.dataGridGroupBox.TabStop = false;
            // 
            // AssetMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 531);
            this.Controls.Add(this.dataGridGroupBox);
            this.Controls.Add(this.settingsGroupBox);
            this.Name = "AssetMonitor";
            this.Text = "Gem. Veere Asset Monitor";
            ((System.ComponentModel.ISupportInitialize)(this.loginstatDataGrid)).EndInit();
            this.settingsGroupBox.ResumeLayout(false);
            this.dataSettingsGroupBox.ResumeLayout(false);
            this.dataSettingsGroupBox.PerformLayout();
            this.dateFilteringGroupBox.ResumeLayout(false);
            this.dateFilteringGroupBox.PerformLayout();
            this.dataGridGroupBox.ResumeLayout(false);
            this.dataGridGroupBox.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.RadioButton beforeRadioButton;
        private System.Windows.Forms.RadioButton afterRadioButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox settingsGroupBox;
        private System.Windows.Forms.GroupBox dateFilteringGroupBox;
        private System.Windows.Forms.GroupBox dataSettingsGroupBox;
        private System.Windows.Forms.GroupBox dataGridGroupBox;
    }
}

