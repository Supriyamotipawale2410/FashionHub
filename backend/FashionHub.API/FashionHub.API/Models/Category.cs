using System.ComponentModel.DataAnnotations;

namespace FashionHub.API.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(100)]
        public string CategoryName { get; set; }

        public string Description { get; set; }

        // Navigation Property
        public ICollection<Product> Products { get; set; }
    }
}