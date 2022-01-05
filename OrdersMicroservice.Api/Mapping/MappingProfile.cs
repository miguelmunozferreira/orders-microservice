using AutoMapper;
using OrdersMicroservice.Core.Domain;

namespace OrdersMicroservice.Api.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            // API to Domain
            CreateMap<Order, Models.Order>();
            CreateMap<OrdersByUser, Models.OrdersByUser>();

            // Domain to API
            CreateMap<Models.Order, Order>();
            CreateMap<Models.OrdersByUser, OrdersByUser>();
        }
    }
}
