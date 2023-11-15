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

        private readonly ProductManagementService productManagementService;

        // GET: api/<ProductsController>
        [HttpGet]
		public Dictionary<Guid, Product> GetProducts()
		{
			Product[] products = productManagementService.GetProducts();
			Dictionary<Guid, Product> prodDict = new();
			foreach (Product product in products)
                prodDict.Add(product.Id, product);
			return prodDict;
		}

		// GET: api/<ProductsController>/79A3A3BE-54D8-4518-B970-2986EB0A8892
		[HttpGet("{id}")]
        public Product? GetProductByID(Guid id)
        {
            return productManagementService.GetProductById(id);
        }
	}
}
