using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026.Pages.Members
{
    public class CreateMemberModel : PageModel
    {
        private readonly IMemberRepository _memberRepo;

        [BindProperty]
        public Member Member { get; set; }

        public CreateMemberModel(IMemberRepository memberRepo)
        {
            _memberRepo = memberRepo;
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
                Member.Id = _memberRepo.GetAllMembers().Count + 1;
                _memberRepo.AddMember(Member);
            }
            catch (Exception e)
            {
                ViewData["ErrorMessage"] = e.Message;
                return Page();
            }
            return RedirectToPage("Index");
        }
    }
}
