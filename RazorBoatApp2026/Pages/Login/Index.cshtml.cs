using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorBoatApp2026.Pages.Login
{
    // WIP
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string UserName { get; set; }

        [BindProperty]
        public string PassWord { get; set; }

        public IndexModel()
        {

        }

        public IActionResult OnGet()
        {
            //UserName = HttpContext.Session.GetString();
            return Page();
        }
    }
}
