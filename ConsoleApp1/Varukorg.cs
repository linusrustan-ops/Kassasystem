using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace Kassasystem
{
    internal class Varukorg(Product product, double quantity)
    {
        public Product _Product { get; } = product;
        public double Quantity { get; } = quantity;
        public double SinglePrice { get; } = product.Price;
        public double RowPrice => Quantity * SinglePrice;

        
    }
    
    

}
       