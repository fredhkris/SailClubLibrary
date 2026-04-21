using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026.Pages.Boats
{
    public class DeleteBoatModel : PageModel
    {
        private IBoatRepositoryAsync _boatRepo;

        [BindProperty]
        public Boat DeleteBoat { get; set; }

        public DeleteBoatModel(IBoatRepositoryAsync boatRepo)
        {
            _boatRepo = boatRepo;
        }

        public async Task<IActionResult> OnGet(string sailNumber)
        {
            DeleteBoat = await _boatRepo.SearchBoat(sailNumber);
            return Page();
        }

        public async Task<IActionResult> OnPostDelete(string sailNumber)
        {
            await _boatRepo.RemoveBoat(sailNumber);
            return RedirectToPage("Index");
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("Index");
        }
    }
}
