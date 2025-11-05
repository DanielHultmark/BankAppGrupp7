using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppGrupp7.MenuClasses
{
    public static class InputValidation
    {
        public static decimal Decimal()
        {
            decimal value = 0;
            bool wasSuccesful = false;
            bool stillValidating = true;

            while (stillValidating)
            {
                string? userInput = Console.ReadLine();
                //Checks if there is something inside the string and that it isn't empty including just a space
                if (!string.IsNullOrWhiteSpace(userInput))
                {
                    //Trim removes specific characters 
                    string trimmedUserInput = userInput.Trim();
                    //If the input is valid the bool will become successful
                    wasSuccesful = decimal.TryParse(trimmedUserInput, out value);
                }

                if (wasSuccesful)
                {
                    //If the input is valid then stillValidating becomes false, ending the loop
                    stillValidating = false;
                }
                else
                {
                    //If the input isn't valid then the loop restarts
                    Thread.Sleep(1000);
                    Console.WriteLine("Välj ett nummer, försök igen!");
                }
            }
            return value;
        }

        public static string TrimmedString()
        {
            string value = "";
            bool stillValidating = true;
            while (stillValidating)
            {
                string? userInput = Console.ReadLine();
                //Trims the string if the string isn't empty or a " " string
                if (!string.IsNullOrWhiteSpace(userInput)) 
                {
                    value = userInput.Trim();
                    stillValidating = false;
                }
                else
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("Välj rätt input, försök igen!");
                }
            }

            return value;
        }
        //Just makes it so that the input becomes toLower so it isn't case sensitive
        public static string TrimmedStringToLower()
        {
            string value = "";
            bool stillValidating = true;
            while (stillValidating)
            {
                string? userInput = Console.ReadLine();
                //Trims the string if the string isn't empty or a " " string
                if (!string.IsNullOrWhiteSpace(userInput))
                {
                    value = userInput.Trim().ToLower();
                    stillValidating = false;
                }
                else
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("Välj rätt input, försök igen!");
                }
            }

            return value;
        }

        public static string ReadStringInput(string prompt)
        {
            Console.Write(prompt + " ");
            string? userInput = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(userInput))
            {                
                return string.Empty;
            }

            return userInput;
        }

        //Int validation
        public static int ReadIntInput(string prompt)
        {
            Console.Write(prompt + " ");
            bool isNUmber = int.TryParse(Console.ReadLine().Trim(), out int number);
            
            if (!isNUmber)
            {             
                return -1;
            }

            return number;
        }
           
        }

        //Input validation for double
        public static double Double()
        {
            double value = 0;
            bool wasSuccesful = false;
            bool stillValidating = true;

            while (stillValidating)
            {
                string? userInput = Console.ReadLine();
                //Checks if there is something inside the string and that it isn't empty including just a space
                if (!string.IsNullOrWhiteSpace(userInput))
                {
                    //Trim removes specific characters 
                    string trimmedUserInput = userInput.Trim();
                    //If the input is valid the bool will become successful
                    wasSuccesful = double.TryParse(trimmedUserInput, out value);
                }

                if (wasSuccesful)
                {
                    //If the input is valid then stillValidating becomes false, ending the loop
                    stillValidating = false;
                }
                else
                {
                    //If the input isn't valid then the loop restarts
                    Thread.Sleep(1000);
                    Console.WriteLine("Välj ett nummer, försök igen!");
                }
            }
            return value;
        }
    }
