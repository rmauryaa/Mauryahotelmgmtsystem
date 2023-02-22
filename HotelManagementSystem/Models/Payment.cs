using System.ComponentModel.DataAnnotations;

namespace HotelMgmtsSystem.Models
{
    public class Payment
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public bool PaymentStatus { get; set; }
        [Required]
        public long TotalCost { get; set; }
       
    }
}
