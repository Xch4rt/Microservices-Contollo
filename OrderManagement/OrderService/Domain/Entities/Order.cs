namespace OrderService.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public Order() { }

        public Order (Guid id, Guid userId, DateTime orderDate, List<OrderItem> orderItems, bool isActive, bool isDeleted)
        {
            Id = id;
            UserId = userId;
            OrderDate = orderDate;
            OrderItems = orderItems;
            IsActive = isActive;
            IsDeleted = isDeleted;
        }
    }
}
