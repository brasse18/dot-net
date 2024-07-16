# Console Application for Competitions Management

This repository contains a .NET console application that performs three tasks involving data retrieval and processing. The application is built using Visual Studio and Microsoft SQL Server (or SQL Server Express). The primary language used is C#.

## Tools and Technologies

- **Visual Studio** (Community version available [here](https://visualstudio.microsoft.com/))
- **Microsoft SQL Server** (SQL Server Express can be downloaded [here](https://www.microsoft.com/en-us/sql-server/sql-server-downloads))
- **.NET Framework** (Compatible versions: 4.x, 5.x – 8.x, or .NET Core)

## Tasks Overview

### Task 1: Data Retrieval Using Entity Framework

- **Goal:** Retrieve and display competition data from a database using Entity Framework (EF).
- **Entity Framework Version:** EF 6.x for .NET Framework 4.x, or EF Core for later versions.
- **Database Structure:**
  - **Entities:** Competition and Participant, each with an ID and Name.
  - **Relations:** A competition can have multiple participants, but a participant can only join one competition.
- **Application Structure:** The solution is divided into three projects:
  1. **Console Application** (.NET Console App)
  2. **Data Access Layer** (Class Library)
  3. **Domain Model** (Class Library with EF entities)
- **Implementation Approach:** 
  - Code First with EF to generate database schema from domain models.
  - Use fluent mapping for entity-table mapping and relationship setup.
- **Data Access Layer Methods:**
  - Retrieve a list of all competitions.
  - Retrieve a specific competition by ID.
- **Console Output:** Display the names of all competitions and their participants.
- **Test Data:** Include sample data in the solution for demonstration.

### Task 2: Data Retrieval Using ADO.NET

- **Goal:** Retrieve and display competition data using ADO.NET and SQL queries.
- **Implementation:** Directly within the console application.
- **Database Connection:** Use `System.Data.SqlClient` for SQL Server Express.
- **Data Retrieval:** 
  - Execute SQL queries to fetch data.
  - Use `DataTable` or `DataReader` for data manipulation.
- **Console Output:** Display the names of all competitions and their participants.

### Task 3: Sorting Integers Alphabetically

- **Goal:** Sort a list of integers (1 to 25) alphabetically by their Swedish names.
- **Implementation:** Directly within the console application.
- **Output:** Display the sorted list of integers based on their Swedish name equivalents.

## Database Setup

- **SQL Server Express Installation:** Download from [here](https://go.microsoft.com/fwlink/?linkid=866658).
- **Management Studio:** Download SQL Server Management Studio (SSMS) from [here](https://docs.microsoft.com/sql/ssms/download-sql-server-management-studio-ssms).

## Getting Started

1. **Clone the Repository:**
   ```bash
   git clone https://github.com/yourusername/console-application.git
## Open the Solution in Visual Studio:
Open ConsoleApplication.sln in Visual Studio.
## Build the Solution:
Restore NuGet packages and build the solution.
## Set Up the Database:
Use the EF migrations to create and seed the database.
## Run the Application:
Set the console application as the startup project and run it.
