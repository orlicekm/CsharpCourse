@snap[north span-100]
# Entity framework and repository design pattern
@snapend

@snap[midpoint span-100]
## Connection between application and database
@snapend

@snap[south-east span-30]
[ Michal Orlicek <xorlic00@stud.fit.vutbr.cz> ]
@snapend

---
## Basic terms
* **Software framework**
* **Database**
  * Database components, types
  * Persistence
  * Object-relational mapping
  * ACID, SQL, CAP, CRUD, DBMS...

---
## Software framework
* **Abstraction** providing **generic functionality**
* Can be selectively changed by additional user-written code
  * Providing application-specific software
* **Universal, reusable software environment**
  * Provides particular functionality as part of a larger software platform
    * To facilitate development of software applications

---
## Database
* **Persistent** data storage
* **Store**, **organize**, and **process information**
  * Query, sort, transform
* Can be **searched**, **referenced**, **compared**, **changed** or otherwise manipulated
* **Optimal speed** and **minimal processing expense**
* **Database management system (DBMS)**
  * System specifically designed to hold databases

+++
### Database components
* *Schema* - collection of one or more tables
* *Table* - contains multiple columns (similar to columns in a spreadsheet)
* *Column* - contains one of several types of data
* *Row* - **data** in a table is listed in rows (like rows of data in a spreadsheet)

+++
### Persistence
* **Official definition**
  * *The continuance of an effect after its cause is removed*
  * *Information survives after the process with which it was created has ended*
* **In database context**
  * *Data is available after application or system reboot*

+++
### ACID
![](/Lectures/Lecture04/Assets/img/acid.jpg)

+++
### CAP
@snap[midpoint]
![](/Lectures/Lecture04/Assets/img/CAPtheorem.png)
@snapend

+++
### CRUD
@snap[midpoint]
![](/Lectures/Lecture04/Assets/img/CRUD.jpg)
@snapend

+++
### Database Types
* *Relational (SQL)* vs *NoSql* databases
* *Single-File* vs *Multi-File* databases
* *Object Oriented* databases
![](/Lectures/Lecture04/Assets/img/SQLvsNOSQL.jpg)


+++
### SQL
* **Structured Query Language**
* Communicate with a database
* Standard language for relational database managment systems
![](/Lectures/Lecture04/Assets/img/sqlstatement.png)


@snap[east]
![](/Lectures/Lecture04/Assets/img/sql.gif)
@snapend

+++
### Microsoft SQL LocalDB
* Feature of *SQL Server Express*
* Targeted to developers
* Minimal set of files necessary to start the SQL Server Database Engine
* Initiate a connection using a special *connection string*
* When connecting, the necessary SQL Server infrastructure is automatically created and started
* Enabling the application to use the database without complex configuration tasks


+++ 
## Object-relational mapping
* *Programming technique*
  * Converting data between incompatible type systems 
  * Using object-oriented programming languages
* Table row to the object
* Creates *"virtual object database"*
* Can be used from within the programming language

@snap[east snap-100]
![](/Lectures/Lecture04/Assets/img/ORM.jpg)
@snapend

+++
### Pros of Object Relation Mapping
* *Abstract*
* *Portable*
* Writing code in *one language* (ORM takes care of vendor specific code by itself)
* *Code reduction* (most of the time)
* *Cache management*
  * Entities are cached in memory (reducing load on the database)

+++
### Cons of Object Relation Mapping
* *Slow*
* *Studying*
  * Minimize the DBMS hits
  * Reduce bad queries which hurts performance
* *Limitations* complex queries are needed
  * Sometimes is faster to write raw SQL

---
## Technologies used to connect to the database
* **ADO.NET**
* **Entity Framework** (used in this course)
* **Dupper**
* **nHibernate**

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

+++
## ADO.NET
* Used before Entity Framework
* Set of classes that expose data access services
  * SqlClient (`System.Data.SqlClient`)
  * OleDb (`System.Data.OleDb`)
  * Odbc (`System.Data.Odbc`)
  * ⋮

