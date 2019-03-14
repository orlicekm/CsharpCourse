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
## Mapper
* **Object-object**
* **Mapping**
  * **Same properties**
  * From *one object* of *one type*
  * To *another object* of *another type*
* E.g. entity `Customer` object to the `CustomerDTO`

+++?code=/Lectures/Lecture08/Assets/sln/Samples/Mapper/CustomerEntity.cs&lang=C#&title=Mapper Sample 1/5
@[5-11]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture08/Assets/sln/Samples/Mapper/CustomerEntity.cs)

+++?code=/Lectures/Lecture08/Assets/sln/Samples/Mapper/CustomerDTO.cs&lang=C#&title=Mapper Sample 2/5
@[5-11]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture08/Assets/sln/Samples/Mapper/CustomerDTO.cs)

+++?code=/Lectures/Lecture08/Assets/sln/Samples/Mapper/EqualityComparers/CustomerEntityEqualityComparer.cs&lang=C#&title=Mapper Sample 3/5
@[5]
@[7-15]
@[17-27]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture08/Assets/sln/Samples/Mapper/EqualityComparers/CustomerEntityEqualityComparer.cs)

+++?code=/Lectures/Lecture08/Assets/sln/Samples/Mapper/CustomerMapper.cs&lang=C#&title=Mapper Sample 4/5
@[7-17]
@[9]
@[10-11, 16]
@[12-15]
@[7-17]
@[19-29]
@[21]
@[22-23, 28]
@[24-27]
@[19-29]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture08/Assets/sln/Samples/Mapper/CustomerMapper.cs)

+++?code=/Lectures/Lecture08/Assets/sln/Samples/MapperTest.cs&lang=C#&title=Mapper Sample 5/5
@[8-9]
@[10]
@[13-27]
@[15-21]
@[23]
@[24]
@[26]
@[13-27]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture08/Assets/sln/Samples/MapperTest.cs)

+++
#### Mapper School Sample
* Mapping *Entity Framework entities* to *models*
* **Model**
  * Part of *Model-View-ViewModel(MVVM)* design pattern
  * Represents the **actual data and information**
  * More info in next lecture

+++?code=/Lectures/Lecture08/Assets/sln/School.BL/Mappers/Base/IMapper.cs&lang=C#&title=School Mapping Sample 1/10
@[7-9]
@[11-12]
@[14-15]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture08/Assets/sln/School.BL/Mappers/Base/IMapper.cs)

+++?code=/Lectures/Lecture08/Assets/sln/School.BL/Mappers/Base/MapperBase.cs&lang=C#&title=School Mapping Sample 2/10
@[8-10]
@[12, 14]
@[16-19]
@[21-24]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture08/Assets/sln/School.BL/Mappers/Base/MapperBase.cs)

+++?code=/Lectures/Lecture08/Assets/sln/School.BL/Models/StudentModel.cs&lang=C#&title=School Mapping Sample 3/10
@[6-13]
@[8]
@[10-12]
@[6-13]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture08/Assets/sln/School.BL/Models/StudentModel.cs)

+++?code=/Lectures/Lecture08/Assets/sln/School.BL/Mappers/StudentMapper.cs&lang=C#&title=School Mapping Sample 4/10
@[8-9]
@[10-11]
@[12]
@[13-14, 25]
@[15-18]
@[19-20, 24]
@[21-23]
@[27-29]
@[31]
@[34-35]
@[36]
@[37-38, 44]
@[39-43]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture08/Assets/sln/School.BL/Mappers/StudentMapper.cs)

+++?code=/Lectures/Lecture08/Assets/sln/School.BL/Models/AddressModel.cs&lang=C#&title=School Mapping Sample 5/10
@[5-13]
@[7-10]
@[12]
@[5-13]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture08/Assets/sln/School.BL/Models/AddressModel.cs)

+++?code=/Lectures/Lecture08/Assets/sln/School.BL/Mappers/AddressMapper.cs&lang=C#&title=School Mapping Sample 6/10
@[7-8]
@[9-20]
@[22-33]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture08/Assets/sln/School.BL/Mappers/AddressMapper.cs)

+++?code=/Lectures/Lecture08/Assets/sln/School.BL/Models/GradeModel.cs&lang=C#&title=School Mapping Sample 7/10
@[6-12]
@[8-9]
@[11]
@[6-12]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture08/Assets/sln/School.BL/Models/GradeModel.cs)

+++?code=/Lectures/Lecture08/Assets/sln/School.BL/Mappers/GradeMapper.cs&lang=C#&title=School Mapping Sample 8/10
@[7-8]
@[9-19]
@[21-31]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture08/Assets/sln/School.BL/Mappers/GradeMapper.cs)

+++?code=/Lectures/Lecture08/Assets/sln/School.BL/Models/CourseModel.cs&lang=C#&title=School Mapping Sample 9/10
@[6-12]
@[8-9]
@[11]
@[6-12]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture08/Assets/sln/School.BL/Models/CourseModel.cs)

+++?code=/Lectures/Lecture08/Assets/sln/School.BL/Mappers/CourseMapper.cs&lang=C#&title=School Mapping Sample 10/10
@[8-9]
@[10-11]
@[12-24]
@[26-28,30]
@[33-43]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture08/Assets/sln/School.BL/Mappers/GradeMapper.cs)

