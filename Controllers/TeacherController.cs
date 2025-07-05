using Microsoft.AspNetCore.Mvc;
using conectArte.Datos;
using conectArte.Models;

namespace conectArte.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ApplicationDBContext _context;

        public TeacherController(ApplicationDBContext context)
        {
            _context = context;
        }

        public IActionResult AddTeacher()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTeacher(Teacher t)
        {

            if (!ModelState.IsValid)
            {
                return View(t);
            }
            _context.Teachers.Add(t);
            _context.SaveChanges();
            return RedirectToAction("ListTeacher");
        }

        public IActionResult ListTeacher()
        {
            List<Teacher> t = _context.Teachers.ToList();
            return View(t);
        }

        public IActionResult DeleteTeacher(int id)
        {
            Teacher t = _context.Teachers.Find(id);
            _context.Teachers.Remove(t);
            _context.SaveChanges();
            return RedirectToAction("ListTeacher");
        }

        public IActionResult UpdateTeacher(int id)
        {
            Teacher t = _context.Teachers.Find(id);
            return View(t);
        }

        [HttpPost]
        public IActionResult UpdateTeacher(Teacher t)
        {
            _context.Teachers.Update(t);
            _context.SaveChanges();
            return RedirectToAction("ListTeacher");
        }
    }
}
