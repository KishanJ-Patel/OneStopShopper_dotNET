using System.Data.Common;
using Backend.Data;
using Backend.Models;

namespace Backend.Services
{
    public class ProductManagementService
    {
        public ProductManagementService(OssDbContext context)
        {
            _developDbContext = context;
        }

        private readonly OssDbContext _developDbContext;

        public void SaveProduct(Product product)
        {
            try
            {
                _developDbContext.Products.Add(product);
                _developDbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Product[] GetProducts()
        {   
            try
            {
                Product[] products = _developDbContext.Products.ToArray();
                return products;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
