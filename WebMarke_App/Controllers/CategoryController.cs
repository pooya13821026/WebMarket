using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebMarke_App.Data;
using WebMarke_App.Models;
using WebMarke_App.Models.ViewModel;

namespace WebMarke_App.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Category> CategoryList = _db.Categories;
            return View(CategoryList);
        }


        public IActionResult Upsert(int? id)
        {
            CategoryShowcase categoryVM = new()
            {
                Category = new(),
                CategoryList = _db.Categories.Where(x => x.ParentId == null).Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString(),
                }).ToList(),
            };
            if (id == null || id == 0)
            {
                return View(categoryVM);
            }
            else
            {
                categoryVM.Category = _db.Categories.FirstOrDefault(u => u.Id == id);
                return View(categoryVM);
            }
        }

        [HttpPost]
        public IActionResult Upsert(CategoryShowcase obj)
        {
            if (obj.Category.Id == 0)
            {
                _db.Categories.Add(obj.Category);
                _db.SaveChanges();
                return RedirectToAction("index");
            }
            else
            {
                _db.Categories.Update(obj.Category);
                _db.SaveChanges();
                return RedirectToAction("index");
            }
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDbFirst = _db.Categories.FirstOrDefault(i => i.Id == id);
            if (categoryFromDbFirst == null)
            {
                return NotFound();
            }
            return View(categoryFromDbFirst);
        }
        [HttpPost]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Categories.FirstOrDefault(i => i.Id == id);
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
