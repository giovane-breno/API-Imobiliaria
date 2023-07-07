using System.Text.Json.Serialization;

namespace CorretoraAPI.Models
{
    public class Customer : Base
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public virtual List<House>? Houses { get; set; }
        public virtual List<Operation>? Operations { get; set; }

    }
}
