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
        readonly MainForm _mainForm;
        readonly List<IntervalRateViewModel> _intervalRatePrizeList = new List<IntervalRateViewModel>();
        readonly List<Thread> _analysisThreads = new List<Thread>();
        CheckedListBox.CheckedItemCollection _redPositions;
        CheckedListBox.CheckedItemCollection _bluePositions;
        long _chooseMaxTermNum;
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        private const int _maxThreads = 5;

        public HighOccurrenceRateAnalysis(MainForm form)
        {
            _mainForm = form;
            _redPositions = (_mainForm.Controls["RedNumPositions"] as CheckedListBox).CheckedItems;
            _bluePositions = (_mainForm.Controls["BlueNumPosition"] as CheckedListBox).CheckedItems;
            _chooseMaxTermNum =ConvertHelper.ConvertLong((_mainForm.Controls["MaxTermNum"] as ComboBox).SelectedValue);
            
        }

        public void Analysis(int intervalRate, int termMinCount, int termMaxCount)
        {

            try
            {
                _intervalRatePrizeList.Clear();
                var termCount = termMinCount;

                timer.Tick += new EventHandler(DrawView); // Everytime timer ticks, timer_Tick will be called
                timer.Interval = (1000) * (5);              // Timer will tick evert second
                timer.Enabled = true;                       // Enable the timer
                timer.Start();                              // Start the timer

                var mainAnalysisThread = new Thread(() =>
                    {
                        while (termCount <= termMaxCount)
                        {
                            lock (_analysisThreads)
                            {
                                var currentTermCount = termCount;
                                int count = termCount;
                                var newThread = new Thread(() =>
                                {
                                    using (var ssqdbentities = new ssqdbEntities())
                                    {
                                        var totalTermInfos = ssqdbentities.TotalTermInfos.Where(w=>w.TermNum<=_chooseMaxTermNum).OrderByDescending(k => k.TermNum).ToList();
                                        var intervalRateViewModel = Calculate(totalTermInfos, currentTermCount);
                                        var numberMappingToUse = ssqdbentities.NumberMapping.Take(count);
                                        var forecast =GetNumsFromTermsAndPositions(numberMappingToUse);
                                        var forecastStr = forecast.Aggregate("", (current, num) => current + (num + ","));
                                        intervalRateViewModel.NextTermNumForecast = forecastStr.TrimEnd(',');
                                        {
                                            _intervalRatePrizeList.Add(intervalRateViewModel);
                                        }
                                    }
                                }) {IsBackground = true};
                                _analysisThreads.Add(newThread);
                                newThread.Start();
                                while (_analysisThreads.Count >= _maxThreads)
                                {
                                    Thread.Sleep(5000);
                                }
                                termCount += intervalRate;
                            }
                        }
                    });
                mainAnalysisThread.Start();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private IntervalRateViewModel Calculate(List<TotalTermInfos> totalTermInfos, int termCount)
        {
            using (var ssqdbentities = new ssqdbEntities())
            {
                var isPrizeList = new List<Boolean>();
                //for (int j1 = 0; j1 < totalTermInfos.Count - termCount; j1++)
                for (int j1 = 0; j1 < 100; j1++)
                {
                    var term = totalTermInfos[j1];
                    var baseNums = new int[7]
                        {
                            ConvertHelper.ConvertInt(term.RedNum1),
                            ConvertHelper.ConvertInt(term.RedNum2),
                            ConvertHelper.ConvertInt(term.RedNum3),
                            ConvertHelper.ConvertInt(term.RedNum4),
                            ConvertHelper.ConvertInt(term.RedNum5),
                            ConvertHelper.ConvertInt(term.RedNum6),
                            ConvertHelper.ConvertInt(term.BlueNum)
                        };
                    var numberMappingToUse = ssqdbentities.NumberMapping.Where(k => k.TermNum < term.TermNum).Take(termCount);
                    if (numberMappingToUse.Count() < termCount)
                        break;
                    var compareNums = GetNumsFromTermsAndPositions(numberMappingToUse);

                    var isPrize = ConvertHelper.IsPrize(compareNums, baseNums);
                    isPrizeList.Add(isPrize);

                    ConvertHelper.ShowMessage(_mainForm.Controls["ProgressingMessage"], string.Format("TermCount:{0};CurrentTerm:{1};isPrize{2}", termCount, j1 + ":" + term.TermNum, isPrize));
                }

                if (isPrizeList.Count > 0)
                {
                    var winningCount = isPrizeList.Count(k => k);
                    var intervalRateViewModel = new IntervalRateViewModel
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

        private int[] GetNumsFromTermsAndPositions(IQueryable<NumberMapping> terms)
        {
            var nums=new int[7];
            var numberOccurrenceRate = GetNumberOccurrenceRate(terms);
            var redNumberOccurrenceRate = numberOccurrenceRate.Where(k => k.NumberType == 0).ToList();
            var blueNumberOccurrenceRate = numberOccurrenceRate.Where(k => k.NumberType == 1).ToList();
            if (redNumberOccurrenceRate.Count() >= 6 && blueNumberOccurrenceRate.Any())
            {
                int i = 0;
                foreach (var position in _redPositions)
                {
                    nums[i] = redNumberOccurrenceRate.ElementAt((int.Parse(position.ToString())) - 1).Number;
                    i++;
                }
                nums[6] =
                    blueNumberOccurrenceRate.ElementAt((int.Parse(_bluePositions[0].ToString())) - 1).Number;
            }

            return nums;
        }

        private void DrawView(object sender, EventArgs e)
        {
            var isChanged = false;
            for (int i = _analysisThreads.Count-1; i >= 0; i--)
            {
                var thread = _analysisThreads[i];
                if (!thread.IsAlive)
                {
                    _analysisThreads.Remove(thread);
                    isChanged = true;
                }
            }

            if (isChanged)
            {
                ConvertHelper.BindDataSource<IntervalRateViewModel>(_mainForm.Controls["IntervalRateView"], _intervalRatePrizeList);
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

            return numberOccurrenceRates.OrderByDescending(k => k.OccurrenceRate);
            
            #endregion
        }
    }
}
