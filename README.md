# FashionHub - Full Stack Ecommerce Clothing Website

FashionHub is a full stack ecommerce clothing web application built using:

- ASP.NET Core Web API (.NET 8)
- React JS
- MS SQL Server
- Entity Framework Core
- JWT Authentication

This project is designed as a real-world ecommerce platform where admin can manage products and customers can browse, search, sort, add to cart, and place orders.

---

# Features

## Admin Features

- Admin Login
- Add Categories
- Add Products
- Upload Product Images
- Update Products
- Delete Products
- Manage Inventory
- Manage Orders

---

## Customer Features

- User Registration/Login
- Browse Products
- Search Products
- Sort Products
- Filter by Categories
- Product Details Page
- Add to Cart
- Checkout
- Order Placement

---

# Technologies Used

## Frontend

- React JS
- React Router DOM
- Axios
- Bootstrap
- React Toastify

---

## Backend

- ASP.NET Core Web API
- Entity Framework Core
- LINQ
- JWT Authentication
- REST APIs

---

## Database

- Microsoft SQL Server

---

# Project Structure

```text
FashionHub
│
├── backend
│   └── FashionHub.API
│
├── frontend
│   └── fashionhub-client
│
└── README.md
```

---

# Backend Architecture

```text
Controllers
Models
DTOs
Data
Repositories
Services
Helpers
Middleware
Images
```

---

# Database Tables

- Users
- Categories
- Products
- Cart
- Orders
- OrderItems

---

# Setup Instructions

# 1. Clone Repository

```bash
git clone YOUR_GITHUB_REPO_URL
```

---

# 2. Backend Setup

Open backend project in Visual Studio.

Install packages:

```powershell
Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 8.0.8
Install-Package Microsoft.EntityFrameworkCore.Tools -Version 8.0.8
Install-Package Microsoft.AspNetCore.Authentication.JwtBearer -Version 8.0.8
Install-Package AutoMapper.Extensions.Microsoft.DependencyInjection -Version 12.0.1
```

---

# 3. Database Setup

Open SQL Server Management Studio.

Create database:

```sql
CREATE DATABASE FashionHubDB;
```

---

# 4. Update Connection String

Update appsettings.json:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=FashionHubDB;Trusted_Connection=True;TrustServerCertificate=True"
}
```

---

# 5. Run Migration

Open Package Manager Console:

```powershell
Add-Migration InitialCreate
Update-Database
```

---

# 6. Run Backend

```bash
Ctrl + F5
```

Swagger UI will open.

Example:

```text
https://localhost:7000/swagger
```

---

# 7. Frontend Setup

Go to frontend folder:

```bash
cd frontend/fashionhub-client
```

Install dependencies:

```bash
npm install
```

Run React app:

```bash
npm run dev
```

Frontend will run on:

```text
http://localhost:5173
```

---

# API Endpoints

## Categories

```http
GET     /api/categories
GET     /api/categories/{id}
POST    /api/categories
PUT     /api/categories/{id}
DELETE  /api/categories/{id}
```

---

## Products

```http
GET     /api/products
GET     /api/products/{id}
POST    /api/products
PUT     /api/products/{id}
DELETE  /api/products/{id}
```

---

# Important Concepts Used

- Entity Framework Core
- Dependency Injection
- Repository Pattern
- DTOs
- Async Programming
- REST APIs
- CRUD Operations
- File Upload
- JWT Authentication
- SQL Relationships
- LINQ Queries

---

# Future Improvements

- Payment Gateway
- Wishlist
- Reviews & Ratings
- Coupon System
- Email Notifications
- Admin Dashboard Analytics
- Cloud Image Storage

---

# Learning Outcomes

This project helps in learning:

- Full Stack Development
- ASP.NET Core Web API
- React JS
- SQL Server
- Git & GitHub
- Real-world Ecommerce Architecture

---

# Author

Developed by Supriya Motipawale
