using System.ComponentModel;

namespace Kassasystem
{
    public class UI
    {
        ProduktRegister produktregister = new ProduktRegister();
        Nykund nykund = new Nykund();
        

        public void Menu1()
        {
            while (true)
            {
                Console.WriteLine("=========== Välkommen till Linus Hälsoshop! ===========");
                Console.WriteLine("" +
                    "[1]. Ny kund\n" +
                    "[2]. Admin\n" +
                    "[0]. Exit");
                string input = ReadString("Ditt Val:");




                switch (input)
                {
                    case "1":
                        int idInput = ReadInteger("Skriv in ID nummer");
                        produktregister.SearchByID(idInput);
                        Product? product = produktregister.GetProductByID(idInput);
                        if (product != null)
                        {

                            double quantity = ReadDecimal("Hur många/mycket vill du ha?");
                            nykund.AddToCustomer(product, quantity);
                        }
                        

                        break;

                    case "2":
                        Admin.Password();
                        Admin.AdminMenu();
                        return;

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

        public static double ReadDecimal(string message)
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

