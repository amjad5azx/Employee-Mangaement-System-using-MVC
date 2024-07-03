using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos
{
    public class EmployeeUpdateDto
    {
        [Required]
        public string EmployeeName { get; set; }

        [Required]
        public int RoleId { get; set; }

        [Required]
        public int TeamId { get; set; }
    }
}
