using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026.Pages.Boats
{
    public class CreateBoatModel : PageModel
    {
        private readonly IBoatRepositoryAsync _boatRepo;

        [BindProperty]
        public Boat NewBoat { get; set; }

        public CreateBoatModel(IBoatRepositoryAsync boatRepository)
        {
            _boatRepo = boatRepository;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                NewBoat.Id = await FindUniqueId();
                await _boatRepo.AddBoat(NewBoat);
            }
            catch (Exception exp)
            {
                ViewData["ErrorMessage"] = exp.Message;
                return Page();
            }
            return RedirectToPage("Index");
        }

        private async Task<int> FindUniqueId()
        {
            List<Boat> boats = await _boatRepo.GetAllBoats();
            HashSet<int> reservedIds = new(boats.Select(m => m.Id));
            int newId = 1;
            while (reservedIds.Contains(newId))
            {
                newId++;
            }
            return newId;
        }
    }
}
