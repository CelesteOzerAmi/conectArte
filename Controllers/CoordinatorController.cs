using conectArte.Datos;
using conectArte.Models;
using Microsoft.AspNetCore.Mvc;

namespace conectArte.Controllers
{
    public class CoordinatorController : Controller
    {
        private readonly ApplicationDBContext _context;

        public CoordinatorController(ApplicationDBContext context)
        {
            _context = context;
        }

        public IActionResult AddCoordinator()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCoordinator(Coordinator c)
        {
            _context.Coordinators.Add(c);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult ListCoordinator()
        {
            List<Coordinator> coordinators = _context.Coordinators.ToList();
            return View(coordinators);
        }

        public IActionResult DeleteCoordinator(int id)
        {
            Coordinator c = _context.Coordinators.Find(id);
            _context.Coordinators.Remove(c);
            _context.SaveChanges();
            return RedirectToAction("ListCoordinator");
        }

        public IActionResult UpdateCoordinator(int id)
        {
            Coordinator c = _context.Coordinators.Find(id);
            return View(c);
        }

        [HttpPost]
        public IActionResult UpdateCoordinator(Coordinator c)
        {
            _context.Coordinators.Update(c);
            _context.SaveChanges();
            return RedirectToAction("ListCoordinator");
        }
    }
}
