using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026.Pages.Boats
{
    public class EditBoatModel : PageModel
    {
        private readonly IBoatRepository _boatRepo;

        [BindProperty]
        public Boat BoatToUpdate { get; set; }

        public EditBoatModel(IBoatRepository boatRepository)
        {
            _boatRepo = boatRepository;
        }

        public void OnGet(string sailNumber)
        {
            BoatToUpdate = _boatRepo.SearchBoat(sailNumber);
        }

        public IActionResult OnPostUpdate()
        {
            _boatRepo.UpdateBoat(BoatToUpdate);
            return RedirectToPage("Index");
        }

        public IActionResult OnPostDelete()
        {
            _boatRepo.RemoveBoat(BoatToUpdate.SailNumber);
            return RedirectToPage("Index");
        }
    }
}
