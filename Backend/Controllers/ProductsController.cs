using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using Backend.Services;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {   
        public ProductsController(ProductManagementService productManagementService)
        {
            this.productManagementService = productManagementService;
        }

        private ProductManagementService productManagementService;

        // GET: api/<ProductsController>
        [HttpGet]
        public Product[] GetProducts()
        {
            return productManagementService.GetProducts();
        }

        // GET: api/<ProductsController>/79A3A3BE-54D8-4518-B970-2986EB0A8892
        [HttpGet("api/[controller]/{id}")]
        public Product? GetProductByID(Guid id)
        {
            return productManagementService.GetProductById(id);
        }
	}
}
