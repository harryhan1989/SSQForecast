using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSQForecast.Models
{
    public class NumberOccurrenceRate
    {
        /// <summary>
        /// 0---red;1--blue
        /// </summary>
        public int NumberType { get; set; }
        public int Number { get; set; }
        public int OccurrenceRate { get; set; }
    }
}
