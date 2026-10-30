using Kassasystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kassasystem.Repos
{
    public interface IKampanjRepo
    {
        IReadOnlyList<Kampanj> ShowCampaigns();
        public void AddCampaignToList(Kampanj kampanj);
        public bool CampaignExists(Kampanj kampanj);
        public void RemoveCampaign(Kampanj kampanj);

    }
}
