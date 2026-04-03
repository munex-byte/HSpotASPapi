# H+ Sport API - Testing Guide with Postman

## API Setup
- **Base URL**: `http://localhost:5233`
- **API Endpoint**: `http://localhost:5233/api`
- **Database**: SQLite (shop.db)
- **Framework**: ASP.NET Core 6.0

## API Endpoints

### 1. Get All Products
```
GET http://localhost:5233/api/products
```
**Description**: Retrieves all products from the database  
**Response**: Array of Product objects (200 OK)

**Example Response**:
```json
[
  {
    "id": 1,
    "sku": "AWMGSJ",
    "name": "Grunge Skater Jeans",
    "description": "",
    "price": 68.0,
    "isAvailable": true,
    "categoryId": 1,
    "category": {
      "id": 1,
      "name": "Active Wear - Men",
      "products": null
    }
  }
]
```

---

### 2. Get Product by ID
```
GET http://localhost:5233/api/products/{id}
```
**Description**: Retrieves a specific product by ID  
**Parameters**:
- `id` (path parameter): Product ID (integer)

**Example**: `GET http://localhost:5233/api/products/1`

**Response**: Single Product object (200 OK) or 404 Not Found

---

### 3. Create New Product
```
POST http://localhost:5233/api/products
Content-Type: application/json
```

**Request Body**:
```json
{
  "name": "New Running Shoes",
  "sku": "RS001",
  "description": "Professional running shoes with comfort cushioning",
  "price": 89.99,
  "isAvailable": true,
  "categoryId": 1
}
```

**Response**: 201 Created with Location header pointing to the new product

**Example Response**:
```json
{
  "id": 34,
  "sku": "RS001",
  "name": "New Running Shoes",
  "description": "Professional running shoes with comfort cushioning",
  "price": 89.99,
  "isAvailable": true,
  "categoryId": 1,
  "category": null
}
```

---

### 4. Update Product
```
PUT http://localhost:5233/api/products/{id}
Content-Type: application/json
```

**Request Body**:
```json
{
  "id": 1,
  "name": "Updated Grunge Skater Jeans",
  "sku": "AWMGSJ",
  "description": "Classic grunge style jeans updated",
  "price": 79.99,
  "isAvailable": true,
  "categoryId": 1
}
```

**Response**: 204 No Content (success) or 404 Not Found

---

### 5. Delete Product
```
DELETE http://localhost:5233/api/products/{id}
```

**Description**: Deletes a product by ID  
**Parameters**:
- `id` (path parameter): Product ID (integer)

**Response**: 200 OK with deleted product data

**Example Response**:
```json
{
  "id": 1,
  "sku": "AWMGSJ",
  "name": "Grunge Skater Jeans",
  "description": "",
  "price": 68.0,
  "isAvailable": true,
  "categoryId": 1,
  "category": null
}
```

---

### 6. Delete Multiple Products
```
POST http://localhost:5233/api/products/Delete?ids=1&ids=2&ids=3
```

**Description**: Deletes multiple products by their IDs  
**Parameters**:
- `ids` (query parameter): Array of Product IDs

**Response**: 200 OK with array of deleted products

**Example Response**:
```json
[
  {
    "id": 1,
    "sku": "AWMGSJ",
    "name": "Grunge Skater Jeans",
    "price": 68.0,
    "isAvailable": true,
    "categoryId": 1
  },
  {
    "id": 2,
    "sku": "AWMPS",
    "name": "Polo Shirt",
    "price": 35.0,
    "isAvailable": true,
    "categoryId": 1
  }
]
```

---

## Testing Workflow in Postman

### Step 1: Import or Create Environment
1. Create a new **Postman Environment** named "H+ Sport Local"
2. Add variables:
   - `base_url`: `http://localhost:5233`
   - `api_endpoint`: `{{base_url}}/api`

### Step 2: Test GET All Products
1. Create new request: **GET** `{{api_endpoint}}/products`
2. Send and verify response contains all 33 seeded products

### Step 3: Test GET Product by ID
1. Create new request: **GET** `{{api_endpoint}}/products/1`
2. Verify response contains the product details for ID 1

### Step 4: Test CREATE Product
1. Create new request: **POST** `{{api_endpoint}}/products`
2. Set Header: `Content-Type: application/json`
3. Send Body:
```json
{
  "name": "Premium Yoga Mat",
  "sku": "YM001",
  "description": "High-quality non-slip yoga mat with carrying strap",
  "price": 45.99,
  "isAvailable": true,
  "categoryId": 1
}
```
4. Verify 201 response and note the new ID

### Step 5: Test UPDATE Product
1. Create new request: **PUT** `{{api_endpoint}}/products/1`
2. Set Header: `Content-Type: application/json`
3. Send Body:
```json
{
  "id": 1,
  "name": "Grunge Skater Jeans - Premium",
  "sku": "AWMGSJ",
  "description": "Premium quality grunge skater jeans",
  "price": 88.99,
  "isAvailable": true,
  "categoryId": 1
}
```
4. Verify 204 No Content response

### Step 6: Test DELETE Product
1. Create new request: **DELETE** `{{api_endpoint}}/products/34`
2. Send and verify 200 OK response with deleted product data

### Step 7: Test DELETE Multiple Products
1. Create new request: **POST** `{{api_endpoint}}/products/Delete?ids=32&ids=33`
2. Send and verify response contains both deleted products

---

## Database Overview

### Categories (5 Total):
1. Active Wear - Men (9 products)
2. Active Wear - Women (8 products)
3. Mineral Water (6 products)
4. Publications (1 product)
5. Supplements (9 products)

### Key Product Fields:
- **id**: Auto-generated integer
- **sku**: Stock Keeping Unit (unique identifier string)
- **name**: Product name
- **description**: Optional product description
- **price**: Decimal price
- **isAvailable**: Boolean availability status
- **categoryId**: Foreign key to Category

---

## Swagger UI Testing
Alternative: Access interactive API documentation at:
```
http://localhost:5233/swagger
```

You can test all endpoints directly from the Swagger UI without needing Postman.

---

## Client Application Testing

### Access the Client:
```
http://localhost:8000/client.html
```

### Features:
- **View All Products**: Display all products in a responsive grid
- **Search**: Filter products by name or SKU
- **Filter by Category**: View products in specific categories
- **Add Product**: Create new products with full details
- **Edit Product**: Modify existing product information
- **Delete Product**: Remove products from the catalog
- **Statistics**: Real-time product count and availability stats

---

## Common Issues & Solutions

### Issue: CORS Error
**Solution**: CORS is already enabled in Program.cs with `UseCors("AllowAll")`

### Issue: Database Not Found
**Solution**: Run `dotnet-ef database update` in the API project folder

### Issue: Port Already in Use
**Solution**: Change port in `launchSettings.json` or kill the process using the port

### Issue: API Connection Refused
**Solution**: Ensure the API is running with `dotnet run` and listening on port 5233

---

## Performance Tips

1. **Batch Operations**: Use the Delete Multiple endpoint for better performance
2. **Filtering**: Perform filtering on the client side to reduce server load
3. **Caching**: Consider implementing response caching for GET requests
4. **Pagination**: For large datasets, implement pagination in the API

---

## Data Validation

The API validates:
- All required fields (name, sku, categoryId, price)
- CategoryId must exist in the database
- Price must be a valid decimal
- Product name and SKU length validation in models

---

For questions or issues, check the API logs in the terminal running `dotnet run`
