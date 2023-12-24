
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class UserDto
    {
        public int UserId { get; set; }
        [MaxLength(20)]
        [MinLength(1)]
        [Required]
        [EmailAddress]
        public string UserName { get; set; }
        [MaxLength(20)]
        [Required]
        public string Password { get; set; }
        [MaxLength(20)]
        [MinLength(1)]
        [Required]
        public string FirstName { get; set; }
        [MaxLength(20)]
        [MinLength(1)]
        public string LastName { get; set; }

    }
}
