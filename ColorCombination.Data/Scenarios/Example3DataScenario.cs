using System.Collections.Generic;
using ColorCombination.Data.Entities;
using ColorCombination.Data.Enumerations;

namespace ColorCombination.Data.Scenarios
{
    public class Example3DataScenario : SecuritySystemDataScenario
    {
        public SecurityColor BeginningMarkerColor
        {
            get { return SecurityColor.Blue; }
        }

        public SecurityColor EndMarkerColor
        {
            get { return SecurityColor.Green; }
        }

        public List<Chip> Chips
        {
            get
            {
                return new List<Chip>()
                {
                    new Chip(SecurityColor.Blue, SecurityColor.Green), 
                    new Chip(SecurityColor.Blue, SecurityColor.Yellow), 
                    new Chip(SecurityColor.Green, SecurityColor.Yellow), 
                    new Chip(SecurityColor.Orange, SecurityColor.Red), 
                    new Chip(SecurityColor.Red, SecurityColor.Green), 
                    new Chip(SecurityColor.Red, SecurityColor.Orange), 
                    new Chip(SecurityColor.Yellow, SecurityColor.Blue), 
                    new Chip(SecurityColor.Yellow, SecurityColor.Red)
                };
            }
        }
    }
}
