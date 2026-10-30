using System;
using System.Collections.Generic;
using System.Text;
using Kassasystem.Models;
using Kassasystem.Repos;

namespace Kassasystemet.Tests_
{
    public class KampanjTest : IDisposable
    {
        public KampanjTest()
        {
            File.WriteAllLines("Testkampanj.txt", new[] {"999;25;2026-05-06;2026-12-30"});
        }
        [Fact]
        public void SearchCampaignTestNotNull()
        {
            ProduktRegister prodrepotest = new ProduktRegister("Testvaror.txt");
            KampanjRegister repotest = new KampanjRegister(prodrepotest, "Testkampanj.txt");

            Product testProduct = new(801, "Test0", 29.90, Kassasystem.Type.KG);
            Kampanj testKampanj0 = new(testProduct, 39.90, DateTime.Now, DateTime.Now.AddDays(1));
            repotest.AddCampaignToList(testKampanj0);

            Kampanj? campaignExists = repotest.SearchCampaign(801);

            Assert.NotNull(campaignExists);

        }

        [Fact]

        public void CampaignNotFoundTest()
        {
            ProduktRegister prodrepotest = new("Testvaror.txt");
            KampanjRegister repotest = new(prodrepotest, "Testkampanj.txt");

            Product testProduct = new(802, "Test1", 28.90, Kassasystem.Type.KG);
            Kampanj testKampanj1 = new(testProduct, 38.90, DateTime.Now, DateTime.Now.AddDays(2));

            bool working = repotest.CampaignExists(testKampanj1);
            Assert.False(working);

        }

        [Fact]
        public void CampaignfoundTest()
        {
            ProduktRegister prodrepotest = new("Testvaror.txt");
            KampanjRegister repotest = new(prodrepotest, "Testkampanj.txt");

            Product testRroduct = new(802, "Test2", 18.90, Kassasystem.Type.KG);
            Kampanj testKampanj2 = new(testRroduct, 35.90, DateTime.Now, DateTime.Now.AddDays(3));

            repotest.AddCampaignToList(testKampanj2);

            bool working = repotest.CampaignExists(testKampanj2);

            Assert.True(working);
        }

        [Fact]

        public void CampaignSearchIDFound()
        {
            ProduktRegister prodrepotest = new("Testvaror.txt");
            KampanjRegister repotest = new(prodrepotest, "Testkampanj.txt");

            Product testProduct = new(803, "Test3", 48.90, Kassasystem.Type.KG);
            Kampanj testKampanj3 = new(testProduct, 9, DateTime.Now, DateTime.Now.AddDays(4));

            repotest.AddCampaignToList(testKampanj3);

            Kampanj? isTheSame = repotest.SearchCampaign(testKampanj3.KProduct.ID);

            Assert.NotNull(isTheSame);


        }

        [Fact]

        public void CampaignSearchIDNotFound()
        {
            ProduktRegister prodrepotest = new("Testvaror.txt");
            KampanjRegister repotest = new(prodrepotest, "Testkampanj.txt");

            Product testProduct = new(803, "Test3", 48.90, Kassasystem.Type.KG);
            

            Kampanj? isTheSame = repotest.SearchCampaign(803);

            Assert.Null(isTheSame);


        }
        public void Dispose()
        {
            if (File.Exists("Testkampanj.txt"))
            {
                File.Delete("Testkampanj.txt");
            }
        }
    }
}
