using DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Model.Models;

namespace Library.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AuthorController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Fluent_Author> authors = _db.Fluent_Author.ToList();
            return View(authors);
        }

        //[HttpPost]
        public IActionResult Upsert(int? id)
        {
            Fluent_Author author = new Fluent_Author();
            
            if(id is not null)
            {
                author = _db.Fluent_Author.FirstOrDefault(x => x.Author_Id == id);
                if (author is null) return NotFound();
            }

            return View(author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Fluent_Author author)
        {
            if (!ModelState.IsValid) return View(author);
            
            if(author.Author_Id == 0) //Create
            {
                _db.Fluent_Author.Add(author);
            }
            else //Update
            {
                _db.Fluent_Author.Update(author);
            }
            _db.SaveChanges();
            
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Fluent_Author author = _db.Fluent_Author.FirstOrDefault(x => x.Author_Id == id);
            if(author is null) return NotFound();

            _db.Fluent_Author.Remove(author);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        
        
        
    }
}
