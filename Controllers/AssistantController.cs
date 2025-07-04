using Microsoft.AspNetCore.Mvc;
using conectArte.Datos;
using conectArte.Models;
using System.Collections.Generic;

namespace conectArte.Controllers
{
    public class AssistantController : Controller
    {
        private readonly ApplicationDBContext _context;

        public AssistantController(ApplicationDBContext context)
        {
            _context = context;
        }

        public IActionResult AddAssistant()
        {
            ViewData["Centers"] = _context.Centers.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddAssistant(Assistant a)
        {
            _context.Assistants.Add(a);
            _context.SaveChanges();
            return RedirectToAction("ListAssistant");
        }

        public IActionResult ListAssistant()
        {
            List<Assistant> assistants = _context.Assistants.ToList();
            return View(assistants);
        }

        public IActionResult DeleteAssistant(int id)
        {
            Assistant a = _context.Assistants.Find(id);
            _context.Assistants.Remove(a);
            _context.SaveChanges();
            return RedirectToAction("ListAssistant");
        }

        public IActionResult UpdateAssistant(int id)
        {
            Assistant a = _context.Assistants.Find(id);
            ViewData["Centers"] = _context.Centers.ToList();
            return View(a);
        }

        [HttpPost]
        public IActionResult UpdateAssistant(Assistant a)
        {
            _context.Assistants.Update(a);
            _context.SaveChanges();
            return RedirectToAction("ListAssistant");
        }
    }
} 