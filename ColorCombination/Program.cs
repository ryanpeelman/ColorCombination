using System;
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
            SecuritySystemDataScenario dataScenario = new Example1DataScenario();

            SecuritySystem securitySystem = new SecuritySystem(dataScenario.LeftMarker, dataScenario.RightMarker);

            if (securitySystem.CanBeUnlocked(dataScenario.Chips))
            {
                Console.WriteLine("UNLOCKED!");
            }
            else 
            {
                Console.WriteLine("Cannot unlock master panel");
            }

            Console.ReadLine();
        }        
    }
}
