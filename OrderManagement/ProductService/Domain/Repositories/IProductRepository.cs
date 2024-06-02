using ProductService.Domain.Entities;

namespace ProductService.Domain.Repositories
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Guid id);
        Task<List<Product>> FindAllAsync();  
        Task<Product> FindByIdAsync(Guid id);
        Task<Product> FindByNameAsync(string name);
    }
}
