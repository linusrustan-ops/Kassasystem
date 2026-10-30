using Kassasystem.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Kassasystem.Repos
{
    public class Nykund
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

                Console.WriteLine($"\n{row._Product.Name} | {row.Quantity} * {row.SinglePrice}kr/{row._Product.Type}|\n");
            }

        }
        public (int, double) GetIDAndQuantity()
        {
            double quantity;
            int id;

            while (true)
            {

                string both = UI.ReadString("Vilket id och hur många? skriv \"ID (mellanrum) mängd\" ");
                string[] array = both.Split(" ");

                if (array.Length != 2 || !int.TryParse(array[0], out id) || !double.TryParse(array[1], out quantity))
                {
                    Console.WriteLine("Ogiltigt skrivet, det ska vara: \"ID (mellanrum) mängd\"");
                    continue;
                }
                else if (id <= 0 || quantity <= 0)
                {
                    Console.WriteLine("ID och mängd måste vara positiva tal.");
                    continue; 
                }
                else
                {
                    break;
                }
            }
            return (id, quantity);



        }
    }
}

