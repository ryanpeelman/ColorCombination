using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorCombination.Data.Entities;
using ColorCombination.Data.Enumerations;

namespace ColorCombination
{
    public class SecuritySystem 
    {
        private SecurityColor _beginningMarkerColor;
        private SecurityColor _endMarkerColor;

        public string UnlockSequence { get; private set; }

        public SecuritySystem(SecurityColor beginningMarkerColor, SecurityColor endMarkerColor)
        {
            _beginningMarkerColor = beginningMarkerColor;
            _endMarkerColor = endMarkerColor;
        }

        public bool CanBeUnlocked(List<Chip> chips)
        {
            if (chips == null || !chips.Any())
                return false;

            if (!chips.Any(x => x.Left == _beginningMarkerColor))
                return false;

            if (!chips.Any(x => x.Right == _endMarkerColor))
                return false;

            ChipChainer chainer = new ChipChainer();

            List<List<Chip>> chains = new List<List<Chip>>();
            foreach (Chip validHeadChip in chips.Where(c => c.Left == _beginningMarkerColor))
            {
                List<Chip> proxyChips = new List<Chip>(chips);
                proxyChips.Remove(validHeadChip);

                List<List<Chip>> pchains = chainer.GetChains(validHeadChip, proxyChips);
                pchains.ForEach(p => chains.Add(p));
            }

            List<Chip> chipSequence = chains.LastOrDefault(x => x.Last().Right == _endMarkerColor);
            if (chipSequence != null)
            {
                StringBuilder builder = new StringBuilder();
                foreach (Chip chip in chipSequence)
                {
                    builder.AppendLine(chip.Left + ", " + chip.Right);
                }
                UnlockSequence = builder.ToString();
            }

            return chipSequence != null;            
        }
    }
}
