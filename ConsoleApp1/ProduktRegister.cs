using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml.Linq;

namespace Kassasystem
{
    internal class ProduktRegister
    {
        private Dictionary<int, Product> varuRegister;

        public ProduktRegister()
        {
            varuRegister = FillDictionary();
        }
        


        public Dictionary<int, Product> FillDictionary()
        {
            string searchFile = "Varor.txt";
            Dictionary<int, Product> varuRegister = new Dictionary<int, Product>();

            if (File.Exists(searchFile))
                foreach (var row in File.ReadLines(searchFile))
                { 
                    string[] parts = row.Split(":");
 
                    if (parts.Length != 4 ||
                        !int.TryParse(parts[0], out int id) ||
                        !double.TryParse(parts[2], out double price) ||
                        !Enum.TryParse<_Type>(parts[3], out _Type type))
                    {
                        Console.WriteLine("Det finns fel i produktfilen");
                        continue;
                    }
                    string name = parts[1];
                    Product vara = new Product(id, name, price, type);
                    varuRegister[id] = vara;
                }

            return varuRegister;
        }
        public void SearchByID(int input)
        {
            
            if (varuRegister.ContainsKey(input))
            {
                Console.WriteLine($"{varuRegister[input].ID} | {varuRegister[input].Name} | {varuRegister[input].Price}kr/{varuRegister[input].Type} ");
            }
            else
            {
                Console.WriteLine("Varan hittades inte");
            }
        }
        public Product? GetProductByID(int ID)
        {
            if (varuRegister.TryGetValue(ID, out Product? product))
            {
                return product;
            }
            return null;
        }

        public void ExportDictionary(Dictionary<int, Product> varuRegister)
        {
            string searchFile = "Varor.txt";
            string[] rows = varuRegister.Values.Select(p => $"{p.ID}:{p.Name}:{p.Price}:{p.Type}").ToArray();

            File.WriteAllLines(searchFile, rows);
        }

        public bool AddToDictionary(Product product)
        {
            bool publish = varuRegister.TryAdd(product.ID, product); 

            if (publish)
            {
                ExportDictionary(varuRegister);
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ChangeExProductName()
        {
            int searchID = UI.ReadInteger("Vilken produkt vill du ändra på? (Sök med id)\n");
            SearchByID(searchID);
            Product? product = GetProductByID(searchID);
            if (product == null)
            {
                return;
            }

            string newName = UI.ReadString("Vad ska produktens nya namn vara?\n").Trim();
            newName = newName.Substring(0, 1).ToUpper() + newName.Substring(1).ToLower();
            product.ChangeName(newName);



            ExportDictionary(varuRegister);
        }

        public void ChangeExProductPrice()
        {
            int searchID = UI.ReadInteger("Vilken produkt vill du ändra på? (Sök med id)\n");
            SearchByID(searchID);
            Product? product = GetProductByID(searchID);
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

            ExportDictionary(varuRegister);
        }

        public int GenerateID()
        {
            int highestID = varuRegister.Keys.Max();
            int generatedID = (highestID + 1);
            return generatedID;
        }




    }

}



