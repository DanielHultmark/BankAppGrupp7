using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppGrupp7.UsersClasses
{
    internal class LogIn
    {

        //We need to save which customer/user is logging in to now which account to show in next menu
        //Where do we create admin user?
        public int LoginAttempts { get; set; } = 3;

        public User User { get; set; }

        public void LoginMethod()
        {

        }
    }
}
