using System;
using System.Collections.Generic;

namespace Contentful.Models
{
    public partial class CampaignType
    {
        public CampaignType()
        {
            CampaignConfiguration = new HashSet<CampaignConfiguration>();
        }

        public short Id { get; set; }
        public string CampaignType1 { get; set; }

        public ICollection<CampaignConfiguration> CampaignConfiguration { get; set; }
    }
}
