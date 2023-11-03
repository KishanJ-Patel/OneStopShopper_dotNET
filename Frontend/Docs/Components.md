# Components Documentation

**Table of Contents**

| No. | Components |
| --- | ----- |
| 1.  | [ProductCard](#product-card) |

---

## 1. Product Card

The Product Card displays name, price and image, and is responsive to different screen sizes.
This documentation provides an overview of its UI elements, parameters and behaviour.

## Parameters

### `Product` *(Product)* 

- **Description**: An instance of the Product model.
- **Required**: Yes

## Behaviour

## UI Elements

### Image

- **Description**: An image of the product.
- **Notes**: If image is not found then show an "Image Load Error" image instead.

### Name

- **Description**: The name of the product.
- **Notes**: Display ellipsis (...) if the text does not fit inside the text div.

### Price

- **Description**: The price of the product.
- **Notes**: Display the integral digits in bold. Currency sign and decimal digits will have smaller font size.


---