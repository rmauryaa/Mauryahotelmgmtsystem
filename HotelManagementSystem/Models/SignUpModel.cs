using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class SignUpModel
    {

        [Required]
        public string FullName { get; set; }
        [Range(7006000000, 9999999999)]
        public string MobileNumber { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }
       
        [Required]
        public string UserName { get; set; }
        [Required]

        public string Password { get; set; }
        [Required]
        public string IdProof { get; set; }
        [Required]
        public string Gender { get; set; }
    }
}
