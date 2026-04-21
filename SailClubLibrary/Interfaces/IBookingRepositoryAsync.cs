using SailClubLibrary.Models;

namespace SailClubLibrary.Interfaces
{
    public interface IBookingRepositoryAsync
    {
        Task AddBooking(Booking booking);
        Task RemoveBooking(Booking b);
        Task<List<Booking>> GetAllBookings();
        Task UpdateBooking(int id, Booking newBooking);
        Task PrintAll();
        Task<int> GetBookingCountForMember(Member member);
        Task<Dictionary<string, int>> GetAllBookingsForMembers();
    }
}
