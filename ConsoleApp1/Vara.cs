using System;
using System.Collections.Generic;
using System.Text;

namespace Kassasystem
{
    internal class Vara
    {
        public int ID { get; set; }

        public bool IsAvaible { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public Type Type { get; set; }


        public Vara(int id, bool isAvaible, string name, double price, Type type)
        {
            ID = id;
            Name = name;
            Price = price;
            Type = type;
            IsAvaible = isAvaible;

        }

        Vara hej = new Vara(300, false, "gion", 3000, Type.Styck );

    }
   

    

}
