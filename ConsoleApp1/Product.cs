using System;
using System.Collections.Generic;
using System.Text;

namespace Kassasystem
{
    internal class Product(int id, string name, double price, _Type type)
    {
        public int ID { get; set; } = id;
        public string Name { get; set; } = name;
        public double Price { get; set; } = price;
        public _Type Type { get; set; } = type;
        
       
    }
   

    

}
