using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_Care.Models
{
    public class UserModel
    {
        string username;
        string password;
        string roleId;
        public UserModel(string username, string password, string roleId)
        {
            this.username = username;
            this.password = password;
            this.roleId = roleId;
        }


        public string getUsername()
        {
            return this.username;
        }

        public string getPassword()
        {
            return this.password;
        }

        public string getRoleIdd()
        {
            return this.roleId;
        }
    }
}
