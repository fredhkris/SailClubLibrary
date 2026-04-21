using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Helpers.Filter;
using SailClubLibrary.Helpers.Sorting;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026.Pages.Members
{
    public class IndexModel : PageModel
    {
        private readonly IMemberRepositoryAsync _memberRepo;

        public List<Member> Members { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? FilterCriteria { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? FilterBy { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SortBy { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool IsDescending { get; set; }

        [BindProperty(SupportsGet = true)]
        public string PreviousSort { get; set; }

        [BindProperty(SupportsGet = true)]
        public MemberType? SelectedMemberType { get; set; }

        public IndexModel(IMemberRepositoryAsync memberRepo)
        {
            _memberRepo = memberRepo;
        }

        public async Task OnGet()
        {
            IsDescending = !string.IsNullOrEmpty(SortBy) && SortBy == PreviousSort && !IsDescending;
            Members = await _memberRepo.GetAllMembers();
            if (SelectedMemberType.HasValue)
            {
                Members = Members.FindAll(m => m.TheMemberType == SelectedMemberType);
            }
            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                FilterMembers();
            }
            if (!string.IsNullOrEmpty(SortBy))
            {
                SortMembers();
            }
            PreviousSort = SortBy;
        }

        private void FilterMembers()
        {
            string search = FilterCriteria.Trim();
            Predicate<Member> searchFilter;
            switch (FilterBy)
            {
                case "FirstName":
                    searchFilter = m => m.FirstName.Contains(search, StringComparison.InvariantCultureIgnoreCase);
                    break;
                case "SurName":
                    searchFilter = m => m.SurName.Contains(search, StringComparison.InvariantCultureIgnoreCase);
                    break;
                case "PhoneNumber":
                    searchFilter = m => m.PhoneNumber.Contains(search, StringComparison.InvariantCultureIgnoreCase);
                    break;
                case "Mail":
                    searchFilter = m => m.Mail.Contains(search, StringComparison.InvariantCultureIgnoreCase);
                    break;
                case "Address":
                    searchFilter = m => m.Address.Contains(search, StringComparison.InvariantCultureIgnoreCase);
                    break;
                case "City":
                    searchFilter = m => m.City.Contains(search, StringComparison.InvariantCultureIgnoreCase);
                    break;
                default:
                case "All":
                    searchFilter = m =>
                        m.FirstName.Contains(search, StringComparison.InvariantCultureIgnoreCase) ||
                        m.SurName.Contains(search, StringComparison.InvariantCultureIgnoreCase) ||
                        m.PhoneNumber.Contains(search, StringComparison.InvariantCultureIgnoreCase) ||
                        m.Mail.Contains(search, StringComparison.InvariantCultureIgnoreCase) ||
                        m.Address.Contains(search, StringComparison.InvariantCultureIgnoreCase) ||
                        m.City.Contains(search, StringComparison.InvariantCultureIgnoreCase);
                    break;
            }
            Members = FilterFunctions<Member>.FilterList(Members, searchFilter);
        }

        private void SortMembers()
        {
            switch (SortBy)
            {
                case "Id":
                    Members.Sort(new GenericComparer<Member, int>(b => b.Id, IsDescending));
                    break;
                case "FirstName":
                    Members.Sort(new GenericComparer<Member, string>(b => b.FirstName, IsDescending));
                    break;
                case "SurName":
                    Members.Sort(new GenericComparer<Member, string>(b => b.SurName, IsDescending));
                    break;
                case "PhoneNumber":
                    Members.Sort(new GenericComparer<Member, string>(b => b.PhoneNumber, IsDescending));
                    break;
                case "Address":
                    Members.Sort(new GenericComparer<Member, string>(b => b.Address, IsDescending));
                    break;
                case "City":
                    Members.Sort(new GenericComparer<Member, string>(b => b.City, IsDescending));
                    break;
                case "Mail":
                    Members.Sort(new GenericComparer<Member, string>(b => b.Mail, IsDescending));
                    break;
            }
        }


    }
}
