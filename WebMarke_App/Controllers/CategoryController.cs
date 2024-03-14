using Microsoft.AspNetCore.Mvc;

namespace WebMarke_App.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
