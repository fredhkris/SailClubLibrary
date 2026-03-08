using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Exceptions;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;
using System.ComponentModel.DataAnnotations;

namespace RazorBoatApp2026.Pages.Bookings
{
    public class CreateBookingModel : PageModel
    {
        private IBoatRepository _boatRepo;
        private IBookingRepository _bookingRepo;
        private IMemberRepository _memberRepo;

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

        public CreateBookingModel(IBoatRepository boatRepo, IBookingRepository bookingRepo, IMemberRepository memberRepo)
        {
            _boatRepo = boatRepo;
            _bookingRepo = bookingRepo;
            _memberRepo = memberRepo;
        }

        public void OnGet(string sailNumber)
        {
            Boat = _boatRepo.SearchBoat(sailNumber);
        }

        public IActionResult OnPost(string sailNumber)
        {
            Boat = _boatRepo.SearchBoat(sailNumber);
            if (!ModelState.IsValid || Boat == null)
            {
                return Page();
            }
            try
            {
                Member? member = _memberRepo.SearchMember(PhoneNumber);
                if (member == null)
                {
                    return Page();
                }
                int id = _bookingRepo.GetAllBookings().Count + 1;
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
    }
}
