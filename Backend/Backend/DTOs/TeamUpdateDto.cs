using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos
{
    public class TeamUpdateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
