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

`api/products`

## Required Services 

- ProductManagementService

## Methods (RESTful APIs)

### `GetProducts()` API

- **Usage**: Copies all products from the database into an array.
- **HTTP method**: `HttpGet`
- **Access Modifier**: `public`
- **Parameters**: *none*
- **Returns**: `Product[]`
- **Example**: `https://backend.com/api/products`

## Example Usage

Call GetProducts() API by making request to the following route which will return an array of Products:
```
https://backend.com/api/products
```

---