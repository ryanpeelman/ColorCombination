using System.Collections.Generic;
using ColorCombination.Data.Entities;
using ColorCombination.Data.Enumerations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ColorCombination.Tests
{
    [TestClass]
    public class SecuritySystemTests
    {
        [TestMethod]
        public void ShouldHaveChipsDefined()
        {
            List<Chip> chips = null;

            SecuritySystem system = new SecuritySystem(SecurityColor.Blue, SecurityColor.Blue);

            Assert.IsFalse(system.CanBeUnlocked(chips));
        }

        [TestMethod]
        public void ShouldHaveAtLeastOneChip()
        {
            List<Chip> chips = new List<Chip>();

            SecuritySystem system = new SecuritySystem(SecurityColor.Blue, SecurityColor.Blue);

            Assert.IsFalse(system.CanBeUnlocked(chips));
        }

        [TestMethod]
        public void BlueLeftMarker_NoChipsWithBlueOnLeftSide_CannotBeUnlocked()
        {
            List<Chip> chips = new List<Chip>() 
            { 
                new Chip(SecurityColor.Green, SecurityColor.Blue), 
                new Chip(SecurityColor.Orange, SecurityColor.Blue), 
                new Chip(SecurityColor.Purple, SecurityColor.Blue)
            };

            SecuritySystem system = new SecuritySystem(SecurityColor.Blue, SecurityColor.Blue);

            Assert.IsFalse(system.CanBeUnlocked(chips));
        }

        [TestMethod]
        public void BlueRightMarker_NoChipsWithBlueOnRightSide_CannotBeUnlocked()
        {
            List<Chip> chips = new List<Chip>() 
            { 
                new Chip(SecurityColor.Blue, SecurityColor.Red), 
                new Chip(SecurityColor.Blue, SecurityColor.Yellow), 
                new Chip(SecurityColor.Blue, SecurityColor.Green)
            };

            SecuritySystem system = new SecuritySystem(SecurityColor.Blue, SecurityColor.Blue);

            Assert.IsFalse(system.CanBeUnlocked(chips));
        }
    }
}
