using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Kassasystem.Models;



namespace Kassasystem.Services
{
    public class Prisberäkningar
    {
        public static double MomsOnly(double price)
        {
            double moms = 0.25;

            double momsOnly = price * moms; 
            return momsOnly;
        }


        public static double MomsTotal(double price)
        {
            double moms = 0.25;

            double momsTotal = price * (moms + 1);
            return momsTotal;
        }

        public static double CalculateTotal(List<Varukorg> items)
        {
            double total = 0;

            foreach (Varukorg price in items)
            {
                total += price.RowPrice;
            }
            return total;
        }
    }
}
