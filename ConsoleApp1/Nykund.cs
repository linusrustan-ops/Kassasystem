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

                Console.WriteLine($"\n{row._Product.Name} |{row.Quantity} * {row.SinglePrice}kr/{row._Product.Type}|\n");
            }

        }
        public string TodaysDate(bool dateOrTime)
        {
            DateTime dateAndTime = DateTime.Now;

            if (dateOrTime == true)
            {
                string receiptDate = dateAndTime.ToString("yyyy-MM-dd");
                return receiptDate;
            }
            else
            {
                string receiptTime = dateAndTime.ToString("HH: mm");
                return receiptTime;
            }
           

            
            
        }

        public void Receipt()
        {
            string date = TodaysDate(true);
            string time = TodaysDate(false);
            string filename ="Receipt_" + date + ".txt";
            double totalPrice = 0;
            string receipt = ($"""
                ==============================================
                ============== Linus Hälsobutik ==============
                ==============================================

                Datum:{date}
                Tid:{time}
         
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
                {"Total:",-34} {totalPrice,8:F2}kr

                ==============================================
                               VÄLKOMMEN ÅTER!


                """;


            
            Console.WriteLine(receipt);

            Directory.CreateDirectory("Kvitton");

            string combinedName = Path.Combine("Kvitton", filename);

            File.AppendAllText(combinedName, receipt);


        }
        
    }
}
