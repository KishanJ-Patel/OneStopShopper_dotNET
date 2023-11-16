# Services Documentation

**Table of Contents**

| No. | Service |
| --- | ----- |
| 1.  | [ProductManagementService](#product-management-service) |
| 1.  | [CartManagementService](#cart-management-service) |

---

## 1. Product Management Service

The Product Management Service manages products in the database.
This documentation provides an overview of its attributs, properties, methods and example usages.

### Methods

#### `SaveProduct()`

- **Usage**: Saves a product model instance into the database.
- **Access Modifier**: `public`
- **Parameters**:
    - `product` *(Product)*: Product model instance
- **Returns**: `void`
- **Example**: `SaveProduct(product);`

#### `GetProducts()`

- **Usage**: Copies all products from the database into an array.
- **Access Modifier**: `public`
- **Parameters**: *none*
- **Returns**: `Product[]`
- **Example**: `Product[] products = GetProducts();`

#### `GetProductById()`

- **Usage**: Finds product by Id in the database and returning a copy.
- **Access Modifier**: `public`
- **Parameters**:
    - `id` *(Guid)*: Unique Guid id of the product.
- **Returns**: `Product?`
    - Return a copy of product if found.
    - Return null if no product with matching id exists in the database.
- **Example**: `Product? product = GetProductById(id);`

### Example Usage

Saving a product model instance into the database.
```
Product newProduct = new Product
{
    Name = "Example Product",
    Price = 29.99,
    ImageUri = "https://example.com/images/example-product.jpg",
    SellerName = "Example Seller",
    Details = "Example Product Specification\n- Line 1\n- Line 2\n- Line 3\n"
};

SaveProduct(newProduct);
```

Copying all products from the database into an array.
```
Product[] products = GetProducts();
```

Finding a product by id in the database and returning a copy.
```
Guid id = Guid.Parse("286A7B2E-32FB-43B6-948E-91B84C9838F7");
Product? product = GetProductById(id);
```

---

## 2. Cart Management Service

The Product Management Service manages products in the local cart and database cart.
This documentation provides an overview of its attributs, properties, methods and example usages.

### Methods

#### `AddProductToLocalCart()`

- **Usage**: Inserts the product id into the local cart if it doesn’t exist 
or increases its count by 1 if it exists.
- **Access Modifier**: `public`
- **Parameters**:
    - `id` *(Guid)*: Unique Guid product id.
    - `localCart` *(Dictionary<Guid, uint>)*: Dictionary of product ids as keys and their counts as values.
- **Returns**: `Dictionary<Guid, uint>`
- **Example**: `AddProductToLocalCart(id, localCart);`

#### `RemoveProductFromLocalCart()`

- **Usage**: Removes the product id from the local cart if its count is 1 
or decreases its count by 1 if its count is greater than 1.
- **Access Modifier**: `public`
- **Parameters**:
    - `id` *(Guid)*: Unique Guid product id.
    - `localCart` *(Dictionary<Guid, uint>)*:  Dictionary of product ids as keys and their counts as values.
- **Returns**: `Dictionary<Guid, uint>`
- **Notes**: If the product id doesn't exist in the local cart, then return the dictionary as is.
- **Example**: `RemoveProductFromLocalCart(id, localCart);`

#### `GetProductCountFromLocalCart()`

- **Usage**: Finds the product id in the local cart and returns the count.
- **Access Modifier**: `public`
- **Parameters**:
    - `id` *(Guid)*: Unique Guid product id.
    - `localCart` *(Dictionary<Guid, uint>)*:  Dictionary of product ids as keys and their counts as values.
- **Returns**: `uint`
- **Notes**: If the product id doesn't exist in the local cart, then return 0.
- **Example**: `GetProductCountFromLocalCart(id, localCart);`

### Example Usage

Inserting the product id into the local cart if it doesn’t exist 
or increasing its count by 1 if it exists.
```
Guid id = Guid.Parse("286A7B2E-32FB-43B6-948E-91B84C9838F7");
var localCart = new Dictionary<Guid, uint>();
localCart = AddProductToLocalCart(id, localCart);
```

Removing the product id from the local cart if its count is 1
or decreasing its count by 1 if its count is greater than 1.
```
Guid id = Guid.Parse("286A7B2E-32FB-43B6-948E-91B84C9838F7");
var localCart = new Dictionary<Guid, uint>();
localCart.Add(id, 3);
localCart = RemoveProductFromLocalCart(id, localCart);
```

Getting the count of the product from the local cart.
```
Guid id = Guid.Parse("286A7B2E-32FB-43B6-948E-91B84C9838F7");
var localCart = new Dictionary<Guid, uint>();
localCart.Add(id, 3);
uint count = GetProductCountFromLocalCart(id, localCart);
```

---
