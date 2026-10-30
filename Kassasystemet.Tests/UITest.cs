using System;
using System.Collections.Generic;
using System.Text;
using Kassasystem;

namespace Kassasystemet.Tests_
{
    public class UITest
    {
        [Fact]

        public void TestZeroAsInput()
        {
            var normalInput = Console.In;

            var input = new StringReader("0\n5");
            Console.SetIn(input);
            int working = UI.ReadInteger("s");

            Assert.Equal(5, working);

            Console.SetIn(normalInput);
        }

        [Fact]

        public void TestNegativeNumberAsInput()
        {
            var normalInput = Console.In;

            var input = new StringReader("-5\n9.99");
            Console.SetIn(input);

            double working = UI.ReadDouble("s");

            Assert.Equal(9.99, working);

            Console.SetIn(normalInput);
        }
    }
}
