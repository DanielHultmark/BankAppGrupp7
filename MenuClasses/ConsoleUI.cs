using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppGrupp7.MenuClasses
{
    internal class ConsoleUI
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
            Console.ReadKey();
        }
        // Use to give feedback to user, for error or confirmation.
        public static void ShowFeedbackMessage(string message, ConsoleColor color, int millisecondsDelay)
        {
            Console.ForegroundColor = color;
            Console.Write("\n" + message);
            Console.ResetColor();

            Thread.Sleep(millisecondsDelay);
        }

        public static void ShowFeedbackMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write("\n" + message);
            Console.ResetColor();


        }

    }
}
