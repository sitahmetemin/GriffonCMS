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
The system was built with N-Tier Architecture and Domain Driven Design (DDD) was adopted.

### GriffonCMS.Persistance / GriffonCMS.Core
- The database is the access layer.
    - DBContext
    - Repositories

### GriffonCMS.Application / GriffonCMS.Business
- Business Logic
    - MediatR - CQRS / Services
    - DTOS
    - Options
    - AutoMapper Profiles
    - Registrations

### GriffonCMS.Domain
- It is the layer where domain separation is provided.
    - Entities
    - Repository Interfaces
    - Service Interfaces
    - ...

### GriffonCMS.Infrastructure
- You can access all external resources that the application will need through this layer.
    - IRequest Objects
    - Requests (Http, ...)
    - Request/Response Adapters
    - ...

### GriffonCMS.WebUI
- It is the layer where only Interface related operations are applied.
    - Contollers
    - Models
    - Areas
    - Views



