using IdentityApp.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityApp.Pages
{
    [Authorize]
    public class StoreModel : PageModel
    {
        public StoreModel(ProductsDbContext ctx) => DbContext = ctx;
        public ProductsDbContext DbContext { get; set; }
        public void OnGet()
        {
        }
    }
}
