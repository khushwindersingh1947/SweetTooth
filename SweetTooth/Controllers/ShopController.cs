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

        public IActionResult ShopByCategory(int id) 
        {
            //get list of products for the specified categoryId
            //_context - connects us to the database
            //.Products - connects us to the product table
            var products = _context.Products.Where(p => p.CategoryId == id)
                                            .OrderBy(p => p.Name)
                                            .ToList();

            if (products == null) { 
                return NotFound();
            }

            return View(products);
        }
    }
}
