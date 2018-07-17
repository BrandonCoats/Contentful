using System;
using System.Collections.Generic;

namespace Contentful.Models
{
    public partial class CampaignConfiguration
    {
        public int Id { get; set; }
        public short CampaignTypeId { get; set; }
        public string Keyword { get; set; }

        public CampaignType CampaignType { get; set; }
    }
}
