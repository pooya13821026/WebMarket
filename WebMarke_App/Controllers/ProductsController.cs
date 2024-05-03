using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebMarke_App.Data;
using WebMarke_App.Models;
using WebMarke_App.Models.ViewModel;

namespace WebMarke_App.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _WebHostEnviroment;

        public ProductsController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _WebHostEnviroment = webHostEnvironment;
        }


        public IActionResult Index(double min, double max, int? id, string? searche, int? categoryId, int?[] fieldId, string? value)
        {
            //var products = from product in _db.Products select product;
            //if (id.HasValue)
            //{
            //    var idd = id.Value;
            //    products = products.Where(x => x.Id == idd);
            //}

            //if (!String.IsNullOrEmpty(searche))
            //{
            //    products = products.Where(p => p.Title.Contains(searche));
            //}

            //if (max == 0)
            //{
            //    max = _db.Products.Max(product => product.Price);
            //}
            //var filterPrice = from product in _db.Products select product;
            //filterPrice = _db.Products.Where(f => f.Price >= min && f.Price <= max);

            //if (categoryId == null)
            //{
            //    ProductShowcase products = new()
            //    {
            //        Categoryy = _db.Categories.ToList(),
            //        ProductList = _db.Products.ToList()
            //    };
            //    return View(products);
            //}
            //ProductShowcase filter = new()
            //{
            //    Categoryy = _db.Categories.ToList(),
            //    ProductList = _db.Products.Where(i => i.Id == categoryId).ToList()
            //};
            //return View(filter);

            //Console.WriteLine(fieldId);
            if (value == null)
            {
                ProductShowcase products = new()
                {
                    Categoryy = _db.Categories.ToList(),
                    ProductList = _db.Products.ToList(),
                    FieldList = _db.Fields.ToList(),
                };
                return View(products);
            }
            ProductShowcase filter = new()
            {
                Categoryy = _db.Categories.ToList(),
                ProductList = _db.Products
                .Where(i => i.FildeValues.Any(x => x.Value.Contains(value) && fieldId.Contains(x.FildeId.Value))).ToList(),
                FieldList = _db.Fields.ToList(),
            };
            return View(filter);
        }


        public async Task<ActionResult> Upsert(int? id)
        {
            ProductShowcase product = new()
            {
                Product = new(),
                CategoryList = await _db.Categories.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString(),
                }).ToListAsync(),
            };
            if (id == null || id == 0)
            {
                return View(product);
            }
            else
            {
                product.Product = await _db.Products.FirstOrDefaultAsync(u => u.Id == id);
                return View(product);
            }
        }

        [HttpPost]
        public IActionResult Upsert(ProductShowcase obj)
        {
            string wwwrootPath = _WebHostEnviroment.WebRootPath;
            if (ModelState.IsValid)
            {
                if (obj.Product.File != null)
                {
                    string FileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwrootPath, @"img");
                    var extention = Path.GetExtension(obj.Product.File.FileName);

                    if (obj.Product.Img != null)
                    {
                        var oldImgPath = Path.Combine(wwwrootPath, obj.Product.Img.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImgPath))
                        {
                            System.IO.File.Delete(oldImgPath);
                        }
                    }

                    using (var FileStream =
                           new FileStream(Path.Combine(uploads, FileName + extention), FileMode.Create))
                    {
                        obj.Product.File.CopyTo(FileStream);
                    }

                    obj.Product.Img = @"img/" + FileName + extention;
                }

                if (obj.Product.Id == 0)
                {
                    _db.Products.Add(obj.Product);
                    _db.SaveChanges();
                    return RedirectToAction("index");
                }
                else
                {
                    _db.Products.Update(obj.Product);
                    _db.SaveChanges();
                    return RedirectToAction("index");
                }
            }

            return View(obj);
        }



        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var ProductDbFirst = _db.Products.FirstOrDefault(i => i.Id == id);
            if (ProductDbFirst == null)
            {
                return NotFound();
            }

            return View(ProductDbFirst);
        }

        [HttpPost]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Products.FirstOrDefault(i => i.Id == id);
            _db.Products.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}