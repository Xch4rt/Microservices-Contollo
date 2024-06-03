
namespace OrderService.API.DTOs
{
    public class OrderItemDto 
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
    }
}
