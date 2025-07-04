using Microsoft.AspNetCore.Mvc;
using conectArte.Datos;
using conectArte.Models;
using System.Collections.Generic;

namespace conectArte.Controllers
{
    public class WorkshopController : Controller
    {
        private readonly ApplicationDBContext _context;

        public WorkshopController(ApplicationDBContext context)
        {
            _context = context;
        }

        public IActionResult AddWorkshop()
        {
            ViewData["Teachers"] = _context.Teachers.ToList();
            ViewData["Rooms"] = _context.Rooms.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddWorkshop(Workshop w)
        {
            _context.Workshops.Add(w);
            _context.SaveChanges();
            return RedirectToAction("ListWorkshop");
        }

        public IActionResult ListWorkshop()
        {
            List<Workshop> workshops = _context.Workshops.ToList();
            return View(workshops);
        }

        public IActionResult DeleteWorkshop(int id)
        {
            Workshop w = _context.Workshops.Find(id);
            _context.Workshops.Remove(w);
            _context.SaveChanges();
            return RedirectToAction("ListWorkshop");
        }

        public IActionResult UpdateWorkshop(int id)
        {
            Workshop w = _context.Workshops.Find(id);
            ViewData["Teachers"] = _context.Teachers.ToList();
            ViewData["Rooms"] = _context.Rooms.ToList();
            return View(w);
        }

        [HttpPost]
        public IActionResult UpdateWorkshop(Workshop w)
        {
            _context.Workshops.Update(w);
            _context.SaveChanges();
            return RedirectToAction("ListWorkshop");
        }
    }
} 