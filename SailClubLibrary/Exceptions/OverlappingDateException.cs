namespace SailClubLibrary.Exceptions
{
    /// <summary>
    /// Exception for if a booking date is overlapping with another
    /// </summary>
    public class OverlappingDateException : Exception
    {
        public OverlappingDateException(string message) : base(message)
        {

        }
    }
}
