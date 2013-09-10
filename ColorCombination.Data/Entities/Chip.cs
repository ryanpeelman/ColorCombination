using ColorCombination.Data.Enumerations;

namespace ColorCombination.Data.Entities
{
    public class Chip
    {
        public SecurityColor LeftColor { get; private set; }
        public SecurityColor RightColor { get; private set; }

        public Chip(SecurityColor left, SecurityColor right)
        {
            LeftColor = left;
            RightColor = right;
        }

        public override string ToString()
        {
            return LeftColor + ", " + RightColor;
        }
    }
}
