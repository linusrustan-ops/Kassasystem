using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Kassasystem
{
    internal class Admin
    {

        public static bool Password()
        {
            while (true)
            {


                Console.Clear();
                Console.WriteLine("Vänligen skriv in Lösenordet:\n ===============\n  Eller skriv exit for att asvluta.");

                string input = Console.ReadLine();

                if (input == "admin")
                {
                    Console.WriteLine("Välkommen!");
                    return true;
                }
                else if (input.ToLower() == "exit");

                else
                {
                    Console.WriteLine("Fel lösenord, försök igen!");

                }
            }

           
        }

        public static void AdminMenu()
        {
            while (true)
            {


                Console.Clear();
                Console.WriteLine("==========Välkommen till Admin Menyn==========");
                Console.WriteLine("" +
                    "[1]. Ändra varors egenskaper\n" +
                    "[2]. Visa Kvitton\n" +
                    "[3]. Skapa kampanj\n" +
                    "[4]. Lägg till vara\n" +
                    "[0]. Exit");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        break;

                case "2":
                        break;

                    case "3":
                        break;

                    case "4":
                        break;

                    case "0":
                        Environment.Exit(2);
                        break;

                    default:
                        Console.WriteLine("Ogiltigt Svar försök igen.");
                        break;
                }
            }
        }


    }
}
