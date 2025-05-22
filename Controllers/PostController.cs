using Microsoft.AspNetCore.Mvc;
using PrimarieApp.Models;
using PrimarieApp.Services;

namespace PrimarieApp.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _service;

        public PostController(IPostService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var posturi = _service.GetAll();
            return View(posturi);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Post post)
        {
            _service.Add(post);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var post = _service.GetById(id);
            if (post == null)
                return NotFound();

            return View(post);
        }

        [HttpPost]
        public IActionResult Edit(Post post)
        {
            _service.Update(post);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var post = _service.GetById(id);
            if (post == null)
                return NotFound();

            return View(post);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Pagina(int id)
        {
            var post = _service.GetById(id);
            if (post == null)
                return NotFound();

            return View("Pagina", post);
        }
    }
}
