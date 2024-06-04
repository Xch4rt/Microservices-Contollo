using MediatR;
using OrderService.API.DTOs;
using OrderService.Application.Queries;
using OrderService.Domain.Repositories;

namespace OrderService.Application.Handlers
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderByIdQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.FindByIdAsync(request.OrderId);
            var orderDto = new OrderDto
            {
                Id = order.Id,
                UserId = order.UserId,
                OrderDate = order.OrderDate,
                OrderItems = order.OrderItems.Select(oi => new OrderItemDto
                {
                    ProductId = oi.ProductId,
                    Discount = oi.Discount,
                    Price = oi.Price,
                    Quantity = oi.Quantity
                }).ToList()
            };

            return orderDto;
        }
    }
}
