using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos
{
    public class DepartmentUpdateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
