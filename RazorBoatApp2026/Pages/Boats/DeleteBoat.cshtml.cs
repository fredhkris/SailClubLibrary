using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026.Pages.Boats
{
    public class DeleteBoatModel : PageModel
    {
        private IBoatRepository _boatRepo;

        [BindProperty]
        public Boat DeleteBoat { get; set; }

        public DeleteBoatModel(IBoatRepository boatRepo)
        {
            _boatRepo = boatRepo;
        }

        public IActionResult OnGet(string sailNumber)
        {
            DeleteBoat = _boatRepo.SearchBoat(sailNumber);
            return Page();
        }

        public IActionResult OnPostDelete(string sailNumber)
        {
            _boatRepo.RemoveBoat(sailNumber);
            return RedirectToPage("Index");
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("Index");
        }
    }
}
