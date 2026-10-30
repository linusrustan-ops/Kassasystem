using Kassasystem.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml.Linq;

namespace Kassasystem.Repos
{
    public class ProduktRegister : IProductRepo
    {
        private Dictionary<int, Product> varuRegister;

        public ProduktRegister()
        {
            varuRegister = FillDictionary();
        }
        


        public Dictionary<int, Product> FillDictionary()
        {
            string searchFile = "Varor.txt";
            Dictionary<int, Product> register = new Dictionary<int, Product>();

            if (File.Exists(searchFile))
                foreach (var row in File.ReadLines(searchFile))
                { 
                    string[] parts = row.Split(":");
 
                    if (parts.Length != 4 ||
                        !int.TryParse(parts[0], out int id) ||
                        !double.TryParse(parts[2], out double price) ||
                        !Enum.TryParse<Type>(parts[3], out Type type))
                    {
                        Console.WriteLine("Det finns fel i produktfilen");
                        continue;
                    }
                    string name = parts[1];
                    Product vara = new Product(id, name, price, type);
                    register[id] = vara;
                }

            return register;
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

        public void ExportDictionary()
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
                ExportDictionary();
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GenerateID()
        {
            int highestID = varuRegister.Keys.Max();
            int generatedID = (highestID + 1);
            return generatedID;
        }
        public bool CheckIfNameExists(string name)
        {
            return (varuRegister.Values.Any(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase)));
        }




    }

}



