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

🔁 Data Flow

<img width="431" height="193" alt="image" src="https://github.com/user-attachments/assets/9f2cb1cd-1911-4011-92a5-9521fcbb7a0b" />

🧩 Student CRUD Example (Simplified)

  🧭 Folder Structure (just related parts)

  <img width="327" height="568" alt="image" src="https://github.com/user-attachments/assets/9314ccd4-236b-4060-af15-0ae73c76b4e6" />

🧩 Domain Interface
   
   - Only database related Interface will add in Domain layer.
   - Interface that has data fetch, insert/post , update ,delete will declare here.
   - This interface implementation will implement in Infrustraction layer.
   - So High lavel (Domain) doesn't depends on low label(Infrustracture). Rather they depends on Interface.

🧩 Step-by-Step Implementation

1️⃣ Domain Layer — Entity

```
// TopUp.Domain/Entities/Student.cs
namespace TopUp.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public int Age { get; set; }
        public string Email { get; set; } = default!;
    }
}
```

2️⃣ Domain Layer — Interface

```
using TopUp.Domain.Entities;

namespace TopUp.Domain.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Student?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task AddAsync(Student student, CancellationToken cancellationToken = default);
        Task UpdateAsync(Student student, CancellationToken cancellationToken = default);
        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
```

3️⃣ Application Layer — Commands + Queries

- Create Command
  <img width="393" height="432" alt="image" src="https://github.com/user-attachments/assets/2031c748-3308-4688-9c4d-2451d852272d" />

```
using TopUp.Application.Common.CustomMediator;

namespace TopUp.Application.Features.Students.Commands
{
    public record CreateStudentCommand : IRequest<long>
    {
        public string Name { get; set; } = "";
        public int Age { get; set; }
        public string Email { get; set; } = "";
    };
}
```

- Create Handler

```

using TopUp.Application.Common.CustomMediator;
using TopUp.Application.Features.Students.Commands;
using TopUp.Domain.Entities;
using TopUp.Domain.Interfaces;

namespace TopUp.Application.Features.Students.Handlers
{
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand,long>
    {
        private readonly IStudentRepository _repo;
        public CreateStudentHandler(IStudentRepository repo)
        {
            _repo = repo;
        }

        public async Task<long> Handle(CreateStudentCommand request, CancellationToken cancellationToken = default)
        {
            var student = new Student { Name = request.Name, Age = request.Age };
            await _repo.AddAsync(student, cancellationToken); // pass token down to db
            return student.Id;
        }
    }
}

```

- Get All Query

```
using TopUp.Application.Common.CustomMediator;
using TopUp.Domain.Entities;

namespace TopUp.Application.Features.Students.Queries
{
    public record GetStudentsQuery() : IRequest<IEnumerable<Student>>;
}
```

- Get All Handler

```
using TopUp.Application.Common.CustomMediator;
using TopUp.Application.Features.Students.Queries;
using TopUp.Domain.Entities;
using TopUp.Domain.Interfaces;

namespace TopUp.Application.Features.Students.Handlers
{

    public class GetStudentsHandler : IRequestHandler<GetStudentsQuery, IEnumerable<Student>>
    {
        private readonly IStudentRepository _repo;
        public GetStudentsHandler(IStudentRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Student>> Handle(GetStudentsQuery request, CancellationToken cancellationToken = default)
        {
            return await _repo.GetAllAsync(cancellationToken);
        }
    }
}

```  

4️⃣ Infrastructure Layer — Repository Implementation

```
using Microsoft.EntityFrameworkCore;
using TopUp.Domain.Entities;
using TopUp.Domain.Interfaces;
using TopUp.Infrastructure.Persistence.Context;

namespace TopUp.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllAsync(CancellationToken cancellationToken = default) =>  await _context.Students.ToListAsync(cancellationToken);
        
        public async Task<Student?> GetByIdAsync(int id, CancellationToken cancellationToken = default) => await _context.Students.FindAsync(id, cancellationToken);

        public async Task AddAsync(Student student, CancellationToken cancellationToken = default)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Student student, CancellationToken cancellationToken = default)
        {

            _context.Students.Update(student);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
       
    }
}
```

🧱 API Layer — Controller

