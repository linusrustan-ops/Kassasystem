using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Kassasystem
{
    internal class Admin (ProduktRegister produktregister)
    {
        

        public static bool Password()
        {
            while (true)
            {


                Console.Clear();
                Console.WriteLine("Vänligen skriv in Lösenordet:\n =============== \n  Eller skriv exit for att asvluta.");

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
                    "[0]. Exit");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        int userChoice = UI.ReadInteger("Vill du:" +
                            "[1]. Ändra en varas namn." +
                            "[2]. Ändra en varas pris." +
                            "[3]. Ändra både namn och pris." +
                            "[0]. Avsluta.");
                        if (userChoice == 1)
                        {
                            produktregister.ChangeExProductName();
                            break;
                        }
                        else if (userChoice == 2)
                        {
                            produktregister.ChangeExProductPrice();
                            break;
                        }
                        else if (userChoice == 3)
                        {
                            produktregister.ChangeExProductName();
                            produktregister.ChangeExProductPrice();
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
                         break;

                            case "3":
                                Product newproduct = NewProduct();
                                if (produktregister.AddToDictionary(newproduct) == true)
                                {
                                    Console.WriteLine("Produkten lades till");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Produktens ID finns redan i systemet");
                                    break;
                                }

                            case "0":
                                Environment.Exit(2);
                                break;

                            default:
                                Console.WriteLine("Ogiltigt Svar försök igen.");
                                break;
                            }
                        }
                        
                        
                        
                        
            }
        


        public Product NewProduct()
        {
            int prodID = produktregister.GenerateID();
            string prodName = UI.ReadString("Vad ska varan heta?");
            double prodPrice = UI.ReadDouble("Vad ska varan kosta?");
            _Type prodType = Product.GetProductType();
            Product product = new Product(prodID, prodName, prodPrice, prodType);

            return product;
        }

        
       
        

        
        

        


    }
}
