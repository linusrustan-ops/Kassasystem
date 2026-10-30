using Kassasystem.Models;
using Kassasystem.Services;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Kassasystem
{
    public class Admin(ProductService productservice, KampanjService kampanjservice)
    {


        public static void Password()
        {
            while (true)
            {


                Console.Clear();
                Console.WriteLine("Vänligen skriv in Lösenordet:\n =============================== \n  Eller skriv exit for att asvluta.");

                string input = UI.ReadString("Tips: admin");

                if (input == "admin")
                {
                    Console.WriteLine("Välkommen!");
                    return;
                }
                else if (input.ToLower() == "exit")
                {
                    return;
                }

                else
                {
                    Console.WriteLine("Fel lösenord, försök igen!");
                }
                }
            }

        public void AdminMenu()
        {
            while (true)
            {


                Console.Clear();
                Console.WriteLine("==========Välkommen till Admin Menyn==========");
                Console.WriteLine("" +
                    "[1]. Ändra varors egenskaper\n" +
                    "[2]. Skapa kampanj\n" +
                    "[3]. Lägg till vara\n" +
                    "[4]. Ta bort Kampanj\n" +
                    "[0]. Return to Main menu.");
                string input = UI.ReadString("");

                switch (input)
                {
                    case "1":
                        int userChoice = UI.ReadInteger("Vill du:\n" +
                            "[1]. Ändra en varas namn.\n" +
                            "[2]. Ändra en varas pris.\n" +
                            "[3]. Ändra både namn och pris.\n" +
                            "[0]. Avsluta.");
                        if (userChoice == 1)
                        {
                            productservice.ChangeExProductName();
                            break;
                        }
                        else if (userChoice == 2)
                        {
                            productservice.ChangeExProductPrice();
                            break;
                        }
                        else if (userChoice == 3)
                        {
                            productservice.ChangeExProductName();
                            productservice.ChangeExProductPrice();
                            break;
                        }
                        else if (userChoice == 0)
                        {
                            Environment.Exit(2);
                        }

                        else
                        {
                            Console.WriteLine("Ogiltigt Svar försök igen");
                            break;
                        }
                        break;

                    case "2":
                        Kampanj newKampanj = kampanjservice.CreateKampanj();
                        if (kampanjservice.CheckCampaign(newKampanj))
                        {
                            Console.WriteLine("Kampanjen har lagts till!");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("En likadan kampanj finns redan på produkten");
                            break;
                        }

                    case "3":
                                Product? newproduct = productservice.NewProduct();
                                if (newproduct != null && productservice.ProductIsAdded(newproduct))
                                {
                                    Console.WriteLine("Produkten lades till");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Produkten lades inte till, den finns redan");
                                    break;
                                }
                    case "4":
                        kampanjservice.RemoveACampaign();
                        break;

                    case "0":
                        return;


                    default:
                        Console.WriteLine("Ogiltigt Svar försök igen.");
                        break;
                            }
                        }
            }
        
    }
}
