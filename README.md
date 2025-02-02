# DirectoryX
## Individual Management System

This project is an **Individual Management System** built with **.NET 8**, **Entity Framework Core**, and a **Clean Architecture** approach. It follows the **CQRS pattern** with **MediatR**, uses **FluentValidation** for validation, and implements the **Result Pattern** for better error handling. The domain model is designed using **Domain-Driven Design (DDD)** principles, with a rich domain model and repository and unit of work pattern for data access.

---
![image](https://github.com/user-attachments/assets/58a6510a-2eec-492d-8a9b-f2fb22c0a3fe)

---

## Features

- **CQRS Pattern**: Separates commands (write operations) and queries (read operations) for better scalability and maintainability.
- **MediatR**: Handles commands and queries using the mediator pattern.
- **FluentValidation**: Provides robust validation for incoming requests.
- **Result Pattern**: Ensures consistent error handling and response formatting.
- **Unit of Work and Repository Patterns**: Abstracts data access logic and ensures transactional consistency.
- **Rich Domain Model**: Encapsulates business logic within the domain entities.
- **Logging**: Integrated logging for request processing and error tracking.
- **API Endpoints**: RESTful API for managing individuals and their related parties.

---

## Technologies Used

- **.NET 8**: The latest version of the .NET framework.
- **Entity Framework Core**: ORM for database interactions.
- **MediatR**: Mediator pattern implementation for CQRS.
- **FluentValidation**: Validation library for .NET.
- **Result Pattern**: Custom implementation for consistent error handling.
- **Repository Pattern**: Abstraction layer for data access.
- **Unit of Work**: Ensures transactional consistency across repositories.
- **Swagger/OpenAPI**: API documentation and testing.

---

## API Endpoints

### Individuals Controller (`/api/individuals`)

| Method | Endpoint                     | Description                                      |
|--------|------------------------------|--------------------------------------------------|
| POST   | `/api/individuals/Search`    | Search for individuals based on criteria.        |
| GET    | `/api/individuals/{id}`      | Get an individual by ID.                         |
| POST   | `/api/individuals`           | Add a new individual.                            |
| PUT    | `/api/individuals`           | Update an existing individual.                   |
| POST   | `/api/individuals/update-picture` | Update an individual's profile picture.      |
| DELETE | `/api/individuals/{id}`      | Delete an individual by ID.                      |

### Related Individuals Controller (`/api/related-individuals`)

| Method | Endpoint                     | Description                                      |
|--------|------------------------------|--------------------------------------------------|
| GET    | `/api/related-individuals/report` | Generate a report of related individuals.    |
| POST   | `/api/related-individuals`   | Add a related individual.                        |
| DELETE | `/api/related-individuals`   | Delete a related individual.                     |

---

## Getting Started

### Prerequisites

- **.NET 8 SDK**: [Download .NET 8](https://dotnet.microsoft.com/download/dotnet/8.0)
- **Database**: Mssql.
- **IDE**: Visual Studio 2022, Visual Studio Code, or JetBrains Rider.

### Setup
- When you clone this repository and run the code, it will work automatically. It will create the tables in your db and it will also insert the starting data for you to test the project.
- The only you thing you might want to change is in the appsetting.development.json. You can change any directory path or you can ching the connection string, that is up to you.

### Testing
- If you want to test the application, you can use the swagger ui. <localhost>/swagger/index.html.
