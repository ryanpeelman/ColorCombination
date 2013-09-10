using System.Collections.Generic;
using ColorCombination.Data.Entities;
using ColorCombination.Data.Enumerations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ColorCombination.Tests
{
    [TestClass]
    public class ChipChainerTests
    {
        [TestMethod]
        public void NoChainPossibleReturnsEmptyList()
        {
            Chip firstChip = new Chip(SecurityColor.Blue, SecurityColor.Green);
            List<Chip> remainingChips = new List<Chip>()
            {
                new Chip(SecurityColor.Orange, SecurityColor.Purple), 
                new Chip(SecurityColor.Red, SecurityColor.Yellow)
            };

            ChipChainer chainer = new ChipChainer();

            List<List<Chip>> result = chainer.GetChains(firstChip, remainingChips);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void SingleChipReturnsSingleItemChain()
        {
            Chip firstChip = new Chip(SecurityColor.Blue, SecurityColor.Green);
            List<Chip> remainingChips = new List<Chip>();

            ChipChainer chainer = new ChipChainer();

            List<List<Chip>> result = chainer.GetChains(firstChip, remainingChips);

            Assert.IsTrue(result.Count == 1);
        }

        [TestMethod]
        public void SingleChipReturnsChainContainingSingleChip()
        {
            Chip firstChip = new Chip(SecurityColor.Blue, SecurityColor.Green);
            List<Chip> remainingChips = new List<Chip>();

            ChipChainer chainer = new ChipChainer();

            List<List<Chip>> result = chainer.GetChains(firstChip, remainingChips);
            List<Chip> firstChain = result[0];

            Assert.AreEqual(firstChip, firstChain[0]);
        }

        [TestMethod]
        public void TwoMismatchedChipsReturnsNoChains()
        {
            Chip firstChip = new Chip(SecurityColor.Blue, SecurityColor.Green);
            Chip secondChip = new Chip(SecurityColor.Orange, SecurityColor.Purple);
            List<Chip> remainingChips = new List<Chip>() { secondChip };

            ChipChainer chainer = new ChipChainer();

            List<List<Chip>> result = chainer.GetChains(firstChip, remainingChips);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void TwoMatchedChipsReturnSingleChain()
        {
            Chip firstChip = new Chip(SecurityColor.Blue, SecurityColor.Green);
            Chip secondChip = new Chip(SecurityColor.Green, SecurityColor.Purple);
            List<Chip> remainingChips = new List<Chip>() { secondChip };

            ChipChainer chainer = new ChipChainer();

            List<List<Chip>> result = chainer.GetChains(firstChip, remainingChips);

            Assert.IsTrue(result.Count == 1);
        }

        [TestMethod]
        public void TwoMatchedChipsReturnProperlySequencedChain()
        {
            Chip firstChip = new Chip(SecurityColor.Blue, SecurityColor.Green);
            Chip secondChip = new Chip(SecurityColor.Green, SecurityColor.Purple);
            List<Chip> remainingChips = new List<Chip>() { secondChip };

            ChipChainer chainer = new ChipChainer();

            List<List<Chip>> result = chainer.GetChains(firstChip, remainingChips);
            List<Chip> firstChain = result[0];

            Assert.AreEqual(firstChip, firstChain[0]);
            Assert.AreEqual(secondChip, firstChain[1]);
        }

        [TestMethod]
        public void MultipleMatchesReturnMultipleChains()
        {
            Chip firstChip = new Chip(SecurityColor.Blue, SecurityColor.Green);
            Chip secondChip = new Chip(SecurityColor.Green, SecurityColor.Purple);
            Chip thirdChip = new Chip(SecurityColor.Green, SecurityColor.Orange);
            Chip fourthChip = new Chip(SecurityColor.Purple, SecurityColor.Green);
            Chip fifthChip = new Chip(SecurityColor.Orange, SecurityColor.Green);
            List<Chip> remainingChips = new List<Chip>() { secondChip, thirdChip, fourthChip, fifthChip };

            ChipChainer chainer = new ChipChainer();

            List<List<Chip>> result = chainer.GetChains(firstChip, remainingChips);

            Assert.IsTrue(result.Count == 2);
        }

        [TestMethod]
        public void MultipleMatchesReturnPropertlySequencedChains()
        {
            Chip firstChip = new Chip(SecurityColor.Blue, SecurityColor.Green);
            Chip secondChip = new Chip(SecurityColor.Green, SecurityColor.Purple);
            Chip thirdChip = new Chip(SecurityColor.Green, SecurityColor.Orange);
            Chip fourthChip = new Chip(SecurityColor.Purple, SecurityColor.Green);
            Chip fifthChip = new Chip(SecurityColor.Orange, SecurityColor.Green);
            List<Chip> remainingChips = new List<Chip>() { secondChip, thirdChip, fourthChip, fifthChip };

            ChipChainer chainer = new ChipChainer();

            List<List<Chip>> result = chainer.GetChains(firstChip, remainingChips);

            List<Chip> firstChain = result[0];
            Assert.AreEqual(firstChip, firstChain[0]);
            Assert.AreEqual(secondChip, firstChain[1]);
            Assert.AreEqual(fourthChip, firstChain[2]);
            Assert.AreEqual(thirdChip, firstChain[3]);
            Assert.AreEqual(fifthChip, firstChain[4]);

            List<Chip> secondChain = result[1];
            Assert.AreEqual(firstChip, secondChain[0]);
            Assert.AreEqual(thirdChip, secondChain[1]);
            Assert.AreEqual(fifthChip, secondChain[2]);
            Assert.AreEqual(secondChip, secondChain[3]);
            Assert.AreEqual(fourthChip, secondChain[4]);
        }
    }
}
