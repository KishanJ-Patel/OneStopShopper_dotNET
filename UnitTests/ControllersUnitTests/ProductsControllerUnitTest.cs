using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Backend.Services;
using Backend.Controllers;
using UnitTests.IEqualityComparers;
using UnitTests.TestDbFixtures;

namespace UnitTests.ControllersUnitTests
{
    public class ProductsControllerUnitTest : IClassFixture<ControllersTestDbFixture>
    {
        public ProductsControllerUnitTest(ControllersTestDbFixture fixture)
        {
            Fixture = fixture;
        }

        public ControllersTestDbFixture Fixture { get; }

        // Test the GetProducts() API to ensure it gets all products
        [Fact]
        public void GetProducts_ShouldGetAllPorducts()
        {
            // Arrange
            using var context = Fixture.CreateContext();
            var service = new ProductManagementService(context);
            var controller = new ProductsController(service);
            string uniqueName1 = "NameOfProduct1 " + Guid.NewGuid().ToString();
            string uniqueName2 = "NameOfProduct2 " + Guid.NewGuid().ToString();
            string uniqueName3 = "NameOfProduct3 " + Guid.NewGuid().ToString();
            decimal price1 = 101.34m;
            decimal price2 = 102.34m;
            decimal price3 = 103.34m;
            string imageUri1 = "https://i.postimg.cc/85yJJXHm/pexels-math-90946.jpg";
            string imageUri2 = "https://i.postimg.cc/85yJJXHm/pexels-math-90946.jpg";
            string imageUri3 = "https://i.postimg.cc/85yJJXHm/pexels-math-90946.jpg";
            Product product1 = new()
            {
                Name = uniqueName1,
                Price = price1,
                ImageUri = imageUri1
            };
            Product product2 = new()
            {
                Name = uniqueName2,
                Price = price2,
                ImageUri = imageUri2
            };
            Product product3 = new()
            {
                Name = uniqueName3,
                Price = price3,
                ImageUri = imageUri3
            };
            Product[] expectedProducts = { product1, product2, product3 };

            // Act and Assert
            context.Database.BeginTransaction();
            context.Products.ExecuteDelete();
            service.SaveProduct(product1);
            service.SaveProduct(product2);
            service.SaveProduct(product3);
            Product[] actualProducts = controller.Get();
            Assert.Equal(expectedProducts, actualProducts, new ProductCollectionEqualityComparer<Product>());
            context.Database.RollbackTransaction();
        }

        // Test the GetProducts() API to ensure it returns empty array if no products exist
        [Fact]
        public void GetProducts_ShouldReturnEmptyArray()
        {
            // Arrange
            using var context = Fixture.CreateContext();
            var service = new ProductManagementService(context);
            var controller = new ProductsController(service);

            // Act and Assert
            context.Database.BeginTransaction();
            context.Products.ExecuteDelete();
            Product[] productsInDb = controller.Get();
            Assert.Empty(productsInDb);
            context.Database.RollbackTransaction();
        }
    }
}
