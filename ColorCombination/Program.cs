﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorCombination.Data.Scenarios;

namespace ColorCombination
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<SecuritySystemDataScenario> scenarios = new List<SecuritySystemDataScenario>()
            {
                new Example1DataScenario(), 
                new Example2DataScenario(), 
                new Example3DataScenario()
            };

            foreach (SecuritySystemDataScenario scenario in scenarios)
            {
                Console.Write(scenario.GetType().Name + ":  ");

                SecuritySystem securitySystem = new SecuritySystem(scenario.LeftMarker, scenario.RightMarker);

                if (securitySystem.CanBeUnlocked(scenario.Chips))
                {
                    Console.WriteLine(securitySystem.UnlockSequence);
                }
                else
                {
                    Console.WriteLine("Cannot unlock master panel");
                }
            }

            Console.ReadLine();
        }        
    }
}
