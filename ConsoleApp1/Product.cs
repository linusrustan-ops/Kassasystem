using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Kassasystem
{
    public class Product(int id, string name, double price, Type type)
    {
        public int ID { get; } = id; 
        public string Name { get; private set; } = name;
        public double Price { get; private set; } = price;
        public Type Type { get; private set; } = type;


        public void ChangeName(string productName)
        {
            Name = productName;
            
        }

        public void ChangePrice(double newPrice)
        {
            Price = newPrice;
            
        }

        public static Type GetProductType()
        {
            while (true)
            {


                string Choice = UI.ReadString("Vilken typ har varan:" +
                    "[1]. Styckvis" +
                    "[2]. Kilogram");

                switch (Choice)
                {
                    case "1":
                        return Type.Styck;
                        

                    case "2":
                        return Type.KG;
                        

                    default:
                        Console.WriteLine("Ogiltigt svar, försök igen!");
                        break;
                }
            }
            
        }

    }

        
   

    

}
