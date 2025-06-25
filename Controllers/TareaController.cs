using Microsoft.AspNetCore.Mvc;
using conectArte.Datos;
using conectArte.Models;

namespace conectArte.Controllers
{
    public class TareaController : Controller
    {
        private readonly ApplicationDBContext _context;

        public TareaController(ApplicationDBContext context)
        {
            _context = context;
        }

        public IActionResult AddTarea()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTarea(Tarea t)
        {
            _context.Tareas.Add(t);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult ListTarea()
        {
            List<Tarea> tareas = _context.Tareas.ToList();
            return View(tareas);
        }
            
        public IActionResult DeleteTarea(int id)
        {
            Tarea t = _context.Tareas.Find(id);
            _context.Tareas.Remove(t);
            _context.SaveChanges();
            return RedirectToAction("ListTarea");
        }

        public IActionResult UpdateTarea(int id)
        {
            Tarea t = _context.Tareas.Find(id);
            return View(t);
        }

        [HttpPost]
        public IActionResult UpdateTarea(Tarea t)
        {
            _context.Tareas.Update(t);
            _context.SaveChanges();
            return RedirectToAction("ListTarea");
        }
    }
}
