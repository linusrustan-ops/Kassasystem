using System;
using System.Collections.Generic;
using System.Text;

namespace Kassasystem.Services
{
    public class KvittoNummer
    {
        public static int ReceiptIndex()
        {
            string fileCheck = "ReceiptNumber.txt";
            if (File.Exists(fileCheck) == false)
            {
                File.AppendAllText(fileCheck, 999.ToString() + Environment.NewLine);
            }
            else if(File.Exists(fileCheck) && !File.ReadLines(fileCheck).Any())
            {
                File.AppendAllText(fileCheck, 999.ToString() + Environment.NewLine);
            }
            int nextNumber = File.ReadLines(fileCheck).Max(int.Parse) + 1;
            File.AppendAllText(fileCheck, nextNumber.ToString() + Environment.NewLine);
            return nextNumber;
        }
    }
}
