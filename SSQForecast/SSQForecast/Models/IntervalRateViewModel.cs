using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSQForecast.Models
{
    public class IntervalRateViewModel
    {
        public long TermNum { get; set; }
        public long PreviousTermsNum { get; set; }
        public int MaxRecursionTermsThisJob { get; set; }
        public float WinningRate { get; set; }
        public string NextTermNumForecast { get; set; }
    }
}
