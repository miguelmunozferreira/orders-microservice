namespace OrdersMicroservice.Api.Models
{
    public class OrdersByUser
    {
        public Guid UserId { get; set; }
        public Guid[] Orders { get; set; }
        public long TotalAmount { get; set; }
    }
}
