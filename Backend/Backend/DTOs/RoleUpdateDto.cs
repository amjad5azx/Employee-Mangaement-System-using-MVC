using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos
{
    public class RoleUpdateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
