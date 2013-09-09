using ColorCombination.Enumerations;

namespace ColorCombination.Entities
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
