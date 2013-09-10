using System.Collections.Generic;
using ColorCombination.Data.Entities;
using ColorCombination.Data.Enumerations;

namespace ColorCombination.Data.Scenarios
{
    public interface SecuritySystemDataScenario
    {
        SecurityColor BeginningMarkerColor { get; }
        SecurityColor EndMarkerColor { get; }
        List<Chip> Chips { get; }
    }
}
