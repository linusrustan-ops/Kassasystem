using System.ComponentModel;

namespace Kassasystem
{
    public class UI
    {
        ProduktRegister produktregister = new ProduktRegister();

        public void Menu1()
        {
            while (true)
            {
                Console.WriteLine("=========== Välkommen till kassasystemet! ===========");
                Console.WriteLine("" +
                    "[1]. Ny kund\n" +
                    "[2]. Admin\n" +
                    "[0]. Exit");
                string input = ReadString("Ditt Val:");




                switch (input)
                {
                    case "1":
                        produktregister.SearchByID();

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


        public static void VisaProdukter(string message)
        {

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

