namespace SailClubLibrary.Exceptions
{
    /// <summary>
    /// Exception for when a member's phone number already exists
    /// </summary>
    public class MemberPhoneNumberExistsException : Exception
    {
        public MemberPhoneNumberExistsException(string message) : base(message)
        {

        }
    }
}
