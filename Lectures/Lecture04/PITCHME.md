# Entity framework and repository design pattern

@snap[midpoint span-100]
## Connection between application and database

<div class="right">
[ Michal Orlicek <xorlic00@stud.fit.vutbr.cz> ]
</div>

@snapend

---
## Definitions
* Software framework 
* Database
* Persistence

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

+++
## Software framework
* **Abstraction** providing **generic functionality**
* Can be selectively changed by additional user-written code
  * Providing application-specific software
* **Universal, reusable software environment**
  * Provides particular functionality as part of a larger software platform
    * To facilitate development of software applications

+++
## Database
* Large quantity of indexed digital information
* Can be **searched**, **referenced**, **compared**, **changed** or otherwise manipulated
* **Optimal speed** and **minimal processing expense**
* **Components**
  * *Schema* - collection of one or more tables
  * *Table* - contains multiple columns (similar to columns in a spreadsheet)
  * *Column* - contains one of several types of data
  * *Row* - **data** in a table is listed in rows (like rows of data in a spreadsheet)


+++
TODO DIAGRAM

+++
## Persistence
* *The continuance of an effect after its cause is removed*
* *Data survives* after the process with which it was created has ended

---
## TODO
* Microsoft SQL Local Database (MSSQLLocalDB)
* Entity Framework
* Object-relational mapping

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

+++

## Microsoft SQL LocalDB
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
* Creates *"virtual object database"*
* Can be used from within the programming language

@snap[east snap-100]
![](/Lectures/Lecture04/Assets/img/ORM.jpg)
@snapend


---
## Entity Framework (EF)
* **Official definition:** *“Entity Framework is an object-relational mapper (O/RM) that enables .NET developers to work with a database using .NET objects. It eliminates the need for most of the data-access code that developers usually need to write.”*
* **Object-relational mapping framework**
* By Microsoft
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
* **Saving** - executes `INSERT`, `UPDATE`, and `DELETE` commands to the database based on the changes occurred to your entities 
* **Concurrency** - uses Optimistic Concurrency by default to protect overwriting changes made by another user since data was fetched from the database
* **Transactions** - automatic transaction management while querying or saving data (can be customized)
* **Caching** - includes first level of caching out of the box (repeated querying will return data from the cache)
* **Built-in Conventions** - follows conventions over the configuration programming pattern, and includes a set of default rules which automatically configure the EF model
* **Configurations** - allows us to configure the EF model by using data annotation attributes or Fluent API to override default conventions
* **Migrations** - set of migration commands to create or manage underlying database Schema

+++ 
### Entity Framework Versions
* Currently, there are two latest versions of Entity Framework
![](/Lectures/Lecture04/Assets/img/EFversions.png)

* **EF 6** was released in 2013 
  * .NET 4.0 & .NET 4.5
  * Visual Studio 2012
* **EF Core 2.0** was released in August 2017
  * .NET Core 2.0
  * Visual Studio 2017

+++
   



+++
@snap[east snap-100]
![](/Lectures/Lecture04/Assets/img/database.jpg)
@snapend







+++
4. Propojení aplikace s databází pro zajištění persistence pomocí ORM rozšíření Entity Framework
 s návrhovými vzory UnitOfWork a Repository.

6. Návrhový vzor Model-View-ViewModel (MVVM) a architektura desktopových aplikací. 
Mapování databázových entit na modelové třídy. Konflikt???

---
## References:
[C# 7.0 in a Nutshell: The Definitive Reference](https://www.amazon.com/C-7-0-Nutshell-Definitive-Reference/dp/1491987650)  
[EntityFrameworkTutorial.net](http://www.entityframeworktutorial.net/)
[Microsoft documentation](https://docs.microsoft.com)  
[Computer Hope](https://www.computerhope.com)  
[Wikipedia](https://en.wikipedia.org)

+++
## Refences to used images:
[Computer Hope](https://www.computerhope.com)