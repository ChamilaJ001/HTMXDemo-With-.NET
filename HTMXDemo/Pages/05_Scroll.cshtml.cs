using Htmx;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HTMXDemo.Pages
{
    public class _05_ScrollModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Cursor { get; set; } = 1;

        public IActionResult OnGet()
        {
            return Request.IsHtmx()
                ? Partial("_Cards", this)
                : Page();
        }
    }
}
