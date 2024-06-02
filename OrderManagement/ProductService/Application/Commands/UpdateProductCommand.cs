using MediatR;
using ProductService.API.DTOs;
using ProductService.Domain.Entities;

namespace ProductService.Application.Commands
{
    public class UpdateProductCommand : IRequest<Product>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }

        public UpdateProductCommand() { }

        public UpdateProductCommand(Guid id, UpdateProductDto updateProductDto)
        {
            Id = id;
            Name = updateProductDto.Name;
            Description = updateProductDto.Description;
            Quantity = updateProductDto.Quantity;
            Price = updateProductDto.Price;
        }
    }
}
