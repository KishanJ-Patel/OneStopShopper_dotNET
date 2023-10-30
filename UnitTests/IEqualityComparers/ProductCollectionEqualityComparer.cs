namespace UnitTests.IEqualityComparers
{
    public class ProductCollectionEqualityComparer<Product> : IEqualityComparer<IEnumerable<Product>>
        where Product : Backend.Models.Product
    {
        public bool Equals(IEnumerable<Product>? x, IEnumerable<Product>? y)
        {
            if (x == null && y == null) return true;
            if (x == null || y == null) return false;

            IEnumerator<Product> enumratorX = x.GetEnumerator();
            IEnumerator<Product> enumratorY = y.GetEnumerator();
            Product productX, productY;

            while (true)
            {
                bool hasNextX = enumratorX.MoveNext();
                bool hasNextY = enumratorY.MoveNext();

                if (!hasNextX || !hasNextY) 
                    return (hasNextX == hasNextY);

                productX = enumratorX.Current;
                productY = enumratorY.Current;

                if (productX.Id != productY.Id) return false;
                if (productX.Name != productY.Name) return false;
                if (productX.Price != productY.Price) return false;
                if (productX.ImageUri != productY.ImageUri) return false;
            }
        }

        public int GetHashCode(IEnumerable<Product> obj)
        {
            throw new NotImplementedException();
        }
    }
}
