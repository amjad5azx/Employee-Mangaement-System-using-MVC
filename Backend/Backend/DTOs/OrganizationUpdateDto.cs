using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos
{
    public class OrganizationUpdateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
