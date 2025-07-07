using conectArte.Datos;
using conectArte.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Cryptography;

namespace conectArte.Controllers
{
    public class FilterController : Controller
    {
        private readonly ApplicationDBContext _context;
        public FilterController(ApplicationDBContext context)
        {
            this._context = context;
        }

        public IActionResult NoResourceWorkshopAssistants()
        {
            List<Workshop> workshops = _context.Workshops
                .Where(w => w.Room.ResourcesRooms.Any())
                .ToList();

            List<WorkshopAssistant> workasst = _context.WorkshopAssistants
                .Include(aw => aw.Assistant)
                .Include(w => w.Workshop)
                .Where(w =>!workshops.Contains(w.Workshop))
                .ToList();

            List<Assistant> assistant = new List<Assistant>();

            if (workasst.Count > 0)
            {
                
                foreach(WorkshopAssistant wa in workasst)
                {
                    assistant.Add(wa.Assistant);
                }
            }

            return View(assistant);
        }


        public IActionResult AssistantsForWorkshopAttendance()
        {
            List<Assistant> assistants = _context.Assistants
                .Include(a => a.Center)
                .Include(a => a.WorkshopsAttended)
                    .ThenInclude(aw => aw.Workshop)
                .Where(a => a.WorkshopsAttended.Count > 0)
                .OrderByDescending(aa => aa.WorkshopsAttended.Count())
                .Take(5)
                .ToList();            
            return View(assistants);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
