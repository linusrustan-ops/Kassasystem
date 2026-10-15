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

        public void PrintList()
        {
            foreach (var row in KundLista)
            {

                Console.WriteLine($"\n{row._Product.Name}{row.RowPrice}{row.SinglePrice}{row._Product.Type}{row.Quantity}\n");
            }

        }
        public string TodaysDate()
        {
            DateTime dateAndTime = DateTime.Now;


            string receiptDate = dateAndTime.ToString("yyyy-MM-dd" + " HH:mm | UTC zz");

            return receiptDate;
        }

        public void Receipt()
        {
            string datum = TodaysDate();
            double totalPrice = 0;
            string receipt = ($"""
                ==============================================
                ============== Linus Hälsobutik ==============
                ==============================================

                Kvittonummer:
                Datum:{datum}
         
                ----------------------------------------------

                Produkt            Antal     À-Pris     Summa
                ----------------------------------------------
                """);
            foreach (var row in KundLista)
            {
                totalPrice += row.RowPrice;
                receipt += $"\n" +
                    $"{row._Product.Name, -16}" +
                    $"{row.Quantity, 7:F2}" +
                    $"{row.SinglePrice, 11:F2}" +
                    $"{row.RowPrice, 12:F2}";
                
            }

            receipt += $"""

                ----------------------------------------------
                $"{"Total:",-34} {totalPrice,8:F2}kr";

                ==============================================
                               VÄLKOMMEN ÅTER!
                """;
                
                

            Console.WriteLine(receipt);
            
        }
    }
}
