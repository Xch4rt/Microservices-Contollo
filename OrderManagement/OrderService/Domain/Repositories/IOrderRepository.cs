using OrderService.Domain.Entities;

namespace OrderService.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task AddAsync(Order order);
        Task UpdateAsync (Order order);
        Task<List<Order>> GetAllOrdersByUserIdAsync(Guid userId);
        Task<Order> FindByIdAsync(Guid id);
    }
}
