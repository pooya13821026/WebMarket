using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebMarke_App.Data;
using WebMarke_App.Models;
using WebMarke_App.Models.ViewModel;

namespace WebMarke_App.Controllers
{
    public class FieldController : Controller
    {
        private readonly ApplicationDbContext _db;

        public FieldController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Field> FieldList = _db.Fields;
            return View(FieldList);
        }

        public IActionResult Upsert(int? id)
        {
            FieldShowcase fieldVM = new()
            {
                Field = new(),
                CategoryList = _db.Categories.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString(),
                }).ToList(),
            };
            if (id == null || id == 0)
            {
                return View(fieldVM);
            }
            else
            {
                fieldVM.Field = _db.Fields.FirstOrDefault(u => u.Id == id);
                return View(fieldVM);
            }
        }

        [HttpPost]
        public IActionResult Upsert(FieldShowcase obj)
        {
            if (obj.Field.Id == 0)
            {
                _db.Fields.Add(obj.Field);
                _db.SaveChanges();
                return RedirectToAction("index");
            }
            else
            {
                _db.Fields.Update(obj.Field);
                _db.SaveChanges();
                return RedirectToAction("index");
            }
        }
    }
}
