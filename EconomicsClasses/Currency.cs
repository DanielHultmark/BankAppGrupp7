using BankAppGrupp7.MenuClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BankAppGrupp7.EconomicsClasses
{
    public class Currency
    {
        public CurrencyCode Code { get; }
        public decimal SekToCurrencyRate { get; set; }

        public Currency(CurrencyCode code, decimal sekToCurrencyRate)
        {
            Code = code;
            SekToCurrencyRate = sekToCurrencyRate;
        }
        
    }
}
