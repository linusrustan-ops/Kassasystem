using Kassasystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kassasystem.Repos
{
    public class KampanjRegister : IKampanjRepo
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
                    string[] parts = row.Split(";");
                    if (parts.Length != 4 || 
                        !int.TryParse(parts[0], out int kampanjID) ||
                        !double.TryParse(parts[1], out double campaignPrice) ||
                        !DateTime.TryParse(parts[2], out DateTime startDate) ||
                        !DateTime.TryParse(parts[3], out DateTime endDate))
                    {
                        Console.WriteLine("Radfel Finns på kampanjen");
                        continue;
                    }
                    Product? product = produktregister.GetProductByID(kampanjID);
                    if (product == null)
                    {
                        Console.WriteLine("Produkten hittades inte, kontakta support!");
                        Environment.Exit(2);
                    }
                    Kampanj kampanj = new Kampanj(product, campaignPrice, startDate, endDate);
                    kampanjRegister.Add(kampanj);
                }

            return kampanjRegister;
        }
        public void ExportList(List<Kampanj> kampanjRegister)
        {
            string searchFile = "Kampanj.txt";
            string[] rows = kampanjRegister.Select(k => $"{k.KProduct.ID};{k.KPrice};{k.StartTime};{k.EndTime}").ToArray();

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
        public bool CampaignExists(Kampanj kampanj)
        {
            return campaignRegister.Any(k => k.KPrice == kampanj.KPrice &&
            k.KProduct.ID == kampanj.KProduct.ID
            && k.EndTime == kampanj.EndTime);
        }
        public void AddCampaignToList(Kampanj kampanj)
        {
            campaignRegister.Add(kampanj);
            ExportList(campaignRegister);
        }
        public void RemoveCampaign(Kampanj kampanj)
        {
            if (campaignRegister.Contains(kampanj))
            {
                campaignRegister.Remove(kampanj);
                ExportList(campaignRegister);
            }
        }
        public IReadOnlyList<Kampanj> ShowCampaigns()
        {
            return campaignRegister.AsReadOnly();
        }
    }
}
