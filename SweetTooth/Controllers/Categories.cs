using Microsoft.AspNetCore.Mvc;
using SweetTooth.Models;

namespace SweetTooth.Controllers
{
    public class Categories : Controller
    {
        public IActionResult Index()
        {
            var categories = new List<Category>();
            for (int i = 1; i <= 10; i++)
                categories.Add(new Category { CategoryId = i, Name = "Category " + i });
            return View(categories);
        }
        //the argument called category passsed into the method so we know which category to display
        public IActionResult Browse(string type)
        {
            ViewData["type"] = type;
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
