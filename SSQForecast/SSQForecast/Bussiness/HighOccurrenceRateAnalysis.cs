using System.Data.Entity;
using System.Globalization;
using SSQForecast.Helper;
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
        public HighOccurrenceRateAnalysis()
        {
        }

        public void Analysis(DataGridView intervalRateView, int intervalRate, int termMinCount, int termMaxCount)
        {
            using (var ssqdbentities = new ssqdbEntities())
            {
                try
                {
                    List<TotalTermInfos> totalTermInfos = ssqdbentities.TotalTermInfos.OrderByDescending(k=>k.TermNum).ToList();
                    var termCount = termMinCount;

                    var intervalRatePrizeList = new List<IntervalRateViewModel>();
                    while (termCount <= termMaxCount)
                    {
                        var isPrizeList = new List<bool>();
                        for (int j1 = 0; j1 < totalTermInfos.Count() - termCount; j1++)
                        {
                            var term = totalTermInfos[j1];
                            var baseNums = new string[7]
                                {
                                    term.RedNum1.ToString(CultureInfo.InvariantCulture),
                                    term.RedNum2.ToString(CultureInfo.InvariantCulture),
                                    term.RedNum3.ToString(CultureInfo.InvariantCulture)
                                    , term.RedNum4.ToString(CultureInfo.InvariantCulture),
                                    term.RedNum5.ToString(CultureInfo.InvariantCulture), term.RedNum6.ToString(),
                                    term.BlueNum.ToString(CultureInfo.InvariantCulture)
                                };

                            var compareNums = new string[7];
                            var numberMappingToUse =
                                ssqdbentities.NumberMapping.Where(k => k.TermNum < term.TermNum).Take(termCount);

                            var numberOccurrenceRate = GetNumberOccurrenceRate(numberMappingToUse);

                            var redNumberOccurrenceRate = numberOccurrenceRate.Where(k => k.NumberType == 0).ToList();
                            var blueNumberOccurrenceRate = numberOccurrenceRate.Where(k => k.NumberType == 0).ToList();
                            if (redNumberOccurrenceRate.Count() >= 6 && blueNumberOccurrenceRate.Any())
                            {
                                for (int i = 0; i < 6; i++)
                                {
                                    compareNums[0] =
                                        ConvertHelper.ConvertString(redNumberOccurrenceRate.ElementAt(i).Number);
                                }
                                compareNums[7] =
                                    ConvertHelper.ConvertString(blueNumberOccurrenceRate.ElementAt(0).Number);
                            }

                            isPrizeList.Add(ConvertHelper.IsPrize(compareNums, baseNums));
                        }

                        if (isPrizeList.Count > 0)
                        {
                            intervalRatePrizeList.Add(new IntervalRateViewModel
                                {
                                    TermNum = totalTermInfos.First().TermNum,
                                    PreviousTermsNum=termCount,
                                    WinningRate = (isPrizeList.Count(k=>k.Equals(true)) / isPrizeList.Count()) * 100
                                });
                        }

                        if (termCount < termMaxCount)
                        {
                            termCount += intervalRate;
                        }
                        else
                        {
                            break;
                        }
                    }


                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        private List<NumberOccurrenceRate> GetNumberOccurrenceRate(IQueryable<NumberMapping> numberMappingData)
        {
            var numberOccurrenceRates = new List<NumberOccurrenceRate>();

            //RedNum
            for (int i = 1; i <= 32; i++)
            {
                numberOccurrenceRates.Add(new NumberOccurrenceRate
                {
                    NumberType = 0,
                    Number = 1,
                    OccurrenceRate = numberMappingData.Count(k =>(bool)k.GetType().GetField(string.Format("BlueNum{0}", i)).GetValue(k))
                });
            }

            //BlueNum
            for (int i = 1; i <= 16; i++)
            {
                numberOccurrenceRates.Add(new NumberOccurrenceRate
                {
                    NumberType = 0,
                    Number = 1,
                    OccurrenceRate = numberMappingData.Count(k => ConvertHelper.ConvertBoolean(k.GetType().GetMember(string.Format("BlueNum{0}", i)).GetValue(0)))
                });
            }
            return numberOccurrenceRates.OrderBy(k => k.OccurrenceRate).ToList();
        }
    }
}
