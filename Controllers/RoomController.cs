using conectArte.Datos;
using conectArte.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace conectArte.Controllers
{
    public class RoomController : Controller
    {
        private readonly ApplicationDBContext _context;

        public RoomController(ApplicationDBContext context)
        {
            _context = context;
        }

        public IActionResult AddRoom()
        {
            List<Center> centers = _context.Centers.ToList();
            ViewData["Centers"] = centers;
            List<Resource> resources = _context.Resources.ToList();
            ViewData["Resources"] = resources;
            return View();
        }

        [HttpPost]
        public IActionResult AddRoom(Room r)
        {
            _context.Rooms.Add(r);
            _context.SaveChanges();
            foreach(int i in r.ResourcesIds)
            {
                ResourceRoom rr = new ResourceRoom
                {
                    ResourceId = i,
                    RoomName = r.Name,
                    ResourceCount = 1
                };
                _context.Add(rr);
            }
            _context.SaveChanges();
            return RedirectToAction("ListRoom");
        }

        public IActionResult ListRoom()
        {
            List<Room> rooms = _context.Rooms
                .Include(r => r.Center)
                .ToList();
            return View(rooms);
        }

        public IActionResult DeleteRoom(int id)
        {
            Room r = _context.Rooms.Find(id);
            _context.Rooms.Remove(r);
            _context.SaveChanges();
            return RedirectToAction("ListRoom");
        }

        public IActionResult UpdateRoom(int id)
        {
            Room r = _context.Rooms.Find(id);
            List<Center> centers = _context.Centers.ToList();
            ViewData["Centers"] = centers;
            return View(r);
        }

        [HttpPost]
        public IActionResult UpdateRoom(Room t)
        {
            _context.Rooms.Update(t);
            _context.SaveChanges();
            return RedirectToAction("ListRoom");
        }
    }
}
