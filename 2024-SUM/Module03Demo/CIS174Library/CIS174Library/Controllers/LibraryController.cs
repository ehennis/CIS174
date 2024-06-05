using CIS174Library.Data;
using CIS174Library.Models;
using CIS174Library.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CIS174Library.Controllers
{
    public class LibraryController : Controller
    {
        // Step 3
        private LibraryContext context;
        //private ILibraryRepository libraryRepository;

        //public MovieController(MovieContext ctx)

        public LibraryController(LibraryContext ctx)
        {
            context = ctx;
        }
        //public LibraryController(ILibraryRepository repository)
        //{
        //    //context = ctx
        //    this.libraryRepository = repository;
        //}

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
            // Step 3
            var book = this.context.Books.Find(id);
            //var book = this.libraryRepository.Find(id);
            if (book.BookId == 10)
            {
                book.Year = -1;
            }
            return View(book);
        }

        //[HttpPost]
        //public IActionResult Edit(Book book)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (book.BookId == 0)
        //        {
        //            // Step 3
        //            this.context.Books.Add(book);
        //            //this.libraryRepository.InsertBook(book);
        //        }
        //        else
        //        {
        //            // Step 3
        //            this.context.Books.Update(book);
        //            //this.libraryRepository.UpdateBook(book);
        //        }
        //        // Step 3
        //        this.context.SaveChanges();
        //        //this.libraryRepository.Save();
        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        ViewBag.Action = (book.BookId == 0) ? "Add" : "Edit";
        //        return View(book);
        //    }
        //}

        // Step 12
        [HttpPost]
        public IActionResult Edit(Book book)
        {
            // Null Exception
            book = null;
            if (ModelState.IsValid)
            {
                if (book.BookId == 0)
                {
                    this.context.Books.Add(book);
                    //this.libraryRepository.InsertBook(book);
                }
                else
                {
                    this.context.Books.Update(book);
                    //this.libraryRepository.UpdateBook(book);
                }
                this.context.SaveChanges();
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
            // Step 3
            var book = this.context.Books.Find(id);
            //var book = this.libraryRepository.Find(id);
            return View(book);
        }

        [HttpPost]
        public IActionResult Delete(Book book)
        {
            // Step 3
            context.Books.Remove(book);
            context.SaveChanges();
            //this.libraryRepository.DeleteBook(book);
            return RedirectToAction("Index", "Home");
        }
    }
}
