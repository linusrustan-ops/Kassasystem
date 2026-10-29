namespace Kassasystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            Kvitto kvitto = new Kvitto();
            ProduktRegister produktregister = new ProduktRegister();
            KampanjRegister kampanjregister = new KampanjRegister(produktregister);
            ProductService productservice = new ProductService(produktregister);
            Admin admin = new Admin(produktregister, kampanjregister, productservice);
            UI Ui = new UI(produktregister, admin, kampanjregister, kvitto);
            Ui.Menu1();
            
        }
    }
}
