using MediatR;
using OrderService.API.DTOs;
using OrderService.Domain.Entities;

namespace OrderService.Application.Commands
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }

        public CreateOrderCommand (Guid userId, List<OrderItemDto> orderItems)
        {
            UserId = userId;
            OrderItems = orderItems;
        }
    }
}
