using System;
using System.Collections.Generic;
using System.Text;

namespace Kassasystem
{
    internal class Kvitto
    {
        public static string TodaysDate()
        {
            DateTime today = DateTime.Today;

            string receiptDate = today.ToString("yyyy-MM-dd");

            return receiptDate;
        }
    }
}
