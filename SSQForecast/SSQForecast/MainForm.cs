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

namespace SSQForecast
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitialBindingData();
        }

        private void InitialBindingData()
        {
            InitialDbData.FromAndToTermBinding(FromTerm,ToTerm);
        }

        #region Event

        private void InitialAllData_Click(object sender, EventArgs e)
        {
            InitialDbData.InitialAllNumberMappingData();
        }

        private void InitialNewestData_Click(object sender, EventArgs e)
        {
            InitialDbData.InitialNewestNumberMappingData();
        }

        #endregion
    }
}
