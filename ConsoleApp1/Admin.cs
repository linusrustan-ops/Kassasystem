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
    internal class Admin(ProduktRegister produktregister, KampanjRegister kampanjregister)
    {


        public static bool Password()
        {
            while (true)
            {


                Console.Clear();
                Console.WriteLine("Vänligen skriv in Lösenordet:\n =============================== \n  Eller skriv exit for att asvluta.");

                string input = UI.ReadString("Tips: dom som vet dom vet");

                if (input == "dsvdv")
                {
                    Console.WriteLine("Välkommen!");
                    return true;
                }
                else if (input.ToLower() == "exit") ;

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
                        Kampanj newKampanj = CreateKampanj();
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
                        return;


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
            Product product = new(prodID, prodName, prodPrice, prodType);

            return product;
        }
        public Kampanj? CreateKampanj()
        {

            Product? product = null;
            while (product == null)
            {
                int userInputID = UI.ReadInteger("Vilken produkt ska kampanjen skapas på?");
                product = produktregister.GetProductByID(userInputID);

                if (product == null)
                {
                    Console.WriteLine("Produkten hittades tyvärr inte, försök igen.");
                }

            }
            double campaignPrice;
            Console.WriteLine($"Nuvarandet priset på {product.Name} är: {product.Price}kr");
            while (true)
            {
                campaignPrice = UI.ReadDouble("Vad ska Kampanjpriset vara?");
                if (campaignPrice > 0 && campaignPrice < product.Price)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Priset måste vara högre än 0 och mindre än nuvarande priset.");
                }
            }
            DateTime startDate = DateTime.Now;

            DateTime endDate;
            while (true)
            {
                int inputDays = UI.ReadInteger("Hur många dagar ska kampanjen vara? (1-14 dagar)");

                if (inputDays > 0 && inputDays <= 14)
                {
                    endDate = startDate.AddDays(inputDays);
                    Console.WriteLine("Kampanjen har skapats!");
                    break;
                }
                else
                {
                    Console.WriteLine("Du måste välja mellan 1-14 dagar!");
                }

            }

            Kampanj newCampaign = new(product, campaignPrice, startDate, endDate);

            return newCampaign;






        }
    }
}
