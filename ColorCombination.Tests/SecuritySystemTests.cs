using System;
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
        public void BlueLeftMarker_NoChipsWithBlueOnLeftSide_CannotBeUnlocked()
        {
            Marker leftMarker = new Marker(SecurityColor.Blue);
            Marker rightMarker = new Marker(SecurityColor.Blue);
            List<Chip> chips = new List<Chip>() 
            { 
                new Chip(SecurityColor.Green, rightMarker.Color), 
                new Chip(SecurityColor.Orange, rightMarker.Color), 
                new Chip(SecurityColor.Purple, rightMarker.Color)
            };

            SecuritySystem system = new SecuritySystem(leftMarker, rightMarker);

            Assert.IsFalse(system.CanBeUnlocked(chips));
        }

        [TestMethod]
        public void BlueRightMarker_NoChipsWithBlueOnRightSide_CannotBeUnlocked()
        {
            Marker leftMarker = new Marker(SecurityColor.Blue);
            Marker rightMarker = new Marker(SecurityColor.Blue);
            List<Chip> chips = new List<Chip>() 
            { 
                new Chip(leftMarker.Color, SecurityColor.Red), 
                new Chip(leftMarker.Color, SecurityColor.Yellow), 
                new Chip(leftMarker.Color, SecurityColor.Green)
            };

            SecuritySystem system = new SecuritySystem(leftMarker, rightMarker);

            Assert.IsFalse(system.CanBeUnlocked(chips));
        }
    }
}
