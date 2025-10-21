## Clean Architecture solution with xUnit tests.

👍 — Let’s design a Clean Architecture solution named TopUp with xUnit tests.

Below is the recommended folder structure (for .NET 8 or newer), following best practices for maintainability, testability, and separation of concerns.

🧩 Layer Responsibilities

1️⃣ Domain Layer (TopUp.Domain)

 - Pure business logic, no dependencies on other layers.
 - Contains:
   - Entities → e.g. User, TopUpTransaction
   - ValueObjects, Enums, Events, Domain Exceptions

2️⃣ Application Layer (TopUp.Application)

- Coordinates the app's business rules (CQRS pattern).
- Contains:
  - Commands / Queries (Handlers)
  - Interfaces for Infrastructure (e.g. IEmailService, IUnitOfWork)
  - MediatR pipeline behaviors (validation, logging)
  - FluentValidation, AutoMapper configurations

3️⃣ Infrastructure Layer (TopUp.Infrastructure)

- External dependencies:
  - Database (EF Core DbContext)
  - File storage
  - Email, SMS, External APIs
  - Logging and Identity
- Implements interfaces from the Application layer.

4️⃣ API Layer (TopUp.API)

- Entry point (Web API controllers)
- Handles:
  - Request/response mapping (DTOs)
  - Middleware (ExceptionHandler, JWT auth, Logging)
  - Swagger setup, DI registration

🏗 Folder Structure

<img width="386" height="1521" alt="image" src="https://github.com/user-attachments/assets/91e03550-e9b6-4938-a679-b05e01afb8a4" />
