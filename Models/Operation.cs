namespace CorretoraAPI.Models
{
    public class Operation : Base
    {
        public int Id { get; set; }
        public int HouseId { get; set; }
        public int CustomerId { get; set; }
        public int AgentId { get; set; }

        public decimal Price { get; set; }

        // NAVIGATION REFERENCES
        public virtual House? House { get; }
        public virtual Customer? Customer { get; }
        public virtual Agent? Agent { get; }
    }
}