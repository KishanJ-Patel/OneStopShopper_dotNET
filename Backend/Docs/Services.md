# Services Documentation

**Table of Contents**

| No. | Service |
| --- | ----- |
| 1.  | [ProductManagementService](#product-management-service) |

---

## 1. Product Management Service

The Product Management Service manages products in the database.
This documentation provides an overview of its attributs, properties, methods and example usages.

## Methods

### `SaveProduct()`

- **Usage**: Saves a product model instance into the database.
- **Access Modifier**: `public`
- **Parameters**:
    - product *(Product)*: Product model instance
- **Returns**: `void`
- **Example**: `SaveProduct(product);`

### `GetProducts()`

- **Usage**: Copies all products from the database into an array.
- **Access Modifier**: `public`
- **Parameters**: *none*
- **Returns**: `Product[]`
- **Example**: `Product[] products = GetProducts();`

### `GetProductById()`

- **Usage**: Finds product by Id in the database and returning a copy.
- **Access Modifier**: `public`
- **Parameters**:
    - id *(Guid)*: Unique Guid id of the product
- **Returns**: `Product?`
    - Return a copy of product if found.
    - Return null if no product with matching id exists in the database.
- **Example**: `Product? product = GetProductById(id);`

## Example Usage

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