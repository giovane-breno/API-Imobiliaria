namespace CorretoraAPI.Models.Dto.Agent
{
    public class AgentDto {
        public int id { get; set; }
        public string name { get; set; }
        public string serial { get; set; }

        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}