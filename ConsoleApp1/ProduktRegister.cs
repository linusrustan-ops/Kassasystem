using System;
using System.Collections.Generic;
using System.Text;

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
                    if (parts.Length >= 4)
                    {
                        int id;
                        int.TryParse(parts[0], out id);
                        string name = parts[1];
                        double price;
                        double.TryParse(parts[2], out price);
                        _Type type = (Enum.Parse<_Type>(parts[3]));


                        Product vara = new Product(id, name, price, type);
                        varuRegister[id] = vara;

                    }
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





    }

}



