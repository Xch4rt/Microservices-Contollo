using MediatR;
using OrderService.API.DTOs;

namespace OrderService.Application.Queries
{
    public class GetOrderByIdQuery : IRequest<OrderDto>
    {
        public Guid OrderId { get; set; }

        public GetOrderByIdQuery() { }

        public GetOrderByIdQuery(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}
