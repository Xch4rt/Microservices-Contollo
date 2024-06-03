using MediatR;
using OrderService.API.DTOs;

namespace OrderService.Application.Queries
{
    public class GetAllOrdersByUserIdQuery : IRequest<List<OrderDto>>
    {
        public Guid UserId { get; set; }

        public GetAllOrdersByUserIdQuery() { }
        public GetAllOrdersByUserIdQuery(Guid userId) 
        {
            UserId = userId;
        }

    }
}
