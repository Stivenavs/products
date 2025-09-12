using Microsoft.AspNetCore.Mvc;
using product_management.Application.Abstractions;
using product_management.Application.Products.In;
using product_management.Application.Products.Out;
using product_management.Domain.Entities;

namespace product_management.Infraestructure.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IProductRepository repo) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
            var products = await repo.GetAllAsync();
            return Ok(products.Select(p => new ProductDto(p.Id, p.Name, p.Description, p.Price, p.CreatedAt)));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetById(int id)
        {
            var p = await repo.GetByIdAsync(id);
            if (p is null) return NotFound();
            return new ProductDto(p.Id, p.Name, p.Description, p.Price, p.CreatedAt);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDtoIn>> Create(ProductDtoIn dto)
        {
            Product entity = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                CreatedAt = DateTime.Now
            };

            var created = await repo.SaveAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = created.Id },
                new ProductDto(created.Id, created.Name, created.Description, created.Price, created.CreatedAt));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, ProductDto dto)
        {
            var existing = await repo.GetByIdAsync(id);
            if (existing is null) return NotFound();

            existing.Name = dto.Name;
            existing.Description = dto.Description;
            existing.Price = dto.Price;

            await repo.UpdateAsync(existing);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await repo.GetByIdAsync(id);
            if (existing is null) return NotFound();

            await repo.DeleteAsync(existing);
            return NoContent();
        }
    }
}
