using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026.Pages.Members
{
    public class EditMemberModel : PageModel
    {
        private readonly IMemberRepository _memberRepo;

        [BindProperty]
        public Member Member { get; set; }

        public EditMemberModel(IMemberRepository memberRepo)
        {
            _memberRepo = memberRepo;
        }

        public void OnGet(string phoneNumber)
        {
            Member = _memberRepo.SearchMember(phoneNumber);
        }

        public IActionResult OnPostUpdate()
        {
            _memberRepo.UpdateMember(Member);
            return RedirectToPage("Index");
        }

        public IActionResult OnPostDelete()
        {
            _memberRepo.RemoveMember(Member);
            return RedirectToPage("Index");
        }
    }
}