```

using Microsoft.AspNetCore.Mvc;
using TopUp.Application.Common.CustomMediator;
using TopUp.Application.Features.Students.Commands;
using TopUp.Application.Features.Students.Queries;
using TopUp.Domain.Entities;

namespace TopUp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Student>> GetAll()
        {
            try
            {
                return await _mediator.Send(new GetStudentsQuery());
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception)
            {
                return Enumerable.Empty<Student>();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStudentCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(new { StudentId = id });
        }
    }
}
```

✅ Summary Flow

```
HTTP Request
   ↓
Controller (API)
   ↓
MediatR → Application Handler 
   ↓
Repository Interface Call (Application)
   ↓
Repository Implementation (Infrastructure)
   ↓
DbContext (EF Core)
```

1️⃣ What is DependencyInjection.cs?

In Clean Architecture, we usually create a static helper class called DependencyInjection.cs in each layer/project (Application, Infrastructure, sometimes Domain if needed).

Its purpose:
 - Register services, MediatR handlers, repositories etc. for that layer.
 - Keep Program.cs / Startup.cs clean.

2️⃣ Where to put it?

You have options:
Option A — Root of the Project (Recommended)

```
TopUp.Application/
 ├── DependencyInjection.cs   ← good, simple
 ├── Interfaces/
 ├── Features/
 └── TopUp.Application.csproj

```
- Keeps it easy to find.
- Other projects (Infrastructure, API) can call services.AddApplication().

Option B — Separate folder like “Configuration” or “DI”

```
TopUp.Application/
 ├── Configuration/
 │    └── DependencyInjection.cs
 ├── Interfaces/
 └── Features/
```
More structured if you have many startup configurations.

- Optional, adds a bit of nesting.
- Option C — Folder per feature.

3️⃣ Summary / Recommendation

- You do not need a separate folder just for DependencyInjection.
- Most clean architecture projects just put DependencyInjection.cs in the root of Application/Infrastructure project.

Keep it simple — if later the file grows too big, you can create a folder.
Not recommended for DI — keep DI at project level so you can register all handlers/repositories/services in one place.

💡 Example Call from API

```
// Program.cs
builder.Services.AddApplication();    // calls Application.DependencyInjection
builder.Services.AddInfrastructure(builder.Configuration); // Infrastructure DI

```

This makes Program.cs clean and each layer self-contained.

🧱 1️⃣ What Mediator Does

The Mediator pattern decouples senders and receivers:

```
Sender (Controller) → Mediator → Handler → Response
```

- Controller doesn’t call repository directly
- Only sends a request to the mediator
- Mediator finds the appropriate handler and executes it
- Returns result back to controller

✅ Advantages of Custom Mediator

 - Lightweight — no external dependencies
 - Full control over behavior
 - Can easily add custom pipelines (logging, validation, caching)
 - Perfect learning exercise

1️⃣ Use Git Branches for Version Management

 - Each branch can represent a version/state of your app:

dev → for ongoing development
staging → for QA/testing
release / production → for live deployments

- In Visual Studio 2022:

1. Open Git Changes panel (View → Git Changes).
2. Click Branch dropdown → New Branch.
3. Name it according to versioning logic, e.g., v1.0-dev, v1.0-release.

2️⃣ Use Git Tags for Version Numbers

Tags are snapshots of specific commits.

 - Light tags → simple labels (e.g., v1.0.0)
 - Annotated tags → include metadata, author, date, and message

In Visual Studio 2022:

1. Go to Git Repository Window (View → Git Repository).
2. Right-click a commit → Create Tag.
3. Name the tag according to versioning, e.g., v1.2.0-dev.

This is better than putting versions in branch names alone, as you can tag releases precisely.

3️⃣ Automatically Version in the Project

For .NET projects, you can maintain version in the .csproj file:

```
<PropertyGroup>
    <Version>1.0.0-dev</Version>
    <FileVersion>1.0.0.0</FileVersion>
    <AssemblyVersion>1.0.0.0</AssemblyVersion>
</PropertyGroup>

```

Tip:
You can change version per branch using:

Branch-specific .csproj edits
Or a Directory.Build.props override per branch
Or a build pipeline (CI/CD) to automatically inject version based on branch name/tag.

4️⃣ Example Hierarchy / Flow

