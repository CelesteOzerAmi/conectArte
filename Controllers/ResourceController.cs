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
        public IActionResult AddResource(Resource r)
        {
            _context.Resources.Add(r);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult ListResource()
        {
            List<Resource> resources = _context.Resources.ToList();
            return View(resources);
        }

        public IActionResult DeleteResource(int id)
        {
            Resource r = _context.Resources.Find(id);
            _context.Resources.Remove(r);
            _context.SaveChanges();
            return RedirectToAction("ListResource");
        }

        public IActionResult UpdateResource(int id)
        {
            Resource r = _context.Resources.Find(id);
            return View(r);
        }

        [HttpPost]
        public IActionResult UpdateResource(Resource r)
        {
            _context.Resources.Update(r);
            _context.SaveChanges();
            return RedirectToAction("ListResource");
        }
    }
}
