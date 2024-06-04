using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.API.DTOs;
using OrderService.Application.Commands;
using OrderService.Application.Queries;

namespace OrderService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<OrderDto>>> GetAll(Guid id)
        {
            var query = new GetAllOrdersByUserIdQuery(id);
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateOrder([FromBody] CreateOrderCommand command)
        {
            var orderId = await _mediator.Send(command);
            return Ok(orderId);
        }

        [HttpGet("order/{id}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var query = new GetOrderByIdQuery(id);

            var order = await _mediator.Send(query);

            return Ok(order);
        }


    }
}
