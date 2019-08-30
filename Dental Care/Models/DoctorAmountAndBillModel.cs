using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Care.Models
{
    public class DoctorAmountAndBillModel
    {
        int bilNo;
        string doctorName;
        float amount;
        public DoctorAmountAndBillModel(int billNo, string doctor, float amount)
        {
            this.bilNo = billNo;
            this.doctorName = doctor;
            this.amount = amount;
        }

        public int GetBillNo()
        {
            return this.bilNo;
        }
        public string GetDocName()
        {
            return this.doctorName;
        }
        public float GetAmount()
        {
            return this.amount;
        }
    }

}
