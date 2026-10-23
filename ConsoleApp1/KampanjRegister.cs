using System;
using System.Collections.Generic;
using System.Text;

namespace Kassasystem
{
    internal class KampanjRegister
    {
        private readonly ProduktRegister produktregister;
        private List<Kampanj> campaignRegister;
        
        public KampanjRegister(ProduktRegister produktregister)
        {
            this.produktregister = produktregister;
            this.campaignRegister = FillCampaignList();
        }



        public List<Kampanj> FillCampaignList()
        {
            string searchFile = "Kampanj.txt";
            List<Kampanj> kampanjRegister = new List<Kampanj>();

            if (File.Exists(searchFile))
                foreach (var row in File.ReadLines(searchFile))
                {
                    string[] parts = row.Split(":");
                    if (parts.Length >= 4)
                    {
                        int kampanjID;
                        int.TryParse(parts[0], out kampanjID);

                        double campaignPrice;
                        double.TryParse(parts[1], out campaignPrice);

                        DateTime startDate;
                        DateTime.TryParse(parts[2], out startDate);

                        DateTime endDate;
                        DateTime.TryParse(parts[3], out endDate);

                        Product product = produktregister.GetProductByID(kampanjID);
                        Kampanj kampanj = new Kampanj(product, campaignPrice, startDate, endDate);
                        kampanjRegister.Add(kampanj);
                       

                    }
                }

            return kampanjRegister;
        }
        public void ExportList(List<Kampanj> kampanjRegister)
        {
            string searchFile = "Kampanj.txt";
            string[] rows = kampanjRegister.Select(k => $"{k.KProduct.ID}:{k.KPrice}:{k.StartTime}:{k.EndTime}").ToArray();

            File.WriteAllLines(searchFile, rows);
        }

        public Kampanj? SearchCampaign(int searchID)
        {
            Kampanj? campaign = campaignRegister.Where(c => c.KProduct.ID == searchID 
            && c.StartTime <= DateTime.Now 
            && c.EndTime >= DateTime.Now).
            OrderBy(c => c.KPrice).FirstOrDefault();

            return campaign;
            
        }
    }
}
