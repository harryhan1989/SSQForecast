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
using System.Threading;
using System.Timers;

namespace SSQForecast.Bussiness
{
    public class HighOccurrenceRateAnalysis
    {
        MainForm _mainForm;
        List<IntervalRateViewModel> intervalRatePrizeList = new List<IntervalRateViewModel>();
        List<Thread> analysisThreads = new List<Thread>();
        public HighOccurrenceRateAnalysis(MainForm form)
        {
            _mainForm = form;
        }

        public void Analysis(int intervalRate, int termMinCount, int termMaxCount)
        {
            using (var ssqdbentities = new ssqdbEntities())
            {
                try
                {
                    intervalRatePrizeList.Clear();
                    List<TotalTermInfos> totalTermInfos = ssqdbentities.TotalTermInfos.OrderByDescending(k => k.TermNum).ToList();
                    var termCount = termMinCount;
                    while (termCount <= termMaxCount)
                    {
                        Thread newThread = new Thread(() =>
                        {
                            var intervalRateViewModel = Calculate(totalTermInfos, termCount);
                            lock (intervalRatePrizeList)
                            {
                                if (intervalRateViewModel != null)
                                    intervalRatePrizeList.Add(intervalRateViewModel);
                            }
                        });
                        newThread.IsBackground = true;
                        analysisThreads.Add(newThread);
                        newThread.Start();
                        Thread.Sleep(1000);
                        termCount += intervalRate;
                    }
                    Thread drawView = new Thread(() => {
                        DrawView();
                    });
                    drawView.Start();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        private void DrawView()
        {
            Thread.Sleep(1000);
            for (int i = analysisThreads.Count-1; i >= 0; i--)
            {
                var thread = analysisThreads[i];
                if (!thread.IsAlive)
                {
                    analysisThreads.Remove(thread);
                }
            }
            if (analysisThreads.Count == 0)
            {
                ConvertHelper.BindDataSource<IntervalRateViewModel>(_mainForm.Controls["IntervalRateView"], intervalRatePrizeList);
                return;
            }
            DrawView();
        }

        private IntervalRateViewModel Calculate(List<TotalTermInfos> totalTermInfos, int termCount)
        {
            using (var ssqdbentities = new ssqdbEntities())
            {
                var isPrizeList = new List<Boolean>();
                for (int j1 = 0; j1 < totalTermInfos.Count - termCount; j1++)
                //for (int j1 = 0; j1 < 50; j1++)
                {
                    var term = totalTermInfos[j1];
                    var baseNums = new string[7]
                                {
                                    term.RedNum1.ToString(CultureInfo.InvariantCulture),
                                    term.RedNum2.ToString(CultureInfo.InvariantCulture),
                                    term.RedNum3.ToString(CultureInfo.InvariantCulture),
                                    term.RedNum4.ToString(CultureInfo.InvariantCulture),
                                    term.RedNum5.ToString(CultureInfo.InvariantCulture),
                                    term.RedNum6.ToString(CultureInfo.InvariantCulture),
                                    term.BlueNum.ToString(CultureInfo.InvariantCulture)
                                };

                    var compareNums = new string[7];
                    var numberMappingToUse =
                        ssqdbentities.NumberMapping.Where(k => k.TermNum < term.TermNum).Take(termCount);

                    if (numberMappingToUse.Count() < termCount)
                        break;
                    var numberOccurrenceRate = GetNumberOccurrenceRate(numberMappingToUse);
                    var redNumberOccurrenceRate = numberOccurrenceRate.Where(k => k.NumberType == 0).ToList();
                    var blueNumberOccurrenceRate = numberOccurrenceRate.Where(k => k.NumberType == 1).ToList();
                    if (redNumberOccurrenceRate.Count() >= 6 && blueNumberOccurrenceRate.Any())
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            compareNums[i] =
                                ConvertHelper.ConvertString(redNumberOccurrenceRate.ElementAt(i).Number);
                        }
                        compareNums[6] =
                            ConvertHelper.ConvertString(blueNumberOccurrenceRate.ElementAt(0).Number);
                    }
                    var isPrize = ConvertHelper.IsPrize(compareNums, baseNums);
                    isPrizeList.Add(isPrize);

                    ConvertHelper.ShowMessage(_mainForm.Controls["ProgressingMessage"], string.Format("TermCount:{0};CurrentTerm:{1};isPrize{2}", termCount, j1 + ":" + term.TermNum, isPrize));
                }

                if (isPrizeList.Count > 0)
                {
                    var winningCount = isPrizeList.Count(k => k);
                    var intervalRateViewModel=new IntervalRateViewModel
                     {
                         TermNum = totalTermInfos.First().TermNum,
                         PreviousTermsNum = termCount,
                         WinningRate = (winningCount * 100 / isPrizeList.Count())
                     };
                    ConvertHelper.ShowMessage(_mainForm.Controls["ProgressingMessage"], string.Format("TermNum{0};PreviousTermsNum{1};WinningRate{2}"
                        , intervalRateViewModel.TermNum, intervalRateViewModel.PreviousTermsNum, intervalRateViewModel.WinningRate));
                    return intervalRateViewModel;
                    
                }
                else
                {
                    return null;
                }
            }
        }

        private IOrderedEnumerable<NumberOccurrenceRate> GetNumberOccurrenceRate(IQueryable<NumberMapping> numberMappingData)
        {
            #region convert
            var numberOccurrenceRates = new List<NumberOccurrenceRate>();

            //RedNum
            //for (int i = 1; i <= 32; i++)
            //{
            //    numberOccurrenceRates.Add(new NumberOccurrenceRate
            //    {
            //        NumberType = 0,
            //        Number = i,
            //        OccurrenceRate = numberMappingData.AsEnumerable().Count(k =>(bool)k.GetType().GetProperty(string.Format("RedNum{0}", i)).GetValue(k))
            //    });
            //}

            ////BlueNum
            //for (int i = 1; i <= 16; i++)
            //{
            //    numberOccurrenceRates.Add(new NumberOccurrenceRate
            //    {
            //        NumberType = 1,
            //        Number = i,
            //        OccurrenceRate = numberMappingData.AsEnumerable().Count(k => (bool)k.GetType().GetProperty(string.Format("BlueNum{0}", i)).GetValue(k))
            //    });
            //}

            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 0,
                Number = 1,
                OccurrenceRate = numberMappingData.Count(k=>(bool)k.RedNum1)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 0,
                Number = 2,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.RedNum2)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 0,
                Number = 3,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.RedNum3)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 0,
                Number = 4,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.RedNum4)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 0,
                Number = 5,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.RedNum5)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 0,
                Number = 6,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.RedNum6)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 0,
                Number = 7,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.RedNum7)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 0,
                Number = 8,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.RedNum8)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 0,
                Number = 9,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.RedNum9)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 0,
                Number = 10,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.RedNum10)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 0,
                Number = 11,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.RedNum11)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 0,
                Number = 12,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.RedNum12)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 0,
                Number = 13,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.RedNum13)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 0,
                Number = 14,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.RedNum14)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 0,
                Number = 15,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.RedNum15)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 0,
                Number = 16,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.RedNum16)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 0,
                Number = 17,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.RedNum17)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 0,
                Number = 18,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.RedNum18)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 0,
                Number = 19,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.RedNum19)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 0,
                Number = 20,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.RedNum20)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 0,
                Number = 21,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.RedNum21)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 0,
                Number = 22,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.RedNum22)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 0,
                Number = 23,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.RedNum23)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 0,
                Number = 24,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.RedNum24)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 0,
                Number = 25,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.RedNum25)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 0,
                Number = 26,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.RedNum26)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 0,
                Number = 27,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.RedNum27)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 0,
                Number = 28,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.RedNum28)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 0,
                Number = 29,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.RedNum29)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 0,
                Number = 30,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.RedNum30)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 0,
                Number = 31,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.RedNum31)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 0,
                Number = 32,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.RedNum32)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 1,
                Number = 1,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.BlueNum1)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 1,
                Number = 2,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.BlueNum2)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 1,
                Number = 3,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.BlueNum3)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 1,
                Number = 4,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.BlueNum4)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 1,
                Number = 5,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.BlueNum5)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 1,
                Number = 6,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.BlueNum6)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 1,
                Number = 7,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.BlueNum7)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 1,
                Number = 8,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.BlueNum8)
            });

            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 1,
                Number = 9,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.BlueNum9)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 1,
                Number = 10,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.BlueNum10)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 1,
                Number = 11,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.BlueNum11)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 1,
                Number = 12,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.BlueNum12)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 1,
                Number = 13,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.BlueNum13)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 1,
                Number = 14,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.BlueNum14)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 1,
                Number = 15,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.BlueNum15)
            });
            numberOccurrenceRates.Add(new NumberOccurrenceRate
            {
                NumberType = 1,
                Number = 16,
                OccurrenceRate = numberMappingData.Count(k => (bool)k.BlueNum16)
            });

            return numberOccurrenceRates.OrderBy(k => k.OccurrenceRate);
            
            #endregion
        }
    }
}
