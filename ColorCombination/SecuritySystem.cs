using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorCombination.Data.Entities;

namespace ColorCombination
{
    public class SecuritySystem 
    {
        private Marker _leftMarker;
        private Marker _rightMarker;

        public string UnlockSequence { get; private set; }

        public SecuritySystem(Marker leftMarker, Marker rightMarker)
        {
            _leftMarker = leftMarker;
            _rightMarker = rightMarker;
        }

        public bool CanBeUnlocked(List<Chip> chips)
        {
            if (_leftMarker == null || _rightMarker == null)
                return false;

            if (chips == null || !chips.Any())
                return false;

            if (!chips.Any(x => x.Left == _leftMarker.Color))
                return false;

            if (!chips.Any(x => x.Right == _rightMarker.Color))
                return false;

            ChipChainer chainer = new ChipChainer();

            List<List<Chip>> chains = new List<List<Chip>>();
            foreach (Chip validHeadChip in chips.Where(c => c.Left == _leftMarker.Color))
            {
                List<Chip> proxyChips = new List<Chip>(chips);
                proxyChips.Remove(validHeadChip);

                List<List<Chip>> pchains = chainer.GetChains(validHeadChip, proxyChips);
                pchains.ForEach(p => chains.Add(p));
            }

            List<Chip> chipSequence = chains.LastOrDefault(x => x.Last().Right == _rightMarker.Color);
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
