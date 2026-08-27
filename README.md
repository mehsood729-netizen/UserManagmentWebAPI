# User Management Web API

## Overview

The **User Management Web API** is a RESTful backend application developed using **ASP.NET Core Web API**, **Entity Framework Core**, and **SQL Server**.

The system provides user management and authentication functionality through a clean and structured architecture. It uses the **Repository Pattern**, **Service Layer**, and **Dependency Injection** to maintain separation of concerns and improve code maintainability.

This project is designed as a learning and practice project to demonstrate how a modern ASP.NET Core Web API can interact with a SQL Server database while following clean architectural principles.

---

## Key Features

### User Management

* Create and manage users
* Store user information in SQL Server
* Retrieve user information from the database
* Search users using email or username
* Handle user-related database operations

### Authentication Features

* User authentication
* Login using email or username
* Check whether a user exists
* Repository-based authentication logic
* Service layer for authentication operations

### API Features

* RESTful API architecture
* HTTP request handling using Controllers
* Dependency Injection
* Swagger / OpenAPI integration
* Database integration using Entity Framework Core

---

## Architecture

The application follows a layered architecture with clear separation of responsibilities:

* ASP.NET Core Web API Presentation Layer
* Service / Business Logic Layer
* Repository / Data Access Layer
* Entity Framework Core ORM Layer
* SQL Server Database Layer

### Architecture Flow

```text
Client / Swagger
       │
       ▼
   Controllers
       │
       ▼
    Services
       │
       ▼
  Repositories
       │
       ▼
Entity Framework Core
       │
       ▼
    SQL Server
```

### Design Principles

* Repository Pattern
* Service Layer Pattern
* Separation of Concerns (SoC)
* Dependency Injection
* Entity Framework Core ORM
* RESTful API Design

---

## Technology Stack

| Component             | Technology                         |
| --------------------- | ---------------------------------- |
| Framework             | ASP.NET Core Web API               |
| Language              | C#                                 |
| ORM                   | Entity Framework Core              |
| Database              | Microsoft SQL Server               |
| Architecture          | Repository Pattern & Service Layer |
| Dependency Management | Built-in Dependency Injection      |
| API Documentation     | Swagger / OpenAPI                  |
| IDE                   | Visual Studio                      |

---

## Database Entity

The application manages user data through the `User` entity.

```csharp
public DbSet<User> Users { get; set; }
```

### Entity Responsibility

The `User` entity is responsible for storing user-related information such as:

* User ID
* Username
* User Email
* Authentication-related information

The database operations are managed through `UserManagementDbContext`.

---

## Project Structure

```text
UserManagmentWebAPI
│
├── Controllers
│   └── AuthController.cs
│
├── Data
│   └── UserManagementDbContext.cs
│
├── Models
│   └── User.cs
│
├── Repositories
│   ├── Interfaces
│   │   └── IAuthenticationRepo.cs
│   │
│   └── Implementation
│       └── AuthenticationRepo.cs
│
├── Services
│   ├── Interfaces
│   │   └── IAuthenticationService.cs
│   │
│   └── Implementation
│       └── AuthenticationService.cs
│
├── Properties
│   └── launchSettings.json
│
├── appsettings.json
├── Program.cs
└── UserManagmentWebAPI.csproj
```

---

## Getting Started

### Prerequisites

Make sure you have the following installed:

* Visual Studio
* .NET SDK
* SQL Server or SQL Server LocalDB
* SQL Server Management Studio (Optional)
* Git

---

## Installation

### 1. Clone Repository

```bash
git clone https://github.com/mehsood729-netizen/UserManagmentWebAPI.git
```

Move into the project directory:

```bash
cd UserManagmentWebAPI
```

---

### 2. Open the Project

Open the project in **Visual Studio**.

Make sure all required NuGet packages are restored.

You can restore packages using:

```bash
dotnet restore
```

---

### 3. Configure SQL Server Connection

Update the connection string inside:

```text
appsettings.json
```

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConn": "Server=(localdb)\\MSSQLLocalDB;Database=UserManagementDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

You can change the database name according to your preference.

For SQL Server:

```json
{
  "ConnectionStrings": {
    "DefaultConn": "Server=YOUR_SERVER_NAME;Database=UserManagementDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

---

### 4. Configure Database Context

The project uses `UserManagementDbContext` for database communication.

The DbContext is registered in `Program.cs`:

```csharp
builder.Services.AddDbContext<UserManagementDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConn")
    )
);
```

---

### 5. Apply Database Migrations

Using Package Manager Console:

```powershell
Update-Database
```

Or using the .NET CLI:

```bash
dotnet ef database update
```

This will create or update the database based on the Entity Framework Core migrations.

---

### 6. Run the Application

Using Visual Studio:

* Set **UserManagmentWebAPI** as the Startup Project.
* Press **F5** or **Ctrl + F5**.
* Navigate to the application URL.





```bash
dotnet run
```

---

## Authentication Workflow

The authentication system follows this flow:

```text
User
 │
 │ Sends Email or Username
 ▼
