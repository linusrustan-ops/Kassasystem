namespace Kassasystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProduktRegister produktregister = new ProduktRegister();
            KampanjRegister kampanjregister = new KampanjRegister(produktregister);
            Admin admin = new Admin(produktregister, kampanjregister);
            UI Ui = new UI(produktregister, admin, kampanjregister);
            Ui.Menu1();
            
        }
    }
}
