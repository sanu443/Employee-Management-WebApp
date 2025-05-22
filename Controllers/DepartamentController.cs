using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrimarieApp.Models;
using PrimarieApp.Services;

namespace PrimarieApp.Controllers
{
    public class DepartamentController : Controller
    {
        private readonly IDepartamentService _service;

        public DepartamentController(IDepartamentService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var departamente = _service.GetAll();
            return View(departamente);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Departament departament)
        {
            _service.Add(departament);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var departament = _service.GetById(id);
            if (departament == null)
                return NotFound();

            return View(departament);
        }

        [HttpPost]
        public IActionResult Edit(Departament departament)
        {
            _service.Update(departament);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var departament = _service.GetById(id);
            if (departament == null)
                return NotFound();

            return View(departament);
        }

        // 🔴 Numele metodei = ruta => trebuie să fie "DeleteConfirmed"
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Pagina(int id)
        {
            var departament = _service.GetById(id);

            if (departament == null)
                return NotFound();

            return View(departament);
        }
    }
}
