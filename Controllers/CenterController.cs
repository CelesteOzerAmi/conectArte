using conectArte.Datos;
using conectArte.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            return RedirectToAction("ListCenter");
        }

        public IActionResult ListCenter()
        {
            List<Center> centers = _context.Centers
                .Include(t => t.Coordinator)
                .ToList();
            return View(centers);
        }

        public IActionResult DeleteCenter(int id)
        {
            Center t = _context.Centers.Find(id);
            _context.Centers.Remove(t);
            _context.SaveChanges();
            return RedirectToAction("ListCenter");
        }

        public IActionResult CenterDetails(int id)
        {
            Center c = _context.Centers.Include(c => c.Coordinator)
                        .FirstOrDefault(c => c.Id == id);
            return View(c);
        }

        public IActionResult UpdateCenter(int id)
        {
            Center t = _context.Centers.Find(id);
            List<Coordinator> coordinators = _context.Coordinators.ToList();
            ViewData["Coordinators"] = coordinators;    
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
