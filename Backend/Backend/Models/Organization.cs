    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    namespace Backend.Models
    {
        public class Organization
        {
            public int Id { get; set; }

            [Required]
            public string Name { get; set; }
            public int User_id { get; set; }
            [JsonIgnore]
            public UserDetail UserDetail { get; set; }
            public ICollection<Department> Departments { get; set; }=new List<Department>();
        }
    }
