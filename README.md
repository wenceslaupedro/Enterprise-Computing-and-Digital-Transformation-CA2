# Enterprise-Computing-and-Digital-Transformation-CA2
Enterprise Computing and Digital Transformation

# TEST
# Fitness Tracker Project - C# & .NET 8

## Overview
This is a simple fitness tracker project built using C#, .NET 8, and MySQL. The application allows users to log their workout activity through an interactive calendar.

## Tech Stack
- **Backend**: ASP.NET Core 8 / Web API
- **Database**: MySQL
- **Client**: Web Application (ASP.NET Core MVC)
- **Cloud Deployment**: AWS, Azure, GCP, or OCI
- **Version Control**: GitHub / GitLab

## Features
- **User Authentication**:
    - Login page with options to sign in or sign up.
    - Sign-up page with fields for Name, Login, and Password.
- **Workout Tracking**:
    - A calendar interface on the main page.
    - Users click on a date to mark whether they worked out.
    - Visual feedback: dates turn **green** when a workout is logged, and **red** otherwise.
- **Responsive Design**:
    - The application is built using ASP.NET Core MVC to ensure a dynamic and responsive user interface.
- **Cloud Deployment Ready**:
    - The project is configured for easy deployment to popular cloud platforms like AWS, Azure, GCP, or OCI.
- **RESTful API**:
    - The backend exposes API endpoints to handle data operations, making it flexible for integration with other services.


## Setup Instructions
### 1. Clone the repository:
   ```sh
   git clone https://github.com/yourusername/fitness-tracker.git
   cd fitness-tracker
   ```
### 2. Set Up the MySQL Database

Although the default configuration in `appsettings.json` might be set to SQL Server LocalDB, this project is designed to work with MySQL. Follow these steps to configure MySQL:

- **Install MySQL Server:**  
  Download and install [MySQL Community Server](https://dev.mysql.com/downloads/) if you haven’t already.

- **Create the Database:**
    - Open your MySQL client (such as MySQL Workbench) or use the command line.
    - Create a new database named `FitnessTracker`:
      ```sql
      CREATE DATABASE FitnessTracker;
      ```

- **Run SQL Scripts:**
    - Navigate to the `/Database` folder in the repository where you will find the SQL scripts.
    - Execute these scripts in your MySQL client or via the command line to create the necessary tables and seed data.

- **Update the Connection String:**
    - Open `appsettings.json` and update the connection string under `"ConnectionStrings"` to point to your MySQL database. For example:
      ```json
      "ConnectionStrings": {
        "DefaultConnection": "server=localhost;port=3306;database=FitnessTracker;user=yourusername;password=yourpassword"
      }
      ```
    - Replace `yourusername` and `yourpassword` with your actual MySQL credentials.

- **Test the Connection:**  
  Run the application to confirm that it connects successfully to your MySQL database.

### 3. Update the connection string in `appsettings.json`.
### 4. Run the backend API:
   ```sh
   dotnet run --project WebApi
   ```
### 5. Run the frontend application:
   ```sh
   dotnet run --project FitnessTrackerApp
   ```

## Deployment
- The application can be deployed to AWS, Azure, GCP, or OCI.
- CI/CD setup for automatic deployment (coming soon!).

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you’d like to change.

## License
MIT License
