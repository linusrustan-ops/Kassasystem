using Kassasystem.Models;
using Kassasystem.Repos;
using Kassasystem.Services;
using System.ComponentModel;

namespace Kassasystem
{
    public class UI(ProductService productservice, Admin admin, KvittoService kvitto, KampanjService kampanjservice)
    {
        public void Menu1()
        {
            while (true)
            {
                Console.WriteLine("=========== Välkommen till Linus Hälsoshop! ===========");
                Console.WriteLine("" +
                    "[1]. Ny kund\n" +
                    "[2]. Admin\n" +
                    "[0]. Exit");
                string input = ReadString("\nDitt Val:\n");




                switch (input)
                {
                    
                    case "1":

                        Nykund nykund = new Nykund();
                    while (true)
                    {
                        (int idInput, double quantity) = nykund.GetIDAndQuantity();
                        Kampanj? campaign = kampanjservice.GetActiveCampaign(idInput);
                        Product? product = productservice.GetProductBySearch(idInput);
                        if (product != null && campaign != null)
                        {
                            nykund.AddToCustomer(campaign.KProduct, quantity, campaign.KPrice);
                            Console.WriteLine("Kampanj hittades!");
                            Console.WriteLine("Din varukorg består av:");
                            nykund.PrintList();
                        }
                        else if (product != null)
                        {
                            nykund.AddToCustomer(product, quantity, product.Price);
                            Console.WriteLine("Din varukorg består av:");
                            nykund.PrintList();
                        }

                        else
                        {
                            Console.WriteLine("Varan finns tyvärr inte i vårt system, försök igen!");
                            continue;
                        }



                            string payOrExit = ReadString("Skriv \"PAY\" för att betala eller skriv \"Enter\" för att lägga till en ny vara\n");
                            if (payOrExit.ToUpper().Trim() == "PAY")
                            {
                                Console.Clear();
                                kvitto.CheckReceipt(kvitto.Receipt(nykund));
                                break;
                            }
                            else if (payOrExit.ToUpper().Trim() == "ENTER")
                            {
                                Console.Clear();
                                continue;
                            }

                        }
                            break;

                    case "2":
                        Admin.Password();
                        admin.AdminMenu();
                        break;

                    case "0":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Ogiltigt svar, försök igen!");
                        continue;
            }
            }

        }


        

        
        public static string ReadString(string message)
        {
            while (true)
            {
                Console.WriteLine(message);
                string? input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Ogiltigt värde. Försök igen");
                }
                else return input;
            }
        }

        public static int ReadInteger(string message)
        {
            while (true)
            {
                Console.WriteLine(message);
                string? input = Console.ReadLine();
                int value = 0;

                if (!int.TryParse(input, out value))
                {
                    Console.WriteLine("Ogiltigt värde. Försök igen");
                }
                else if (value <= 0)
                {
                    Console.WriteLine("Ett tal får inte vara negativt.");
                }
                else
                {
                    return value;
                }
            }
        }
        

        public static double ReadDouble(string message)
        {
            while (true)
            {
                
                Console.Write(message);
                string? input = Console.ReadLine();
                double value = 0;
                if (!double.TryParse(input, out value))
                {
                    Console.WriteLine("Ogiltigt värde. Försök igen");
                }
                else if (!double.IsFinite(value) || value <= 0)
                {
                    Console.WriteLine("Ett tal får inte vara negativt.");
                }
                else
                {
                    return value;
                }
            }
        }
    }
}

