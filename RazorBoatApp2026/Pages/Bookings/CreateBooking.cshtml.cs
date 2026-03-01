using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026.Pages.Bookings
{
    public class CreateBookingModel : PageModel
    {
        private IBoatRepository _repo;
        public Boat Boat { get; set; }

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
            throw new NotImplementedException();
        }
    }
}
