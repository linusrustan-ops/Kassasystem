using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Kassasystem
{
    internal class Nykund
    {
        public List<Varukorg> KundLista = new List<Varukorg>();


        public Varukorg AddToCustomer(Product product, double quantity, double realPrice)
        {
            Varukorg row = new Varukorg(product, quantity, realPrice);
            KundLista.Add(row);
            return row;
        }

        public void PrintList()
        {
            foreach (var row in KundLista)
            {

                Console.WriteLine($"\n{row._Product.Name} |{row.Quantity} * {row.SinglePrice}kr/{row._Product.Type}|\n");
            }

        }
    }
}
