namespace Kassasystemet.Tests_;

using Kassasystem.Services;

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
    }

