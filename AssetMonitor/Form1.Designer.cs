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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.commandListComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkAssetsButton = new System.Windows.Forms.Button();
            this.databaseFileSelectButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dbLocationTextBox = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(29, 168);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(387, 305);
            this.dataGridView1.TabIndex = 0;
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
            this.label2.Location = new System.Drawing.Point(313, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Asset number";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(316, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 4;
            // 
            // checkAssetsButton
            // 
            this.checkAssetsButton.Location = new System.Drawing.Point(30, 129);
            this.checkAssetsButton.Name = "checkAssetsButton";
            this.checkAssetsButton.Size = new System.Drawing.Size(386, 22);
            this.checkAssetsButton.TabIndex = 5;
            this.checkAssetsButton.Text = "Check assets";
            this.checkAssetsButton.UseVisualStyleBackColor = true;
            // 
            // databaseFileSelectButton
            // 
            this.databaseFileSelectButton.Location = new System.Drawing.Point(30, 90);
            this.databaseFileSelectButton.Name = "databaseFileSelectButton";
            this.databaseFileSelectButton.Size = new System.Drawing.Size(121, 23);
            this.databaseFileSelectButton.TabIndex = 6;
            this.databaseFileSelectButton.Text = "Select database file";
            this.databaseFileSelectButton.UseVisualStyleBackColor = true;
            this.databaseFileSelectButton.Click += new System.EventHandler(this.DatabaseFileSelectButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(226, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Database file to check assets on (must be .db)";
            // 
            // dbLocationTextBox
            // 
            this.dbLocationTextBox.Enabled = false;
            this.dbLocationTextBox.Location = new System.Drawing.Point(171, 92);
            this.dbLocationTextBox.Name = "dbLocationTextBox";
            this.dbLocationTextBox.Size = new System.Drawing.Size(245, 20);
            this.dbLocationTextBox.TabIndex = 8;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 504);
            this.Controls.Add(this.dbLocationTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.databaseFileSelectButton);
            this.Controls.Add(this.checkAssetsButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.commandListComboBox);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Gem. Veere Asset Monitor";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox commandListComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button checkAssetsButton;
        private System.Windows.Forms.Button databaseFileSelectButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox dbLocationTextBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

