using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026.Pages.Boats
{
    public class EditBoatModel : PageModel
    {
        private readonly IBoatRepositoryAsync _boatRepo;

        [BindProperty]
        public Boat BoatToUpdate { get; set; }

        public EditBoatModel(IBoatRepositoryAsync boatRepository)
        {
            _boatRepo = boatRepository;
        }

        public async Task OnGet(string sailNumber)
        {
            BoatToUpdate = await _boatRepo.SearchBoat(sailNumber);
        }

        public async Task<IActionResult> OnPostUpdate()
        {
            await _boatRepo.UpdateBoat(BoatToUpdate);
            return RedirectToPage("Index");
        }

        public async Task<IActionResult> OnPostDelete()
        {
            await _boatRepo.RemoveBoat(BoatToUpdate.SailNumber);
            return RedirectToPage("Index");
        }
    }
}
