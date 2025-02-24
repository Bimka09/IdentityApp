using IdentityApp.DB;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApp.Controllers
{
    public class HomeController : Controller
    {
        private ProductsDbContext DbContext;
        public HomeController(ProductsDbContext ctx) => DbContext = ctx;
        public IActionResult Index() => View(DbContext.Products);
    }
}
