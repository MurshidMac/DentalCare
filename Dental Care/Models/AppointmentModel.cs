using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Care.Models
{
    public class AppointmentModel
    {
        private string doctorName;
        private string PatientName;
        private string Treatment;
        private string Amount;
        private string Date;
        public AppointmentModel(string docName, string PatientName, string treatme, string amo, string dateforap)
        {
            this.doctorName = docName;
            this.PatientName = PatientName;
            this.Treatment = treatme;
            this.Amount = amo;
            this.Date = dateforap;
        }
        public string getDocName()
        {
            return this.doctorName;
        }
        public string getPatientName()
        {
            return this.PatientName;
        }
        public string getTreatmentDetails()
        {
            return this.Treatment;
        }
        public string getAmount()
        {
            return this.Amount;
        }
        public string getDate()
        {
            return this.Date;
        }
    }
}
