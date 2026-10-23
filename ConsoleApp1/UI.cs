using System.ComponentModel;

namespace Kassasystem
{
    internal class UI(ProduktRegister produktregister, Admin admin, KampanjRegister kampanjregister, Kvitto kvitto)
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
                        int idInput = ReadInteger("Skriv in ID nummer\n");
                        Kampanj? campaign = kampanjregister.SearchCampaign(idInput);
                        Product? product = produktregister.GetProductByID(idInput);
                        if (product != null && campaign != null)
                        {
                            double quantity = ReadDouble("Hur många/mycket vill du ha?\n");
                            nykund.AddToCustomer(campaign.KProduct, quantity, campaign.KPrice);
                            Console.WriteLine("Kampanj hittades!");
                            Console.WriteLine("Din varukorg består av:");
                            nykund.PrintList();
                        }
                        else if (product != null)
                        {
                            double quantity = ReadDouble("Hur många/mycket vill du ha?\n");
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
                                kvitto.Receipt(nykund);
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
                else
                {
                    return value;
                }
            }
        }
    }
}

