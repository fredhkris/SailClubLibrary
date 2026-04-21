namespace SailClubLibrary.Exceptions
{
    /// <summary>
    /// Exception for if a date cannot exist
    /// </summary>
    public class InvalidDateException : Exception
    {
        public InvalidDateException(string message) : base(message)
        {

        }
    }
}
