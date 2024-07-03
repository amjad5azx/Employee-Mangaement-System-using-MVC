using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos
{
    public class RoleCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int TeamId { get; set; }
    }
}
