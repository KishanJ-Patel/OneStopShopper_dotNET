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

## Example Usage

Saving a product model instance into the database.
```
Product newProduct = new Product
{
    Name = "Example Product",
    Price = 29.99,
    ImageUri = "https://example.com/images/example-product.jpg"
};

SaveProduct(newProduct);
```

Copying all products from the database into an array.
```
Product[] products = GetProducts();
```

---