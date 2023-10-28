using System.Data.Common;
using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    /// <summary>
    /// Class <c>ProductManagementService</c> manages products in the database.
    /// </summary>
    public class ProductManagementService
    {
        public ProductManagementService(OssDbContext context)
        {
            _developDbContext = context;
        }

        private readonly OssDbContext _developDbContext;

        // Service Methods

        /// <summary>
        /// Method <c>SaveProduct</c> saves a product model instance into the database.
        /// For more information check <c>Services.md</c> doc.
        /// <example>
        /// Usage Example:
        /// <code>
        /// Product newProduct = new Product
        /// {
        ///     Name = "Example Product",
        ///     Price = 29.99,
        ///     ImageUri = "https://example.com/images/example-product.jpg"
        /// };
        /// SaveProduct(newProduct);
        /// </code>
        /// </example>
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        /// <param name="product">the product model instance.</param>
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

        /// <summary>
        /// Method <c>GetProducts</c> copies all products from the database into an array.
        /// For more information check <c>Services.md</c> doc.
        /// <example>
        /// Usage Example:
        /// <code>
        /// Product[] products = GetProducts();
        /// </code>
        /// </example>
        /// </summary>
        /// <returns>An array of products. An empty array if no product exists.</returns>
        /// <exception cref="Exception">
        /// </exception>
        // Copies all products from the database into an array
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
