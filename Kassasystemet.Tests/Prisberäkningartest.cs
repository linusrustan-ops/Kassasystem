namespace Kassasystemet.Tests_;

using Kassasystem.Services;
using Kassasystem.Models;

public class PrisberäkningarTest
{
    [Fact]
    public void MomsOnlyTest1()
    {
        double result = Prisberäkningar.MomsOnly(1000);

        Assert.Equal(250, result);
    }
    [Fact]
    public void MomsTotaltest()
    {
        double result = Prisberäkningar.MomsTotal(100);

        Assert.Equal(125, result);
    }

    [Fact]

    public void CalculateTotalTest()
    {
        Product testProduct = new(10000, "Limpan", 1, Kassasystem.Type.KG);
        Product testProduct2 = new(100, "Linus", 2, Kassasystem.Type.KG);

        Varukorg testKund = new(testProduct, 10, testProduct.Price);
        Varukorg testKund2 = new(testProduct2, 10, testProduct2.Price);

        List<Varukorg> testList = new List<Varukorg>();

        testList.Add(testKund);
        testList.Add(testKund2);

        double result = Prisberäkningar.CalculateTotal(testList);

        Assert.Equal(30, result);
    }

}

