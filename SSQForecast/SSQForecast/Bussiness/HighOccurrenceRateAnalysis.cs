using SSQForecast.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSQForecast.Bussiness
{
    public class HighOccurrenceRateAnalysis
    {
        private List<TotalTermInfo> totalTermInfos;
        public HighOccurrenceRateAnalysis()
        {
            using (var ssqdbentities = new ssqdbEntities())
            {
                try
                {
                    totalTermInfos = ssqdbentities.TotalTermInfos.ToList();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public void Analysis(DataGridView intervalRateView, int intervalRate)
        {
            using (var ssqdbentities = new ssqdbEntities())
            {
                try
                {
                    foreach (var term in totalTermInfos)
                    {
                        string[] baseNums = new string[] { term.RedNum1.ToString(),term.RedNum2.ToString(),term.RedNum3.ToString()
                        ,term.RedNum4.ToString(),term.RedNum5.ToString(),term.RedNum6.ToString(),term.BlueNum.ToString()};
                        string[] compareNums;
                    }
                    
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
    }
}
