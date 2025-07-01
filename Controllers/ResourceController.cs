using conectArte.Datos;
using conectArte.Models;
using Microsoft.AspNetCore.Mvc;

namespace conectArte.Controllers
{
    public class ResourceController : Controller
    {
        private readonly ApplicationDBContext _context;

        public ResourceController(ApplicationDBContext context)
        {
            _context = context;
        }

        public IActionResult AddResource()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddResource(Resource t)
        {
            _context.Resources.Add(t);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult ListResource()
        {
            List<Resource> coordinators = _context.Resources.ToList();
            return View(coordinators);
        }

        public IActionResult DeleteResource(int id)
        {
            Resource t = _context.Resources.Find(id);
            _context.Resources.Remove(t);
            _context.SaveChanges();
            return RedirectToAction("ListResource");
        }

        public IActionResult UpdateResource(int id)
        {
            Resource t = _context.Resources.Find(id);
            return View(t);
        }

        [HttpPost]
        public IActionResult UpdateResource(Resource t)
        {
            _context.Resources.Update(t);
            _context.SaveChanges();
            return RedirectToAction("ListResource");
        }
    }
}
