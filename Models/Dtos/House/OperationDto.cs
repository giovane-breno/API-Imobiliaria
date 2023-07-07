namespace CorretoraAPI.Models.Dto.House
{
    public class OperationDto {
        public int id { get; set; }
        public CustomerDto buyer { get; set; }
        public AgentDto seller { get; set; }
        public decimal price { get; set; }
        public DateTime created_at { get; set; }
    }
}