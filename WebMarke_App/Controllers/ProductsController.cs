using Humanizer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IActionResult Index(string searche)
        {
            var products = from product in _db.Products select product;
            if (!String.IsNullOrEmpty(searche))
            {
                products = products.Where(p => p.Title.Contains(searche));
            }
            return View(products.ToList());
        }

        [HttpPost]
        public IActionResult Index(double min, double max)
        {
            var filterPrice = from product in _db.Products select product;
            filterPrice = _db.Products.Where(f => f.Price >= min && f.Price <= max);
            return View(filterPrice);
        }




        //public IActionResult Upsert(int? id)
        //{
        //    ProductVM productVM = new()
        //    {
        //        Product = new(),
        //        CategoryList = _db.Categories.Select(i => new SelectListItem
        //        {
        //            Text = i.Name,
        //            Value = i.Id.ToString(),
        //        }).ToList(),
        //    };
        //    if (id == null || id == 0)
        //    {
        //        return View(productVM);
        //    }
        //    else
        //    {
        //        productVM.Product = _db.Products.FirstOrDefault(u => u.Id == id);
        //        return View(productVM);
        //    }
        //    return View(productVM);
        //}

        //[HttpPost]
        //public IActionResult Upsert(ProductVM obj, IFormFile? file)
        //{
        //    string wwwrootPath = _WebHostEnviroment.WebRootPath;
        //    if (ModelState.IsValid)
        //    {
        //        if (file != null)
        //        {
        //            string FileName = Guid.NewGuid().ToString();
        //            var uploads = Path.Combine(wwwrootPath, @"img");
        //            var extention = Path.GetExtension(file.FileName);

        //            if (obj.Product.Img != null)
        //            {
        //                var oldImgPath = Path.Combine(wwwrootPath, obj.Product.Img.TrimStart('\\'));
        //                if (System.IO.File.Exists(oldImgPath))
        //                {
        //                    System.IO.File.Delete(oldImgPath);
        //                }
        //            }
        //            using (var FileStream = new FileStream(Path.Combine(uploads, FileName + extention), FileMode.Create))
        //            {
        //                file.CopyTo(FileStream);
        //            }
        //            obj.Product.Img = @"img/" + FileName + extention;
        //        }
        //        if (obj.Product.Id == 0)
        //        {
        //            _db.Products.Add(obj.Product);
        //            _db.SaveChanges();
        //            return RedirectToAction("index");
        //        }
        //        else
        //        {
        //            _db.Products.Update(obj.Product);
        //            _db.SaveChanges();
        //            return RedirectToAction("index");
        //        }
        //    }
        //    return View(obj);
        //}







        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product obj, IFormFile? file)
        {
            string wwwrootPath = _WebHostEnviroment.WebRootPath;
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string FileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwrootPath, @"img");
                    var extention = Path.GetExtension(file.FileName);
                    //if (obj.Img != null)
                    //{
                    //    var oldImgPath = Path.Combine(wwwrootPath, obj.Img.TrimStart('\\'));
                    //    if (System.IO.File.Exists(oldImgPath))
                    //    {
                    //        System.IO.File.Delete(oldImgPath);
                    //    }
                    //}
                    using (var FileStream = new FileStream(Path.Combine(uploads, FileName + extention), FileMode.Create))
                    {
                        file.CopyTo(FileStream);
                    }
                    obj.Img = @"img/" + FileName + extention;
                }
                _db.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(obj);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
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
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("index");
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
