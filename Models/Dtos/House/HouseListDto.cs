namespace CorretoraAPI.Models.Dto.House
{
    public class HouseListDto {
        public int id {get; set;}
        public string address {get; set;}
        public CustomerDto Customer {get; set;}
        public AgentDto Agent {get; set;}
        public DateTime created_at {get; set;} 
        public DateTime updated_at {get; set;}
    }
}