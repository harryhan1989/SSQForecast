using SSQForecast.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSQForecast.Bussiness
{
    public class InitialDbData
    {
        public void InitialAllNumberMappingData()
        {
            using (var ssqdbentities=new ssqdbEntities())
            {               
                try
                {
                    ssqdbentities.Database.ExecuteSqlCommand("Delete from NumberMapping");
                    ssqdbentities.Database.ExecuteSqlCommand("Insert into NumberMapping select * from UV_NumberMapping");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public void InitialNewestNumberMappingData()
        {
        
        }
    }
}
