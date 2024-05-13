Weather Data Application
This Weather Data Application is designed to manage and display weather information. It allows for operations such as creating, updating, deleting, and fetching weather data, including hourly weather updates. Built with ASP.NET Core 8, the system employs Entity Framework Core for object-relational mapping, MediatR for implementing the CQRS pattern, AutoMapper for object mapping, and utilizes Background Services for scheduled tasks.

Features
CRUD Operations: Create, read, update, and delete weather data.
Hourly Weather Data: Manage and retrieve hourly updates on weather conditions.
Automated Cleanup: A background service that performs daily cleanup of outdated records.
CQRS Implementation: Separate command and query responsibilities for improved scalability and maintainability.
Technologies
ASP.NET Core 8
Entity Framework Core
MediatR
AutoMapper
Microsoft SQL Server
