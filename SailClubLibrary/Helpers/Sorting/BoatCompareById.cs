using SailClubLibrary.Models;

namespace SailClubLibrary.Helpers.Sorting
{
    public class BoatCompareById : IComparer<Boat>
    {
        public int Compare(Boat? x, Boat? y)
        {
            return x == null || y == null ? 0 : x.Id.CompareTo(y.Id);
        }
    }
}
