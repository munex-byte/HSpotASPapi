# H+ Sport API - Complete Solution

A full-stack ASP.NET Core 6.0 REST API with SQLite database and HTML/CSS/JavaScript client application for managing a sports product catalog.

## 🎯 Features

- **RESTful API** with full CRUD operations (Create, Read, Update, Delete)
- **SQLite Database** with Entity Framework Core ORM
- **Database Migrations** for schema management
- **Swagger/OpenAPI** documentation
- **CORS Enabled** for cross-origin requests
- **Modern Web Client** with search, filter, and real-time updates
- **Responsive Design** that works on all devices
- **33 Seeded Products** across 5 categories

## 📋 Project Structure

```
HPlusSport/
├── HPlusSport.API/
│   ├── Controllers/
│   │   └── ProductsController.cs       # API endpoints
│   ├── Models/
│   │   ├── Product.cs                  # Product entity
│   │   ├── Category.cs                 # Category entity
│   │   ├── ShopContext.cs              # DbContext
│   │   └── ModelBuilderExtensions.cs   # Database seeding
│   ├── Migrations/
│   │   └── [Migration files]           # Database schema
│   ├── Program.cs                      # API configuration
│   ├── appsettings.json                # Settings
│   └── HPlusSport.API.csproj           # Project file
├── client.html                         # Web UI client
├── POSTMAN_TESTING_GUIDE.md           # API testing guide
├── README.md                           # This file
└── .gitignore                          # Git ignore rules
```

## 🚀 Getting Started

### Prerequisites
- .NET 6.0 SDK or later
- Python 3.7+ (for local web server)
- Git

### Installation

1. **Clone the repository**
```bash
git clone https://github.com/Eldoradowies/HSpotASPapi.git
cd HSpotASPapi/End_0308/HPlusSport
```

2. **Restore NuGet packages**
```bash
cd HPlusSport.API
dotnet restore
```

3. **Create the database**
```bash
dotnet-ef database update
```

4. **Start the API server**
```bash
dotnet run
```
The API will be available at: `http://localhost:5233`

5. **Start the web server** (in a new terminal)
```bash
cd ..
python -m http.server 8000
```

6. **Open the client**
Navigate to: `http://localhost:8000/client.html`

## 📖 API Documentation

### Base URL
```
http://localhost:5233/api
```

### Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/products` | Get all products |
| GET | `/products/{id}` | Get product by ID |
| POST | `/products` | Create new product |
| PUT | `/products/{id}` | Update product |
| DELETE | `/products/{id}` | Delete product |
| POST | `/products/Delete?ids=1&ids=2` | Delete multiple products |

### Example: Get All Products
```bash
curl http://localhost:5233/api/products
```

### Example: Create New Product
```bash
curl -X POST http://localhost:5233/api/products \
  -H "Content-Type: application/json" \
  -d '{
    "name": "Running Shoes",
    "sku": "RS001",
    "description": "Professional running shoes",
    "price": 89.99,
    "isAvailable": true,
    "categoryId": 1
  }'
```

## 🛠️ Tech Stack

### Backend
- **Framework**: ASP.NET Core 6.0
- **Database**: SQLite
- **ORM**: Entity Framework Core
- **Documentation**: Swagger/OpenAPI

### Frontend
- **HTML5**: Semantic markup
- **CSS3**: Modern responsive design with gradients and animations
- **JavaScript**: Vanilla JS (no frameworks) with async/await
- **API Communication**: Fetch API

## 📊 Database Schema

### Categories Table
```sql
CREATE TABLE Categories (
  Id INTEGER PRIMARY KEY,
  Name TEXT NOT NULL
);
```

### Products Table
```sql
CREATE TABLE Products (
  Id INTEGER PRIMARY KEY,
  Sku TEXT NOT NULL,
  Name TEXT NOT NULL,
  Description TEXT,
  Price TEXT NOT NULL,
  IsAvailable INTEGER NOT NULL,
  CategoryId INTEGER NOT NULL,
  FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);
```

## 💾 Seeded Data

The database comes pre-loaded with:
- **5 Categories**: Active Wear (Men & Women), Mineral Water, Publications, Supplements
- **33 Products**: ranging from $0 to $125 in price

## 🧪 Testing

### Option 1: Swagger UI
Visit `http://localhost:5233/swagger` for interactive API testing

### Option 2: Postman
See [POSTMAN_TESTING_GUIDE.md](POSTMAN_TESTING_GUIDE.md) for complete testing workflows and examples

### Option 3: Web Client
Use `http://localhost:8000/client.html` for full-featured UI testing

## 🎨 Client Features

- **Product Grid**: View all products with images and details
- **Search**: Filter products by name or SKU
- **Category Filter**: View products by category
- **Add Product**: Create new products with form validation
- **Edit Product**: Modify existing product details
- **Delete Product**: Remove products from catalog
- **Statistics Dashboard**: Real-time product counts and availability
- **Responsive Design**: Works on mobile, tablet, and desktop

## 🔧 Configuration

### Database Connection
The SQLite database is configured in `Program.cs`:
```csharp
options.UseSqlite("Data Source=shop.db");
```

### CORS Policy
CORS is enabled for all origins in development:
```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
```

## 📝 Key Code Files

### ProductsController.cs
Implements all REST endpoints with:
- GetAllProducts() - returns all products
- GetProduct(id) - returns single product
- PostProduct() - creates new product
- PutProduct() - updates product
- DeleteProduct() - deletes single product
- DeleteMultiple() - batch deletion

### ShopContext.cs
Entity Framework DbContext that:
- Configures entity relationships
- Seeds initial data
- Manages database operations

### client.html
Full-featured web UI with:
- Product grid display
- Search and filter functionality
- Add/Edit/Delete modals
- Statistics dashboard
- Real-time UI updates

## 🐛 Troubleshooting

### Database Issues
```bash
# Reset database
rm shop.db
dotnet-ef database update
```

### API Won't Start
```bash
# Check if port 5233 is in use
# If so, modify launchSettings.json or kill the process
```

### Client Can't Connect
- Ensure API is running on `http://localhost:5233`
- Check browser console for errors
- Verify CORS is enabled in Program.cs

### Entity Framework Issues
```bash
# Reinstall EF Core tools
dotnet tool uninstall --global dotnet-ef
dotnet tool install --global dotnet-ef --version 6.0.1
```

## 🌐 Deployment

### Preparing for Production

1. **Update appsettings.json** with production database connection
2. **Change CORS policy** to specific origins only
3. **Enable HTTPS** enforcement
4. **Add authentication/authorization** as needed
5. **Build release**:
   ```bash
   dotnet publish -c Release
   ```

## 📚 Learning Resources

- [ASP.NET Core Documentation](https://docs.microsoft.com/aspnet/core)
- [Entity Framework Core](https://docs.microsoft.com/ef/core)
- [REST API Best Practices](https://restfulapi.net)
- [SQLite Documentation](https://www.sqlite.org/docs.html)

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📄 License

This project is open source and available under the MIT License.

## 👨‍💼 Author

Created as a learning project for ASP.NET Core API development with database integration.

## 📞 Support

For issues or questions:
1. Check the [POSTMAN_TESTING_GUIDE.md](POSTMAN_TESTING_GUIDE.md)
2. Review the API logs in terminal
3. Check browser console for client-side errors
4. Verify all prerequisites are installed

---

**Happy coding!** 🚀
