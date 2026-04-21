using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;
using System.ComponentModel.DataAnnotations;

namespace RazorBoatApp2026.Pages.Bookings
{
    public class CreateBookingModel : PageModel
    {
        private IBoatRepositoryAsync _boatRepo;
        private IBookingRepository _bookingRepo;
        private IMemberRepositoryAsync _memberRepo;

        public Boat Boat { get; set; }

        public Booking Booking { get; set; }

        [BindProperty]
        [MinLength(8), MaxLength(8)]
        [Required(AllowEmptyStrings = false)]
        public string PhoneNumber { get; set; }

        [BindProperty]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [BindProperty]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(1);

        [BindProperty]
        public string? Destination { get; set; }

        public CreateBookingModel(IBoatRepositoryAsync boatRepo, IBookingRepository bookingRepo, IMemberRepositoryAsync memberRepo)
        {
            _boatRepo = boatRepo;
            _bookingRepo = bookingRepo;
            _memberRepo = memberRepo;
        }

        public async Task OnGet(string sailNumber)
        {
            Boat = await _boatRepo.SearchBoat(sailNumber);
        }

        public async Task<IActionResult> OnPost(string sailNumber)
        {
            Boat = await _boatRepo.SearchBoat(sailNumber);
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                Member? member = await _memberRepo.SearchMember(PhoneNumber);
                int id = FindUniqueId();
                Booking = new(id, StartDate, EndDate, Destination, member, Boat);
                _bookingRepo.AddBooking(Booking);
                return RedirectToPage("Index");
            }
            catch (Exception e)
            {
                ViewData["ErrorMessage"] = e.Message;
                return Page();
            }
        }

        private int FindUniqueId()
        {
            List<Booking> bookings = _bookingRepo.GetAllBookings();
            HashSet<int> reservedIds = new(bookings.Select(m => m.Id));
            int newId = 1;
            while (reservedIds.Contains(newId))
            {
                newId++;
            }
            return newId;
        }
    }
}
