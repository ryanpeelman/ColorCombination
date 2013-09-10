using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorCombination.Data.Entities;

namespace ColorCombination.Services
{
    public class ChipChain : List<Chip>
    {
        public ChipChain() : base() { }

        public ChipChain(IEnumerable<Chip> chips) : base(chips) { }
    }
}
