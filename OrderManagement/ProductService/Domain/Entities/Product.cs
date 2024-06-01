namespace ProductService.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set;}

        public Product() { }

        public Product(string name, string description, int quantity, decimal price, bool isActive, bool isDeleted)
        {
            Name = name;
            Description = description;
            Quantity = quantity;
            Price = price;
            IsActive = isActive;
            IsDeleted = isDeleted;
        }
    }
}
