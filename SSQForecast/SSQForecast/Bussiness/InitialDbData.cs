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
                    numberMappings = ssqdbentities.NumberMapping.ToList();
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

        public void FromAndToTermBinding(ComboBox fromTerm, ComboBox toTerm)
        {
            using (var ssqdbentities = new ssqdbEntities())
            {
                try
                {
                    fromTerm.DataSource = numberMappings;
                    fromTerm.DisplayMember = "TermNum";
                    fromTerm.ValueMember = "TermNum";
                    toTerm.DataSource = numberMappings;
                    toTerm.DisplayMember = "TermNum";
                    toTerm.ValueMember = "TermNum";
                   
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            } 
        }
    }
}
