using CorretoraAPI.Models.Dto.House;

namespace CorretoraAPI.Models.Dto.Operation
{
    public class OperationListDto {
        public int id { get; set; }
        public HouseListDto House {get; set;}
        public CustomerDto buyer {get; set;}
        public AgentDto Agent {get; set;}
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set;}
    }
}