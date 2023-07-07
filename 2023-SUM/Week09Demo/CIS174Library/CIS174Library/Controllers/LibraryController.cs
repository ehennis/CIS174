using CIS174Library.Data;
using CIS174Library.Models;
using CIS174Library.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CIS174Library.Controllers
{
    public class LibraryController : Controller
    {
        private LibraryContext context;
        //private ILibraryRepository libraryRepository;

        public LibraryController(LibraryContext ctx)
        //public LibraryController(ILibraryRepository repository)
        {
            context = ctx;
            //this.libraryRepository = repository;
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Book());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var movie = this.context.Books.Find(id);// this.libraryRepository.Find(id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                if (book.BookId == 0)
                {
                    context.Books.Add(book);
                    //this.libraryRepository.InsertBook(book);
                }
                else
                {
                    context.Books.Update(book);
                    //this.libraryRepository.UpdateBook(book);
                }
                context.SaveChanges();
                //this.libraryRepository.Save();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (book.BookId == 0) ? "Add" : "Edit";
                return View(book);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = context.Books.Find(id);// this.libraryRepository.Find(id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(Book book)
        {
            context.Books.Remove(book);
            context.SaveChanges();
            //this.libraryRepository.DeleteBook(book);
            return RedirectToAction("Index", "Home");
        }
    }
}
