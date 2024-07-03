using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos
{
    public class DepartmentCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int OrganizationId { get; set; }
    }
}
