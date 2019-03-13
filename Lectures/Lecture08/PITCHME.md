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

---
UnitOf work and Repository are already implemented in entity framework
there is no need to recreate them
this would lead to unnecessary complexity

Dbset -> repository
DbContect -> unit of work

recreating  repository -> minimizes duplicate query logic


+++?code=/Lectures/Lecture08/Assets/sln/School.DAL.Tests/RepositoryTestsSetupFixture.cs&lang=C#&title=Repository Tests Setup Fixture Sample
@[6-7]
@[8-13]
@[15-17]
@[19-22]
@[24-29]
@[31-34]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture08/Assets/sln/School.DAL.Tests/RepositoryTestsSetupFixture.cs)



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
[Programming with Mosh](https://programmingwithmosh.com/)  