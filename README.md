# Enterprise-Computing-and-Digital-Transformation-CA2
Enterprise Computing and Digital Transformation

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
  - Login page with fields for Login and Password.
- **Workout Tracking**:
  - A calendar interface on the main page.
  - Users click on a date to mark whether they worked out.
  - If "Yes" is chosen, the date turns **green**; if "No" is chosen, the date turns **red**.

## Setup Instructions
1. Clone the repository:
   ```sh
   git clone https://github.com/yourusername/fitness-tracker.git
   cd fitness-tracker
   ```
2. Set up the MySQL database (SQL scripts provided in `/Database` folder).
3. Update the connection string in `appsettings.json`.
4. Run the backend API:
   ```sh
   dotnet run --project WebApi
   ```
5. Run the frontend application:
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
