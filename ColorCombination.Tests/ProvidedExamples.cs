using System;
using ColorCombination.Data.Scenarios;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ColorCombination.Tests
{
    [TestClass]
    public class ProvidedExamples
    {
        [TestMethod]
        public void Example1()
        {
            SecuritySystemDataScenario scenario = new Example1DataScenario();

            SecuritySystem system = new SecuritySystem(scenario.LeftMarker, scenario.RightMarker);

            Assert.IsFalse(system.CanBeUnlocked(scenario.Chips));
        }

        [TestMethod]
        public void Example2()
        {
            SecuritySystemDataScenario scenario = new Example2DataScenario();

            SecuritySystem system = new SecuritySystem(scenario.LeftMarker, scenario.RightMarker);

            Assert.IsTrue(system.CanBeUnlocked(scenario.Chips));
        }

        [TestMethod]
        public void Example3()
        {
            SecuritySystemDataScenario scenario = new Example3DataScenario();

            SecuritySystem system = new SecuritySystem(scenario.LeftMarker, scenario.RightMarker);

            Assert.IsTrue(system.CanBeUnlocked(scenario.Chips));
        }
    }
}
