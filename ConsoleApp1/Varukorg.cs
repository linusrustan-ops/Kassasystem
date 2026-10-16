using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace Kassasystem
{
    internal class Varukorg(Product product, double quantity)
    {
        public Product _Product { get; private set; } = product;
        public double Quantity { get; private set; } = quantity;
        public double SinglePrice => _Product.Price;
        public double RowPrice => Quantity * SinglePrice;

        
    

    public double HowMany()
        {
           quantity = UI.ReadDouble("Hur Mycket/Många vill du ha?");

            return quantity;
        }

    }


}
       