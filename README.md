# Patient Tracker

A web app and REST API for tracking patients, built with ASP.NET Core.

## Projects

- **PatientAPI** – ASP.NET Core Web API using Entity Framework Core and SQL Server
- **PatientTracker** – ASP.NET Core MVC web app (Razor views, Bootstrap) that consumes the API

## API endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | /api/patients | List all patients |
| GET | /api/patients/{id} | Get one patient |
| POST | /api/patients | Add a patient |
| PUT | /api/patients/{id} | Update a patient |
| DELETE | /api/patients/{id} | Delete a patient |

Responses use standard HTTP status codes (200, 201, 204, 400, 404).

## Patient fields

FirstName, LastName, Age, Symptoms, BedNumber

## Running locally

1. Clone the repo.
2. Set the `DefaultConnection` string for your SQL Server instance in `PatientAPI/appsettings.json`.
3. Apply the database migrations: `dotnet ef database update`.
4. Start `PatientAPI`, then `PatientTracker`.

## Possible next steps

- Authentication and authorisation
- Input validation and DTOs
- Unit tests

