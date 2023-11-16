using Backend.Services;

namespace UnitTests.ServicesUnitTests
{
	public class CartManagementServiceUnitTests
	{
		// Test the AddProductToLocalCart() method to ensure that it adds the product id
		[Fact]
		public void AddProductToLocalCart_ShouldAddProductId()
		{
			// Arrange
			var service = new CartManagementService();
			var localCart = new Dictionary<Guid, uint>();
			Guid id = Guid.Parse("E8E92231-CEEA-4927-B0F0-B9E12B89FC48");

			// Act
			var newLocalCart = service.AddProductToLocalCart(id, localCart);

			// Assert
			Assert.True(newLocalCart.ContainsKey(id));
			Assert.Equal<uint>(1, newLocalCart[id]);
		}

		// Test the AddProductToLocalCart() method to ensure that it increases the count of product id by 1
		[Fact]
		public void AddProductToLocalCart_ShouldIncreaseProductIdCountBy1()
		{
			// Arrange
			var service = new CartManagementService();
			Guid id = Guid.Parse("E8E92231-CEEA-4927-B0F0-B9E12B89FC48");
			var localCart = new Dictionary<Guid, uint>() 
			{ 
				{ id, 1 } 
			};
			uint expectedCount = 2;

			// Act
			var newLocalCart = service.AddProductToLocalCart(id, localCart);

			// Assert
			Assert.Equal<uint>(expectedCount, newLocalCart[id]);
		}

		// Test the RemoveProductFromLocalCart() method to ensure that it removes the product id
		[Fact]
		public void RemoveProductFromLocalCart_ShouldRemoveProductId()
		{
			// Arrange
			var service = new CartManagementService();
			Guid id = Guid.Parse("E8E92231-CEEA-4927-B0F0-B9E12B89FC48");
			var localCart = new Dictionary<Guid, uint> 
			{ 
				{ id, 1 } 
			};

			// Act
			var newLocalCart = service.RemoveProductFromLocalCart(id, localCart);

			// Assert
			Assert.Empty(newLocalCart);
		}

		// Test the RemoveProductFromLocalCart() method to ensure that it decreases the count of product id by 1
		[Fact]
		public void RemoveProductFromLocalCart_ShouldDecreaseProductIdCountBy1()
		{
			// Arrange
			var service = new CartManagementService();
			Guid id = Guid.Parse("E8E92231-CEEA-4927-B0F0-B9E12B89FC48");
			var localCart = new Dictionary<Guid, uint>()
			{
				{ id, 2 }
			};
			uint expectedCount = 1;

			// Act
			var newLocalCart = service.RemoveProductFromLocalCart(id, localCart);

			// Assert
			Assert.Equal<uint>(expectedCount, newLocalCart[id]);
		}

		// Test the RemoveProductFromLocalCart() method to ensure that it
		// returns the local cart as is if the product id doesn't exist
		[Fact]
		public void RemoveProductFromLocalCart_ShouldReturnLocalCartAsIs()
		{
			// Arrange
			var service = new CartManagementService();
			Guid id1 = Guid.Parse("E8E92231-CEEA-4927-B0F0-B9E12B89FC48");
			Guid id2 = Guid.Parse("BBC5F96D-CFC4-4C1A-9C69-5DB5531C7B39");
			var expectedLocalCart = new Dictionary<Guid, uint>()
			{
				{ id1, 2 }
			};

			// Act
			var actualLocalCart = service.RemoveProductFromLocalCart(id2, expectedLocalCart);

			// Assert
			Assert.True(expectedLocalCart.Equals(actualLocalCart));
		}
	}
}
