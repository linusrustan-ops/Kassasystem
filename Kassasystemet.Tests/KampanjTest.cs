using System;
using System.Collections.Generic;
using System.Text;
using Kassasystem;

namespace Kassasystemet.Tests_
{
    public class KampanjTest
    {
        [Fact]
        public void SearchCampaignTestNotNull()
        {
            ProduktRegister prodrepotest = new ProduktRegister();
            KampanjRegister repotest = new KampanjRegister(prodrepotest);

            Product testproduct = new Product(801, "Test0", 29.90, Kassasystem.Type.KG);
            Kampanj testKampanj = new Kampanj(testproduct, 30.50, DateTime.Now, DateTime.Now.AddDays(1));
            bool working = repotest.AddCampaignToList(testKampanj);
            Console.WriteLine(working);

            Kampanj? campaignExists = repotest.SearchCampaign(801);

            Assert.NotNull(campaignExists);

        }

    }
}
