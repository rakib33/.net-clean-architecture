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

🧪 Test Projects
Unit Tests (TopUp.UnitTests)

Test Application & Domain layers.
Use xUnit, Moq, and FluentAssertions.
Example folders:
              - tests/TopUp.UnitTests/Application/Handlers/
              - tests/TopUp.UnitTests/Domain/Entities/

Integration Tests (TopUp.IntegrationTests)
 - Test Infrastructure with real DB (SQLite in-memory or TestContainers).

Functional Tests (TopUp.FunctionalTests)
 - End-to-end API tests using WebApplicationFactory.

🧱 1️⃣ Clean Architecture Terminology

In Clean Architecture, we usually have layers (or projects) like:
 - Domain
 - Application
 - Infrastructure
 - Presentation (API/UI)

Now, these layers can be organized in two ways:

🗂️ Option A — Each Layer as a Separate Project (Recommended for real solutions)

✅ Professional / Enterprise-level approach

Structure:
<img width="607" height="330" alt="image" src="https://github.com/user-attachments/assets/e1b05ca2-e4b0-4170-aeeb-1a5f8dd77fed" />

Each folder (TopUp.Domain, TopUp.Application, etc.) contains a .NET project (class library or webapi).

So here:
 - TopUp.Domain → both folder name and project name
 - TopUp.Application → both folder name and project name

Each one will have its own .csproj file, for example:
 - src/TopUp.Domain/TopUp.Domain.csproj

🔗 Project References

Each layer references only what it needs:

<img width="870" height="237" alt="image" src="https://github.com/user-attachments/assets/88c3531a-0449-4f5c-bed4-8a65bc1e675f" />

This gives strong isolation and enforces architectural rules.

📁 Option B — One “Domain” Folder with a Subproject Inside

✅ Simpler for small or learning projects

Structure:

<img width="481" height="652" alt="image" src="https://github.com/user-attachments/assets/6c9aecb5-9979-40d6-9099-8c8f221c0dc0" />

Here:

 - Folder name = layer name (Domain, Application, Infrastructure, Presentation)
 - Project name still includes the full solution prefix (TopUp.Domain, TopUp.Application, etc.)

🧩 Example:

<img width="501" height="137" alt="image" src="https://github.com/user-attachments/assets/4992e44c-e8af-4735-890d-1c73aac7203d" />

⚖️ Which Style Should You Use?
<img width="842" height="192" alt="image" src="https://github.com/user-attachments/assets/e8e84841-a41b-4ee5-ad4f-208b4dcfb851" />

🧱 how Clean Architecture dependencies work under the hood.
   - The setup you’re referring to:

   <img width="886" height="237" alt="image" src="https://github.com/user-attachments/assets/8f169fcd-c7e8-46bf-9842-f1ef80267135" />

⚖️ Summary Table

  <img width="843" height="232" alt="image" src="https://github.com/user-attachments/assets/254560e3-c49a-4d13-9727-3c22e3a143ea" />

🧱 1️⃣ Layered Architecture (Traditional)

 - Controller → Service → Repository → DbContext
 - Controller (Presentation Layer): Handles HTTP requests/responses.
 - Service: Contains business logic (validation, transformations).
 - Repository: Talks to database (CRUD).
 - DbContext: Actual EF Core implementation.

🧩 2️⃣ Clean Architecture Equivalent

In Clean Architecture, the same flow exists — but responsibilities are more organized and decoupled:

<img width="823" height="313" alt="image" src="https://github.com/user-attachments/assets/da637114-64d7-4068-ada0-3ee1c6c45942" />
