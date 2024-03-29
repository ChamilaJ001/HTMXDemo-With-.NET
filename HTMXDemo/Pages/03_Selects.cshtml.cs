using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;

namespace HTMXDemo.Pages
{
    public class _03_SelectsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string? Cuisine { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Food { get; set; }

        private readonly Dictionary<string, List<String>> cusins = new()
        {
             {"Italian", new List<string> {"Spaghetti", "Pizza", "Lasagna"}},
             {"Mexican", new List<string> {"Tacos", "Enchiladas", "Churros"}},
             {"American", new List<string> {"Burgers", "Hot dogs", "Barbeque"}}
        };

        public IList<SelectListItem> CuisinsItems
        {
            get
            {
                var items = cusins.Keys.Select(c => new SelectListItem(c, c)).ToList();

                items.Insert(0, new SelectListItem("Choose an option", "")
                {
                    Disabled = true,
                    Selected = true,
                });

                return items;
            }
        }

        public void OnGet()
        {
        }

        public IActionResult OnGetFoods()
        {
            var html = new StringBuilder();
            if (Cuisine is { Length: > 0 } cuisine && cusins.TryGetValue(cuisine, out var foods))
            {
                html.AppendLine("<option disabled selected>Select a food</option>");
                foreach (var food in foods)
                {
                    html.AppendLine($"<option>{food}</option>");
                }
            }

            return Content(html.ToString(), "text/html");
        }

        public IActionResult OnGetLove()
        {
            return Content($"<span><i class=\"fa fa-heart\"></i> I love {Food}!</span>");
        }
    }
}
