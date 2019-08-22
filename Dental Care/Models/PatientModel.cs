using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Care
{
    class PatientModel
    {
        private string name;
        private string address;
        private string nationalIdentityCard;
        private string contact;


 
        public PatientModel(string name, string address, string nationalIdentity, string contact)
        {
            this.name = name;
            this.address = address;
            this.nationalIdentityCard = nationalIdentity;
            this.contact = contact;
        }

       public string getName()
        {
            return name;
        }

        public string getAddress()
        {
            return address;
        }

        public string getNationalIdendity()
        {
            return nationalIdentityCard;
        }

        public string getContact()
        {
            return contact;
        }


        public void setName(string name)
        {
            this.name = name;
        }

        public void setAddress(string address)
        {
            this.address = address;
        }

        public void setNationalIdentity(string nationalIdentity)
        {
            this.nationalIdentityCard = nationalIdentity;
        }

        public void setContact(string contact)
        {
            this.contact = contact;
        }
    }
}
