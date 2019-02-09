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
  * For converting data between incompatible type systems using object-oriented programming languages
* Creates *"virtual object database"*
* Can be used from within the programming language


---
## Entity Framework
* Object-relational mapping framework
* By Microsoft
* To automate all database related activities for your application







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