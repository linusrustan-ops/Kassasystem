using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Kassasystem
{
    internal class Product(int id, string name, double price, _Type type)
    {
        public int ID { get; } = id; //behöver aldrig ändras
        public string Name { get; private set; } = name;
        public double Price { get; private set; } = price;
        public _Type Type { get; private set; } = type;


        public void GetProductName(string productName)
        {
            Name = productName;
            
        }

        public void GetProductPrice(double newPrice)
        {
            Price = newPrice;
            
        }

        public static _Type GetProductType()
        {
            while (true)
            {


                string Choice = UI.ReadString("Vilken typ har varan:" +
                    "[1]. Styckvis" +
                    "[2]. Kilogram");

                switch (Choice)
                {
                    case "1":
                        return _Type.Styck;
                        

                    case "2":
                        return _Type.KG;
                        

                    default:
                        Console.WriteLine("Ogiltigt svar, försök igen!");
                        break;
                }
            }
            
        }

    }

        
   

    

}
