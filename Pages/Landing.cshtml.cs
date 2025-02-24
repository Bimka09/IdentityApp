using IdentityApp.DB;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityApp.Pages
{
    public class LandingModel : PageModel
    {
        public LandingModel(ProductsDbContext ctx) => DbContext = ctx;
        public ProductsDbContext DbContext { get; set; }
        public void OnGet()
        {
        }
    }
}
