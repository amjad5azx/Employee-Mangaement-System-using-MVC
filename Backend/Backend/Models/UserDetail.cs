using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class UserDetail
    {
        public int Id { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public List<Organization> Organizations { get; set; }=new List<Organization>();
    }
}
