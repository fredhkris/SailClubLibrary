using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026.Pages.Bookings
{
    public class ChooseBoatModel : PageModel
    {
        private IBoatRepository _repo;

        public List<Boat> Boats { get; set; }

        public ChooseBoatModel(IBoatRepository boatRepo)
        {
            _repo = boatRepo;
        }

        public void OnGet()
        {
            Boats = _repo.GetAllBoats();
        }
    }
}
