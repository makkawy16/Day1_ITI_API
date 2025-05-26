using System.Text.Json.Serialization;

namespace CQRS.Data.Models
{
    public class Department
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ManagerName { get; set; }
    }
}
