using System;
using System.Collections.Generic;
using System.Text;

namespace Kassasystem
{
    internal class ProduktRegister
    {
        private Dictionary<int, Vara> varuRegister;

        public ProduktRegister()
        {
            varuRegister = FillDictionary();
        }
        


        public Dictionary<int, Vara> FillDictionary()
        {
            string searchFile = "Varor.txt";
            Dictionary<int, Vara> varuRegister = new Dictionary<int, Vara>();

            if (File.Exists(searchFile))
                Console.WriteLine("Filen hittades");
                foreach (var row in File.ReadLines(searchFile))
                {
                    Console.WriteLine($"Läst rad: [{row}]");
                    

                    string[] parts = row.Split(":");
                    Console.WriteLine($"Antal delar: {parts.Length}");
                    if (parts.Length >= 4)
                    {
                        int id;
                        int.TryParse(parts[0], out id);
                        string name = parts[1];
                        double price;
                        double.TryParse(parts[2], out price);
                        _Type type = (Enum.Parse<_Type>(parts[3]));


                        Vara vara = new Vara(id, name, price, type);
                        Console.WriteLine($"Antal varor inlästa: {varuRegister.Count}");
                        varuRegister[id] = vara;

                    }
                }

            return varuRegister;
        }
        public void SearchByID()
        {
            int input = UI.ReadInteger("Skriv in ID:");
            if (varuRegister.ContainsKey(input))
            {
                Console.WriteLine($"{varuRegister[input].ID} | {varuRegister[input].Name} | {varuRegister[input].Price}kr/{varuRegister[input].Type} ");
            }
        }





    }

}



