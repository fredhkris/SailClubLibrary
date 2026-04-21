using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026.Pages.Bookings
{
    public class IndexModel : PageModel
    {
        private IBookingRepository _bookingRepo;

        public List<Booking> Bookings { get; set; }


        public IndexModel(IBookingRepository bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }

        public void OnGet()
        {
            Bookings = _bookingRepo.GetAllBookings();
        }
    }
}
