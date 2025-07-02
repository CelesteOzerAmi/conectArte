using conectArte.Datos;
using conectArte.Models;
using Microsoft.AspNetCore.Mvc;

namespace conectArte.Controllers
{
    public class CenterController : Controller
    {
        private readonly ApplicationDBContext _context;

        public CenterController(ApplicationDBContext context)
        {
            _context = context;
        }

        public IActionResult AddCenter()
        {
            List<Coordinator> coordinators = _context.Coordinators.ToList();
            ViewData["Coordinators"] = coordinators;
            return View();
        }

        [HttpPost]
        public IActionResult AddCenter(Center c)
        {
            _context.Centers.Add(c);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult ListCenter()
        {
            List<Center> centers = _context.Centers.ToList();
            return View(centers);
        }

        public IActionResult DeleteCenter(int id)
        {
            Center t = _context.Centers.Find(id);
            _context.Centers.Remove(t);
            _context.SaveChanges();
            return RedirectToAction("ListCenter");
        }

        public IActionResult UpdateCenter(int id)
        {
            Center t = _context.Centers.Find(id);
            return View(t);
        }

        [HttpPost]
        public IActionResult UpdateCenter(Center t)
        {
            _context.Centers.Update(t);
            _context.SaveChanges();
            return RedirectToAction("ListCenter");
        }
    }
}
