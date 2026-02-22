using SailClubLibrary.Models;

namespace SailClubLibrary.Helpers.Sorting
{
    public class BoatCompareByYear : IComparer<Boat>
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
            if (x.YearOfConstruction.Equals(y.YearOfConstruction))
            {
                return 0;
            }
            if (!x.YearOfConstruction.Equals(y.YearOfConstruction))
            {
                return 1;
            }
            return -1;
        }
    }
}
