using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.StepDefinitions
{
    internal class CitiesObj
    {
        public class City
        {
            public string _id { get; set; }
            public string name { get; set; }
            public string email { get; set; }
            public string slackChannel { get; set; }
            public string slackChannelId { get; set; }
            public DateTime createdAt { get; set; }
            public DateTime updatedAt { get; set; }
            public int __v { get; set; }
            public List<string> visibleIn { get; set; }
            public string regionId { get; set; }
            public string location { get; set; }
        }

        public class Root
        {
            public List<City> cities { get; set; }
            public bool cached { get; set; }
        }

    }
}
