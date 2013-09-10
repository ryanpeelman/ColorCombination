using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorCombination.Data.Entities;
using ColorCombination.Data.Enumerations;

namespace ColorCombination.Services.Interfaces
{
    public interface IBuildChipChains
    {
        List<ChipChain> GetChains(SecurityColor beginningColor, List<Chip> chips);
    }
}
