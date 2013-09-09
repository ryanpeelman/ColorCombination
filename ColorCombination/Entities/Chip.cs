using ColorCombination.Enumerations;

namespace ColorCombination.Entities
{
    public class Chip
    {
        public SecurityColor Left { get; private set; }
        public SecurityColor Right { get; private set; }

        public Chip(SecurityColor left, SecurityColor right)
        {
            Left = left;
            Right = right;
        }
    }
}
