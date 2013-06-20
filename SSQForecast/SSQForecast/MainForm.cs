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
        private InitialDbData initialDbData;
        private HighOccurrenceRateAnalysis highOccurrenceRateAnalysis;
        public MainForm()
        {
            InitializeComponent();
            InitialBindingData();
            initialDbData = new InitialDbData();
            highOccurrenceRateAnalysis = new HighOccurrenceRateAnalysis();
        }

        private void InitialBindingData()
        {
            initialDbData.FromAndToTermBinding(FromTerm, ToTerm);
        }

        #region Event

        private void InitialAllData_Click(object sender, EventArgs e)
        {
            initialDbData.InitialAllNumberMappingData();
        }

        private void InitialNewestData_Click(object sender, EventArgs e)
        {
            initialDbData.InitialNewestNumberMappingData();
        }

        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void IntervalRateAnalysis_Click(object sender, EventArgs e)
        {
            highOccurrenceRateAnalysis.Analysis(IntervalRateView,ConvertHelper.ConvertInt(IntervalRate));
        }
    }
}
