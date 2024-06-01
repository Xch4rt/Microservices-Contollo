using MediatR;

namespace ProductService.Application.Commands
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public string Name { get; }
        public string Description { get; }
        public int Quantity { get; }
        public decimal Price { get; }

        public CreateProductCommand(string name, string description, int quantity, decimal price)
        {
            Name = name;
            Description = description;
            Quantity = quantity;
            Price = price;
        }
    }
}
