using System;
using System.Collections.Generic;
using ColorCombination.Entities;
using ColorCombination.Enumerations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ColorCombination.Tests
{
    [TestClass]
    public class BaseAssumptions
    {
        [TestMethod]
        public void ShouldHaveLeftMarkerDefined()
        {
            Marker leftMarker = null;
            Marker rightMarker = new Marker(SecurityColor.Blue);
            List<Chip> chips = new List<Chip>() { new Chip(SecurityColor.Blue, SecurityColor.Blue) };

            SecuritySystem system = new SecuritySystem(leftMarker, rightMarker);
            
            Assert.IsFalse(system.CanBeUnlocked(chips));        
        }

        [TestMethod]
        public void ShouldHaveRightMarkerDefined()
        {
            Marker leftMarker = new Marker(SecurityColor.Blue);
            Marker rightMarker = null;
            List<Chip> chips = new List<Chip>() { new Chip(SecurityColor.Blue, SecurityColor.Blue) };

            SecuritySystem system = new SecuritySystem(leftMarker, rightMarker);

            Assert.IsFalse(system.CanBeUnlocked(chips));
        }

        [TestMethod]
        public void ShouldHaveChipsDefined()
        {
            Marker leftMarker = new Marker(SecurityColor.Blue);
            Marker rightMarker = new Marker(SecurityColor.Blue);
            List<Chip> chips = null;

            SecuritySystem system = new SecuritySystem(leftMarker, rightMarker);

            Assert.IsFalse(system.CanBeUnlocked(chips));
        }

        [TestMethod]
        public void ShouldHaveAtLeastOneChip()
        {
            Marker leftMarker = new Marker(SecurityColor.Blue);
            Marker rightMarker = new Marker(SecurityColor.Blue);
            List<Chip> chips = new List<Chip>();

            SecuritySystem system = new SecuritySystem(leftMarker, rightMarker);

            Assert.IsFalse(system.CanBeUnlocked(chips));
        }
    }
}
