using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppGrupp7.MenuClasses
{
    internal class Grafik
    {

        public static void DisplayLogo()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n\n");
            Console.WriteLine("       C#C#C#C#C#          C#C#C#C#C#C#C#         C#C#C#C#C#C#                     C#C#C#C#");
            Console.WriteLine("   C#C#C#C#C#C#C#C#C#         C#C#C#C#            C#C#C#C#C#C#C#                  C#C#C#C#C#");
            Console.WriteLine("  C#C#C#        C#C#C#        C#C#C#C#            C#C#       C#C#                C#        C#");
            Console.WriteLine(" C#C#                C#       C#C#C#C#            C#C#        C#C#              C#          C#");
            Console.WriteLine("C#C#                          C#C#C#C#            C#C#       C#C#              C#            C#");
            Console.WriteLine("C#C#                          C#C#C#C#            C#C#C#C#C#C#C#              C#              C#");
            Console.WriteLine("C#C#                          C#C#C#C#            C#C#C#C#C#C#C#             C#                C#");
            Console.WriteLine("C#C#                          C#C#C#C#            C#C#        C#C#          C#C#C#C#C#C#C#C#C#C#C#");
            Console.WriteLine("C#C#                          C#C#C#C#            C#C#         C#C#         C#C#C#C#C#C#C#C#C#C#C#");
            Console.WriteLine("C#C#                          C#C#C#C#            C#C#          C#C#       C#C#                C#C#");
            Console.WriteLine(" C#C#               C#        C#C#C#C#            C#C#         C#C#       C#C#                  C#C#");
            Console.WriteLine("  C#C#C#        C#C#C#        C#C#C#C#            C#C#        C#C#       C#C#                    C#C#");
            Console.WriteLine("  C#C#C#C#C#C#C#C#C#C#        C#C#C#C#            C#C#C#C#C#C#          C#C#                      C#C#");
            Console.WriteLine("      C#C#C#C#C#            C#C#C#C#C#C#          C#C#C#C#C#          C#C#C#C#                   C#C#C#C#");
            Console.ResetColor();
        }
        public static void ShowHeader(string header)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n» {header.ToUpper()} «");
            Console.ResetColor();
            Console.WriteLine();
        }
        
        public static void ReturnToMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Tryck Enter för att gå tillbaka");
            Console.ReadLine();
        }


    }
}
