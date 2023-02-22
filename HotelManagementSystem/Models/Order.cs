using HotelMgmtsSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int TotalFare { get; set; }

        public string Email { get; set; }
        public User User { get; set; }

        public string RoomId { get; set; }
        public Room Room { get; set; }

        public Payment Payment { get; set; }

        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}
