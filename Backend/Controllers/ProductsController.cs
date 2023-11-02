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
        public Product[] Get()
        {
            return productManagementService.GetProducts();
        }
    }
}
