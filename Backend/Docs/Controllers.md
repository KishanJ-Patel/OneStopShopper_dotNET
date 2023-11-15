# Controllers Documentation

**Table of Contents**

| No. | Controllers |
| --- | ----- |
| 1.  | [ProductsController](#products-controller) |

---

## 1. Products Controller

The Products Controller hosts RESTful APIs that process the requests made to its route for Product resources.
This documentation provides an overview of its attributs, properties, methods, RESTful APIs, routes, required services and example usages.

## Controller Route

`api/Products`

## Required Services 

- ProductManagementService

## Methods (RESTful APIs)

### `GetProducts()` API

- **Usage**: Copies all products from the database and product Ids as keys and values in dictionary.
- **HTTP method**: `HttpGet`
- **Access Modifier**: `public`
- **Parameters**: *none*
- **Returns**: `Dictionary<Guid, Product>`
- **Example**: `https://backend.com/api/Products`

### `GetProductById()` API

- **Usage**: Finds the product by id in the database and returns a copy.
- **HTTP method**: `HttpGet`
- **Access Modifier**: `public`
- **Parameters**:
	- `id` *(Guid)*: Unique Guid id of the product
- **Returns**: `Product?`
	- Return a copy of product if found.
    - Return null if no product with matching id exists in the database.
- **Example**: `https://backend.com/api/Products/79A3A3BE-54D8-4518-B970-2986EB0A8892`

## Example Usage

Call GetProducts() API by making request to the following route which will a dictionary of Product Ids and Products:
```
https://backend.com/api/Products
```

Call GetProductById() API by making request to the following route which will return a Product instance or null:
```
https://backend.com/api/Products/79A3A3BE-54D8-4518-B970-2986EB0A8892
```

---