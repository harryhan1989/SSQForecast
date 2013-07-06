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
        private List<NumberMapping> numberMappings;

        public InitialDbData()
        {
            using (var ssqdbentities = new ssqdbEntities())
            {
                try
                {
                    numberMappings = ssqdbentities.NumberMapping.OrderByDescending(m=>m.TermNum).ToList();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

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
            using (var ssqdbentities = new ssqdbEntities())
            {
                try
                {
                    ssqdbentities.Database.ExecuteSqlCommand("Insert into NumberMapping select * from UV_NumberMapping where UV_NumberMapping.TermNum>(select max(NumberMapping.TermNum) from NumberMapping)");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            } 
        }

        public void ComboBoxTermBinding(ComboBox termComboBox)
        {
            using (var ssqdbentities = new ssqdbEntities())
            {
                try
                {
                    termComboBox.DataSource = numberMappings;
                    termComboBox.DisplayMember = "TermNum";
                    termComboBox.ValueMember = "TermNum";                   
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            } 
        }
    }
}
