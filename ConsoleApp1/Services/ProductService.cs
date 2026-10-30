using Kassasystem.Models;
using Kassasystem.Repos;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Kassasystem.Services
{
    public class ProductService
    {
        private readonly IProductRepo _produktRegister;

        public ProductService (IProductRepo produktregister)
        {

            _produktRegister = produktregister;
        }
        public void ChangeExProductPrice()
        {
            int searchID = UI.ReadInteger("Vilken produkt vill du ändra på? (Sök med id)\n");
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
        public Product? NewProduct()
        {
            string prodName = UI.ReadString("Vad ska varan heta?");
            if (_produktRegister.CheckIfNameExists(prodName))
            {
                Console.WriteLine("En vara finns redan med det namnet.");
                return null;
            }
            else
            {
                int prodID = _produktRegister.GenerateID();
                double prodPrice = UI.ReadDouble("Vad ska varan kosta?");
                Type prodType = Product.GetProductType();
                Product product = new(prodID, prodName, prodPrice, prodType);

                return product;
            } 
        }
        public bool ProductIsAdded(Product product)
        {
            return (_produktRegister.AddToDictionary(product));
        }
        public Product? GetProductBySearch(int id)
        {
            return _produktRegister.GetProductByID(id);
        }
    }
}

