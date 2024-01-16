using Htmx;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace HTMXDemo.Pages
{
    public class _06_ModalModel : PageModel
    {
        public IActionResult OnPostModal([FromForm] NewsletterSignup signup)
        {
            if (!ModelState.IsValid)
            {
                Response.Htmx(h => h.Refresh());
                return Content("", "text/html");
            }

            return Partial("_Modal", signup);
        }
    }

    public class NewsletterSignup
    {
        [EmailAddress, Required]
        public string? Email { get; set; } = string.Empty;
    }
}
