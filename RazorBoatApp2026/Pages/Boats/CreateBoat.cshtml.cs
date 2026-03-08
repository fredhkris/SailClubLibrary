using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026.Pages.Boats
{
    public class CreateBoatModel : PageModel
    {
        private readonly IBoatRepository _boatRepo;

        [BindProperty]
        public Boat NewBoat { get; set; }

        public CreateBoatModel(IBoatRepository boatRepository)
        {
            _boatRepo = boatRepository;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                if(NewBoat == null)
                {
                    return Page();
                }
                NewBoat.Id = _boatRepo.GetAllBoats().Count + 1;
                _boatRepo.AddBoat(NewBoat);
            }
            //catch (BoatSailnumberExistsException bex)
            //{
            //    ViewData["ErrorMessage"] = bex.Message;
            //    return Page();
            //}
            catch (Exception exp)
            {
                ViewData["ErrorMessage"] = exp.Message;
                return Page();
            }
            return RedirectToPage("Index");
        }
    }
}
