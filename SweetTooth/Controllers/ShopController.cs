using Microsoft.AspNetCore.Mvc;
using SweetTooth.Data;

namespace SweetTooth.Controllers
{
    public class ShopController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShopController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //query thr DB to get a list of categories to pass into the view
            var categories = _context.Categories.OrderBy(c => c.Name).ToList();
            return View(categories);
        }
    }
}
