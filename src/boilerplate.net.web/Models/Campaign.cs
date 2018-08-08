using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contentful.Models
{
    public class Campaign
    {
        public string title { get; set; }
        public string campaignOwner { get; set; }
        public string pathForPhoto { get; set; }
        public string content { get; set; }
    }
}
