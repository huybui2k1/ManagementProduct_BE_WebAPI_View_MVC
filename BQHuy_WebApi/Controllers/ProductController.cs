using BussinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BQHuy_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository repository = new ProductRepository();
        // GET: api/<ProductController>
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts() => repository.GetProducts();
       

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = repository.GetProductById(id);
            if (product == null)
            {
                return NotFound(); // Trả về lỗi 404 nếu không tìm thấy sản phẩm
            }

            return product;
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult PostProduct(Product p)
        {
           /* try
            {
                var context = new TestApi2010Context();
                context.Products.Add(p);
                context.SaveChanges();
                repository.SaveProduct(p);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new Product ");
            }*/
           repository.SaveProduct(p);
            return NoContent();
        }


        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product p)
        {
            var temp = repository.GetProductById(id);
            if (temp == null) return NotFound();
            repository.UpdateProduct(p);
            return NoContent();
        }


        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var temp = repository.GetProductById(id);
            if (temp == null) return NotFound();
            repository.DeleteProduct(temp);
            return NoContent();
        }
    }
}
