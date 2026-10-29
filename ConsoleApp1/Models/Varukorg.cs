using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace Kassasystem
{
    public class Varukorg(Product product, double quantity, double realPrice)
    {
        public Product _Product { get; private set; } = product;
        public double Quantity { get; } = quantity;
        public double SinglePrice => realPrice;
        public double RowPrice => Quantity * SinglePrice;

    }
}
       