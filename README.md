# CQRS Manage System (ASP.NET Core + MediatR)

This project demonstrates a clean implementation of the **CQRS Pattern** using **MediatR** to manage Employee data while separating read and write responsibilities.

## Overview
The system uses:
- **Commands** → Create, Update, Delete  
- **Queries** → GetById, GetAll  
- **Handlers** → Contain the actual business logic  
- **MediatR** → Routes Commands/Queries to their handlers  
- **EF Core** → Database access through a custom `DBContext`

## Structure
- **Commands**
  - InsertEmpCommand  
  - EditEmpCommand  
  - DeleteEmpCommand  

- **Queries**
  - GetEmpQuery  
  - GetAllEmpsQuery  

- **Handlers**
  - InsertEmpHandler  
  - EditEmpHandler  
  - DeleteEmpHandler  
  - GetEmpHandler  
  - GetListEmpsHandler  

- **Domain & DB**
  - Employee (Entity)
  - DBContext (EF Core)

## How It Works

### Write Example (Command)
```csharp
await _mediator.Send(new InsertEmpCommand(model));
Read Example (Query)
var emp = await _mediator.Send(new GetEmpQuery(id));

Benefits

Clear separation between reading and writing

Clean controller logic

Easy to extend features

Test-friendly architecture

API Layer

EmployeeController sends Commands & Queries through MediatR without containing business logic.

Tech Stack

ASP.NET Core – C# – EF Core – MediatR – SQL Server
