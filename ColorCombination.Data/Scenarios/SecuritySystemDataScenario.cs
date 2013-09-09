using System.Collections.Generic;
using ColorCombination.Data.Entities;

namespace ColorCombination.Data.Scenarios
{
    public interface SecuritySystemDataScenario
    {
        Marker LeftMarker { get; }
        Marker RightMarker { get; }
        List<Chip> Chips { get; }
    }
}
