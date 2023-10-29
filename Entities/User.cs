using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User
    {
        public int userId { get; set; }
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string ToString()
        {
            return "{userName:" + UserName + "\nPassword:" + Password + "\nFirstName:" + FirstName + "\nLastName:" + LastName + "\n}";
        }


    }
}
