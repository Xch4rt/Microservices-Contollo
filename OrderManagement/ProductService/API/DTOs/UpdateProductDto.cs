using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace ProductService.API.DTOs
{
    public class UpdateProductDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Quantity { get; set; }
        public decimal ? Price { get; set; }

    }
}
