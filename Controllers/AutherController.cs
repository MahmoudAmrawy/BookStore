using BookStore.Models;
using BookStore.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class AutherController : Controller
    {
        private readonly IBookStoreRepository<Auther> autherRepository;

        public AutherController(IBookStoreRepository<Auther> autherRepository)
        {
            this.autherRepository = autherRepository;
        }
        // GET: AutherController
        public ActionResult Index()
        {
            var authers = autherRepository.List();
            return View(authers);
        }

        // GET: AutherController/Details/5
        public ActionResult Details(int id)
        {
            var auther = autherRepository.Find(id);
            return View(auther);
        }

        // GET: AutherController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AutherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Auther auther)
        {
            try
            {
                autherRepository.Add(auther);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AutherController/Edit/5
        public ActionResult Edit(int id)
        {
            var auther = autherRepository.Find(id);
            return View(auther);
        }

        // POST: AutherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Auther auther)
        {
            try
            {
                autherRepository.Update(id, auther);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AutherController/Delete/5
        public ActionResult Delete(int id)
        {
            var auther = autherRepository.Find(id);
            return View(auther);
        }

        // POST: AutherController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult confirmDelete(int id)
        {
            try
            {
                autherRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
