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
            _highOccurrenceRateAnalysis = new HighOccurrenceRateAnalysis(this);
            InitialBindingData();
        }

        private void InitialBindingData()
        {
            _initialDbData.FromAndToTermBinding(FromTerm, ToTerm);
        }

        #region Event

        private void InitialAllData_Click(object sender, EventArgs e)
        {
            _initialDbData.InitialAllNumberMappingData();
        }

        private void InitialNewestData_Click(object sender, EventArgs e)
        {
            _initialDbData.InitialNewestNumberMappingData();
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
                this.BlueNumPosition.SelectedItems.Remove(this.BlueNumPosition.SelectedItem);
                this.BlueNumPosition.SetItemChecked(this.BlueNumPosition.SelectedIndex, false);
            }
        }

        #endregion

        #region Verify

        private void VerifyRedAndBlueNumsPositions()
        {
            if (RedNumPositions.SelectedItems.Count!=6)
            {
                MessageBox.Show(@"红球六个位置必须全部选好后才能进行分析！");
            }

            if (BlueNumPosition.SelectedItems.Count != 1)
            {
                MessageBox.Show(@"篮球1个位置必须全部选好后才能进行分析！");
            }
        }

        #endregion

    }
}
