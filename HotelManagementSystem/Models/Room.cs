using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class Room
    {
        
        [Key]
        [Required]
        [RegularExpression(@"R-[1-9]")]
        public string RoomId { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FromDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime? ToDate { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan FromTime { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]

        public TimeSpan ToTime { get; set; }
        [Range(1, 4)]
        public int Capacity { get; set; }
        [RegularExpression(@"AC|Non-AC")]
        [MaxLength(6)]
        [Required]
        public string Type { get; set; }
        public int Fare { get; set; }
        [Required]
        public bool IsBooked { get; set; }
    }
}
