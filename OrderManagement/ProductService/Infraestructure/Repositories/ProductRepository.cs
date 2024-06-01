using ProductService.Domain.Entities;
using ProductService.Domain.Repositories;
using ProductService.Infraestructure.Persistence;

namespace ProductService.Infraestructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _productContext;

        public ProductRepository(ProductContext context)
        {
            _productContext = context;
        }

        public async Task AddAsync(Product product)
        {
            await _productContext.Products.AddAsync(product);
            await _productContext.SaveChangesAsync();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> FindByIdAsync(Guid id)
        {
            return await _productContext.Products.FindAsync(id);
        }

        public Task<Product> FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
