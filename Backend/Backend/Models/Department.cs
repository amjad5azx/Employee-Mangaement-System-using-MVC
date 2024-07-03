using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Backend.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int OrganizationId { get; set; }
        [JsonIgnore]
        public Organization Organization { get; set; }
        public ICollection<Team> Teams { get; set; }=new List<Team>();
    }
}
