using IdentityApp.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApp.Controllers
{
    [Authorize]
    public class StoreController : Controller
    {
        private ProductsDbContext DbContext;
        public StoreController(ProductsDbContext ctx) => DbContext = ctx;
        public IActionResult Index() => View(DbContext.Products);
    }
}
