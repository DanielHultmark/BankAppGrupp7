using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppGrupp7.UsersClasses
{
    internal class User
    {
        public bool IsAdmin { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? FullName { get; set; }

        public int FailedLoginAttempts { get; set; } = 0;

        public void IncreaseNumberLoginAttempts()
        {
            FailedLoginAttempts++;
        }        
    }
}
