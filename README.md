# GriffonCMS

## Initial Flow
```
dotnet clean
dotnet restore
dotnet build
```
---
## Setup Database
**Package Manager Console:**
> Run inside **GriffonCMS\Business\GriffonCMS.Core** project
```
EntityFrameworkCore\Update-Database
```
**cli:**
```
dotnet ef database update
```

---
## Add Migration
**Package Manager Console:**
> Run inside **GriffonCMS\Business\GriffonCMS.Core** project
```
EntityFrameworkCore\add-migration [migrationName]
```
**cli:**
```
dotnet ef migrations add [migrationName]
```

## Architecture Summary
The system was built with N-Tier Architecture and adopted Clean Architecture and Repository design pattern.

### GriffonCMS.Domain
- It is the layer where domain separation is provided.
    - Entities
    - Service Interfaces
    - Enumerations
    - Exceptions
    - Logic
    - ...

### GriffonCMS.Application / GriffonCMS.Business
- Business Logic
    - MediatR + CQRS / Services
    - DTOS
    - Validators
    - Exceptions
    - AutoMapper Profiles
    - Registrations
    - Repository Interfaces, ...

### GriffonCMS.Persistence / GriffonCMS.Core
- The database is the access layer.
    - DBContext
    - Repositories
    - Migrations
    - DB Configurations
    - Seedings
    - ...

### GriffonCMS.Infrastructure
- You can access all external resources that the application will need through this layer.
    - IRequest Objects
    - Request/Response Adapters
    - Request/Response Models
    - Exp: Email/SMS/Notification
    - File System
    - Anything External
    - ...

### GriffonCMS.WebUI
- It is the layer where only Interface related operations are applied.
    - Contollers
    - View Models
    - Areas
    - Views

## Architecture Map
``` mermaid
graph TD;
    GriffonCMS.Domain --> GriffonCMS.Application
    GriffonCMS.Application --> GriffonCMS.WebUI
    GriffonCMS.Application --> GriffonCMS.Infrastructure
    GriffonCMS.Infrastructure --> Vendor
    GriffonCMS.Application --> GriffonCMS.Persistence
    GriffonCMS.Persistence --> DB
```



