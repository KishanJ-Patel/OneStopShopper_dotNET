using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Backend.Services;
using UnitTests.IEqualityComparers;
using UnitTests.TestDbFixtures;

namespace UnitTests.ServicesUnitTests
{
    public class ProductManagementServiceUnitTest : IClassFixture<ServicesTestDbFixture>
    {
        public ProductManagementServiceUnitTest(ServicesTestDbFixture fixture) 
        {
            Fixture = fixture;
        }

        public ServicesTestDbFixture Fixture { get; }

        // Test the SaveProduct() method to ensure that it saves product
        [Fact]
        public void SaveProduct_ShouldSaveProduct()
        {
            // Arrange
            using var context = Fixture.CreateContext();
            var service = new ProductManagementService(context);
            string uniqueName = "NameOfProduct " + Guid.NewGuid().ToString();
            decimal price = 100.34m;
            string imageUri = "https://i.postimg.cc/85yJJXHm/pexels-math-90946.jpg";
			string sellerName = "NameOfProductSeller";
			string details = "Product Specification\n- Line 1\n- Line 2\n- Line 3\n";
			Product product = new()
            {
                Name = uniqueName,
                Price = price,
                ImageUri = imageUri,
                SellerName = sellerName,
                Details = details
            };

            // Act and Assert
            context.Database.BeginTransaction();
            service.SaveProduct(product);
            Product? savedProduct = context.Products.Single(p => p.Name == product.Name);
            Assert.NotNull(savedProduct);
            context.Database.RollbackTransaction();
        }

        // Test the SaveProduct() method to ensure that it saves accurate product data
        [Fact]
        public void SaveProduct_ShouldSaveAccurateData()
        {
            // Arrange
            using var context = Fixture.CreateContext();
            var service = new ProductManagementService(context);
            string uniqueName = "NameOfProduct " + Guid.NewGuid().ToString();
            decimal price = 100.34m;
            string imageUri = "https://i.postimg.cc/85yJJXHm/pexels-math-90946.jpg";
			string sellerName = "NameOfProductSeller";
			string details = "Product Specification\n- Line 1\n- Line 2\n- Line 3\n";
			Product product = new()
            {
                Name = uniqueName,
                Price = price,
                ImageUri = imageUri,
                SellerName = sellerName,
                Details = details
            };

            // Act and Assert
            context.Database.BeginTransaction();
            service.SaveProduct(product);
            Product? savedProduct = context.Products.Single(p => p.Name == product.Name);
            Assert.Equal(product.Name, savedProduct.Name);
            Assert.Equal(product.Price, savedProduct.Price);
            Assert.Equal(product.ImageUri, savedProduct.ImageUri);
            context.Database.RollbackTransaction();
        }

        // Test the GetProducts() method to ensure it gets all products
        [Fact]
        public void GetProducts_ShouldGetAllProducts()
        {
            // Arrange
            using var context = Fixture.CreateContext();
            var service = new ProductManagementService(context);
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
            Product product3= new()
            {
                Name = uniqueName3,
                Price = price3,
                ImageUri = imageUri3,
                SellerName = sellerName3,
                Details = details3
            };
            Product[] products = { product1, product2, product3 };

            // Act and Assert
            context.Database.BeginTransaction();
            context.Products.ExecuteDelete();
            service.SaveProduct(product1);
            service.SaveProduct(product2);
            service.SaveProduct(product3);
            Product[] productsInDb = service.GetProducts();
            Assert.Equal(products, productsInDb, new ProductCollectionEqualityComparer<Product>());
            context.Database.RollbackTransaction();
        }

        // Test the GetProducts() method to ensure it returns empty array if no products exist
        [Fact]
        public void GetProducts_ShouldReturnEmptyArray()
        {
            // Arrange
            using var context = Fixture.CreateContext();
            var service = new ProductManagementService(context);

            // Act and Assert
            context.Database.BeginTransaction();
            context.Products.ExecuteDelete();
            Product[] productsInDb = service.GetProducts();
            Assert.Empty(productsInDb);
            context.Database.RollbackTransaction();
        }

		// Test the GetProductById() method to ensure it gets correct product
		[Fact]
		public void GetProductById_ShouldGetCorrectProduct()
		{
			// Arrange
			using var context = Fixture.CreateContext();
			var service = new ProductManagementService(context);
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
			Product[] products = { product1, product2, expectedProduct };
            Guid id = Guid.Empty;

			// Act and Assert
			context.Database.BeginTransaction();
			context.Products.ExecuteDelete();
			service.SaveProduct(product1);
			service.SaveProduct(product2);
			service.SaveProduct(expectedProduct);
			Product[] productsInDb = service.GetProducts();
            id = productsInDb[2].Id;
            Product? actualProduct = service.GetProductById(id);
			Assert.Equal(expectedProduct, actualProduct, new ProductEqualityComparer<Product>());
			context.Database.RollbackTransaction();
		}

		// Test the GetProductById() method to ensure it returns null if no product exist with matching id
		[Fact]
		public void GetProductById_ShouldReturnNull()
		{
			// Arrange
			using var context = Fixture.CreateContext();
			var service = new ProductManagementService(context);
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
			Product? actualProduct = service.GetProductById(id);
			Assert.Null(actualProduct);
			context.Database.RollbackTransaction();
		}

	}
}
