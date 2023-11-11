using Backend.Models;

namespace UnitTests.IEqualityComparers
{
	public class ProductEqualityComparer<Product> : IEqualityComparer<Product?>
		where Product : Backend.Models.Product
	{
		public bool Equals(Product? x, Product? y)
		{
			if (x == null && y == null) return true;
			if (x == null || y == null) return false;

			if (x.Id != y.Id) return false;
			if (x.Name != y.Name) return false;
			if (x.Price != y.Price) return false;
			if (x.ImageUri != y.ImageUri) return false;
			if (x.SellerName != y.SellerName) return false;
			if (x.Details != y.Details) return false;

			return true;
		}

		public int GetHashCode(Product obj)
		{
			throw new NotImplementedException();
		}
	}
}
