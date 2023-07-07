using System.Text.Json.Serialization;

namespace CorretoraAPI.Models
{
    public class Agent : Base {
        public string Name { get; set;}
        public string Serial {get; set;}

        //NAVEGAÇÃO
        public virtual List<House>? Houses { get; set; }
        public virtual List<Operation>? Operations { get; set; }
    }
}