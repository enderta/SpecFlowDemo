using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.StepDefinitions
{
    internal class Regions
    {
        public class Region
        {
            public string _id { get; set; }
            public string name { get; set; }
            public string code { get; set; }
            public DateTime createdAt { get; set; }
            public DateTime updatedAt { get; set; }
            public int __v { get; set; }
        }

        public class AllRegions
        {
            public List<Region> regions { get; set; }
        }

    }
}
