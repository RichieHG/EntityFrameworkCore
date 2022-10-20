using DataAccess.Data;
using DataAccess.FluentConfig;
using Microsoft.AspNetCore.Mvc;
using Model.Models;

namespace Library.Controllers
{
    public class PublisherController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PublisherController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Fluent_Publisher> publishers = _db.Fluent_Publisher.ToList();
            return View(publishers);
        }

        //[HttpPost]
        public IActionResult Upsert(int? id)
        {
            Fluent_Publisher publisher = new Fluent_Publisher();
            
            if(id is not null)
            {
                publisher = _db.Fluent_Publisher.FirstOrDefault(x => x.Publisher_Id == id);
                if (publisher is null) return NotFound();
            }

            return View(publisher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Fluent_Publisher publisher)
        {
            if (!ModelState.IsValid) return View(publisher);
            
            if(publisher.Publisher_Id == 0) //Create
            {
                _db.Fluent_Publisher.Add(publisher);
            }
            else //Update
            {
                _db.Fluent_Publisher.Update(publisher);
            }
            _db.SaveChanges();
            
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Fluent_Publisher publisher = _db.Fluent_Publisher.FirstOrDefault(x => x.Publisher_Id == id);
            if(publisher is null) return NotFound();

            _db.Fluent_Publisher.Remove(publisher);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        
    }
}
