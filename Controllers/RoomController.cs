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
            ViewData["Centers"] = _context.Centers.ToList();
            ViewData["Resources"] = _context.Resources.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddRoom(Room r)
        {
            try
            {
                /*if (_context.Rooms.Any(ro => ro.Name == r.Name))
                {
                    ModelState.AddModelError("Name", "El identificador ya existe");
                    return View(r);
                }

                if (!ModelState.IsValid)
                {
                    return View(r);
                }*/
                _context.Rooms.Add(r);
                _context.SaveChanges();
                foreach (int i in r.ResourcesIds)
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
            catch (Exception ex)
            {
                ModelState.AddModelError ("", "Error interno del sistema");
                return View(r);
            }
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

        public IActionResult RoomDetails(string name)
        {
            Room r = _context.Rooms.Include(r => r.Center)
                                    .Include(r => r.ResourcesRooms)
                                    .ThenInclude(rr => rr.AssignedResource)
                                    .FirstOrDefault(r => r.Name == name);
            return View(r);
        }

        public IActionResult UpdateRoom(string name)
        {
            Room r = _context.Rooms.Include(r => r.ResourcesRooms)
                            .FirstOrDefault(r => r.Name == name);
            List<Center> centers = _context.Centers.ToList();
            ViewData["Centers"] = centers;
            List<Resource> resources = _context.Resources.ToList();
            ViewData["Resources"] = resources;
            return View(r);
        }

        [HttpPost]
        public IActionResult UpdateRoom(Room r)
        {
            _context.Rooms.Update(r);
            _context.SaveChanges();

            List<ResourceRoom> previous = _context.Set<ResourceRoom>()
                .Where(rr => rr.RoomName == r.Name)
                .ToList();
            _context.Set<ResourceRoom>().RemoveRange(previous);
            _context.SaveChanges();

            if(r.ResourcesIds != null)
            {
                foreach(int id in r.ResourcesIds)
                {
                    ResourceRoom rr = new ResourceRoom { ResourceId = id, RoomName = r.Name};
                    _context.Add(rr);
                }
                _context.SaveChanges();
            }
            return RedirectToAction("ListRoom");
        }

        [HttpPost]
        public IActionResult DeleteAssignedResource(string roomName, int id)
        {
            ResourceRoom resroom = _context.Set<ResourceRoom>()
                        .FirstOrDefault(rr => rr.RoomName == roomName && rr.ResourceId == id);
            if(resroom != null)
            {
                _context.Set<ResourceRoom>().Remove(resroom);
                _context.SaveChanges();
            }
            return RedirectToAction("RoomDetails", new { name = roomName });
        }

        [HttpPost]
        public IActionResult UpdateAssignedResourceCount(string roomName, int ResourceId, int ResourceCount)
        {
            ResourceRoom rsm = _context.Set<ResourceRoom>()
                 .FirstOrDefault(rr => rr.RoomName == roomName && rr.ResourceId == ResourceId);
            rsm.ResourceCount = ResourceCount;
            _context.ResourceRooms.Update(rsm);
            _context.SaveChanges();
            return RedirectToAction("RoomDetails", new { name = rsm.RoomName });
        }
    }
}
