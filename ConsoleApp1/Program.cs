namespace Kassasystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProduktRegister produktregister = new ProduktRegister();
            Product product = new Product();
            Admin admin = new Admin(produktregister);
            UI Ui = new UI(produktregister, admin);
            Ui.Menu1();
            
        }
    }
}
