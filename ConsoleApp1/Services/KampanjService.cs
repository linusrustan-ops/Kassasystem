using Kassasystem.Models;
using Kassasystem.Repos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Kassasystem.Services
{
    public class KampanjService
    {
        private readonly IKampanjRepo _kampanjRegister;
        private readonly IProductRepo _produktRegister;

        public KampanjService(IKampanjRepo kampanjregister, IProductRepo produktregister)
        {
            _kampanjRegister = kampanjregister;
            _produktRegister = produktregister;

        }
        public Kampanj CreateKampanj()
        {

            Product? product = null;
            while (product == null)
            {
                int userInputID = UI.ReadInteger("Vilken produkt ska kampanjen skapas på?");
                product = _produktRegister.GetProductByID(userInputID);

                if (product == null)
                {
                    Console.WriteLine("Produkten hittades tyvärr inte, försök igen.");
                }

            }
            double campaignPrice;
            Console.WriteLine($"Nuvarandet priset på {product.Name} är: {product.Price}kr");
            while (true)
            {
                campaignPrice = UI.ReadDouble("Vad ska Kampanjpriset vara?");
                if (campaignPrice > 0 && campaignPrice < product.Price)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Priset måste vara högre än 0 och mindre än nuvarande priset.");
                }
            }
            DateTime startDate = DateTime.Now;

            DateTime endDate;
            while (true)
            {
                int inputDays = UI.ReadInteger("Hur många dagar ska kampanjen vara? (1-14 dagar)");

                if (inputDays > 0 && inputDays <= 14)
                {
                    endDate = startDate.AddDays(inputDays);
                    Console.WriteLine("Kampanjen har skapats!");
                    break;
                }
                else
                {
                    Console.WriteLine("Du måste välja mellan 1-14 dagar!");
                }

            }

            Kampanj newCampaign = new(product, campaignPrice, startDate, endDate);

            return newCampaign;
        }

        public bool CheckCampaign(Kampanj kampanj)
        {
            if (!_kampanjRegister.CampaignExists(kampanj))
            {
                _kampanjRegister.AddCampaignToList(kampanj);
                return true;
            }
            else
            {
                return false;
            }

        }
        public void RemoveACampaign()
        {
            while (true)
            {
                IReadOnlyList<Kampanj> campaigns = _kampanjRegister.ShowCampaigns();
                int index = 1;
                foreach (var c in campaigns)
                {
                    Console.WriteLine($"{index}.{c}");
                    index++;
                }
                int input = UI.ReadInteger("0. Avsluta \n Vilken kampanj vill du ta bort?");

                if (input == 0)
                {
                    break;
                }
                else if (input >= 1 &&  input <= campaigns.Count)
                {
                    Kampanj? selectedCampaign = campaigns[input - 1];
                    _kampanjRegister.RemoveCampaign(selectedCampaign);
                    Console.WriteLine("Vald kampanj är borttagen.");
                    break;
                }
                else
                {
                    Console.WriteLine("Ogiltigt val.");
                    continue;
                }
            }

            
        }
        public Kampanj? GetActiveCampaign(int id)
        {
            return _kampanjRegister.SearchCampaign(id);
        }
    }
}
