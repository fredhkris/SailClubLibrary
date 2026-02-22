using SailClubLibrary.Models;

namespace SailClubLibrary.Helpers.Sorting
{
    public class BoatCompareBySailNumber : IComparer<Boat>
    {
        public int Compare(Boat? x, Boat? y)
        {
            if (x == null)
            {
                return -1;
            }
            if (y == null)
            {
                return 1;
            }
            if (x.SailNumber == y.SailNumber)
            {
                return 0;
            }
            if (x.SailNumber != y.SailNumber)
            {
                return 1;
            }
            return -1;
        }
    }
}
