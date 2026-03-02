using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;
using System.ComponentModel.DataAnnotations;

namespace RazorBoatApp2026.Pages.Bookings
{
    public class CreateBookingModel : PageModel
    {
        private IBoatRepository _repo;

        public Boat Boat { get; set; }

        [BindProperty]
        [MinLength(8), MaxLength(8)]
        public string PhoneNumber { get; set; }

        [BindProperty]
        public DateTime StartDate { get; set; }

        [BindProperty]
        public DateTime EndDate { get; set; }

        public CreateBookingModel(IBoatRepository repo)
        {
            _repo = repo;
        }

        public void OnGet(string sailNumber)
        {
            Boat = _repo.SearchBoat(sailNumber);
        }

        public IActionResult OnPost(string sailNumber)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _repo.AddBoat(Boat);
            return Page();
        }
    }
}
