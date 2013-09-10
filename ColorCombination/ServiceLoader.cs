using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorCombination.Services;
using ColorCombination.Services.Interfaces;

namespace ColorCombination
{
    public static class ServiceLoader
    {
        public static void Load()
        {
            ServiceContainer.Instance.AddService<IBuildChipChains>(new ChipChainBuilder());
        }
    }
}
