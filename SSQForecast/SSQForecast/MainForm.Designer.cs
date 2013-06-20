namespace SSQForecast
{
    partial class MainForm
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
            this.FromTerm = new System.Windows.Forms.ComboBox();
            this.ToTerm = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Search = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.InitialAllData = new System.Windows.Forms.Button();
            this.InitialNewestData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // FromTerm
            // 
            this.FromTerm.FormattingEnabled = true;
            this.FromTerm.Location = new System.Drawing.Point(136, 63);
            this.FromTerm.Name = "FromTerm";
            this.FromTerm.Size = new System.Drawing.Size(121, 21);
            this.FromTerm.TabIndex = 0;
            // 
            // ToTerm
            // 
            this.ToTerm.FormattingEnabled = true;
            this.ToTerm.Location = new System.Drawing.Point(301, 63);
            this.ToTerm.Name = "ToTerm";
            this.ToTerm.Size = new System.Drawing.Size(121, 21);
            this.ToTerm.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "期数";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(276, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "到";
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(445, 61);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(75, 23);
            this.Search.TabIndex = 4;
            this.Search.Text = "搜索";
            this.Search.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(92, 101);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(547, 351);
            this.dataGridView1.TabIndex = 5;
            // 
            // InitialAllData
            // 
            this.InitialAllData.Location = new System.Drawing.Point(13, 13);
            this.InitialAllData.Name = "InitialAllData";
            this.InitialAllData.Size = new System.Drawing.Size(75, 23);
            this.InitialAllData.TabIndex = 6;
            this.InitialAllData.Text = "重置数据";
            this.InitialAllData.UseVisualStyleBackColor = true;
            this.InitialAllData.Click += new System.EventHandler(this.InitialAllData_Click);
            // 
            // InitialNewestData
            // 
            this.InitialNewestData.Location = new System.Drawing.Point(95, 13);
            this.InitialNewestData.Name = "InitialNewestData";
            this.InitialNewestData.Size = new System.Drawing.Size(75, 23);
            this.InitialNewestData.TabIndex = 7;
            this.InitialNewestData.Text = "初始化最新";
            this.InitialNewestData.UseVisualStyleBackColor = true;
            this.InitialNewestData.Click += new System.EventHandler(this.InitialNewestData_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 496);
            this.Controls.Add(this.InitialNewestData);
            this.Controls.Add(this.InitialAllData);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ToTerm);
            this.Controls.Add(this.FromTerm);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox FromTerm;
        private System.Windows.Forms.ComboBox ToTerm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button InitialAllData;
        private System.Windows.Forms.Button InitialNewestData;
    }
}