using ColorCombination.Data.Enumerations;

namespace ColorCombination.Data.Entities
{
    public class Marker
    {
        public SecurityColor Color { get; private set; }

        public Marker(SecurityColor color)
        {
            Color = color;
        }
    }
}
