using System;
using System.Collections.Generic;
using System.Text;



namespace Kassasystem
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

        public double CalculateTotal(double a, double b)
        {
            double total = a * b;
            return total;
        }
    }
}
