using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026.Pages.Members
{
    public class DeleteMemberModel : PageModel
    {
        private readonly IMemberRepository _memberRepo;

        [BindProperty]
        public Member DeleteMember { get; set; }

        public DeleteMemberModel(IMemberRepository memberRepo)
        {
            _memberRepo = memberRepo;
        }

        public IActionResult OnGet(string phoneNumber)
        {
            DeleteMember = _memberRepo.SearchMember(phoneNumber);
            return Page();
        }

        public IActionResult OnPostDelete(string phoneNumber)
        {
            _memberRepo.RemoveMember(DeleteMember);
            return RedirectToPage("Index");
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("Index");
        }
    }
}
