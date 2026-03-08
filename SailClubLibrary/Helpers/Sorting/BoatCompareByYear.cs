using SailClubLibrary.Models;

namespace SailClubLibrary.Helpers.Sorting
{
    public class BoatCompareByYear : IComparer<Boat>
    {
        public int Compare(Boat? x, Boat? y)
        {
            return x == null || y == null ? 0 : x.YearOfConstruction.CompareTo(y.YearOfConstruction);
        }
    }
}
