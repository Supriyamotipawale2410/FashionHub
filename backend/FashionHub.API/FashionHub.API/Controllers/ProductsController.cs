using FashionHub.API.Data;
using FashionHub.API.DTOs;
using FashionHub.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FashionHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public ProductsController(ApplicationDbContext context,
                                  IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products
                .Include(p => p.Category)
                .ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.ProductId == id);

            if (product == null)
            {
                return NotFound("Product not found");
            }

            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct([FromForm] ProductDTO dto)
        {
            string imagePath = "";

            // Upload Image
            if (dto.Image != null)
            {
                string folderPath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "Images",
                    "Products"
                );

                // Create folder if not exists
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Unique file name
                string fileName = Guid.NewGuid().ToString()
                                  + Path.GetExtension(dto.Image.FileName);

                string filePath = Path.Combine(folderPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await dto.Image.CopyToAsync(stream);
                }

                imagePath = "/Images/Products/" + fileName;
            }

            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Stock = dto.Stock,
                CategoryId = dto.CategoryId,
                ImageUrl = imagePath
            };

            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(
    int id,
    [FromForm] ProductDTO dto)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound("Product not found");
            }

            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Price = dto.Price;
            product.Stock = dto.Stock;
            product.CategoryId = dto.CategoryId;

            // Update image if uploaded
            if (dto.Image != null)
            {
                string folderPath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "Images",
                    "Products"
                );

                string fileName = Guid.NewGuid().ToString()
                                  + Path.GetExtension(dto.Image.FileName);

                string filePath = Path.Combine(folderPath, fileName);



                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await dto.Image.CopyToAsync(stream);
                }

                product.ImageUrl = "/Images/Products/" + fileName;
            }

            await _context.SaveChangesAsync();

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound("Product not found");
            }

            _context.Products.Remove(product);

            await _context.SaveChangesAsync();

            return Ok("Product deleted successfully");
        }


        [HttpGet("search")]
        public async Task<IActionResult> SearchProducts(string keyword)
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .Where(p => p.Name.Contains(keyword))
                .ToListAsync();

            return Ok(products);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetProductsByCategory(int categoryId)
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();

            return Ok(products);
        }

        [HttpGet("sort")]
        public async Task<IActionResult> SortProducts(string order = "asc")
        {
            var products = order.ToLower() == "desc"
                ? await _context.Products
                    .OrderByDescending(p => p.Price)
                    .ToListAsync()
                : await _context.Products
                    .OrderBy(p => p.Price)
                    .ToListAsync();

            return Ok(products);
        }


    }


}