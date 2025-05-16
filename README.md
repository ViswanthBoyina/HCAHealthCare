This web application enables to book appointments with doctors in a hospital. It supports full CRUD functionality with Patient Management and scheduling appointment.

Tech Stack Used:
1.	Backend: ASP.NET Core MVC (C#)
2.	Frontend: Razor Views (HTML/CSS)
3.	Database: SQL Server with Entity Framework Core
4.	Architecture: Layered (Presentation, Services, Data, Common)
5.	Tools/Libraries: AutoMapper, Dependency Injection, LINQ

Prerequisites:
1.	.NET 6+ SDK
2.	SQL Server
3.	Visual Studio or VS Code

Steps:
1.	Clone the repository from GitHub
2.	Restore NuGet packages using Visual Studio or dotnet restore
3.	Configure SQL Server in appsettings.json
4.	Run the application using dotnet run or via Visual Studio
5.	Navigate to https://localhost:xxxx in browser

Best Practices Followed:
1.	Layered Architecture (Presentation, Services, Data)
2.  SOLID Principles
3.  Dependency Injection across layers
4.  AutoMapper for model/entity mapping
5.  Separation of Concerns in code structure
6.  Clean Code & Commenting
