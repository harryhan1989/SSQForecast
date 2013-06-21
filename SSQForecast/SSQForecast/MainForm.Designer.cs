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
            this.components = new System.ComponentModel.Container();
            this.FromTerm = new System.Windows.Forms.ComboBox();
            this.ToTerm = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Search = new System.Windows.Forms.Button();
            this.IntervalRateView = new System.Windows.Forms.DataGridView();
            this.TermNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PreviousTermsNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WinningRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InitialAllData = new System.Windows.Forms.Button();
            this.InitialNewestData = new System.Windows.Forms.Button();
            this.IntervalRateAnalysis = new System.Windows.Forms.Button();
            this.IntervalRate = new System.Windows.Forms.TextBox();
            this.TermMinCount = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.TermMaxCount = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.IntervalRateView)).BeginInit();
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
            // IntervalRateView
            // 
            this.IntervalRateView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.IntervalRateView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TermNum,
            this.PreviousTermsNum,
            this.WinningRate});
            this.IntervalRateView.Location = new System.Drawing.Point(92, 101);
            this.IntervalRateView.Name = "IntervalRateView";
            this.IntervalRateView.Size = new System.Drawing.Size(547, 351);
            this.IntervalRateView.TabIndex = 5;
            // 
            // TermNum
            // 
            this.TermNum.HeaderText = "期号";
            this.TermNum.Name = "TermNum";
            // 
            // PreviousTermsNum
            // 
            this.PreviousTermsNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PreviousTermsNum.HeaderText = "预估数据期数（连续前几期）";
            this.PreviousTermsNum.Name = "PreviousTermsNum";
            // 
            // WinningRate
            // 
            this.WinningRate.HeaderText = "中奖率（%）";
            this.WinningRate.Name = "WinningRate";
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
            // IntervalRateAnalysis
            // 
            this.IntervalRateAnalysis.Location = new System.Drawing.Point(12, 461);
            this.IntervalRateAnalysis.Name = "IntervalRateAnalysis";
            this.IntervalRateAnalysis.Size = new System.Drawing.Size(98, 23);
            this.IntervalRateAnalysis.TabIndex = 8;
            this.IntervalRateAnalysis.Text = "间隔概率分析";
            this.IntervalRateAnalysis.UseVisualStyleBackColor = true;
            this.IntervalRateAnalysis.Click += new System.EventHandler(this.IntervalRateAnalysis_Click);
            // 
            // IntervalRate
            // 
            this.IntervalRate.Location = new System.Drawing.Point(132, 462);
            this.IntervalRate.Name = "IntervalRate";
            this.IntervalRate.Size = new System.Drawing.Size(100, 20);
            this.IntervalRate.TabIndex = 9;
            this.IntervalRate.Text = "10";
            this.toolTip1.SetToolTip(this.IntervalRate, "间隔数例：5");
            // 
            // TermMinCount
            // 
            this.TermMinCount.AccessibleDescription = "";
            this.TermMinCount.Location = new System.Drawing.Point(248, 462);
            this.TermMinCount.Name = "TermMinCount";
            this.TermMinCount.Size = new System.Drawing.Size(100, 20);
            this.TermMinCount.TabIndex = 10;
            this.TermMinCount.Tag = "";
            this.TermMinCount.Text = "50";
            this.toolTip1.SetToolTip(this.TermMinCount, "分析期数最小值例：10");
            // 
            // TermMaxCount
            // 
            this.TermMaxCount.Location = new System.Drawing.Point(368, 461);
            this.TermMaxCount.Name = "TermMaxCount";
            this.TermMaxCount.Size = new System.Drawing.Size(100, 20);
            this.TermMaxCount.TabIndex = 11;
            this.TermMaxCount.Text = "100";
            this.toolTip1.SetToolTip(this.TermMaxCount, "分析期数最大值例：100");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 496);
            this.Controls.Add(this.TermMaxCount);
            this.Controls.Add(this.TermMinCount);
            this.Controls.Add(this.IntervalRate);
            this.Controls.Add(this.IntervalRateAnalysis);
            this.Controls.Add(this.InitialNewestData);
            this.Controls.Add(this.InitialAllData);
            this.Controls.Add(this.IntervalRateView);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ToTerm);
            this.Controls.Add(this.FromTerm);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.IntervalRateView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox FromTerm;
        private System.Windows.Forms.ComboBox ToTerm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.DataGridView IntervalRateView;
        private System.Windows.Forms.Button InitialAllData;
        private System.Windows.Forms.Button InitialNewestData;
        private System.Windows.Forms.Button IntervalRateAnalysis;
        private System.Windows.Forms.TextBox IntervalRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn TermNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn PreviousTermsNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn WinningRate;
        private System.Windows.Forms.TextBox TermMinCount;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox TermMaxCount;
    }
}