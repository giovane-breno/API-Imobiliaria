namespace CorretoraAPI.Models
{
    public class House : Base
    {
        public int OwnerId { get; set; } 
        public int SellerId {get; set; }
        public string Address { get; set; }

        // NAVIGATION REFERENCES
        public virtual Customer? Customer { get; }
        public virtual Agent? Agent { get; set; }
        public virtual List<Operation>? Operations { get; set; }
    }
}
