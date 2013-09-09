using System.Collections.Generic;
using ColorCombination.Entities;

namespace ColorCombination.Tests.Scenarios
{
    public interface SecuritySystemDataScenario
    {
        Marker LeftMarker { get; }
        Marker RightMarker { get; }
        List<Chip> Chips { get; }
    }
}
