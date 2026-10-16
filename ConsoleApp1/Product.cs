using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Kassasystem
{
    internal class Product(int id, string name, double price, _Type type)
    {
        public int ID { get; set; } = id;
        public string Name { get; set; } = name;
        public double Price { get; set; } = price;
        public _Type Type { get; set; } = type;


        public string GetProductName()
        {
            string productName = UI.ReadString("Vad ska produkten heta?");
            return productName;
        }

        public int GetProductID()
        {
            int productID = UI.ReadInteger("Vad är produktens ID?");
            return productID;
        }

        public double GetProductPrice()
        {
            double productPrice = UI.ReadDecimal("Vad är produktens pris?");
            return productPrice;
        }

        public _Type GetProductType()
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
            return productType;
        }

    }

        
   

    

}
