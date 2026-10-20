using System;
using System.Collections.Generic;
using System.Text;

namespace Kassasystem
{
    internal class Kampanj(Product kProduct, double kPrice, DateTime startTime, DateTime endTime)
    {
        public Product KProduct { get; } = kProduct;
        public double KPrice { get; } = kPrice;
        public DateTime StartTime { get; } = startTime;
        public DateTime EndTime { get; } = endTime;


        
    }
}