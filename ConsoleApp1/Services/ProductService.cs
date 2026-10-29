using System;
using System.Collections.Generic;
using System.Text;

namespace Kassasystem
{
    public class ProductService
    {
        private readonly ProduktRegister _produktRegister;

        public ProductService(ProduktRegister produktregister)
        {
            _produktRegister = produktregister;
        }
        public void ChangeExProductPrice()
        {
            int searchID = UI.ReadInteger("Vilken produkt vill du ändra på? (Sök med id)\n");
            //_produktRegister.SearchByID(searchID);
            Product? product = _produktRegister.GetProductByID(searchID);
            if (product == null)
            {
                return;
            }
            bool priceIsAccepted = false;
            while (!priceIsAccepted)
            {
                double newPrice = UI.ReadDouble("Vad ska produktens nya pris vara? (Max tillåtna pris är 10000.00)\n");

                if (newPrice >= 1 && newPrice <= 10000)
                {
                    product.ChangePrice(newPrice);
                    priceIsAccepted = true;
                }
                else
                {
                    Console.WriteLine("Endast 1-10000 är tillåtet som pris");
                }

            }

            _produktRegister.ExportDictionary();
        }
        public void ChangeExProductName()
        {
            int searchID = UI.ReadInteger("Vilken produkt vill du ändra på? (Sök med id)\n");
            //_produktRegister.SearchByID(searchID);
            Product? product = _produktRegister.GetProductByID(searchID);
            if (product == null)
            {
                return;
            }

            string newName = UI.ReadString("Vad ska produktens nya namn vara?\n").Trim();
            newName = newName.Substring(0, 1).ToUpper() + newName.Substring(1).ToLower();
            product.ChangeName(newName);



            _produktRegister.ExportDictionary();
        }
        
    }
}
