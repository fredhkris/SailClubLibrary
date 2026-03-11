using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;

namespace RazorBoatApp2026.Pages.Members
{
    public class CreateMemberModel : PageModel
    {
        private readonly IMemberRepository _memberRepo;
        private readonly IWebHostEnvironment _webHostEnvironment;

        [BindProperty]
        public Member Member { get; set; }

        [BindProperty]
        public IFormFile Photo { get; set; }


        public CreateMemberModel(IMemberRepository memberRepo, IWebHostEnvironment webHostEnvironment)
        {
            _memberRepo = memberRepo;
            _webHostEnvironment = webHostEnvironment;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            try
            {
                if (Photo != null)
                {
                    ProcessPhoto();
                }
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

        private void ProcessPhoto()
        {
            if(Photo != null)
            {
                if (Member.MemberImage != null)
                {
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "/images/MemberImages", Member.MemberImage);
                    System.IO.File.Delete(filePath);
                }
                Member.MemberImage = ProcessUploadedFile();
            }
        }

        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;
            if (Photo != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images/MemberImages");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
