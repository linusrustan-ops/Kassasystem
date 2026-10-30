using Kassasystem.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kassasystem.Services
{
    public class KvittoService(KvittoRegister kvittoregister)
    {
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

        public string Receipt(Nykund nykund)
        {
            
            string date = TodaysDate(true);
            string time = TodaysDate(false);
            int receiptNumber = KvittoNummer.ReceiptIndex();
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
            totalPrice += Prisberäkningar.CalculateTotal(nykund.KundLista);
            foreach (var row in nykund.KundLista)
            {
                momsPrice += Prisberäkningar.MomsTotal(row.RowPrice);
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

            return receipt;

        }

        public void CheckReceipt(string receipt)
        {
            string date = TodaysDate(true);
            if (!string.IsNullOrWhiteSpace(receipt))
            {
                kvittoregister.ExportReceipt(receipt, date);
            }
            else
            {
                Console.WriteLine("Kvittot lyckades tyvär inte skapas, kontakta Linus.");
            }
            
        }


    }
}
