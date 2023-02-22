using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Controllers
{
    public class BookingController : Controller
    {

        Order finalOrder = new Order();
        private HotelBindasDbContext db;
        public BookingController(HotelBindasDbContext db)
        {
            this.db = db;
        }

        public UserManager<User> UserManager { get; }
        public SignInManager<User> SignInManager { get; }

        [HttpGet]
        public IActionResult Book()
        {
            List<Room> emptyRooms = new List<Room>();
            foreach(Room room in  db.Rooms.ToList())
            {
                if(!room.IsBooked)
                {
                    emptyRooms.Add(room);
                }
            }
            return View(emptyRooms);
        }
        public IActionResult RoomSelect(string roomId)
        {
            Room tobeBooked = db.Rooms.FirstOrDefault(r => r.RoomId.Equals(roomId));
            return RedirectToAction("TimeSelect", tobeBooked);
        }
        [HttpGet]
        public IActionResult TimeSelect(Room room)
        {
            Order order = new Order
            {
                Room = room,
                RoomId = room.RoomId
            };
            return View(order);
        }
        [HttpPost]
        public IActionResult TimeSelect(Order order)
        {
            Room toBeBooked = db.Rooms.FirstOrDefault(r => r.RoomId.Equals(order.RoomId));
            finalOrder.Room = toBeBooked;
            finalOrder.RoomId = toBeBooked.RoomId;
            finalOrder.CheckIn = order.CheckIn;
            finalOrder.CheckOut = order.CheckOut;
            finalOrder.User = db.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            finalOrder.Email = finalOrder.User.Email;
            toBeBooked.IsBooked = true;
            db.Orders.Add(finalOrder);
            db.SaveChanges();
            return RedirectToAction("PastBooking", "Dashboard");
        }
    }
}