```
main (production-ready)
│
├─ release/1.2
│   └─ hotfix/1.2.1
│
└─ develop (active dev)
    ├─ feature/login
    ├─ feature/payment
    └─ bugfix/123

```

Deployment Mapping:

develop → stage (QA/testing)
release/x.y → production (after testing)
hotfix/x.y.z → production (emergency fix)
main = always production stable

💡 Tips:

Keep main / production stable — never push untested code.
Use release/x.y to prep for production; merge back to develop to keep fixes.
Use short-lived feature branches for daily development.

<img width="1536" height="1024" alt="GitBranch" src="https://github.com/user-attachments/assets/dabf1cc0-7e4c-4626-80d1-50f32bd70568" />

🧠 What is an Integration Test?

An integration test verifies that multiple parts of your system work correctly together — for example:

 - Your controller, routing, middleware, filters, and dependency injection all functioning as expected.
 - Ensuring real infrastructure boundaries (like database, HTTP calls, or file storage) behave correctly when connected.

Unlike unit tests, which test a single class or method in isolation, integration tests start your real application (or parts of it) and make real HTTP calls to the in-memory web server.

🧩 Example:

```
| Test Type            | What It Tests                    | Example                                                                                                 |
| -------------------- | -------------------------------- | ------------------------------------------------------------------------------------------------------- |
| **Unit Test**        | One method/class only            | Does `AgentBalanceController` return OK when mediator returns a list?                                   |
| **Integration Test** | Components working together      | Can `/get-topup-request-async` endpoint return a list when the app runs with DI + routing + middleware? |
| **End-to-End (E2E)** | Full system + external resources | Does the deployed API connect to the real DB and return expected data for an agent?                     |

```
🏗️ Should You Create a Separate Project?

✅ Yes — absolutely recommended.

Typical structure:
```
MyApp.sln
├── src/
│   ├── MyApp.Api/
│   ├── MyApp.Application/
│   ├── MyApp.Infrastructure/
│   └── MyApp.Domain/
└── tests/
    ├── MyApp.UnitTests/
    └── MyApp.IntegrationTests/
```

This separation gives you:

- Independent dependencies (Moq, FluentAssertions, Microsoft.AspNetCore.Mvc.Testing)
- Clean build pipelines (dotnet test can run all or specific test types)
- Ability to spin up full API instances without polluting your main app
- Clear distinction between fast (unit) and slow (integration) tests

🎯 What You Can Test with Integration Tests

You can test almost the entire request lifecycle, such as:

1. Controller & Routing

✅ Verify that all routes (/api/...) map correctly and return proper HTTP responses.

2. Middleware

✅ Test if authorization, exception handling, logging, and response compression work.

3. Dependency Injection

✅ Ensure correct service registration — e.g. IMediator, IRepository, IUnitOfWork resolve properly.

4. Filters & Attributes

✅ Validate [Authorize], [ValidateModel], or [HttpGet] route behaviors.

5. Model Binding & Validation

✅ Send malformed or missing data and verify validation messages.

6. Database or Infrastructure Integration

✅ Optionally test with an in-memory EF Core database (no real DB connection) using UseInMemoryDatabase.

7. Real Serialization

✅ Confirm that your JSON structure and field names match expectations.

⚖️ Summary — How Many Tests You Can Achieve

```
| Type                       | Scope                 | Example Count | Runtime | Purpose                        |
| -------------------------- | --------------------- | ------------- | ------- | ------------------------------ |
| **Unit Tests**             | Individual methods    | 100+          | Fast    | Logic correctness              |
| **Integration Tests**      | API + DI + Middleware | 10–30         | Medium  | System integration correctness |
| **E2E / Functional Tests** | Full stack + real DB  | 5–10          | Slow    | Real-world behavior            |

```
Rule of thumb:

~80% Unit Tests, ~15% Integration Tests, ~5% E2E Tests
That balance keeps your test suite fast but reliable.

✅ TL;DR — Quick Takeaways
Question	Answer

Should I create a separate project?	✔️ Yes, MyApp.IntegrationTests

What’s integration testing?	Testing real interactions (controller, DI, routing, middleware)

Can I mock dependencies?	✔️ Yes, like IMediator or external services

Can I include DB tests?	✔️ With EF InMemory or TestContainers

How many integration tests?	Around 10–30 covering key API endpoints

