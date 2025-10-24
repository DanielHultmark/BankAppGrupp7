using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppGrupp7.UsersClasses
{
    internal class LogIn
    {

        //We need to save which customer/user is logging in somehow to know which account to show in next menu
        
        public int LoginAttempts { get; set; } = 3;

        public UserRegister Users { get; set; }

        public void LoginMethod()
        {

        }
    }
}
