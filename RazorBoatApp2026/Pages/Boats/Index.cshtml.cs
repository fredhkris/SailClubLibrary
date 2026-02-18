using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Helpers.Sorting;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026InClass.Pages.Boats
{
    public class IndexModel : PageModel
    {
        private IBoatRepository bRepo;
        public List<Boat> Boats { get; set; }

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SortBy { get; set; }

        public IndexModel(IBoatRepository boatRepository)
        {
            bRepo = boatRepository;
        }
        public void OnGet()
        {
            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                Boats = bRepo.FilterBoats(FilterCriteria);
            }
            else
            {
                Boats = bRepo.GetAllBoats();
            }
            SortBoats();
        }

        public void SortBoats()
        {
            if(SortBy.Equals("Id"))
            {
                BoatCompareById c = new();
                Boats.Sort(c);
            }
            if (SortBy.Equals("SailNumber"))
            {
                BoatCompareBySailNumber c = new();
                Boats.Sort(c);
            }
            if (SortBy.Equals("YearOfConstruction"))
            {
                BoatCompareByYear c = new();
                Boats.Sort(c);
            }
        }
    }
}
