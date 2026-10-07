using System;
using System.Collections.Generic;
using System.Text;

namespace Kassasystem
{
    internal class Prisberäkningar
    {
        

        public static double MomsCalc()
        {
            double pris = 1; //temporär

            double moms = 0.25;

            double momsPris = pris * (moms + 1);
            return momsPris;
        }

        public static double DicountCustomer()
        {
            double pris = 1; //temporär

            double discount = 0.75; //25% rabatt

            double discountPrice = pris * discount;

            return discountPrice;
        }
    }
}
