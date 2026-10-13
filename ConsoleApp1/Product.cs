using System;
using System.Collections.Generic;
using System.Text;

namespace Kassasystem
{
    internal class Product(int id, string name, double price, _Type type/*, bool isAvaible*/)
    {
        public int ID { get; set; } = id;
        public string Name { get; set; } = name;
        public double Price { get; set; } = price;
        public _Type Type { get; set; } = type;
        //public bool IsAvaible { get; set; } = isAvaible;


       
    }
   

    

}
