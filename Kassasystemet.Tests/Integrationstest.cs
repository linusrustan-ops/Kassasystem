using Kassasystem.Repos;
using Kassasystem.Services;
using Kassasystem.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace Kassasystemet.Tests_
{
    public class Integrationstest
    {
        [Fact]
        public void IntegrationsTestCampaign()
        {
            File.WriteAllLines("Testkampanj.txt", new[] { "999;25;2026-05-06;2026-12-30" });
            File.WriteAllLines("Testvaror.txt", new[] { "999:Päron:50:KG" });

            ProduktRegister produktregister = new("TestVaror.txt");
            KampanjRegister kampanjregister = new(produktregister, "Testkampanj.txt");
            ProductService productservice = new(produktregister);
            KampanjService kampanjservice = new(kampanjregister, produktregister);
            Nykund nykund = new();

            Product? testproduct = productservice.GetProductBySearch(999);

            Assert.NotNull(testproduct);

            Kampanj? testcampaign = kampanjservice.GetActiveCampaign(testproduct.ID);

            Assert.NotNull(testcampaign);
            
            nykund.AddToCustomer(testproduct, 10, testcampaign.KPrice);
            
            Varukorg row = nykund.KundLista[0];

            Assert.Single(nykund.KundLista);
            Assert.Equal(10, row.Quantity);
            Assert.Equal(testcampaign.KPrice, row.SinglePrice);
            Assert.Equal(250, row.RowPrice);
            



        }

    }
}
