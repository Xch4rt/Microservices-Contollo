using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.API.DTOs;
using ProductService.Application.Commands;
using ProductService.Application.Handlers;
using ProductService.Application.Queries;

namespace ProductService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
        {
            if (command == null)
            {
                return BadRequest("Cannot create product");
            }

            var product = await _mediator.Send(command);

            return Ok(product);
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var query = new GetAllProductsQuery();
            var products = await _mediator.Send(query);

            return Ok(products);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] UpdateProductDto updateProductDto)
        {
            if (id ==  Guid.Empty)
            {
                return BadRequest("Id not provided");
            }

            var command = new UpdateProductCommand(id, updateProductDto);

            var updatedProduct = await _mediator.Send(command);

            if (updatedProduct == null) 
            {
                return NotFound();
            }

            return Ok(updatedProduct);
        }
    }
}
