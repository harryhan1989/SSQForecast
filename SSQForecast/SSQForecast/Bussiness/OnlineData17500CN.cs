using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSQForecast.Bussiness
{
    public class OnlineData17500CN
    {
        private string _url;

        public OnlineData17500CN()
        {
            _url = "http://www.17500.cn/getData/ssq.TXT";
            using (WebClient myWebClient = new WebClient())
            {
                myWebClient.DownloadFile(_url, Application.StartupPath + @"\Data\ssq.csv");
            }

        //    WebRequest request = WebRequest.Create(_url);
        //    request.Timeout = 30 * 60 * 1000;
        //    request.UseDefaultCredentials = true;
        //    request.Proxy.Credentials = request.Credentials;
        //    WebResponse response = (WebResponse)request.GetResponse();
        //    using (Stream stream = response.GetResponseStream())
        //    {
        //        using (Stream s = File.Create(Application.StartupPath + @"\Data\ssq.TXT"))
        //        {
        //            stream.CopyTo(s);
        //        }
        //    }
        }
    }
}
