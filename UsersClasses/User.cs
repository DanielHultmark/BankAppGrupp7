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
        public Dictionary<string , string > LoginDetails { get; set; } = new Dictionary<string, string>();
     
        public string FullName { get; set; }

       
    }
}
