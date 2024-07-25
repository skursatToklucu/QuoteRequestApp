# QuoteRequestApp

**QuoteRequestApp** is a web application that allows users to choose transportation modes, calculate the number of boxes and pallets, and create shipping quotes.

## Technologies and Tools

### Backend
- **.NET 8**: Used for building the application logic and APIs.
- **ASP.NET Core 8**: Used for API development and application logic execution.
- **Entity Framework Core (EF Core)**: Used for database operations and ORM.
- **Swagger**: Used for API documentation and testing.
- **FluentValidation**: A library used for data validation and model validation.

### Frontend
- **Angular 18**: Framework used for building user interfaces.
- **Ng Zorro**: A UI component library for Angular, especially used for form elements and UI components.

### Other Tools
- **JWT (JSON Web Token)**: Used for user authentication and authorization.

## Architecture

**N-Tier Architecture**: The application is divided into the following layers:

- **API Layer**: Handles communication with the outside world, responding to client requests and providing data.
- **Application Layer**: Contains the business logic, services, validations, and business rules.
- **Data Access Layer**: Manages database operations and data access. Uses the Repository pattern.
- **Core Layer**: Contains the fundamental building blocks, models, and general business logic of the application.

## Setup

### Backend

1. **Database Settings**: Configure the database connection settings in the `appsettings.json` file.
2. **Migrations**:
   - Navigate to the `DataAccess` directory.
   - Run the following commands in the Package Manager Console:
   ```bash
   Add-Migration InitialCreate
   Update-Database

### Frontend

1.**Requirements**: Ensure Node.js and Angular CLI are installed.

2.**Install Dependencies**:
  ```bash
  npm install
  ```
3.**Start the Angular Application**:
  ```bash
  ng serve
  ```

## Default HTTP Configuration

The application is set to run on the default HTTP configuration. If you wish to change this setting:

1. **API Layer Configuration**:
   - Modify the `launchSettings.json` file in the API project. This file is located under the `Properties` folder in your API project directory.
   - Adjust the application URL under the `profiles` section to the desired configuration.

2. **Frontend Configuration**:
   - Update the base URL for the API in the `api.service.ts` file on the frontend side. This file is located in the `src/app/services` directory of the Angular project.
   - Ensure the `apiUrl` variable points to the correct backend endpoint after the change.

Make sure both the API and frontend configurations are consistent with each other to avoid connectivity issues.



