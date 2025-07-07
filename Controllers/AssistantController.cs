using Microsoft.AspNetCore.Mvc;
using conectArte.Datos;
using conectArte.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult AddAssistant(Assistant a)
        {
            _context.Assistants.Add(a);
            _context.SaveChanges();
            // Crear el registro en WorkshopAssistant
            foreach(int i in a.WorkshopIds)
            {
                WorkshopAssistant wa = new WorkshopAssistant
                {
                    AssistantId = a.Id,
                    WorkshopId = i
                };
                _context.WorkshopAssistants.Add(wa);
            }
            _context.SaveChanges();
            return RedirectToAction("ListAssistant");
        }

        public IActionResult ListAssistant()
        {
            List<Assistant> assistants = _context.Assistants
                .Include(a => a.Center)
                .ToList();
            ;
            return View(assistants);
        }

        public IActionResult AssistantDetails(int id)
        {
            Assistant r = _context.Assistants.Include(r => r.Center)
                                    .Include(r => r.WorkshopsAttended)
                                    .ThenInclude(rr => rr.Workshop)
                                    .FirstOrDefault(r => r.Id == id);
            return View(r);
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
            Assistant a = _context.Assistants
                .Include(a => a.WorkshopsAttended)
                .FirstOrDefault(a => a.Id == id);
            ViewData["Centers"] = _context.Centers.ToList();
            ViewData["Workshops"] = _context.Workshops.ToList();
            return View(a);
        }

        [HttpPost]
        public IActionResult UpdateAssistant(Assistant a)
        {
            _context.Assistants.Update(a);
            _context.SaveChanges();
            List<WorkshopAssistant> previous = _context.Set<WorkshopAssistant>()
                .Where(rr => rr.AssistantId == a.Id)
                .ToList();

            if (a.WorkshopIds != null)
            {
                foreach (int id in a.WorkshopIds)
                {
                    WorkshopAssistant wk = previous.Find(wk => wk.WorkshopId == id);
                    if (wk != null)
                    {
                        previous.Remove(wk);
                    }
                    else
                    {
                        WorkshopAssistant rr = new WorkshopAssistant { WorkshopId = id, AssistantId = a.Id};
                        _context.Add(rr);
                    }
                }
            }
            _context.Set<WorkshopAssistant>().RemoveRange(previous);
            _context.SaveChanges();
            return RedirectToAction("ListAssistant");
        }

        public IActionResult AssignScore(int AssistantId, int WorkshopId)
        {

            ViewData["Workshop"] = _context.Workshops.Find(WorkshopId);
            ViewData["Assistant"] = _context.Assistants.Find(AssistantId);
            WorkshopAssistant wka = _context.Set<WorkshopAssistant>()
                .FirstOrDefault(wk => wk.AssistantId == AssistantId && wk.WorkshopId == WorkshopId);
            return View(wka);
        }

        [HttpPost]
        public IActionResult AssignScore(int AssistantId, int WorkshopId, int Rating)
        {
            WorkshopAssistant wa = _context.Set<WorkshopAssistant>()
                .FirstOrDefault(w => w.AssistantId == AssistantId && w.WorkshopId == WorkshopId);
           wa.Rating = Rating;
            _context.WorkshopAssistants.Update(wa);
            _context.SaveChanges();
            return RedirectToAction("AssistantDetails", new { id = wa.AssistantId });
        }

        [HttpPost]
        public IActionResult DeleteAttendedWorkshop(int AssistantId, int WorkshopId)
        {
            WorkshopAssistant resroom = _context.Set<WorkshopAssistant>()
                        .FirstOrDefault(rr => rr.AssistantId == AssistantId && rr.WorkshopId == WorkshopId);
            if (resroom != null)
            {
                _context.Set<WorkshopAssistant>().Remove(resroom);
                _context.SaveChanges();
            }
            return RedirectToAction("AssistantDetails", new { id = AssistantId });
        }
    }
} 