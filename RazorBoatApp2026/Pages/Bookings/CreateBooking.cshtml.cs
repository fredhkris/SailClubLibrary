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

        [BindProperty]
        public Boat? Boat { get; set; }

        [BindProperty]
        [MinLength(8), MaxLength(8)]
        [Required(AllowEmptyStrings = false)]
        //[RegularExpression(@"^[0-9]*$", ErrorMessage = "Must be a number")]
        public string PhoneNumber { get; set; }

        [BindProperty]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [BindProperty]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; } = DateTime.Now;

        public CreateBookingModel(IBoatRepository boatRepo, IBookingRepository bookingRepo)
        {
            _boatRepo = boatRepo;
            _bookingRepo = bookingRepo;
        }

        public void OnGet(string sailNumber)
        {
            Boat = _boatRepo.SearchBoat(sailNumber);
        }

        public IActionResult OnPost(string sailNumber)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Boat = _boatRepo.SearchBoat(sailNumber);
            if (Boat == null)
            {
                return RedirectToPage("Index");
            }
            try
            {
                Member member = new Member(0, "Hans", "Hansen", PhoneNumber, "Vej 123", "By", "mail@mail.dk", MemberType.Adult, MemberRole.Member);
                _bookingRepo.AddBooking(new Booking(0, StartDate, EndDate, "", member, Boat));
            }
            catch (Exception e)
            {
                ViewData["ErrorMessage"] = e.Message;
                return Page();
            }
            return RedirectToPage("Index");
        }
    }
}
