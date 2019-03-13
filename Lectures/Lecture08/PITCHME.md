@snap[north span-100]
# Repository, UnitOfWork, Facade and Mapper design patterns
@snapend

@snap[midpoint span-100]
## Mapping Entities to Models
@snapend

@snap[south-east span-30]
[ Michal Orlicek <xorlic00@stud.fit.vutbr.cz> ]
@snapend

---
## Repository
* Mediates **between the domain and data mapping layers**
* Acting like an **in-memory collection** of domain objects 


![](/Lectures/Lecture08/Assets/img/repository.jpg)

+++
### Repository Benefits
* **Minimizes duplicate** query logic
* **Decouples** application from persistence frameworks
* Promotes **testability**

+++
### Repository Responsibility
* **Add** *object*
* **Remove** *object*
* **Get** *object* by *ID*
* **Get all** *objects*
* **Find** using *predicate*

+++
### Repository vs UnitOfWork
* **Repository** design pattern
  * Should **not have sematict of database**
  * E.g. *Update*, *Save*, *Delete*... 
* How are these objects going to be saved to database?
  * **UnitOfWork** design pattern

+++?code=/Lectures/Lecture08/Assets/sln/School.DAL/RepositoryBase.cs&lang=C#&title=Repository Sample
@[8-10]
@[11-16]
@[18-21]
@[23-28]
@[30-33]
@[35-38]
@[40-43]
@[45-48]
@[50-53]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture08/Assets/sln/School.DAL/RepositoryBase.cs)

---
## UnitOfWork
* Maintains a list of objects affected by a business transaction
* Coordinates the writing out of changes

![](/Lectures/Lecture08/Assets/img/UnitOfWork.jpg)

+++?code=/Lectures/Lecture08/Assets/sln/School.DAL.Tests/RepositoryTestsSetupFixture.cs&lang=C#&title=Repository Tests Setup Fixture Sample
@[6-7]
@[8-13]
@[15-17]
@[19-22]
@[24-29]
@[31-34]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture08/Assets/sln/School.DAL.Tests/RepositoryTestsSetupFixture.cs)

+++?code=/Lectures/Lecture08/Assets/sln/School.DAL.Tests/RepositoryStudentTests.cs&lang=C#&title=Repository Student Tests
@[8-9]
@[8-13]
@[15]
@[18-34]
@[20-22]
@[24-26]
@[28-33]
@[18-34]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture08/Assets/sln/School.DAL.Tests/RepositoryStudentTests.cs)

+++?code=/Lectures/Lecture08/Assets/sln/School.DAL.Tests/RepositoryGradeTests.cs&lang=C#&title=Repository Grade Tests
@[8-9]
@[8-13]
@[15]
@[18-35]
@[20-23]
@[25-27]
@[29-34]
@[18-35]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture08/Assets/sln/School.DAL.Tests/RepositoryGradeTests.cs)


---
### Entity Framework as UnitOfWork and Repository
* *UnitOfWork* and *Repository* are **already implemented** in *Entity Framework*
* **Do not bring the architectural benefits** from these patterns

![](/Lectures/Lecture08/Assets/img/EntityFramework.jpg)

+++
### Entity Framework Problems
* *Repository*
  * **Minimizes duplicate** query logic
* *Entity Framework*
  * `DbSet` returns `IQueriable`
  * Does not help with minimizing duplicate:

```C#
var topSellingCourses = schoolCourses.Where(c => c.IsPublic && c.IsApproved).OrderByDescending(c => c.Sales).Take(10);
```

* Can be solved with extension methods
  * Treats the symptoms, not the problem
  * Still retutn IQueryable
* Solution
  * Repository with method `GetTopSellingCourses`


+++
### Entity Framework Problems
* *Repository and UnitOfWork*
  * **Decouples** application from persistence frameworks
  * Only **repository method have to be changed** when switching to different ORM
* *Entity Framework*
  * Application is **tightly coupled** to Entity Framework
  * Aplication **code have to be directly upgraded** when switching to different ORM

---
## Facade

---
## Mapper

---
### Auto Mapper

---
## References:
[C# 7.0 in a Nutshell: The Definitive Reference](https://www.amazon.com/C-7-0-Nutshell-Definitive-Reference/dp/1491987650)  
[Programming with Mosh](https://programmingwithmosh.com/)  

+++
## Refences to used images:
[Microsoft Documentation](https://docs.microsoft.com/en-us/)  
[Programming with Mosh](https://programmingwithmosh.com/)  