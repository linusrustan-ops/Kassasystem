using System;
using System.Collections.Generic;
using System.Text;
using Kassasystem.Models;
using Kassasystem.Repos;

namespace Kassasystemet.Tests_
{
    
    public class ProductRepoTest : IDisposable
    {

        public ProductRepoTest()
        {
            File.WriteAllLines("Testvaror.txt", new[] 
                {"300:Monster:14.99:Styck",
                "301:Redbull:13.99:Styck",
                "302:Lösviktsgodis:99.99:KG"});
        }
        [Fact]
        public void GetProductByIDTestNull()
        {
            ProduktRegister register = new("Testvaror.txt");

            var result = register.GetProductByID(1000);

            Assert.Null(result);
        }

        [Fact]
        public void GetProductByIDTestNotNull()
        {
            ProduktRegister register = new("Testvaror.txt");

            var result = register.GetProductByID(301);

            Assert.NotNull(result);
            Assert.Equal(301, result.ID);
        }

        [Fact]

        public void AddToDictionaryTest()
        {
            Product testProduct = new(500, "Linus", 100.01, Kassasystem.Type.KG);
            ProduktRegister register = new("Testvaror.txt");

            bool working = register.AddToDictionary(testProduct);

            Assert.True(working);
        }

        [Fact]
        public void AddDuplicateToDictionaryTest()
        {
            Product testProduct = new(500, "Linus", 100.01, Kassasystem.Type.KG);
            ProduktRegister register = new("Testvaror.txt");

            register.AddToDictionary(testProduct);

            bool working = register.AddToDictionary(testProduct);

            Assert.False(working);

        }
        public void Dispose()
        {
            if (File.Exists("Testvaror.txt"))
            {
                File.Delete("Testvaror.txt");
            }
        }
    }
}
