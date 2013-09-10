using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorCombination.Data.Entities;

namespace ColorCombination
{
    public class ChipChainer
    {
        public List<List<Chip>> GetChains(Chip headChip, List<Chip> remainingChips) 
        {
            List<List<Chip>> chains = new List<List<Chip>>();

            List<Chip> possibleChain = new List<Chip>() { headChip };
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
                    List<Chip> proxyPossibleChain = new List<Chip>(possibleChain);

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

        private void Recurse(List<List<Chip>> chains, List<Chip> remainingChips, List<Chip> possibleChain)
        {
            List<Chip> nextChips = remainingChips.Where(c => c.Left == possibleChain.Last().Right).ToList();
            foreach (Chip nextChip in nextChips)
            {
                List<Chip> proxyRemainingChips = new List<Chip>(remainingChips);
                List<Chip> proxyPossibleChain = new List<Chip>(possibleChain);

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
