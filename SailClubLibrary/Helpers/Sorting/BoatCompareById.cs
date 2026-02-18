using SailClubLibrary.Models;

namespace SailClubLibrary.Helpers.Sorting
{
    public class BoatCompareById : IComparer<Boat>
    {
        public int Compare(Boat? x, Boat? y)
        {
            if (x == null || y == null)
            {
                throw new ArgumentNullException();
            }
            if (x.Id == y.Id)
            {
                return 0;
            }
            if (x.Id != y.Id)
            {
                return 1;
            }
            return -1;
        }
    }
}
