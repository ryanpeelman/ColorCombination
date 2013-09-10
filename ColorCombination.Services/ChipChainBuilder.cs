using System.Collections.Generic;
using System.Linq;
using ColorCombination.Data.Entities;
using ColorCombination.Data.Enumerations;
using ColorCombination.Services.Interfaces;

namespace ColorCombination.Services
{
    public class ChipChainBuilder : IBuildChipChains
    {
        public List<ChipChain> GetChains(SecurityColor beginningColor, List<Chip> chips)
        {
            List<ChipChain> chains = new List<ChipChain>();
            foreach (Chip validHeadChip in chips.Where(c => c.LeftColor == beginningColor))
            {
                List<Chip> proxyChips = new List<Chip>(chips);
                proxyChips.Remove(validHeadChip);

                chains.AddRange(BuildChains(validHeadChip, proxyChips));
            }
            return chains;
        }

        public List<ChipChain> BuildChains(Chip headChip, List<Chip> remainingChips) 
        {
            List<ChipChain> chains = new List<ChipChain>();

            ChipChain possibleChain = new ChipChain() { headChip };
            if (!remainingChips.Any())
            {
                chains.Add(possibleChain);
            }
            else
            {
                List<Chip> nextChips = remainingChips.Where(c => c.LeftColor == possibleChain.Last().RightColor).ToList();
                foreach (Chip nextChip in nextChips)
                {
                    List<Chip> proxyRemainingChips = new List<Chip>(remainingChips);
                    ChipChain proxyPossibleChain = new ChipChain(possibleChain);

                    proxyRemainingChips.Remove(nextChip);
                    proxyPossibleChain.Add(nextChip);

                    if (!proxyRemainingChips.Any())
                    {
                        chains.Add(proxyPossibleChain);
                    }
                    else
                    {
                        BuildChain(chains, proxyRemainingChips, proxyPossibleChain);                        
                    }
                }
            }
            
            return chains;
        }

        private void BuildChain(List<ChipChain> chains, List<Chip> remainingChips, ChipChain possibleChain)
        {
            List<Chip> nextChips = remainingChips.Where(c => c.LeftColor == possibleChain.Last().RightColor).ToList();
            foreach (Chip nextChip in nextChips)
            {
                List<Chip> proxyRemainingChips = new List<Chip>(remainingChips);
                ChipChain proxyPossibleChain = new ChipChain(possibleChain);

                proxyRemainingChips.Remove(nextChip);
                proxyPossibleChain.Add(nextChip);

                if (!proxyRemainingChips.Any())
                {
                    chains.Add(proxyPossibleChain);
                }
                else
                {
                    BuildChain(chains, proxyRemainingChips, proxyPossibleChain);
                }
            }
        }
    }
}
