# Workout Tracker - C# & .NET 8

**CA2 Mini Project for Enterprise Computing and Digital Transformation - TUD**

## Overview

This is a simple fitness tracker project built using C#, .NET 8, and Azure SQL Database. The application allows users to log their workout activity through an interactive calendar.

## Tech Stack

- **Backend:** ASP.NET Core 8 / Web API
- **Database:** Azure SQL Database
- **Client:** Web Application (ASP.NET Core MVC)
- **Cloud Deployment:** AWS, Azure, GCP, or OCI
- **Version Control:** GitHub / GitLab

## Features

### User Authentication

- Login page with options to sign in or sign up
- Sign-up page with fields for Name, Login, and Password

### Workout Tracking

- Calendar interface on the main page
- Users can click on a date to mark whether they worked out
- Visual feedback: dates turn green when a workout is logged, and red otherwise

### Responsive Design

- Built using ASP.NET Core MVC to ensure a dynamic and responsive user interface

### Cloud Deployment Ready

- Configured for easy deployment to popular cloud platforms

### RESTful API

- Backend exposes API endpoints to handle data operations
- Flexible for integration with other services

## Setup Instructions

### 1. Clone the Repository

```bash
git clone https://github.com/yourusername/fitness-tracker.git
cd fitness-tracker
```

### 2. Set Up the Azure SQL Database

#### Create an Azure SQL Database

1. Log in to the Azure Portal
2. Create a new SQL Database with the following details:
  - Database name (e.g., `FitnessTrackerAzure`)
  - Create a new server or use an existing one
  - Configure server name, admin login, and password
  - Select an appropriate pricing tier

#### Configure Server Firewall

1. Navigate to the server in the Azure Portal
2. In Firewalls and virtual networks settings, add your local machine's IP address
3. Save the changes

#### Obtain and Configure Connection String

1. In the Azure Portal, find the Connection strings section
2. Copy the ADO.NET connection string
3. Update `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=tcp:yourserver.database.windows.net,1433;Initial Catalog=FitnessTrackerAzure;Persist Security Info=False;User ID=yourusername;Password=yourpassword;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

4. Test the connection
5. Run Entity Framework Core migrations (if applicable):

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 3. Run the Backend API

```bash
dotnet run --project WebApi
```

### 4. Run the Frontend Application

```bash
dotnet run --project FitnessTrackerApp
```

## Deployment

- Deployable to AWS, Azure, GCP, or OCI
- CI/CD setup for automatic deployment (coming soon!)


## License

[MIT License](LICENSE)
