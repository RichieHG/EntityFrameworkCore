using DataAccess.Data;
using DataAccess.FluentConfig;
using Microsoft.AspNetCore.Mvc;
using Model.Models;

namespace Library.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> categories = _db.Category.ToList();
            return View(categories);
        }

        //[HttpPost]
        public IActionResult Upsert(int? id)
        {
            Category category = new Category();
            
            if(id is not null)
            {
                category = _db.Category.FirstOrDefault(x => x.Category_Id == id);
                if (category is null) return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Category category)
        {
            if (!ModelState.IsValid) return View(category);
            
            if(category.Category_Id == 0) //Create
            {
                _db.Category.Add(category);
            }
            else //Update
            {
                _db.Category.Update(category);
            }
            _db.SaveChanges();
            
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Category category = _db.Category.FirstOrDefault(x => x.Category_Id == id);
            if(category is null) return NotFound();

            _db.Category.Remove(category);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateMultiple2()
        {
            List<Category> categories = new List<Category>();
            for(int i = 0; i < 2; i++)
            {
                categories.Add(new(){Name = $"BulkCat - {i}"});
                //_db.Category.Add(new(){Name = $"BulkCat - {i}"});
            }
            _db.Category.AddRange(categories);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateMultiple5()
        {
            List<Category> categories = new List<Category>();
            for (int i = 0; i < 5; i++)
            {
                categories.Add(new() { Name = $"BulkCat2 - {i}" });
                //_db.Category.Add(new() { Name = $"BulkCat2 - {i}" });
            }
            _db.Category.AddRange(categories);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveMultiple2()
        {
            IEnumerable<Category> categories = _db.Category.OrderByDescending(x => x.Category_Id)
                                                            .Take(2).ToList();
            _db.RemoveRange(categories);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveMultiple5()
        {
            IEnumerable<Category> categories = _db.Category.OrderByDescending(x => x.Category_Id)
                                                             .Take(5).ToList();
            _db.RemoveRange(categories);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
