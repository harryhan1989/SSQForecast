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
            _highOccurrenceRateAnalysis = new HighOccurrenceRateAnalysis();
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

        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void IntervalRateAnalysis_Click(object sender, EventArgs e)
        {
            _highOccurrenceRateAnalysis.Analysis(IntervalRateView, ConvertHelper.ConvertInt(IntervalRate.Text), ConvertHelper.ConvertInt(TermMinCount.Text), ConvertHelper.ConvertInt(TermMaxCount.Text));
        }
    }
}
