using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Backend.Models
{
    public class Team
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int DepartmentId { get; set; }

        [JsonIgnore]
        public Department Department { get; set; }
        public ICollection<Employee> Employees { get; set; }=new List<Employee>();
        public ICollection<Role> Roles { get; set; }=new List<Role>();
    }
}
