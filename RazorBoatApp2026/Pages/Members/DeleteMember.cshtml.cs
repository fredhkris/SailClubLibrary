using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026.Pages.Members
{
    public class DeleteMemberModel : PageModel
    {
        private readonly IMemberRepositoryAsync _memberRepo;

        [BindProperty]
        public Member DeleteMember { get; set; }

        public DeleteMemberModel(IMemberRepositoryAsync memberRepo)
        {
            _memberRepo = memberRepo;
        }

        public async Task<IActionResult> OnGet(string phoneNumber)
        {
            DeleteMember = await _memberRepo.SearchMember(phoneNumber);
            return Page();
        }

        public async Task<IActionResult> OnPostDelete(string phoneNumber)
        {
            await _memberRepo.RemoveMember(DeleteMember);
            return RedirectToPage("Index");
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("Index");
        }
    }
}
