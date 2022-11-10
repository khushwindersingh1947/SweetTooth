using Microsoft.AspNetCore.Mvc;
using SweetTooth.Data;
using SweetTooth.Models;

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
        //POST: Shop/AddTOCart
        [HttpPost]
        public IActionResult AddToCart(int ProductId, int Quantity) 
        {
            var product = _context.Products.Find(ProductId);
            var price = product.Price;

            //set random userId of cart Time
            var UserId = getUserId();

            //Create a new CartTime object
            var cartItem = new CartItem { 
                ProductId = ProductId,
                Quantity = Quantity,
                Price = price,
                UserId = UserId
            };

            //save the cartitem object to the database
            _context.CartItems.Add(cartItem);
            _context.SaveChanges();

            return RedirectToAction("Cart");
        }

        //GetUserId() will return a unique userId
        private string getUserId() {
            if (HttpContext.Session.GetString("UserId") == null) {

                var userId = "";
                if (User.Identity.IsAuthenticated)
                {
                    //user has logged in
                    userId = User.Identity.Name;
                }
                else { //user is anonymouse
                    userId = Guid.NewGuid().ToString();
                }

                //store userId in the session variable
                HttpContext.Session.SetString("UserId",userId);
            }
            return HttpContext.Session.GetString("UserId");
        }
    }
}
