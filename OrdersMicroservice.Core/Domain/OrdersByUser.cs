namespace OrdersMicroservice.Core.Domain
{
    public class OrdersByUser
    {
        public Guid UserId { get; set; }
        public IEnumerable<Guid>? Orders { get; set; }
        public long TotalAmount { get; set; }
    }
}
