using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos
{
    public class TeamCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int DepartmentId { get; set; }
    }
}
