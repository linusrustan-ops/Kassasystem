using System;
using System.Collections.Generic;
using System.Text;
using Kassasystem.Models;
using Kassasystem.Repos;

namespace Kassasystemet.Tests_
{
    public class KampanjTest
    {
        [Fact]
        public void SearchCampaignTestNotNull()
        {
            ProduktRegister prodrepotest = new ProduktRegister();
            KampanjRegister repotest = new KampanjRegister(prodrepotest);

            Product testProduct = new Product(801, "Test0", 29.90, Kassasystem.Type.KG);
            Kampanj testKampanj0 = new Kampanj(testProduct, 39.90, DateTime.Now, DateTime.Now.AddDays(1));
            repotest.AddCampaignToList(testKampanj0);

            Kampanj? campaignExists = repotest.SearchCampaign(801);

            Assert.NotNull(campaignExists);

        }

        [Fact]

        public void CampaignNotFoundTest()
        {
            ProduktRegister prodrepotest = new();
            KampanjRegister repotest = new(prodrepotest);

            Product testProduct = new Product(802, "Test1", 28.90, Kassasystem.Type.KG);
            Kampanj testKampanj1 = new Kampanj(testProduct, 38.90, DateTime.Now, DateTime.Now.AddDays(2));

            bool working = repotest.CampaignExists(testKampanj1);
            Assert.False(working);

        }

        [Fact]
        public void CampaignfoundTest()
        {
            ProduktRegister prodrepotest = new();
            KampanjRegister repotest = new(prodrepotest);

            Product testRroduct = new Product(802, "Test2", 18.90, Kassasystem.Type.KG);
            Kampanj testKampanj2 = new Kampanj(testRroduct, 35.90, DateTime.Now, DateTime.Now.AddDays(3));

            repotest.AddCampaignToList(testKampanj2);

            bool working = repotest.CampaignExists(testKampanj2);

            Assert.True(working);
        }

        [Fact]

        public void CampaignSearchIDFound()
        {
            ProduktRegister prodrepotest = new();
            KampanjRegister repotest = new(prodrepotest);

            Product testProduct = new Product(803, "Test3", 48.90, Kassasystem.Type.KG);
            Kampanj testKampanj3 = new(testProduct, 9, DateTime.Now, DateTime.Now.AddDays(4));

            repotest.AddCampaignToList(testKampanj3);


        }
    }
}
