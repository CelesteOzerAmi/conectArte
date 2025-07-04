using Microsoft.AspNetCore.Mvc;
using conectArte.Datos;
using conectArte.Models;
using System.Collections.Generic;
using System.Linq;

namespace conectArte.Controllers
{
    public class AssistantController : Controller
    {
        private readonly ApplicationDBContext _context;

        public AssistantController(ApplicationDBContext context)
        {
            _context = context;
        }

        public IActionResult AddAssistant(int? CenterId)
        {
            ViewData["Centers"] = _context.Centers.ToList();
            if (CenterId.HasValue)
            {
                ViewData["Workshops"] = _context.Workshops
                    .Where(w => w.Room != null && w.Room.CenterId == CenterId.Value)
                    .ToList();
            }
            else
            {
                ViewData["Workshops"] = new List<Workshop>();
            }
            Assistant model = new Assistant();
            if (CenterId.HasValue) model.CenterId = CenterId.Value;
            return View(model);
        }

        [HttpPost]
        public IActionResult AddAssistant(Assistant a, int WorkshopId, double Rating)
        {
            _context.Assistants.Add(a);
            _context.SaveChanges();
            // Crear el registro en WorkshopAssistant
            WorkshopAssistant wa = new WorkshopAssistant
            {
                AssistantId = a.Id,
                WorkshopId = WorkshopId,
                Rating = Rating
            };
            _context.WorkshopAssistants.Add(wa);
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