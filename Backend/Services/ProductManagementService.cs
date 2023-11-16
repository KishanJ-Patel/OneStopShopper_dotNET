using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;

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
        public Product[] GetProducts()
        {
            try
            {
                Product[] products = _developDbContext.Products.AsNoTracking().ToArray();
                return products;
            }
            catch (Exception)
            {
                throw;
            }
        }

		/// <summary>
		/// Method <c>GetProductById</c> finds the product by id in the database and returns a copy.
		/// For more information check <c>Services.md</c> doc.
		/// <example>
		/// Usage Example:
		/// <code>
		/// Product? product = GetProductById(id);
		/// </code>
		/// </example>
		/// </summary>
        /// <returns>A product instance. Null if no product exists with matching id.</returns>
        /// <exception cref="InvalidOperationException">
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        /// <exception cref="Exception">
        /// </exception>
        public Product? GetProductById(Guid id)
        {
            try
            {
                Product? product = _developDbContext.Products.AsNoTracking().SingleOrDefault(p => p.Id == id);
                if (product == null) return null;
                return product;
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("More than one product with matching id exists in the database.");
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException(nameof(id), "Id cannot be null.");
            }
            catch (Exception)
            {
                throw;
            }
        }
	}
}