AuthController
 │
 ▼
AuthenticationService
 │
 ▼
AuthenticationRepo
 │
 ▼
UserManagementDbContext
 │
 ▼
SQL Server Database
 │
 ├───────────────┐
 ▼               ▼
User Found    User Not Found
 │               │
 ▼               ▼
Success       Authentication Failed
```

The system checks whether the provided identifier matches:

* User Email
* Username

Example logic:

```csharp
var existingUser = await _context.Users
    .FirstOrDefaultAsync(x =>
        x.UserEmail == identifier ||
        x.UserName == identifier);
```

If the user exists, the authentication process can continue.

If no matching user is found, the API can return an appropriate response such as:

```text
User not found
```

---

## Dependency Injection

The project uses ASP.NET Core Dependency Injection.

Repository registration:

```csharp
builder.Services.AddScoped<IAuthenticationRepo, AuthenticationRepo>();
```

Service registration:

```csharp
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
```

This allows the application to automatically inject dependencies where required.

### Dependency Flow

```text
Controller
    │
    ▼
Service Interface
    │
    ▼
Service Implementation
    │
    ▼
Repository Interface
    │
    ▼
Repository Implementation
    │
    ▼
Database
```

---

## Entity Framework Core

Entity Framework Core is used as the ORM for database operations.

The application uses EF Core to:

* Connect with SQL Server
* Query user data
* Insert records
* Update records
* Manage database entities
* Apply database migrations

### Database Flow

```text
API Request
     │
     ▼
Controller
     │
     ▼
Service
     │
     ▼
Repository
     │
     ▼
DbContext
     │
     ▼
SQL Server
```

---

## API Documentation

Swagger / OpenAPI is integrated into the project for API documentation and testing.

After running the application, open:

```text
/swagger
```

Example:

```text
https://localhost:PORT/swagger
```

Swagger provides:

* Available API endpoints
* Request methods
* Request models
* Response information
* API testing interface

---

## NuGet Packages

The project uses packages related to:

```text
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Swashbuckle.AspNetCore
```

If required, install packages using:

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```

```bash
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

```bash
dotnet add package Swashbuckle.AspNetCore
```

---

## Repository Pattern

The Repository Pattern is used to separate database access logic from the business logic.

### Benefits

* Clean and organized code
* Separation of database logic
* Easier maintenance
* Reusable data access methods
* Better application structure
* Easier testing

The authentication repository is responsible for communicating with the database and retrieving user information.

---

## HTTP Response Handling

The API can use standard HTTP status codes to represent request results.

| Status Code                 | Description                    |
| --------------------------- | ------------------------------ |
| `200 OK`                    | Request completed successfully |
| `201 Created`               | New user created successfully  |
| `400 Bad Request`           | Invalid request data           |
| `401 Unauthorized`          | Authentication failed          |
| `404 Not Found`             | User not found                 |
| `500 Internal Server Error` | Unexpected server error        |

---

## Security Improvements

The current project can be further improved by adding:

* Password hashing
* JWT Authentication
* Role-Based Authorization
* Refresh Tokens
* Secure password validation
* Global exception handling
* Input validation

---

## Future Enhancements

Possible future improvements include:

* JWT Token Authentication
* User Registration API
* Update User API
* Delete User API
* Get All Users API
* Get User by ID API
* Password Hashing using BCrypt
* Role-Based Authorization
* Refresh Tokens
* DTO Implementation
* AutoMapper
* Fluent Validation
* Global Exception Handling
* Logging
* Pagination
* Search and Filtering
* Unit Testing
* Integration Testing
* API Versioning
* Docker Support

---

## Contributing

Contributions and suggestions are welcome.

1. Fork the repository.
2. Create a new feature branch.

```bash
git checkout -b feature/YourFeatureName
```

3. Make your changes.
4. Commit your changes.

```bash
git commit -m "Add Your Feature"
```

5. Push your branch.

```bash
git push origin feature/YourFeatureName
```

6. Create a Pull Request.

---

## License

This project is currently developed for learning and educational purposes.

---

## Author

**Naseem Shah**

GitHub: [mehsood729-netizen](https://github.com/mehsood729-netizen?utm_source=chatgpt.com)

---

⭐ If you find this project useful, consider giving the repository a star!
