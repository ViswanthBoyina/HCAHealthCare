This is a sample project for maintaining patient and doctor records and appointment booking




-- LOCAL Setup steps

dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design

-->  
In AppSettings.json:-
-------
{
  "ConnectionStrings": {
	"SqlServerConnection": "Server=localhost;Database=Apollo;User Id=sa;Password=Passw0rd;
  }
}

--> 
In Program.cs or Startup.cs :-
-----
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

--> 
Open Package Manager Console:
 -- Run the command:  
    dotnet tool install --global dotnet-ef

 -- Add Migration - Run the command:  
    //dotnet ef migrations add InitialCreate --project StateHospital.Data --startup-project StateHospital.Presentation
    Add-Migration InitialCreate -Project StateHospital.Data -StartupProject StateHospital.Presentation
    (Note to remove the migration - Remove-Migration InitialCreate -Project StateHospital.Data -StartupProject StateHospital.Presentation)

 -- Apply changes - Run the command:  
    //dotnet ef database update --project StateHospital.Data --startup-project StateHospital.Presentation
    Update-Database -Project StateHospital.Data -StartupProject StateHospital.Presentation

To Update the database objects with new model changes --
 -- Run migration command - 
    Add-Migration UpdateModels -Project StateHospital.Data -StartupProject StateHospital.Presentation
