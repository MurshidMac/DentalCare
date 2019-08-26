using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Care.Models
{
    class UserModel
    {
        string username;
        string password;
        public UserModel(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        public string getUsername()
        {
            return this.username;
        }

        public string getPassword()
        {
            return this.password;
        }
    }
}
