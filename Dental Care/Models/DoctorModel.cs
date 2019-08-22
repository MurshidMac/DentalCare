using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Care.Models
{
    class DoctorModel
    {
        private string name;
        private string address;
        private string dateofbirth;
        private string nationalIdentityCard;
        private string contact;
        private string yearsofexperience;


        public DoctorModel(string name, string address,string dateofbirth, string nationalIdentity, string contact, string yearsofexperience)
        {
            this.name = name;
            this.address = address;
            this.dateofbirth = dateofbirth;
            this.nationalIdentityCard = nationalIdentity;
            this.contact = contact;
            this.yearsofexperience = yearsofexperience;
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
