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
        public float WinningRate { get; set; }
    }
}
