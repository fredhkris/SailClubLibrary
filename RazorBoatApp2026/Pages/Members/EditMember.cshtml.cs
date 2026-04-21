using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026.Pages.Members
{
    public class EditMemberModel : PageModel
    {
        private readonly IMemberRepositoryAsync _memberRepo;

        [BindProperty]
        public Member Member { get; set; }

        public EditMemberModel(IMemberRepositoryAsync memberRepo)
        {
            _memberRepo = memberRepo;
        }

        public async Task OnGet(string phoneNumber)
        {
            Member = await _memberRepo.SearchMember(phoneNumber);
        }

        public async Task<IActionResult> OnPostUpdate()
        {
            await _memberRepo.UpdateMember(Member);
            return RedirectToPage("Index");
        }

        public async Task<IActionResult> OnPostDelete()
        {
            await _memberRepo.RemoveMember(Member);
            return RedirectToPage("Index");
        }
    }
}
