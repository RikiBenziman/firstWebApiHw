using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDto
    {
        public int UserId { get; set; }
        [MaxLength(20)][MinLength(1)][Required]
        public string UserName { get; set; }
        [MaxLength(20)][MinLength(1)] [Required]
        public string Password { get; set; }
        [MaxLength(20)][MinLength(1)][Required]
        public string FirstName { get; set; }
        [MaxLength(20)][MinLength(1)]
        public string LastName { get; set; }

    }
}
