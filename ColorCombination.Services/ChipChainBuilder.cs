using System.Collections.Generic;
using System.Linq;
using ColorCombination.Data.Entities;

namespace ColorCombination.Services
{
    public class ChipChainBuilder
    {
        public List<ChipChain> GetChains(Chip headChip, List<Chip> remainingChips) 
        {
            List<ChipChain> chains = new List<ChipChain>();

            ChipChain possibleChain = new ChipChain() { headChip };
            if (!remainingChips.Any())
            {
                chains.Add(possibleChain);
            }
            else
            {
                List<Chip> nextChips = remainingChips.Where(c => c.Left == possibleChain.Last().Right).ToList();
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
                        Recurse(chains, proxyRemainingChips, proxyPossibleChain);                        
                    }
                }
            }
            
            return chains;
        }

        private void Recurse(List<ChipChain> chains, List<Chip> remainingChips, ChipChain possibleChain)
        {
            List<Chip> nextChips = remainingChips.Where(c => c.Left == possibleChain.Last().Right).ToList();
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
                    Recurse(chains, proxyRemainingChips, proxyPossibleChain);
                }
            }
        }
    }
}
