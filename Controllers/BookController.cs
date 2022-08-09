using BookStore.Models;
using BookStore.Models.Repositories;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookStoreRepository<Book> bookRepository;
        private readonly IBookStoreRepository<Auther> autherRepository;
#pragma warning disable CS0618 // Type or member is obsolete
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting;
#pragma warning restore CS0618 // Type or member is obsolete

        [Obsolete]
        public BookController(IBookStoreRepository<Book> bookRepository, 
            IBookStoreRepository<Auther> autherRepository,
            Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting)
        {
            this.bookRepository = bookRepository;
            this.autherRepository = autherRepository;
            this.hosting = hosting;
        }

        // GET: BookController
        public ActionResult Index()
        {
            var books = bookRepository.List();
            return View(books);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            var book = bookRepository.Find(id);
            return View(book);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            var model = new BookAutherViewModel
            {
                authers = fillSelectList()
            };
            return View(model);
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookAutherViewModel model)
        {
            try
            {
                string fileName = string.Empty;
                if(model.File != null)
                {
                    string uploads = Path.Combine(hosting.WebRootPath, "Uploads");
                    fileName = model.File.FileName;
                    string fullPath = Path.Combine(uploads, fileName);
                    model.File.CopyTo(new FileStream(fullPath, FileMode.Create));
                }

                if(model.AutherId == -1 )
                {
                    ViewBag.Message = "please select an auther from the list";

                    var vmodel = new BookAutherViewModel
                    {
                        authers = fillSelectList()
                    };

                    return View(vmodel);
                }
                var auther = autherRepository.Find(model.AutherId);
                Book book = new Book
                {
                    IdBook = model.BookId,
                    Title = model.Title,
                    Description = model.Description,
                    Auther = auther,
                    ImgUrl= fileName
                };
                bookRepository.Add(book);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            var book = bookRepository.Find(id);
            var autherId = book.Auther == null ? book.Auther.IdAuther = 0 : book.Auther.IdAuther;
            var viewModel = new BookAutherViewModel
            {
                BookId = book.IdBook,
                Title = book.Title,
                Description = book.Description,
                AutherId = autherId,
                authers = autherRepository.List().ToList(),
                ImgUrl = book.ImgUrl
            };
            return View(viewModel);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookAutherViewModel viewModel)
        {
            try
            {
                string fileName = string.Empty;
                if(viewModel.File != null)
                {
                    string uploads = Path.Combine(hosting.WebRootPath, "Uploads");
                    fileName = viewModel.File.FileName;
                    string fullPath = Path.Combine(uploads, fileName);

                    //delete the old file
                    string oldFile = bookRepository.Find(viewModel.BookId).ImgUrl;
                    string fullOldPath = Path.Combine(uploads, oldFile);

                    if(fullPath != fullOldPath)
                    {
                        System.IO.File.Delete(fullOldPath);
                        //save the new file
                        viewModel.File.CopyTo(new FileStream(fullPath, FileMode.Create));
                    }

                }
                var auther = autherRepository.Find(viewModel.AutherId);
                Book book = new Book
                {
                    Title = viewModel.Title,
                    Description = viewModel.Description,
                    Auther = auther,
                    ImgUrl = fileName
                };
                bookRepository.Update(viewModel.BookId, book);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            var book = bookRepository.Find(id);
            return View(book);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult confirmDelete(int id)
        {
            try
            {
                bookRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public List<Auther> fillSelectList()
        {
            var authers = autherRepository.List().ToList();
            authers.Insert(0, new Auther { IdAuther = -1, NameAuther = "---- please select an auther ----" });
            return authers;
        }
    }
}
