using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026.Pages.Bookings
{
    public class ChooseBoatModel : PageModel
    {
        private IBoatRepositoryAsync _boatRepo;

        public List<Boat> Boats { get; set; }

        public ChooseBoatModel(IBoatRepositoryAsync boatRepo)
        {
            _boatRepo = boatRepo;
        }

        public async Task OnGet()
        {
            Boats = await _boatRepo.GetAllBoats();
        }
    }
}
