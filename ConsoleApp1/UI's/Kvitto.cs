using Kassasystem.Repos;
using Kassasystem.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kassasystem
{
    public class Kvitto()
    {
        public void CreateFile(string name, string text)
        {
            Directory.CreateDirectory("Kvitton");

            string combinedName = Path.Combine("Kvitton", name);

            File.AppendAllText(combinedName, text);
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
                string receiptTime = dateAndTime.ToString("HH:mm");
                return receiptTime;
            }
        }

        public void Receipt(Nykund nykund)
        {
            
            string date = TodaysDate(true);
            string time = TodaysDate(false);
            int receiptNumber = KvittoNummer.ReceiptIndex();
            string filename = "RECEIPT_" + date + ".txt";
            double totalPrice = 0;
            double momsPrice = 0;
            string receipt = $"""
                ==============================================
                ============== Linus Hälsobutik ==============
                ==============================================

                Kvitto.nr:{receiptNumber}
                Datum:{date}
                Tid:{time}
         
                ----------------------------------------------

                Produkt            Antal     À-Pris     Summa
                ----------------------------------------------
                """;
            foreach (var row in nykund.KundLista)
            {
                momsPrice += Prisberäkningar.MomsTotal(row.RowPrice);
                totalPrice += row.RowPrice;
                receipt += $"\n" +
                    $"{row._Product.Name,-16}" +
                    $"{row.Quantity,7:F2}" +
                    $"{row.SinglePrice,11:F2}" +
                    $"{row.RowPrice,12:F2}";
                    

            }

            receipt += $"""

                ----------------------------------------------
                {"Total Netto:",-34} {totalPrice,8:F2}kr
                {"Total Brutto:",-34} {momsPrice,8:F2}kr
                {"Varav Moms:", -34}  {Prisberäkningar.MomsOnly(totalPrice)}
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
