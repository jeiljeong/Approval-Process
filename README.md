# ApprovalProcess Project

## Description

ApprovalProcess is a .NET Core application designed to streamline and automate the approval workflow in your organization. This application allows users to submit requests, which are then processed according to a predefined approval flow.

## Getting Started

### Prerequisites

- .NET 5.0 SDK or later
- A suitable IDE like Visual Studio or VS Code
- SQL Server or any compatible SQL database for development
- MongoDB instance for development

### Setup

1. Clone the repository:
   ```bash
   git clone https://github.com/jeiljeong/Approval-Process.git
2. Navigate to the project directory:
   ```bash
   cd ApprovalProcess
3. Restore dependencies:
   ```bash
   dotnet restore
4. Build the project:
   ```bash
   dotnet build

### Configuration

The project uses appsettings.json files for configuration. Follow these steps to set up your local environment:

1. Rename **appsettings.json** to **appsettings.Development.json** in the ApprovalProcess.API project.

2. Update **appsettings.Development.json** with your local development settings, such as database connection strings.
   ```bash
   {
      "ConnectionStrings": {
         "DefaultConnection": "Your SQL Server connection string",
         "MongoDbConnection": "Your MongoDB connection string"
      },
      "Logging": {
         "LogLevel": {
            "Default": "Debug",
            "System": "Information",
            "Microsoft": "Information"
         }
      }
   }
   ```

3. Ensure that **appsettings.Development.json** is listed in your **.gitignore** file to avoid pushing sensitive information to the public repository.

4. For production environments, set configuration values through environment variables or a secure **appsettings.Production.json that** is not tracked by Git.

### Running the Application
1. Navigate to the ApprovalProcess.API project directory:
   ```bash
   cd ApprovalProcess.API
2. Run the application:
   ```bash
   dotnet run
3. Access the application through the URL displayed in the console, typically http://localhost:5000 or https://localhost:5001

### Contributing

### Versioning

### Authors

### License

### Acknowledgments