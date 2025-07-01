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
            var coordinators = _context.Coordinators.ToList();  

            var viewModel = new CenterViewModel
            {
                Center = new Center(), 
                Coordinators = coordinators
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddCenter(CenterViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Coordinators = _context.Coordinators.ToList();
                return View(viewModel);
            }

            var selectedCoordinator = _context.Coordinators
                .FirstOrDefault(c => c.Id == viewModel.Center.Coordinator.Id);

            if (selectedCoordinator == null)
            {
                ModelState.AddModelError("Center.Coordinator.Id", "Coordinador inválido.");
                viewModel.Coordinators = _context.Coordinators.ToList();
                return View(viewModel);
            }

            viewModel.Center.Coordinator = selectedCoordinator;

            _context.Centers.Add(viewModel.Center);
            _context.SaveChanges();

            return RedirectToAction("Index");
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
