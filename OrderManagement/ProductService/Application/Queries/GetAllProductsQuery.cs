using MediatR;
using ProductService.API.DTOs;
using ProductService.Domain.Entities;

namespace ProductService.Application.Queries
{
    public class GetAllProductsQuery : IRequest<List<ProductDto>>
    {
        public GetAllProductsQuery() { }
    }
}
