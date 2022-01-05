namespace OrdersMicroservice.Api.Models
{
    public class OrderCreateUpdate
    {
        public Guid UserId { get; set; }
        public int Amount { get; set; }
    }
}
