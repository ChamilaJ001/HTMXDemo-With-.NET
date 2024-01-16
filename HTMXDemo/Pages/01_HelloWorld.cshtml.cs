using Htmx;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HTMXDemo.Pages
{
    public class _01_HelloWorldModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Request.IsHtmx() ? Content("<span>Hello World!</span>", "text/html") : Page();
        }
    }
}
