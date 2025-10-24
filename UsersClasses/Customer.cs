using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankAppGrupp7.UsersClasses
{
    internal class Customer : User
    {
        //Constructor; set IsAdmin to falsem also making sure that evert customer har username, password and a fullname.
        public Customer(string userName, string password, string fullName)
        {
            IsAdmin = false;

            LoginDetails["username"] = userName;

            LoginDetails["password"] = password;

            FullName = fullName;
        }

    }
}
