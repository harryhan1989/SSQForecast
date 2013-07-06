using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SSQForecast.Helper;
using SSQForecast.Models;

namespace SSQForecast.Bussiness
{
    public class OnlineData17500CN
    {
        private string _url;
        private string _downloadFullPath;

        public OnlineData17500CN()
        {
            _url = "http://www.17500.cn/getData/ssq.TXT";
            _downloadFullPath = Application.StartupPath + @"\Data\ssq.csv";
            using (WebClient myWebClient = new WebClient())
            {
                myWebClient.DownloadFile(_url, _downloadFullPath);
            }
        }

        public void UpdateNewest()
        {           
            using (var ssqdbentities = new ssqdbEntities())
            {
                var currentMaxTermNum=ssqdbentities.TotalTermInfos.Max(m => m.TermNum);
                var newestTermInfos = ReadCsv(currentMaxTermNum);
                if (newestTermInfos.Count > 0)
                {
                    foreach (var totalTermInfo in newestTermInfos)
                    {
                        ssqdbentities.TotalTermInfos.Add(totalTermInfo);
                        //ssqdbentities.Set<TotalTermInfos>();
                        //ssqdbentities.ChangeTracker.Entries();
                    }
                    ssqdbentities.SaveChanges();
                }
            }
        }

        private List<TotalTermInfos> ReadCsv(long maxTermNum)
        {
            return File.ReadLines(_downloadFullPath)
                       .Skip(1)
                       .Where(s => s != "")
                       .Select(s => s.Split(new[] {' '}))
                       .Where(s => s.Count() == 29 && maxTermNum<ConvertHelper.ConvertLong(s[0]))
                       .Select(a => new TotalTermInfos
                           {
                               TermNum = ConvertHelper.ConvertLong(a[0]),
                               TermDate = ConvertHelper.ConvertDateTime(a[1]),
                               BlueNum = ConvertHelper.ConvertLong(a[9]),
                               RedNum1 = ConvertHelper.ConvertLong(a[9]),
                               RedNum2 = ConvertHelper.ConvertLong(a[10]),
                               RedNum3 = ConvertHelper.ConvertLong(a[11]),
                               RedNum4 = ConvertHelper.ConvertLong(a[12]),
                               RedNum5 = ConvertHelper.ConvertLong(a[13]),
                               RedNum6 = ConvertHelper.ConvertLong(a[14]),
                               TotalPaid = ConvertHelper.ConvertLong(a[15]),
                               PrizePool = ConvertHelper.ConvertLong(a[16]),
                               FirstPrizeNum = ConvertHelper.ConvertLong(a[17]),
                               AmountPerFirstPrize = ConvertHelper.ConvertLong(a[18]),
                               SecondPrizeNum = ConvertHelper.ConvertLong(a[19]),
                               AmountPerSecondPrize = ConvertHelper.ConvertLong(a[20]),
                               ThirdPrizeNum = ConvertHelper.ConvertLong(a[21]),
                               AmountPerThirdPrize = ConvertHelper.ConvertLong(a[22]),
                               FourthPrizeNun = ConvertHelper.ConvertLong(a[23]),
                               AmountPerFourthPrize = ConvertHelper.ConvertLong(a[24]),
                               FifthPrizeNum = ConvertHelper.ConvertLong(a[25]),
                               AmountPerFifthPrize = ConvertHelper.ConvertLong(a[26]),
                               SixthPrizeNum = ConvertHelper.ConvertLong(a[27]),
                               AmountPerSixthPrize = ConvertHelper.ConvertLong(a[28])
                           })
                       .ToList();
        }
    }
}
