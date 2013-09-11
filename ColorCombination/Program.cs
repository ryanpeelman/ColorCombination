using System;
using System.Collections.Generic;
using ColorCombination.Data.Scenarios;

namespace ColorCombination
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceLoader.Load();

            List<SecuritySystemDataScenario> scenarios = new List<SecuritySystemDataScenario>()
            {
                new Example1DataScenario(), 
                new Example2DataScenario(), 
                new Example3DataScenario()
            };

            foreach (SecuritySystemDataScenario scenario in scenarios)
            {
                SecuritySystem securitySystem = new SecuritySystem(scenario.BeginningMarkerColor, scenario.EndMarkerColor);                
                Console.WriteLine(scenario.GetType().Name + ":  " + Environment.NewLine + securitySystem.GetUnlockSequenceReadout(scenario.Chips));
                Console.WriteLine();
            }

            Console.ReadLine();
        }        
    }
}
