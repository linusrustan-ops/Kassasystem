using System;
using System.Collections.Generic;
using System.Text;
using Kassasystem;

namespace Kassasystemet.Tests_
{
    public class VarukorgsTest
    {
        [Fact]
        public void CorrectPriceTest()
        {
            Product testproduct = new Product(800, "Linus", 300.50, Kassasystem.Type.Styck);
            Varukorg varkorgstest = new Varukorg(testproduct, 10, testproduct.Price);

            Assert.Equal(3005, varkorgstest.RowPrice);
            Assert.Equal(300.50, varkorgstest.SinglePrice);
        }
    }
}
