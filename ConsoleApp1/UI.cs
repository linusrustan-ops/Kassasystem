using System.ComponentModel;

namespace Kassasystem
{
    public class UI
    {

        public static void Menu1()
        {
            while (true)
            {
                Console.WriteLine("========= Välkommen till kassasystemet! ===========");
            Console.WriteLine("" +
                "[1]. Ny kund\n" +
                "[2]. Admin\n" +
                "[0]. Exit");
            string input = Console.ReadLine();

            


                switch (input)
                {
                    case "1":
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
    }
}