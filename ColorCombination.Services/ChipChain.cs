using System.Collections.Generic;
using ColorCombination.Data.Entities;

namespace ColorCombination.Services
{
    public class ChipChain : List<Chip>
    {
        public ChipChain() : base() { }

        public ChipChain(IEnumerable<Chip> chips) : base(chips) { }
    }
}
