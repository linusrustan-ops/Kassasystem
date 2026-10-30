using Kassasystem.Repos;
using Kassasystem.Services;

namespace Kassasystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            KvittoRegister kvittoregister = new();
            KvittoService kvitto = new(kvittoregister);
            ProduktRegister produktregister = new();
            KampanjRegister kampanjregister = new(produktregister);
            ProductService productservice = new(produktregister);
            KampanjService kampanjservice = new(kampanjregister, produktregister);
            Admin admin = new(productservice, kampanjservice);
            UI Ui = new(productservice, admin, kvitto, kampanjservice);
            Ui.Menu1();
            
        }
    }
}
