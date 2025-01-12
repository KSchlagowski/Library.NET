using Library.Controllers.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDBContext _db;

        public BookController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Book> bookList = _db.Books.ToList();
            return View(bookList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _db.Books.Add(book);
                _db.SaveChanges();
                return RedirectToAction("Index", "Book");
            }
            return View(book);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Book bookFromDB = _db.Books.Find(id);
            if (bookFromDB == null)
            {
                return NotFound();
            }
            return View(bookFromDB);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _db.Books.Update(book);
                _db.SaveChanges();
                return RedirectToAction("Index", "Book");
            }
            return View(book);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Book bookFromDB = _db.Books.Find(id);
            if (bookFromDB == null)
            {
                return NotFound();
            }
            return View(bookFromDB);
        }

        [HttpPost]
        public IActionResult Delete(Book book)
        {
            _db.Books.Remove(book);
            _db.SaveChanges();
            return RedirectToAction("Index", "Book");
        }
    }
}
