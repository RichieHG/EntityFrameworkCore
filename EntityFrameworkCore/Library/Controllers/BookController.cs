using DataAccess.Data;
using DataAccess.FluentConfig;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Model.Models;
using Model.ViewModels;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Fluent_Book> books = _db.Fluent_Book.Include(x => x.Fluent_Publisher)
                                        .Include(x => x.Fluent_BooksAuthors)
                                        .ThenInclude(x => x.Fluent_Author).ToList();

            //List<Fluent_Book> books = _db.Fluent_Book.ToList();

            //foreach (var book in books)
            //{
            //    //LeastEfficient
            //    //book.Fluent_Publisher = _db.Fluent_Publisher.FirstOrDefault(x => x.Publisher_Id == book.Publisher_Id);

            //    //Explicit Loading (MoreEfficient)
            //    _db.Entry(book).Reference(x => x.Fluent_Publisher).Load();
            //    _db.Entry(book).Collection(x => x.Fluent_BooksAuthors).Load();
            //    foreach(var bookAuth in book.Fluent_BooksAuthors)
            //    {
            //        _db.Entry(bookAuth).Reference(x => x.Fluent_Author).Load();

            //    }
            //}
            return View(books);
        }

        //[HttpPost]
        public IActionResult Upsert(int? id)
        {
            BookVM book = new BookVM();

            book.PublisherList = LoadPublishers();

            if (id is not null)
            {
                book.Book = _db.Fluent_Book.FirstOrDefault(x => x.Book_Id == id);
                if (book is null) return NotFound();
            }

            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(BookVM bookVM)
        {
            //if (!ModelState.IsValid)
            //{
            //    bookVM.PublisherList = LoadPublishers();
            //    return View(bookVM);
            //}

            if (bookVM.Book.Book_Id == 0) //Create
            {
                _db.Fluent_Book.Add(bookVM.Book);
            }
            else //Update
            {
                _db.Fluent_Book.Update(bookVM.Book);
            }
            _db.SaveChanges();
            
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Fluent_Book book = _db.Fluent_Book.FirstOrDefault(x => x.Book_Id == id);
            if(book is null) return NotFound();

            _db.Fluent_Book.Remove(book);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            BookVM book = new BookVM();

            if (id is not null)
            {
                book.Book = _db.Fluent_Book.Include(x => x.Fluent_BookDetails).FirstOrDefault(x => x.Book_Id == id);
                if (book.Book is null) return NotFound();
            }

            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(BookVM bookVM)
        {
            //if (!ModelState.IsValid)
            //{
            //    bookVM.PublisherList = LoadPublishers();
            //    return View(bookVM);
            //}

            if (bookVM.Book.Fluent_BookDetails.BookDetails_Id == 0) //Create
            {
                _db.Fluent_BookDetails.Add(bookVM.Book.Fluent_BookDetails);
                _db.SaveChanges();

                Fluent_Book currentBook = _db.Fluent_Book.FirstOrDefault(x => x.Book_Id == bookVM.Book.Book_Id); 
                if(currentBook is null) return NotFound();

                currentBook.BookDetails_Id = bookVM.Book.Fluent_BookDetails.BookDetails_Id;
            }
            else //Update
            {
                _db.Fluent_BookDetails.Update(bookVM.Book.Fluent_BookDetails);
            }
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult PlayGround()
        {
            //var bookTemp = _db.Fluent_Book.FirstOrDefault();
            //bookTemp.Price = 100;

            //var bookCollection = _db.Fluent_Book;
            //double totalPrice = 0;

            //foreach (var book in bookCollection)
            //{
            //    totalPrice += book.Price;
            //}

            //var bookList = _db.Fluent_Book.ToList();
            //foreach (var book in bookList)
            //{
            //    totalPrice += book.Price;
            //}

            //var bookCollection2 = _db.Fluent_Book;
            //var bookCount1 = bookCollection2.Count();

            //var bookCount2 = _db.Fluent_Book.Count();

            //IEnumerable<Fluent_Book> BookList1 = _db.Fluent_Book;
            //var FilteredBook1 = BookList1.Where(b => b.Price > 1000).ToList();

            //IQueryable<Fluent_Book> BookList2 = _db.Fluent_Book;
            //var fileredBook2 = BookList2.Where(b => b.Price > 1000).ToList();

            //IEnumerable<Fluent_Book> BookList10 = _db.Fluent_Book.Where(b => b.Price > 1000).ToList();

            //IQueryable<Fluent_Book> BookList20 = _db.Fluent_Book.Where(b => b.Price > 1000);
            //IEnumerable<Fluent_Book> bookListFilter = BookList20.ToList();

            //var BookList3 = _db.Fluent_Book.Where(b => b.Price > 1000).ToList();


            var category = _db.Category.FirstOrDefault();
            _db.Entry(category).State = EntityState.Modified;

            _db.SaveChanges();

            //Updating Related Data
            var bookTemp1 = _db.Fluent_Book.Include(b => b.Fluent_BookDetails).FirstOrDefault(b => b.Book_Id == 3);
            bookTemp1.Fluent_BookDetails.NumberOfChapters = 2222;
            //bookTemp1.Price = 12345;
            _db.Fluent_Book.Update(bookTemp1);
            _db.SaveChanges();


            var bookTemp2 = _db.Fluent_Book.Include(b => b.Fluent_BookDetails).FirstOrDefault(b => b.Book_Id == 3);
            bookTemp2.Fluent_BookDetails.Weight = 3333;
            //bookTemp2.Price = 123456;
            _db.Fluent_Book.Attach(bookTemp2);
            _db.SaveChanges();


            return RedirectToAction(nameof(Index));
        }

        public IActionResult ManageAuthors(int id)
        {
            BookAuthorVM bookAuthor = new()
            {
                BookAuthorList = _db.Fluent_BookAuthor.Include(b => b.Fluent_Author)
                                    .Include(b => b.Fluent_Book)
                                    .Where(x => x.Book_Id == id).ToList(),
                BookAuthor = new()
                {
                    Book_Id = id
                },
                Book = _db.Fluent_Book.FirstOrDefault(x => x.Book_Id == id)
            };

            List<int> tempListOfAssignedAuthors = bookAuthor.BookAuthorList.Select(x => x.Author_Id).ToList();

           bookAuthor.AuthorList = _db.Fluent_Author.Where(x => !tempListOfAssignedAuthors.Contains(x.Author_Id))
                                                        .Select(x => new SelectListItem()
                                                        {
                                                            Text = x.FullName,
                                                            Value = x.Author_Id.ToString()
                                                        }).ToList();

            return View(bookAuthor);
        }


        [HttpPost]
        //[ValidateAntiForgeryToken] //Review the functionality of this
        public IActionResult ManageAuthors(BookAuthorVM bookAuthorVM)
        {

            if (bookAuthorVM.BookAuthor.Book_Id != 0 && bookAuthorVM.BookAuthor.Author_Id != 0) //Create
            {
                _db.Fluent_BookAuthor.Add(bookAuthorVM.BookAuthor);
                _db.SaveChanges();

            }
            return RedirectToAction(nameof(ManageAuthors), new {@id = bookAuthorVM.BookAuthor.Book_Id});
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult RemoveAuthors(BookAuthorVM bookAuthorVM, int authorId)
        {
            int bookId = bookAuthorVM.Book.Book_Id;
            Fluent_BookAuthor bookAuthor = _db.Fluent_BookAuthor.FirstOrDefault(x => x.Author_Id == authorId && x.Book_Id == bookId);
            if (bookAuthor == null) return NotFound();

            _db.Fluent_BookAuthor.Remove(bookAuthor);
            _db.SaveChanges();

            return RedirectToAction(nameof(ManageAuthors), new { @id = bookId });
        }
        private IEnumerable<SelectListItem> LoadPublishers()
        {
            return _db.Fluent_Publisher.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Publisher_Id.ToString()
            });
        }
    }
}
