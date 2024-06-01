using MediatR;
using ProductService.Domain.Entities;

namespace ProductService.Application.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public Guid Id { get; }

        public GetProductByIdQuery (Guid id)
        {
            Id = id;
        }
    }
}
