using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos
{
    public class OrganizationCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int User_id { get; set; }
    }
}
