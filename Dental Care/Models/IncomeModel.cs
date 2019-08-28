using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Care.Models
{
    public class IncomeModel
    {
        string date;
        string docName;
        string amount;
        string patientName;
        string treatmentDescription;
        public IncomeModel(string date, string docName, string amount, string patientName, string treatmentdesc)
        {
            this.date = date;
            this.docName = docName;
            this.amount = amount;
            this.patientName = patientName;
            this.treatmentDescription = treatmentdesc;
        }

        public string getDate()
        {
            return this.date;
        }
        public string getDocName()
        {
            return this.docName;
        }
        public string getAmount()
        {
            return this.amount;
        }
        public string getPatientName()
        {
            return this.patientName;
        }
        public string getTreatmentDescription()
        {
            return this.treatmentDescription;
        }
    }
}
