using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebMarke_App.Data;
using WebMarke_App.Models;
using WebMarke_App.Models.ViewModel;

namespace WebMarke_App.Controllers
{
    public class ValueController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ValueController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<FildeValue> ValueList = _db.Values;
            return View(ValueList);
        }

        public IActionResult Upsert(int? id)
        {
            ProductVM valueVM = new()
            {
                Value = new(),
                ProductList = _db.Products.Select(i => new SelectListItem
                {
                    Text = i.Title,
                    Value = i.Id.ToString(),
                }).ToList(),
                FieldList = _db.Fields.Select(i => new SelectListItem
                {
                    Text = i.Filde,
                    Value = i.Id.ToString(),
                }).ToList(),
            };
            if (id == null || id == 0)
            {
                return View(valueVM);
            }
            else
            {
                valueVM.Value = _db.Values.FirstOrDefault(u => u.Id == id);
                return View(valueVM);
            }
        }

        [HttpPost]
        public IActionResult Upsert(ProductVM obj)
        {
            if (obj.Value.Id == 0)
            {
                _db.Values.Add(obj.Value);
                _db.SaveChanges();
                return RedirectToAction("index");
            }
            else
            {
                _db.Values.Update(obj.Value);
                _db.SaveChanges();
                return RedirectToAction("index");
            }
        }
    }
}
