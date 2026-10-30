using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Kassasystem.Repos
{
    public class KvittoRegister()
    {
        public void ExportReceipt(string receipt, string date)
        {
            string filename = "RECEIPT_" + date + ".txt";

            Directory.CreateDirectory("Kvitton");

            string combinedName = Path.Combine("Kvitton", filename);

            File.AppendAllText(combinedName, receipt);
        }
    }
}
