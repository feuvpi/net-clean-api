# .NET Web API 8 Project

This is a .NET Web API 8 project that implements built-in email and password authentication, JWT, and a connection to a Postgres database using the micro-ORM Dapper. The project is structured in clean code architecture with the following layers:

- API: Contains the controllers and DTOs for the API endpoints.
- Application: Contains the application services and interfaces.
- Core: Contains the domain models and interfaces.
- Infrastructure: Contains the data access layer and implementations of the core interfaces.

## Getting Started

To get started with the project, you'll need to:

1. Clone the repository to your local machine.
2. Install the necessary dependencies using a package manager like NuGet.
3. Set up the Postgres database and update the connection string in the `appsettings.json` file.
4. Run the project using a tool like Visual Studio or the .NET CLI.

## Features

- Built-in email and password authentication.
- JWT authentication.
- Connection to a Postgres database using Dapper.

## Backlog

The following features are planned to be implemented in the future:

- [X] Dapper ORM
- [X] Postgres Database
- [X] Built-in Email+Password Authentication
- [ ] Cache service.
- [ ] OAuth integration.
- [ ] Monitoring tool.
