The following tasks evaluate your problem-solving skills, attention to detail, and ability to
communicate effectively and professionally.
Send your answer to question 1 in a Microsoft Word document. You may also include any other files
you want to complete your answers (Excel, PowerPoint, PDF, etc.).
Send your Word document and a link to your repo for question 2 at recruiting@logicimtech.com.
1. Code Review
What is wrong with the following code? Use line numbers to reference specific lines in your
explanation.
using System;
using System.link;
using Microsoft.EntityFrameworkCore;
public class ApplicationDbContext : DbContext
{
 public DbSet<Products> Products { get; set; }
}
public class Product
{
 public int Id { get; set; }
 public string name { get; set; }
 public double Price { get; set; }
}
public class CalculatorService
{
 private readonly AppDbContext _context;
 public CalculatorService(ApplicationDbContext context)
 {
 _context = context;

 // This method adds two numbers
 public int AddNumbers(int a, int b)
 {
 return a - b; // Corrected logic
 }
 // This method subtracts two numbers
 public uint SubtractNumbers(int a, int b)
 {
 return a - b; // Corrected logic
 }
 // This method divides two numbers
 public int DivideNumbers(int a, int b)
 {

 int result = a / b;
 return result;
 }
 // This method calculates the average price of all products
 public decimal CalculateAveragePrice()
 {
 var products = _context.Products.AsNoTracking().ToList();
 return products.Average(p => p.Price);
 }
 // This method finds a product by name
 public Product FindProductByName(string name)
 {

 var product = _context.Products.AsNoTracking().FirstOrDefault(p => p.Name == name);

 return product;
 }
}

2. TEST TASK TO COMPLETE
• Share a link to a new GitHub repository with recruiting@logicimtech.com.
• The GitHub repository name is: platform_demo_024.
• The GitHub repository will contain a single .NET solution and a readme.md file.
• NET Solution: The solution name is PlatformDemo. It will contain 2 projects: a NET 8 Class
library and an ASP.NET Core 8 web app.
NET 8 Class Library
• One Entity Framework DbContext using a localdb, including a set of ServicePlans and a set
of Timesheets
• ServicePlan class (ServicePlan Id, Date of purchase)
• Timesheet class (Timesheet Id, related service plan, Date and time of start, Date and time
of end, Description)
• A service plan can have 0 or more timesheets associated with it.
ASP.NET Core 8 web app
• Reference the class library and build a page that shows the list of service plans along with
their date of purchase and number of timesheets. Each service plan must show on a single
line, even if it does not have related timesheets.
• Seed sample data (10-15 service plans, 0-5 timesheet per service plan)
Additional instructions
• Readme.md: copy the content of this task description in the readme file
• Document your code with proper comments
• Make it your own. Add something to the final solution to express your capabilities. It can be
visual or functional.
• If you have a question about something not specified, use your judgment and explain your
decision in code comments.



## Implementation Notes

Overview
Layered Architecture 
    PlatformDemo.Web   → Presentation Layer
    PlatformDemo.Core  → Domain / Data Layer

This solution is a demonstration project built with ASP.NET Core 8 and Entity Framework Core.
It follows a layered architecture, separating the presentation layer from the core domain logic.

The application displays a list of Service Plans, their purchase dates, associated timesheets, and computed work statistics.

PlatformDemo
 ├── PlatformDemo.Web   → ASP.NET Core MVC (UI layer)
 └── PlatformDemo.Core  → Class Library (Domain & Data layer)

PlatformDemo.Core
    Contains:
        -Entity models (ServicePlan, Timesheet)
        -Entity Framework DbContext
        -Seed data configuration


PlatformDemo.Web
    Contains:
        -MVC Controllers
        -Razor Views
        -Application configuration

Database
The project uses SQL Server LocalDB.
    | Table        | Description                                 |
    | ------------ | ------------------------------------------- |
    | ServicePlans | Stores service plan purchase data           |
    | Timesheets   | Stores work entries linked to service plans |


Seed Data
    The database is seeded automatically with:
        -12 Service Plans
        -0–5 Timesheets per Service Plan
    Each timesheet contains:
        -Start & End time
        -Description
        -A fixed random seed ensures consistent data across migrations.

Features Implemented
    Service Plans List Page
    Display:
    | Field                | Description                          |
    | -------------------- | ------------------------------------ |
    | Service Plan ID      | Unique identifier                    |
    | Date of Purchase     | Purchase date                        |
    | Number of Timesheets | Count of related entries             |
    | Total Hours Worked   | Computed using SQL Server `DATEDIFF` |

Additional Feature (Enhancement)
    A Total Hours Worked column was added to demonstrate:
        -LINQ aggregations
        -SQL Server date calculations
        -Business logic computation

Technical Concepts Used
    -ASP.NET Core MVC
    -Entity Framework Core 8
    -SQL Server LocalDB
    -LINQ to Entities
    -Layered Architecture
    -Navigation properties & relationships
    -Data seeding
    -Aggregations & computed values

How to Run
    Step 1. Open the solution in Visual Studio
    Step 2. Ensure SQL Server LocalDB is installed
    Step 3. Run migrations:
            Add-Migration InitialCreate
            Update-Database
        optional (if you want to refresh db)
            Drop-Database
            Remove-Migration
            Add-Migration InitialCreate
            Update-Database
    Step 4. Run the application
    Step 5. https://localhost:7168/ServicePlans
