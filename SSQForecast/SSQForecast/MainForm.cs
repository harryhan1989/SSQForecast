using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SSQForecast.Bussiness;
using SSQForecast.Helper;

namespace SSQForecast
{
    public partial class MainForm : Form
    {
        private InitialDbData _initialDbData;
        private HighOccurrenceRateAnalysis _highOccurrenceRateAnalysis;
        public MainForm()
        {
            InitializeComponent();
            _initialDbData = new InitialDbData();
            InitialBindingData();
        }

        private void InitialBindingData()
        {
            _initialDbData.ComboBoxTermBinding(FromTerm);
            _initialDbData.ComboBoxTermBinding(ToTerm);
            _initialDbData.ComboBoxTermBinding(MaxTermNum);
        }

        #region Event

        private void UpdateDataOnline_Click(object sender, EventArgs e)
        {
            var onlineData17500CN = new OnlineData17500CN();
            onlineData17500CN.UpdateNewest();
            _initialDbData.InitialNewestNumberMappingData();
            InitialBindingData();
            MessageBox.Show("更新成功！");
        }

        private void InitialAllData_Click(object sender, EventArgs e)
        {
            _initialDbData.InitialAllNumberMappingData();
            MessageBox.Show("更新成功！");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(1);
        }

        private void IntervalRateAnalysis_Click(object sender, EventArgs e)
        {
            _highOccurrenceRateAnalysis = new HighOccurrenceRateAnalysis(this);
            if (VerifyRedAndBlueNumsPositions())
            _highOccurrenceRateAnalysis.Analysis(ConvertHelper.ConvertInt(IntervalRate.Text), ConvertHelper.ConvertInt(TermMinCount.Text), ConvertHelper.ConvertInt(TermMaxCount.Text));
        }

        private void RedNumPositions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RedNumPositions.CheckedItems.Count > 6)
            {
                MessageBox.Show(@"红球六个位置选择不能超过6个！");
                this.RedNumPositions.SetItemChecked(this.RedNumPositions.SelectedIndex,false);
            }
        }

        private void BlueNumPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BlueNumPosition.CheckedItems.Count > 1)
            {
                MessageBox.Show(@"篮球位置选择不能超过1个！");
                try
                {
                    this.BlueNumPosition.SelectedItems.Remove(this.BlueNumPosition.SelectedItem);
                    this.BlueNumPosition.SetItemChecked(this.BlueNumPosition.SelectedIndex, false);
                }
                catch { }
            }
        }

        #endregion

        #region Verify

        private bool VerifyRedAndBlueNumsPositions()
        {
            if (RedNumPositions.CheckedItems.Count != 6)
            {
                MessageBox.Show(@"红球六个位置必须全部选好后才能进行分析！");
                return false;
            }

            if (BlueNumPosition.CheckedItems.Count != 1)
            {
                MessageBox.Show(@"篮球1个位置必须全部选好后才能进行分析！");
                return false;
            }
            return true;
        }

        #endregion
    }
}