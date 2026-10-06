namespace Kassasystem
{
    public class UI
    {

        public static void Menu1()
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
                    break;

                case "0":
                    Environment.Exit(0);
                    break;

                default:
                    break;
            }

        }
    }
}