using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Care.Models
{
    public class DoctorIncomeModel
    {
        string docName;
        float amount;
        public DoctorIncomeModel(string docname, float amount)
        {
            this.docName = docname;
            this.amount = amount;
        }
        public string getDocName()
        {
            return this.docName;
        }
        public float getAmount()
        {
            return this.amount;
        }
    }
}
