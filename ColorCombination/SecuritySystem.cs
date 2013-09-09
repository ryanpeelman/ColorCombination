using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorCombination.Data.Entities;

namespace ColorCombination
{
    public class SecuritySystem 
    {
        private Marker _leftMarker;
        private Marker _rightMarker;

        public SecuritySystem(Marker leftMarker, Marker rightMarker)
        {
            _leftMarker = leftMarker;
            _rightMarker = rightMarker;
        }

        public bool CanBeUnlocked(List<Chip> chips)
        {
            if (_leftMarker == null || _rightMarker == null)
                return false;

            if (chips == null || !chips.Any())
                return false;

            if (!chips.Any(x => x.Left == _leftMarker.Color))
                return false;

            if (!chips.Any(x => x.Right == _rightMarker.Color))
                return false;
            
            return true;
        }
    }
}
