namespace OrderService.Domain.Entities
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public DateTime Created { get; set; } 
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public OrderItem () { }

        public OrderItem (Guid id, Guid orderId, Guid productId, int quantity, decimal price, decimal discount, DateTime created, bool isActive, bool isDeleted)
        {
            Id = id;
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
            Price = price;
            Discount = discount;
            Created = created;
            IsActive = isActive;
            IsDeleted = isDeleted;
        }
    }
}
