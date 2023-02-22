using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Controllers
{

    [Authorize]
    public class DashboardController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private HotelBindasDbContext db;
        public DashboardController(HotelBindasDbContext db, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.db = db;
        }
        public IActionResult AdminDashboard()
        {
            return View(db.Rooms.ToList());
        }
        [HttpGet]
        public IActionResult AddRoom()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddRoom(Room room)
        {
            db.Rooms.Add(room);
            db.SaveChanges();
            return RedirectToAction("AdminDashboard");
        }

 
        public IActionResult SearchRoom()
        {
            List<Room> rooms = new List<Room>();
            foreach(Room room in db.Rooms.ToList())
                {
                rooms.Add(room);
                 }

            return View(rooms);
        }
        [HttpGet]
        public IActionResult EditRoom(string roomId)
        {
            Room toEdit = db.Rooms.FirstOrDefault(x => x.RoomId.Equals(roomId));
            return View(toEdit);
        }
        [HttpPost]
        public IActionResult EditRoom(Room room)
        {
            Room toEdit = db.Rooms.FirstOrDefault(x => x.RoomId.Equals(room.RoomId));
            toEdit.Capacity = room.Capacity;
            toEdit.FromDate = room.FromDate;
            toEdit.ToDate = room.ToDate;
            toEdit.FromTime = room.FromTime;
            toEdit.ToTime = room.ToTime;
            toEdit.Fare = room.Fare;
            toEdit.Type = room.Type;
            toEdit.IsBooked = room.IsBooked;
            db.SaveChanges();
            return RedirectToAction("AdminDashboard");
        }

        public IActionResult DeleteRoom(string roomId)
        {
            Room toDelete = db.Rooms.FirstOrDefault(x => x.RoomId.Equals(roomId));
            db.Remove(toDelete);
            db.SaveChanges();
           return RedirectToAction("AdminDashboard");

        }
       
        public IActionResult UserDashboard()
        {
            User user = db.Users.FirstOrDefault(x => x.UserName.Equals(User.Identity.Name));
            return View(user);
        }
        public IActionResult PastBooking()
        {
            List<Order> previous = new List<Order>();
            User user = db.Users.FirstOrDefault(x => x.UserName.Equals(User.Identity.Name));
            foreach (var order in db.Orders.ToList())
            {
                if(order.Email.Equals(user.Email))
                {
                    previous.Add(order);
                }
            }
            return View(previous);
        }
        public IActionResult CurrentBooking()
        {
            List<Order> previous = new List<Order>();
            User user = db.Users.FirstOrDefault(x => x.UserName.Equals(User.Identity.Name));
            foreach (var order in db.Orders.ToList())
            {
                if (order.Email.Equals(user.Email))
                {
                    previous.Add(order);
                }
            }
            return View(previous);
        }
    }
}
