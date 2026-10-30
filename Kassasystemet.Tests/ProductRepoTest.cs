using System;
using System.Collections.Generic;
using System.Text;
using Kassasystem.Repos;

namespace Kassasystemet.Tests_
{
    
    public class ProductRepoTest
    {
        [Fact]
        public void GetProductByIDTestNull()
        {
            ProduktRegister register = new Kassasystem.ProduktRegister();

            var result = register.GetProductByID(1000);

            Assert.Null(result);
        }

        [Fact]
        public void GetProductByIDTestNotNull()
        {
            ProduktRegister register = new Kassasystem.ProduktRegister();

            var result = register.GetProductByID(301);

            Assert.NotNull(result);
            Assert.Equal(301, result.ID);
        }
    }
}
