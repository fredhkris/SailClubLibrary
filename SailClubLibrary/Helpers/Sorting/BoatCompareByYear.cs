using SailClubLibrary.Models;

namespace SailClubLibrary.Helpers.Sorting
{
    public class BoatCompareByYear : IComparer<Boat>
    {
        public int Compare(Boat? x, Boat? y)
        {
            if (x == null || y == null)
            {
                throw new ArgumentNullException();
            }
            if (x.YearOfConstruction == y.YearOfConstruction)
            {
                return 0;
            }
            if (x.YearOfConstruction != y.YearOfConstruction)
            {
                return 1;
            }
            return -1;
        }
    }
}
