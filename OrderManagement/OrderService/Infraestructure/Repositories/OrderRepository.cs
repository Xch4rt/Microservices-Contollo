using Microsoft.EntityFrameworkCore;
using OrderService.Domain.Entities;
using OrderService.Domain.Repositories;
using OrderService.Infraestructure.Persistence;

namespace OrderService.Infraestructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _orderContext;

        public OrderRepository(OrderContext orderContext)
        {
            _orderContext = orderContext;
        }

        public async Task AddAsync(Order order)
        {
            await _orderContext.AddAsync(order);
            await _orderContext.SaveChangesAsync();
        }

        public async Task<Order> FindByIdAsync(Guid id)
        {
            return await _orderContext.Orders.Include(
                o => o.OrderItems
                ).FirstOrDefaultAsync(
                o => o.Id == id);
        }

        public async Task<List<Order>> GetAllOrdersByUserIdAsync(Guid userId)
        {
            return await _orderContext.Orders.Include(
                o => o.OrderItems
                ).Where(
                o => o.UserId == userId).ToListAsync();
        }

        public Task UpdateAsync(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
