namespace Backend.Services
{
	/// <summary>
	/// Class <c>CartManagementService</c> manages product ids and their counts in the local cart and database cart.
	/// </summary>
	public class CartManagementService
	{
		// Service Methods

		/// <summary>
		/// Method <c>AddProductToLocalCart</c> inserts the product id into the local cart if it doesn’t exist 
		/// or increases its count by 1 if it exists.
		/// For more information check <c>Services.md</c> doc.
		/// <code>
		/// Usage Example:
		/// AddProductToLocalCart(id, localCart);
		/// </code>
		/// </summary>
		/// <exception cref="Exception">
		/// </exception>
		/// <param name="id">Unique Guid product id.</param>
		/// <param name="localCart">Dictionary of product ids as keys and their counts as values.</param>
		public Dictionary<Guid, uint> AddProductToLocalCart(Guid id, Dictionary<Guid, uint> localCart)
		{
			try
			{
				if (localCart.ContainsKey(id)) 
					localCart[id] += 1;
				else 
					localCart.Add(id, 1);

				return localCart;

			}
			catch (Exception)
			{
				throw;
			}
		}

		/// <summary>
		/// Method <c>RemoveProductFromLocalCart</c> removes the product id from the local cart if its count is 1 
		/// or decreases its count by 1 if its count is greater than 1.
		/// For more information check <c>Services.md</c> doc.
		/// <code>
		/// Usage Example:
		/// RemoveProductFromLocalCart(id, localCart);
		/// </code>
		/// </summary>
		/// <exception cref="Exception">
		/// </exception>
		/// <param name="id">Unique Guid product id.</param>
		/// <param name="localCart">Dictionary of product ids as keys and their counts as values.</param>
		public Dictionary<Guid, uint> RemoveProductFromLocalCart(Guid id, Dictionary<Guid, uint> localCart)
		{
			try
			{
				if (localCart.ContainsKey(id))
				{
					localCart[id] -= 1;
					if (localCart[id] <= 0)
						localCart.Remove(id);
				}

				return localCart;

			}
			catch (Exception)
			{
				throw;
			}
		}

		/// <summary>
		/// Method <c>GetProductCountFromLocalCart</c> finds the product id in the local cart and returns the count.
		/// For more information check <c>Services.md</c> doc.
		/// <code>
		/// Usage Example:
		/// GetProductCountFromLocalCart(id, localCart);
		/// </code>
		/// </summary>
		/// <exception cref="Exception">
		/// </exception>
		/// <param name="id">Unique Guid product id.</param>
		/// <param name="localCart">Dictionary of product ids as keys and their counts as values.</param>
		public uint GetProductCountFromLocalCart(Guid id, Dictionary<Guid, uint> localCart)
		{
			try
			{
				if (localCart.ContainsKey(id))
					return localCart[id];
				else
					return 0;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
