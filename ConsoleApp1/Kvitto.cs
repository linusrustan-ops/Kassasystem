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

        public void CreateFile(string name, string text)
        {
            Directory.CreateDirectory("Kvitton");

            string combinedName = Path.Combine("Kvitton", name);

            File.AppendAllText(combinedName, text);
        }
    }
}
