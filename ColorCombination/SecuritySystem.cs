using System.Collections.Generic;
using System.Linq;
using System.Text;
using ColorCombination.Data.Entities;
using ColorCombination.Data.Enumerations;
using ColorCombination.Services;
using ColorCombination.Services.Interfaces;

namespace ColorCombination
{
    public class SecuritySystem 
    {
        private SecurityColor _beginningMarkerColor;
        private SecurityColor _endMarkerColor;
        private IBuildChipChains _chipChainBuilder;

        public ChipChain FoundUnlockSequence { get; private set; }

        public SecuritySystem(SecurityColor beginningMarkerColor, SecurityColor endMarkerColor)
        {
            _beginningMarkerColor = beginningMarkerColor;
            _endMarkerColor = endMarkerColor;
            _chipChainBuilder = ServiceContainer.Instance.GetService<IBuildChipChains>();
        }

        public bool CanBeUnlocked(List<Chip> chips)
        {
            if (chips == null || !chips.Any())
                return false;

            if (!chips.Any(x => x.LeftColor == _beginningMarkerColor))
                return false;

            if (!chips.Any(x => x.RightColor == _endMarkerColor))
                return false;

            if (_chipChainBuilder == null)
                return false;

            List<ChipChain> chains = _chipChainBuilder.GetChains(_beginningMarkerColor, chips);

            FoundUnlockSequence = chains.LastOrDefault(x => x.Last().RightColor == _endMarkerColor);

            return FoundUnlockSequence != null;            
        }

        public string GetUnlockSequenceReadout(List<Chip> chips)
        {
            StringBuilder builder = new StringBuilder();

            if (CanBeUnlocked(chips))
            {
                foreach (Chip chip in FoundUnlockSequence)
                {
                    builder.AppendLine(chip.ToString());
                }
            }
            else
            {
                builder.AppendLine("Cannot unlock master panel");
            }
            
            return builder.ToString();
        }
    }
}
