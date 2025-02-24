using IdentityApp.DB;
using IdentityApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityApp.Pages
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        public EditModel(ProductsDbContext ctx) => DbContext = ctx;
        public ProductsDbContext DbContext { get; set; }
        public Product Product { get; set; }
        public void OnGet(long id)
        {
            Product = DbContext.Find<Product>(id) ?? new Product();
        }
        public IActionResult OnPost([Bind(Prefix = "Product")] Product p)
        {
            DbContext.Update(p);
            DbContext.SaveChanges();
            return RedirectToPage("Admin");
        }
    }
}
