using MediatR;
using ProductService.Application.Commands;
using ProductService.Domain.Entities;
using ProductService.Domain.Repositories;

namespace ProductService.Application.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.FindByIdAsync(request.Id);

            if (product == null)
            {
                throw new KeyNotFoundException("Product not found");
            }

            if (request.Name != null)
            {
                product.Name = request.Name;
            }
            if (request.Description != null)
            {
                product.Description = request.Description;
            }
            if (request.Quantity.HasValue)
            {
                product.Quantity = request.Quantity.Value;
            }
            if (request.Price.HasValue)
            {
                product.Price = request.Price.Value;
            }

            await _productRepository.UpdateAsync(product);

            return product;
        }
    }
}
