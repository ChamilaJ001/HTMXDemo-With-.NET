using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics.Metrics;

namespace HTMXDemo.Pages
{
    public class _02_CounterModel : PageModel
    {
        private static int count = 0;

        public void OnGet()
        {
            count = 0;
        }

        public IActionResult OnPost()
        {
            return Content($"<span>{++count}</span>", "text/html");
        }
    }
}
