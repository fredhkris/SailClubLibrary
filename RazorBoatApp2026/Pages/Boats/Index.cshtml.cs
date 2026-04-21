using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Helpers.Sorting;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026.Pages.Boats
{
    public class IndexModel : PageModel
    {
        private readonly IBoatRepositoryAsync _boatRepo;

        public List<Boat> Boats { get; set; }

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SortBy { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool IsDescending { get; set; }

        public IndexModel(IBoatRepositoryAsync boatRepo)
        {
            _boatRepo = boatRepo;
        }

        public async Task OnGet()
        {
            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                Boats = await _boatRepo.FilterBoats(FilterCriteria);
            }
            else
            {
                Boats = await _boatRepo.GetAllBoats();
            }
            if (!string.IsNullOrEmpty(SortBy))
            {
                SortBoats();
            }
        }

        public void SortBoats()
        {
            switch (SortBy)
            {
                case "Id":
                    Boats.Sort(new GenericComparer<Boat, int>(b => b.Id, IsDescending));
                    break;
                case "TheBoatType":
                    Boats.Sort(new GenericComparer<Boat, string>(b => b.TheBoatType.ToString(), IsDescending));
                    break;
                case "Model":
                    Boats.Sort(new GenericComparer<Boat, string>(b => b.Model, IsDescending));
                    break;
                case "SailNumber":
                    Boats.Sort(new GenericComparer<Boat, string>(b => b.SailNumber, IsDescending));
                    break;
                case "EngineInfo":
                    Boats.Sort(new GenericComparer<Boat, string>(b => b.EngineInfo, IsDescending));
                    break;
                case "Draft":
                    Boats.Sort(new GenericComparer<Boat, double>(b => b.Draft, IsDescending));
                    break;
                case "Width":
                    Boats.Sort(new GenericComparer<Boat, double>(b => b.Width, IsDescending));
                    break;
                case "Length":
                    Boats.Sort(new GenericComparer<Boat, double>(b => b.Length, IsDescending));
                    break;
                case "YearOfConstruction":
                    Boats.Sort(new GenericComparer<Boat, string>(b => b.YearOfConstruction, IsDescending));
                    break;
            }

        }
    }
}
