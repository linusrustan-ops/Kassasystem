using System;
using System.Collections.Generic;
using System.Text;

namespace Kassasystem
{
    internal class Nykund
    {
        public List<Varukorg> KundLista = new List<Varukorg>();


        public Varukorg AddToCustomer(Product product, double quantity)
        {
            Varukorg row = new Varukorg(product, quantity);
            KundLista.Add(row);
            return row;
        }
    }
}
