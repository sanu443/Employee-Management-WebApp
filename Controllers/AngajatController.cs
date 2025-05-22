using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PrimarieApp.Models;
using PrimarieApp.Services;

namespace PrimarieApp.Controllers
{
    public class AngajatController : Controller
    {
        private readonly IAngajatService _service;
        private readonly IPostService _postService;
        private readonly IDepartamentService _departamentService;

        public AngajatController(
            IAngajatService service,
            IPostService postService,
            IDepartamentService departamentService)
        {
            _service = service;
            _postService = postService;
            _departamentService = departamentService;
        }

        public IActionResult Index(string tip, string termen)
        {
            var angajati = _service.GetAll();

            if (!string.IsNullOrEmpty(termen))
            {
                termen = termen.ToLower();

                if (tip == "angajat")
                {
                    angajati = angajati.Where(a =>
                        (a.Nume + " " + a.Prenume).ToLower().Contains(termen)
                    ).ToList();
                }
                else if (tip == "post")
                {
                    angajati = angajati.Where(a => a.Post != null &&
                        a.Post.NumePost.ToLower().Contains(termen)
                    ).ToList();
                }
                else if (tip == "departament")
                {
                    angajati = angajati.Where(a => a.Departament != null &&
                        a.Departament.Nume.ToLower().Contains(termen)
                    ).ToList();
                }
            }

            ViewBag.Tip = tip;
            ViewBag.Termen = termen;

            return View(angajati);
        }

        public IActionResult Create()
        {
            ViewBag.Posturi = new SelectList(_postService.GetAll(), "Id", "NumePost");
            ViewBag.Departamente = new SelectList(_departamentService.GetAll(), "Id", "Nume");

            var model = new Angajat
            {
                DataAngajare = DateTime.UtcNow.Date // trimite ziua curentă cu Kind=Utc
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(Angajat angajat)
        {
            angajat.AngajatCurent = true;
            _service.Add(angajat);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var angajat = _service.GetById(id);
            if (angajat == null)
                return NotFound();
            ViewBag.Posturi = new SelectList(_postService.GetAll(), "Id", "NumePost", angajat.PostId);
            ViewBag.Departamente = new SelectList(_departamentService.GetAll(), "Id", "Nume", angajat.DepartamentId);

            return View(angajat);
        }

        [HttpPost]
        public IActionResult Edit(Angajat angajat)
        {
            angajat.AngajatCurent = true;
            _service.Update(angajat);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var angajat = _service.GetById(id);
            if (angajat == null)
                return NotFound();

            return View(angajat);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Pagina(int id)
        {
            var angajat = _service.GetById(id);
            if (angajat == null)
                return NotFound();

            return View("Pagina", angajat);
        }
    }
}
