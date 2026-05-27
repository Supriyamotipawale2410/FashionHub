using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FashionHub.API.DTOs
{
    public class ProductDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int Stock { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public IFormFile Image { get; set; }
    }
}