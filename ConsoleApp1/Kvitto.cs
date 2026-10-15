using System;
using System.Collections.Generic;
using System.Text;

namespace Kassasystem
{
    internal class Kvitto
    {
        public string TodaysDate()
        {
            DateTime dateAndTime = DateTime.Now;


            string receiptDate = dateAndTime.ToString("yyyy-MM-dd" + " HH:mm | UTC zz");

            return receiptDate;
        }

        public void ReceiptLol()
        {
            string datum = TodaysDate();
            Console.WriteLine($"""
                ======================================
                ========== Linus Hälsobutik ==========
                ======================================

                Kvittonummer:
                Datum:{datum}
                Kassa: 29
                ======================================
                ======================================
                Produkter: 
                """);
        }
    }
}
