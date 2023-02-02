using Lab_DZ_BooksLibrary_7.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab_DZ_BooksLibrary_7.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Book> repository;
        private readonly IWebHostEnvironment hostEnvironment;

        public HomeController(IWebHostEnvironment environment, IRepository<Book> repository)
        {
            this.repository = repository;
            this.hostEnvironment = environment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult BookInfo()
        {
            IEnumerable<Book> books = repository.GetAll();
            return View(books);
        }

        public IActionResult Details(int id)
        {
            Book? book = repository.Get(id);
            return View((Object)book!.AboutBook);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Book book, IFormFile filePath)
        {
            if (!ModelState.IsValid)
            {
                return Content("<html><h2 style='color: red'>There aren`t all filled fields!</h2><html>", "text/html");
            }
            string filename = $"/images/{filePath.FileName}";
            string fileFullpath = hostEnvironment.WebRootPath + filename;
            using(FileStream fs = new (fileFullpath, FileMode.Create, FileAccess.Write))
            {
                filePath.CopyTo(fs);
                book.FilePath = filename;
            }
            repository.Add(book);
            return RedirectToAction("BookInfo");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return Content("<html><h2 style='color: red;'>You must provide id of book!</h2></html>", "text/html");
            }
            Book? book = repository.Get(id.Value);
            return View(book);
        }
        [HttpPost]
        public IActionResult Edit(Book book, IFormFile filePath)
        {
            if (ModelState.IsValid)
            {
                if(filePath != null)
                {
                    string filename = $"/images/{filePath.FileName}";
                    string fileFullpath = hostEnvironment.WebRootPath + filename;
                    using (FileStream fs = new FileStream(fileFullpath, FileMode.Create, FileAccess.Write))
                    {
                        filePath.CopyTo(fs);
                        book.FilePath = filename;
                    }
                }
                repository.Edit(book);
                return RedirectToAction("BookInfo");
            }
            return View(book);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return Content("<html><h2 style='color: red;'>You must provide id of book!</h2></html>", "text/html");
            }
            Book? book = repository.Get(id.Value);
            return View(book);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {
            if (repository.Delete(id!.Value))
            {
                return RedirectToAction("BookInfo");
            }
            else
            {
                return Content($"<html><h2 style='color: red;'>The book with id = {id} is not exists!</h2></html>", "text/html");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}