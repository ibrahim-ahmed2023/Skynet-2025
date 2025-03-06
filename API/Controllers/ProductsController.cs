using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductRepository repo) : ControllerBase
    {
        private readonly IProductRepository repo = repo;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(string? brand , string? type , string? sort){
            return Ok(await repo.GetProductsAsync(brand , type,sort));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProduct(int id){
            var Product = await repo.GetProductByIdAsync(id);
            if(Product is null) {
                return NotFound();
            }
            return Product;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product){
            repo.AddProduct(product);
            if(await repo.SaveChangesAsync()){
                return CreatedAtAction("CreateProduct",new {id = product.Id}, product);
            }
            return BadRequest("Problem In Creating A Product");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateProduct(int id ,Product product){
            if(product.Id != id || !ProductExists(id)){
                return BadRequest("Cannot Update This Product!");
            }
            repo.UpdateProduct(product);
             if(await repo.SaveChangesAsync()){
                return NoContent();
             }
            return BadRequest("Problem In Updating The Product");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProduct(int id){
           var product = await repo.GetProductByIdAsync(id);
           if(product is null){
            return NotFound();
           }
           repo.DeleteProduct(product);
            if(await repo.SaveChangesAsync()){
                return NoContent();
            }
            return BadRequest("Problem In Deleting The Product");

        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<string>>> GetBrands(){
            return Ok(await repo.GetBrandsAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<string>>> GetTypes(){
            return Ok(await repo.GetTypesAsync());
        }


        private bool ProductExists(int id){
            return repo.ProductExists(id);
        }

    }
}
