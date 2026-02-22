using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;
using SailClubLibrary.Services;

namespace RazorBoatApp2026.Pages.Bookings
{
    public class IndexModel : PageModel
    {
        private IBoatRepository _boatRepo;

        public List<Boat> Boats { get; set; }
        public List<Booking> Bookings { get; set; }

        public IndexModel(IBoatRepository boatRepo)
        {
            _boatRepo = boatRepo;
        }

        public void OnGet()
        {
            Boats = _boatRepo.GetAllBoats();
        }

        public void BookBoat()
        {

        }
    }
}
