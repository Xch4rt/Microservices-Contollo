using MediatR;
using OrderService.Application.Commands;
using OrderService.Domain.Entities;
using OrderService.Domain.Repositories;
using OrderService.Infraestructure.Messaging;

namespace OrderService.Application.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ProductMessageSender _messageSender;

        public CreateOrderCommandHandler (IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            _messageSender = new ProductMessageSender();
        }

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                UserId = request.UserId,
                OrderDate = DateTime.UtcNow,
                OrderItems = request.OrderItems.ConvertAll(oi => new OrderItem
                {
                    ProductId = oi.ProductId,
                    Quantity = oi.Quantity,
                    Discount = oi.Discount,
                }),
                IsActive = true,
                IsDeleted = false
            };

            // logic validation availability for products

            foreach (var item in request.OrderItems)
            {
                _messageSender.SendProductUpdateMessage(item.ProductId, item.Quantity);
            }

            await _orderRepository.AddAsync(order);
            
            return order.Id;
        }
    }
}