---
### Auto Mapper
* TODO

---
## Facade
* **Provides a unified interface** to a set of interfaces in a subsystem
* **Higher-level interface** that makes the subsystem easier to use

![](/Lectures/Lecture08/Assets/img/Facade.gif)

+++
### Facade Participants
* **Facade** - (E.g. *MortgageApplication*)
  * Knows which subsystem classes are responsible for a request
  * **Delegates client requests** to appropriate subsystem objects
* **Subsystem classes**  (E.g. *Bank*, *Credit*, *Loan*)
  * **Implement subsystem functionality**
  * Handle work assigned by the Facade object
  * Have no knowledge of the facade and keep no reference to it

+++?code=/Lectures/Lecture08/Assets/sln/Samples/Facade/Customer.cs&lang=C#&title=Facade Sample 1/6
@[5-8]
@[10]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture08/Assets/sln/Samples/Facade/Customer.cs)

+++?code=/Lectures/Lecture08/Assets/sln/Samples/Facade/Bank.cs&lang=C#&title=Facade Sample 2/6
@[5-8]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture08/Assets/sln/Samples/Facade/Bank.cs)

+++?code=/Lectures/Lecture08/Assets/sln/Samples/Facade/Credit.cs&lang=C#&title=Facade Sample 3/6
@[5-8]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture08/Assets/sln/Samples/Facade/Credit.cs)

+++?code=/Lectures/Lecture08/Assets/sln/Samples/Facade/Loan.cs&lang=C#&title=Facade Sample 4/6
@[5-8]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture08/Assets/sln/Samples/Facade/Loan.cs)

+++?code=/Lectures/Lecture08/Assets/sln/Samples/Facade/MortgageFacade.cs&lang=C#&title=Facade Sample 5/6
@[5-7]
@[9-20]
@[11]
@[13-17]
@[19]
@[9-20]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture08/Assets/sln/Samples/Facade/MortgageFacade.cs)

+++?code=/Lectures/Lecture08/Assets/sln/Samples/FacadeTests.cs&lang=C#&title=Facade Sample 6/6
@[8]
@[11-16]
@[13]
@[14]
@[15]
@[11-16]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture08/Assets/sln/Samples/FacadeTests.cs)

+++?code=/Lectures/Lecture08/Assets/sln/School.BL/CRUDFacade.cs&lang=C#&title=School Facade Sample
@[11-13]
@[15-17]
@[19-24]
@[26-29]
@[31-35]
@[36-40]
@[42-45]
@[47-50]
@[52-63]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture08/Assets/sln/School.BL/CRUDFacade.cs)

+++?code=/Lectures/Lecture08/Assets/sln/School.BL.Tests/SetupFixtures/Base/FacadeTestsSetupFixture.cs&lang=C#&title=School Facade Tests Sample 1/5
@[9-11]
@[13]
@[15-21]
@[23]
@[25-28]
@[30-35]
@[37-40]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture08/Assets/sln/School.BL.Tests/SetupFixtures/Base/FacadeTestsSetupFixture.cs)

+++?code=/Lectures/Lecture08/Assets/sln/School.BL.Tests/SetupFixtures/StudentFacadeTestsSetupFixture.cs&lang=C#&title=School Facade Tests Sample 2/5
@[10-12]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture08/Assets/sln/School.BL.Tests/SetupFixtures/StudentFacadeTestsSetupFixture.cs)

+++?code=/Lectures/Lecture08/Assets/sln/School.BL.Tests/SetupFixtures/GradeFacadeTestsSetupFixture.cs&lang=C#&title=School Facade Tests Sample 3/5
@[10-12]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture08/Assets/sln/School.BL.Tests/SetupFixtures/GradeFacadeTestsSetupFixture.cs)

+++?code=/Lectures/Lecture08/Assets/sln/School.BL.Tests/StudentFacadeTests.cs&lang=C#&title=School Facade Tests Sample 4/5
@[7-8]
@[10-13]
@[15]
@[19-30]
@[21-23]
@[25-26]
@[28-29]
@[19-30]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture08/Assets/sln/School.BL.Tests/StudentFacadeTests.cs)

+++?code=/Lectures/Lecture08/Assets/sln/School.BL.Tests/GradeFacadeTests.cs&lang=C#&title=School Facade Tests Sample 5/5
@[7]
@[9-12]
@[14]
@[17-29]
@[19-22]
@[24-25]
@[27-28]
@[17-29]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture08/Assets/sln/School.BL.Tests/GradeFacadeTests.cs)

---
## References:
[C# 7.0 in a Nutshell: The Definitive Reference](https://www.amazon.com/C-7-0-Nutshell-Definitive-Reference/dp/1491987650)  
[Programming with Mosh](https://programmingwithmosh.com/)  
[Data & Object Factory](https://www.dofactory.com/)  
[Code Project](https://www.codeproject.com/)

+++
## Refences to used images:
[Microsoft Documentation](https://docs.microsoft.com/en-us/)  
[Programming with Mosh](https://programmingwithmosh.com/)  
[Data & Object Factory](https://www.dofactory.com/)  