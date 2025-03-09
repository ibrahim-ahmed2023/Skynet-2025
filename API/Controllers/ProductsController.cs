using API.RequestHelpers;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    public class ProductsController(IGenericRepository<Product> repo) : BaseApiController
    {
        private readonly IGenericRepository<Product> repo = repo;



        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts([FromQuery]ProductSpecParams specParams){
            var spec = new ProductSpecification(specParams);
            return await CreatePagedResult(repo , spec , specParams.PageIndex , specParams.PageSize);
        }




        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProduct(int id){
            var Product = await repo.GetByIdAsync(id);
            if(Product is null) {
                return NotFound();
            }
            return Product;
        }



        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product){
            repo.Add(product);
            if(await repo.SaveAllAsync()){
                return CreatedAtAction("CreateProduct",new {id = product.Id}, product);
            }
            return BadRequest("Problem In Creating A Product");
        }



        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateProduct(int id ,Product product){
            if(product.Id != id || !ProductExists(id)){
                return BadRequest("Cannot Update This Product!");
            }
            repo.Update(product);
             if(await repo.SaveAllAsync()){
                return NoContent();
             }
            return BadRequest("Problem In Updating The Product");
        }



        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProduct(int id){
           var product = await repo.GetByIdAsync(id);
           if(product is null){
            return NotFound();
           }
           repo.Remove(product);
            if(await repo.SaveAllAsync()){
                return NoContent();
            }
            return BadRequest("Problem In Deleting The Product");

        }


 
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<string>>> GetBrands(){
            var spec = new BrandListSpecification();
            return Ok(await repo.ListAsync(spec));
        }



        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<string>>> GetTypes(){
              var spec = new TypeListSpecification();
            return Ok(await repo.ListAsync(spec));
        }


        private bool ProductExists(int id){
            return repo.Exists(id);
        }

    }
}
