# Minimal API

## Description

Minimal API is a .NET Minimal API project that provides a structured and efficient way to interact with a database. Below is a detailed overview of the project's structure and functionalities:

### Project Structure

- **Infrastructure**: This directory contains everything related to the database, including:
  - **DbContext**: Manages database connections and transactions.
  - **Models**: Defines the data models used in the application.
  - **Commands**: Contains classes for executing database commands.
  - **Contracts**: Defines interfaces and contracts for the repository.
  - **Repository**: Implements the repository pattern for data access.

- **Helper**: Contains utility classes for various tasks, such as:
  - **DateTime Converter**: Converts date and time formats.
  - **Json Serializer**: Handles JSON serialization and deserialization.
  - **Seeder**: Seeds the database with initial data.

- **Exceptions**: Contains custom exceptions to handle specific error scenarios.

- **ErrorHandlingMiddleware**: Middleware for handling errors in the application.

- **SchemaFilter**: Configures Swagger for API documentation.

### Endpoints

The API provides the following endpoints:

- **GET /Osoby**: Retrieves a list of all `Osoby` in the database.
- **GET /Osoby/{id}**: Retrieves an `Osoba` by its Id.
- **POST /Osoby**: Adds a new `Osoba` to the database.

### Usage Instructions

To safely save the current database status, avoid abruptly terminating the process. The recommended way to stop the application is by pressing `CTRL+C` in the program console.

---

This README provides an overview of the Minimal API project. For more detailed documentation, please refer to the source code and comments within the project files.
