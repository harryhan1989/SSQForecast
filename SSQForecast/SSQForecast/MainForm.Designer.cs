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
            this.NextTermNumForecast = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateDataOnline = new System.Windows.Forms.Button();
            this.InitialAllData = new System.Windows.Forms.Button();
            this.IntervalRateAnalysis = new System.Windows.Forms.Button();
            this.IntervalRate = new System.Windows.Forms.TextBox();
            this.TermMinCount = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.TermMaxCount = new System.Windows.Forms.TextBox();
            this.RedNumPositions = new System.Windows.Forms.CheckedListBox();
            this.BlueNumPosition = new System.Windows.Forms.CheckedListBox();
            this.ProgressingMessage = new System.Windows.Forms.RichTextBox();
            this.termNumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.previousTermsNumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.winningRateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intervalRateViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.MaxTermNum = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.IntervalRateView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intervalRateViewModelBindingSource)).BeginInit();
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
            this.ToTerm.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllSystemSources;
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
            this.IntervalRateView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IntervalRateView.AutoGenerateColumns = false;
            this.IntervalRateView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.IntervalRateView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.termNumDataGridViewTextBoxColumn,
            this.previousTermsNumDataGridViewTextBoxColumn,
            this.winningRateDataGridViewTextBoxColumn,
            this.NextTermNumForecast});
            this.IntervalRateView.DataSource = this.intervalRateViewModelBindingSource;
            this.IntervalRateView.Location = new System.Drawing.Point(92, 101);
            this.IntervalRateView.Name = "IntervalRateView";
            this.IntervalRateView.Size = new System.Drawing.Size(547, 209);
            this.IntervalRateView.TabIndex = 5;
            // 
            // NextTermNumForecast
            // 
            this.NextTermNumForecast.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NextTermNumForecast.DataPropertyName = "NextTermNumForecast";
            this.NextTermNumForecast.HeaderText = "基于当前概率下期预测号";
            this.NextTermNumForecast.Name = "NextTermNumForecast";
            // 
            // UpdateDataOnline
            // 
            this.UpdateDataOnline.Location = new System.Drawing.Point(13, 13);
            this.UpdateDataOnline.Name = "UpdateDataOnline";
            this.UpdateDataOnline.Size = new System.Drawing.Size(75, 23);
            this.UpdateDataOnline.TabIndex = 6;
            this.UpdateDataOnline.Text = "联网更新数据";
            this.UpdateDataOnline.UseVisualStyleBackColor = true;
            this.UpdateDataOnline.Click += new System.EventHandler(this.UpdateDataOnline_Click);
            // 
            // InitialAllData
            // 
            this.InitialAllData.Location = new System.Drawing.Point(99, 13);
            this.InitialAllData.Name = "InitialAllData";
            this.InitialAllData.Size = new System.Drawing.Size(75, 23);
            this.InitialAllData.TabIndex = 7;
            this.InitialAllData.Text = "初始化数据";
            this.InitialAllData.UseVisualStyleBackColor = true;
            this.InitialAllData.Click += new System.EventHandler(this.InitialAllData_Click);
            // 
            // IntervalRateAnalysis
            // 
            this.IntervalRateAnalysis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.IntervalRateAnalysis.Location = new System.Drawing.Point(12, 449);
            this.IntervalRateAnalysis.Name = "IntervalRateAnalysis";
            this.IntervalRateAnalysis.Size = new System.Drawing.Size(98, 23);
            this.IntervalRateAnalysis.TabIndex = 8;
            this.IntervalRateAnalysis.Text = "间隔概率分析";
            this.IntervalRateAnalysis.UseVisualStyleBackColor = true;
            this.IntervalRateAnalysis.Click += new System.EventHandler(this.IntervalRateAnalysis_Click);
            // 
            // IntervalRate
            // 
            this.IntervalRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.IntervalRate.Location = new System.Drawing.Point(132, 450);
            this.IntervalRate.Name = "IntervalRate";
            this.IntervalRate.Size = new System.Drawing.Size(100, 20);
            this.IntervalRate.TabIndex = 9;
            this.IntervalRate.Text = "10";
            this.toolTip1.SetToolTip(this.IntervalRate, "间隔数例：5");
            // 
            // TermMinCount
            // 
            this.TermMinCount.AccessibleDescription = "";
            this.TermMinCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TermMinCount.Location = new System.Drawing.Point(248, 450);
            this.TermMinCount.Name = "TermMinCount";
            this.TermMinCount.Size = new System.Drawing.Size(100, 20);
            this.TermMinCount.TabIndex = 10;
            this.TermMinCount.Tag = "";
            this.TermMinCount.Text = "50";
            this.toolTip1.SetToolTip(this.TermMinCount, "分析期数最小值例：10");
            // 
            // TermMaxCount
            // 
            this.TermMaxCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TermMaxCount.Location = new System.Drawing.Point(368, 449);
            this.TermMaxCount.Name = "TermMaxCount";
            this.TermMaxCount.Size = new System.Drawing.Size(100, 20);
            this.TermMaxCount.TabIndex = 11;
            this.TermMaxCount.Text = "100";
            this.toolTip1.SetToolTip(this.TermMaxCount, "分析期数最大值例：100");
            // 
            // RedNumPositions
            // 
            this.RedNumPositions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RedNumPositions.CheckOnClick = true;
            this.RedNumPositions.ColumnWidth = 40;
            this.RedNumPositions.FormattingEnabled = true;
            this.RedNumPositions.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32"});
            this.RedNumPositions.Location = new System.Drawing.Point(378, 316);
            this.RedNumPositions.MultiColumn = true;
            this.RedNumPositions.Name = "RedNumPositions";
            this.RedNumPositions.Size = new System.Drawing.Size(169, 124);
            this.RedNumPositions.TabIndex = 15;
            this.toolTip1.SetToolTip(this.RedNumPositions, "红球位置选择(必须只选6个)");
            this.RedNumPositions.SelectedIndexChanged += new System.EventHandler(this.RedNumPositions_SelectedIndexChanged);
            // 
            // BlueNumPosition
            // 
            this.BlueNumPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BlueNumPosition.CheckOnClick = true;
            this.BlueNumPosition.ColumnWidth = 40;
            this.BlueNumPosition.FormattingEnabled = true;
            this.BlueNumPosition.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16"});
            this.BlueNumPosition.Location = new System.Drawing.Point(554, 317);
            this.BlueNumPosition.MultiColumn = true;
            this.BlueNumPosition.Name = "BlueNumPosition";
            this.BlueNumPosition.Size = new System.Drawing.Size(85, 124);
            this.BlueNumPosition.TabIndex = 17;
            this.toolTip1.SetToolTip(this.BlueNumPosition, "篮球位置选择（选择且只能选择一个）");
            this.BlueNumPosition.SelectedIndexChanged += new System.EventHandler(this.BlueNumPosition_SelectedIndexChanged);
            // 
            // ProgressingMessage
            // 
            this.ProgressingMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressingMessage.Location = new System.Drawing.Point(92, 316);
            this.ProgressingMessage.Name = "ProgressingMessage";
            this.ProgressingMessage.Size = new System.Drawing.Size(277, 124);
            this.ProgressingMessage.TabIndex = 12;
            this.ProgressingMessage.Text = "";
            // 
            // termNumDataGridViewTextBoxColumn
            // 
            this.termNumDataGridViewTextBoxColumn.DataPropertyName = "TermNum";
            this.termNumDataGridViewTextBoxColumn.FillWeight = 81.61094F;
            this.termNumDataGridViewTextBoxColumn.HeaderText = "期号";
            this.termNumDataGridViewTextBoxColumn.Name = "termNumDataGridViewTextBoxColumn";
            // 
            // previousTermsNumDataGridViewTextBoxColumn
            // 
            this.previousTermsNumDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.previousTermsNumDataGridViewTextBoxColumn.DataPropertyName = "PreviousTermsNum";
            this.previousTermsNumDataGridViewTextBoxColumn.FillWeight = 171.9971F;
            this.previousTermsNumDataGridViewTextBoxColumn.HeaderText = "预估数据期数（连续前几期）";
            this.previousTermsNumDataGridViewTextBoxColumn.Name = "previousTermsNumDataGridViewTextBoxColumn";
            this.previousTermsNumDataGridViewTextBoxColumn.Width = 117;
            // 
            // winningRateDataGridViewTextBoxColumn
            // 
            this.winningRateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.winningRateDataGridViewTextBoxColumn.DataPropertyName = "WinningRate";
            this.winningRateDataGridViewTextBoxColumn.FillWeight = 46.39172F;
            this.winningRateDataGridViewTextBoxColumn.HeaderText = "中奖率（%）";
            this.winningRateDataGridViewTextBoxColumn.Name = "winningRateDataGridViewTextBoxColumn";
            this.winningRateDataGridViewTextBoxColumn.Width = 81;
            // 
            // intervalRateViewModelBindingSource
            // 
            this.intervalRateViewModelBindingSource.DataSource = typeof(SSQForecast.Models.IntervalRateViewModel);
            // 
            // MaxTermNum
            // 
            this.MaxTermNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MaxTermNum.FormattingEnabled = true;
            this.MaxTermNum.Location = new System.Drawing.Point(489, 449);
            this.MaxTermNum.Name = "MaxTermNum";
            this.MaxTermNum.Size = new System.Drawing.Size(121, 21);
            this.MaxTermNum.TabIndex = 18;
            this.toolTip1.SetToolTip(this.MaxTermNum, "最大期号");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 487);
            this.Controls.Add(this.MaxTermNum);
            this.Controls.Add(this.BlueNumPosition);
            this.Controls.Add(this.RedNumPositions);
            this.Controls.Add(this.ProgressingMessage);
            this.Controls.Add(this.TermMaxCount);
            this.Controls.Add(this.TermMinCount);
            this.Controls.Add(this.IntervalRate);
            this.Controls.Add(this.IntervalRateAnalysis);
            this.Controls.Add(this.InitialAllData);
            this.Controls.Add(this.UpdateDataOnline);
            this.Controls.Add(this.IntervalRateView);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ToTerm);
            this.Controls.Add(this.FromTerm);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.IntervalRateView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intervalRateViewModelBindingSource)).EndInit();
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
        private System.Windows.Forms.Button UpdateDataOnline;
        private System.Windows.Forms.Button InitialAllData;
        private System.Windows.Forms.Button IntervalRateAnalysis;
        private System.Windows.Forms.TextBox IntervalRate;
        private System.Windows.Forms.TextBox TermMinCount;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox TermMaxCount;
        private System.Windows.Forms.RichTextBox ProgressingMessage;
        private System.Windows.Forms.CheckedListBox RedNumPositions;
        private System.Windows.Forms.CheckedListBox BlueNumPosition;
        private System.Windows.Forms.BindingSource intervalRateViewModelBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn termNumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn previousTermsNumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn winningRateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NextTermNumForecast;
        private System.Windows.Forms.ComboBox MaxTermNum;
    }
}