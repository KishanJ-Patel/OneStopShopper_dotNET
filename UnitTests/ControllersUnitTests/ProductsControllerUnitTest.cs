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
			string sellerName1 = "NameOfProductSeller1";
			string sellerName2 = "NameOfProductSeller2";
			string sellerName3 = "NameOfProductSeller3";
			string details1 = "Product1 Specification\n- Line 1\n- Line 2\n- Line 3\n";
			string details2 = "Product2 Specification\n- Line 1\n- Line 2\n- Line 3\n";
			string details3 = "Product3 Specification\n- Line 1\n- Line 2\n- Line 3\n";
			Product product1 = new()
            {
                Name = uniqueName1,
                Price = price1,
                ImageUri = imageUri1,
                SellerName = sellerName1,
                Details = details1
            };
            Product product2 = new()
            {
                Name = uniqueName2,
                Price = price2,
                ImageUri = imageUri2,
                SellerName= sellerName2,
                Details = details2
            };
            Product product3 = new()
            {
                Name = uniqueName3,
                Price = price3,
                ImageUri = imageUri3,
                SellerName= sellerName3,
                Details = details3
            };
            Product[] expectedProducts = { product1, product2, product3 };

            // Act and Assert
            context.Database.BeginTransaction();
            context.Products.ExecuteDelete();
            service.SaveProduct(product1);
            service.SaveProduct(product2);
            service.SaveProduct(product3);
            Product[] actualProducts = controller.GetProducts();
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
            Product[] productsInDb = controller.GetProducts();
            Assert.Empty(productsInDb);
            context.Database.RollbackTransaction();
        }

        // Test the GetProductById() API to ensure it returns correct product data
        [Fact]
        public void GetProductById_ShouldGetCorrectProduct()
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
            string sellerName1 = "NameOfProductSeller1";
            string sellerName2 = "NameOfProductSeller2";
            string sellerName3 = "NameOfProductSeller3";
            string details1 = "Product1 Specification\n- Line 1\n- Line 2\n- Line 3\n";
            string details2 = "Product2 Specification\n- Line 1\n- Line 2\n- Line 3\n";
            string details3 = "Product3 Specification\n- Line 1\n- Line 2\n- Line 3\n";
            Product product1 = new()
            {
                Name = uniqueName1,
                Price = price1,
                ImageUri = imageUri1,
                SellerName = sellerName1,
                Details = details1
            };
            Product product2 = new()
            {
                Name = uniqueName2,
                Price = price2,
                ImageUri = imageUri2,
                SellerName = sellerName2,
                Details = details2
            };
            Product expectedProduct = new()
            {
                Name = uniqueName3,
                Price = price3,
                ImageUri = imageUri3,
                SellerName = sellerName3,
                Details = details3
            };
            Guid id = Guid.Empty;

            // Act and Assert
            context.Database.BeginTransaction();
            context.Products.ExecuteDelete();
            service.SaveProduct(product1);
            service.SaveProduct(product2);
            service.SaveProduct(expectedProduct);
            id = expectedProduct.Id;
            Product? actualProduct = controller.GetProductByID(id);
            Assert.Equal(expectedProduct, actualProduct, new ProductEqualityComparer<Product>());
            context.Database.RollbackTransaction();
        }

        // Test the GetProductById() API to ensure it return null if no product with matching id exists
        [Fact]
        public void GetProductById_ShouldReturnNull()
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
			string sellerName1 = "NameOfProductSeller1";
			string sellerName2 = "NameOfProductSeller2";
			string sellerName3 = "NameOfProductSeller3";
			string details1 = "Product1 Specification\n- Line 1\n- Line 2\n- Line 3\n";
			string details2 = "Product2 Specification\n- Line 1\n- Line 2\n- Line 3\n";
			string details3 = "Product3 Specification\n- Line 1\n- Line 2\n- Line 3\n";
			Product product1 = new()
			{
				Name = uniqueName1,
				Price = price1,
				ImageUri = imageUri1,
				SellerName = sellerName1,
				Details = details1
			};
			Product product2 = new()
			{
				Name = uniqueName2,
				Price = price2,
				ImageUri = imageUri2,
				SellerName = sellerName2,
				Details = details2
			};
			Product product3 = new()
			{
				Name = uniqueName3,
				Price = price3,
				ImageUri = imageUri3,
				SellerName = sellerName3,
				Details = details3
			};
			Guid id = Guid.Empty;

			// Act and Assert
			context.Database.BeginTransaction();
			context.Products.ExecuteDelete();
			service.SaveProduct(product1);
			service.SaveProduct(product2);
			service.SaveProduct(product3);
			Product? actualProduct = controller.GetProductByID(id);
			Assert.Null(actualProduct);
			context.Database.RollbackTransaction();
		}
    }
}