+++?code=/Lectures/Lecture04/Assets/sln/Examples/SqlClientExample.cs&lang=C#&title=ADO.NET SqlClient Sample
@[10-53]
@[10-12]
@[14-18]
@[20-21]
@[23-27]
@[28-30]
@[32-50]
@[10-53]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture01/Assets/sln/Examples/SqlClientExample.cs)

---
## Entity Framework (EF)
* **Official definition:** *“Entity Framework is an object-relational mapper (ORM) that enables .NET developers to work with a database using .NET objects. It eliminates the need for most of the data-access code that developers usually need to write.”*
* **Object-relational mapping framework**
* By Microsoft
* Enhancement to ADO.NET
* To automate all database related activities for your application
* Higher level of abstraction when dealing with data
* Enables to work with data using objects without focusing on the underlying database
* [Tutorial](http://www.entityframeworktutorial.net)

+++ 
### Entity Framework Main Features
* **Cross-platform** - EF Core is a cross-platform framework (Windows, Linux, Mac)
* **Modelling** - creates an Entity Data Model (EDM) based on Plain Old CLR Object (POCO) entities with get/set properties of different data types (used when querying or saving entity data)
* **Querying** - allows to use LINQ queries
* **Change Tracking** - keeps track of changes occurred to instances of your entities 
* **Saving** - executes commands to the database based on the changes occurred to your entities 
* **Concurrency** - uses Optimistic Concurrency by default to protect overwriting changes made by another user since data was fetched from the database
* **Transactions** - automatic customizable transaction management
* **Caching** - includes first level of caching out of the box (repeated querying will return data from the cache)
* **Built-in Conventions** - follows conventions over the configuration programming pattern, and includes a set of default rules which automatically configure the EF model
* **Configurations** - allows us to configure the EF model by using data annotation attributes or Fluent API to override default conventions
* **Migrations** - set of migration commands to create or manage underlying database Schema

+++ 
### Entity Framework Versions
* Currently, there are two latest versions of Entity Framework
* **EF 6** released in 2013 
  * .NET 4.0 & .NET 4.5
  * Visual Studio 2012
* **EF Core 2.0** released in August 2017
  * .NET Core 2.0
  * Visual Studio 2017
  * *Used in this course*

![](/Lectures/Lecture04/Assets/img/EFversions.png)

+++
### Entity Framework Core
* [GitHub](https://github.com/aspnet/EntityFrameworkCore)
* [Documentation](https://docs.microsoft.com/sk-sk/ef/core/)
* Is not a part of *.NET Core* or *Standard**
* Intended to be used with *.NET Core* applications
* Can also be used with standard *.NET 4.5+ framework* based applications
* Supported application types:

![](/Lectures/Lecture04/Assets/img/EFCoreSupport.png)

+++
### Approaches
* **Entity Framework Database First**
  * Creating Entity Data Model from your existing database
* **Entity Framework Code First**
  * *Used in this course*
  * Create the database based on your domain classes and configuration
  * Coding in C# or VB.NET and then EF will create the database from code

![](/Lectures/Lecture04/Assets/img/EFApproaches.png)


+++
### Data Providers
* Provider model to access many different databases
* NuGet packages which you need to install

| Database | NuGet Package |
|:-:|:- |
| SQL Server | [Microsoft.EntityFrameworkCore.SqlServer](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer) |
| MySQL | [MySql.Data.EntityFrameworkCore](https://www.nuget.org/packages/MySql.Data.EntityFrameworkCore) |
| PostgreSQL | [Npgsql.EntityFrameworkCore.PostgreSQL](https://www.nuget.org/packages/Npgsql.EntityFrameworkCore.PostgreSQL) |
| SQLite | [Microsoft.EntityFrameworkCore.SQLite](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SQLite) |
| SQL Compact | [EntityFrameworkCore.SqlServerCompact40](https://www.nuget.org/packages/EntityFrameworkCore.SqlServerCompact40) |
| In-memory | [Microsoft.EntityFrameworkCore.InMemory](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.InMemory) |

---
### Installation
* Install *NuGet* packages to use EF Core
  * **EF Core DB provider**
  * **EF Core tools**

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

+++
### Install DB Provider
* Install *NuGet package* for the provider of the database we want to access
* To access **MS SQL Server database**
  * We need to install `Microsoft.EntityFrameworkCore.SqlServer`
    * Tools -> NuGet Package Manager -> Manage NuGet Packages For Solution
    * OR `PM> Install-Package Microsoft.EntityFrameworkCore.SqlServer`

+++
### Install DB Provider Image 1/5
![](/Lectures/Lecture04/Assets/img/install-efcore-1.png)
+++
### Install DB Provider Image 2/5
![](/Lectures/Lecture04/Assets/img/install-efcore-2.png)
+++
### Install DB Provider Image 3/5
![](/Lectures/Lecture04/Assets/img/install-efcore-3.png)
+++
### Install DB Provider Image 4/5
![](/Lectures/Lecture04/Assets/img/install-efcore-4.png)
+++
### Install DB Provider Image 5/5
![](/Lectures/Lecture04/Assets/img/install-efcore-5.png)

+++
### Install Tools
* To execute EF Core commands
* Make it easier to perform several EF Core-related tasks in your project at design time
  * E.g. migrations, scaffolding etc.
* Available as NuGet packages
  * For **Package Manager Console** (PMC) as `Microsoft.EntityFrameworkCore.Tools`
  * For **Command Line Interface** (CLI) as `Microsoft.EntityFrameworkCore.Tools.DotNet`

+++
### Install Tools Image
![](/Lectures/Lecture04/Assets/img/install-efcore-6.png)

---
## Basic concepts
* Data Access Layer
* Entity
* DbContext

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

+++
### Data Access Layer (DAL)
* **Definition**
  * *Layer of a computer program which provides simplified access to data stored in persistent storage*
* DAL might **return a reference to an object complete with its attributes**
* Created higher level of abstraction

![](/Lectures/Assets/img/ef-in-app-architecture.png)

+++
### Entity
* `class` in the domain of your application
* Included as a `DbSet<TEntity>` type property in the derived context class

```C#
public class Student
{
    public int StudentID { get; set; }
    public string StudentName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public byte[]  Photo { get; set; }
    public decimal Height { get; set; }
    public float Weight { get; set; }
}
```

+++
### DbContext
* Integral part of Entity Framework
* Instance represents a session with the database
* Can be used to query and save instances of your entities to a database
* Is a combination of the **Unit Of Work** and **Repository** patterns
* Allows us to perform following tasks:
  1. Manage database connection
  2. Configure model & relationship
  3. Querying database
  4. Saving data to the database
  5. Configure change tracking
  6. Caching
  7. Transaction management

+++
### DbContext Creation
* Class that derives from `DbContext` (known as context class)
* Typically includes `DbSet<TEntity>` properties for each entity in the model


---
## Entity Relationships



---
## Dupper

+++
Dupper vs Entity Framework

---
## References:
[C# 7.0 in a Nutshell: The Definitive Reference](https://www.amazon.com/C-7-0-Nutshell-Definitive-Reference/dp/1491987650)  
[EntityFrameworkTutorial.net](http://www.entityframeworktutorial.net/)  
[Microsoft documentation](https://docs.microsoft.com)  
[Entity Framework GitHub](https://github.com/aspnet/EntityFrameworkCore)  
[Computer Hope](https://www.computerhope.com)  
[Wikipedia](https://en.wikipedia.org)

+++
## Refences to used images:
[EntityFrameworkTutorial.net](http://www.entityframeworktutorial.net/)  
[The Inquisitive Singh](https://inquisitivesingh.wordpress.com)  
[INTELLIPAAT.COM](https://intellipaat.com/)  
[Computer Hope](https://www.computerhope.com)  
[Wikipedia SQL](https://en.wikipedia.org/wiki/SQL)  
[ResearchGate](https://www.researchgate.net/)  
[Data36](https://data36.com/)