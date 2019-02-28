@snap[north span-100]
# Clean code in C#
@snapend

@snap[midpoint span-100]
## SOLID, Refactorization
@snapend

@snap[south-east span-30]
[ Michal Orlicek <xorlic00@stud.fit.vutbr.cz> ]
@snapend

---
## Clean Code
* Code that
  * *Easy to understand*
  * *Easy to change*
* **Subjective**
* [Clean Code Book](https://www.amazon.com/Clean-Code-Handbook-Software-Craftsmanship/dp/0132350882)
* [Clean Code .NET](https://github.com/thangchung/clean-code-dotnet)

@snap[east]
@img[span-60](/Lectures/Lecture07/Assets/img/clean-code.jpg)
@snapend

+++
### Clean Code Citations
* *Clean code is code that has been taken care of. Someone has taken the time to keep it simple and orderly. They have paid appropriate attention to details. They have cared.* — Robert C. Martin 
* *If you want your code to be easy to write, make it easy to read.* — Robert C. Martin
* *Clean code always looks like it was written by someone who cares. There is nothing obvious you can do to make it better.* — Michael Feathers
* *Clean code is simple and direct. Clean code reads like well-written prose. Clean code never obscures the designers’ intent but rather is full of crisp abstractions and straightforward lines of control.* — Grady Booch
* *Any fool can write code that a computer can understand. Good programmers write code that humans can understand.* — Martin Fowler

+++
### Clean Code
* **Easily accessible to others**
  * Straightforward
  * Clear intent
  * Good abstractions
  * No surprises
  * Good naming
  * ⋮
* **Is made for the real-world**
  * Clear error-handling strategy
  * ⋮
* **Author clearly cares for the software and other developers**
* **Is minimal**
* **Is good at what it does**
* **Is easy to test**
* ⋮

+++
### Clean Code Measurement
![](/Lectures/Lecture07/Assets/img/clean-code-measurement.jpg)

---
## Clean code Naming
* Avoid using bad names
* Avoid disinformation name
* Avoid Hungarian notation
* Use consistent capitalization
* Use pronounceable names
* Use Camelcase notation
* Other naming related advices

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

+++
### Avoid Using Bad Names
* Good name **allows the code to be used by many developers**
* The name should **reflect what it does** and give context
* **Bad**

```C#
int d;
```
* **Good**

```C#
int daySinceModification;
```

+++
### Avoid Disinformation Names
* **Avoid** naming with **disinformation name**
* **Name variable to reflect what we want to do** with it
* **Bad**

```C#
var dataFromDb = db.GetFromService().ToList();
```
* **Good**

```C#
var listOfEmployee = employeeService.GetEmployeeListFromDb().ToList();
```

+++
### Avoid Hungarian Notations
* Hungarian Notation **restates the type which is already present in the declaration**
* This is **pointless** since modern IDEs will identify the type
* **Bad**

```C#
int iCounter;
string strFullName;
DateTime dModifiedDate;
```
* **Good**

```C#
int counter;
string fullName;
DateTime modifiedDate;
```

+++ 
### Avoid Hungarian Notations in Parameters
* Should also not be used in paramaters
* **Bad**

```C#
public bool IsShopOpen(string pDay, int pAmount)
{
    // some logic
}
```
* **Good**

```C#
public bool IsShopOpen(string day, int amount)
{
    // some logic
}
```

+++
### Use Consistent Capitalization
* **Capitalization tells you a lot** about your variables, methods...
* **Subjective**, so team can choose whatever they want
* No matter what you choose, just **be consistent**

@snap[east]
![](/Lectures/Lecture07/Assets/img/Capitalization.jpg)
@snapend

+++
### Use Consistent Capitalization - Bad Sample
```C#
const int DAYS_IN_WEEK = 7;
const int daysInMonth = 30;

var songs = new List<string> { 'Back In Black', 'Stairway to Heaven' };
var Artists = new List<string> { 'ACDC', 'Led Zeppelin' };

bool EraseDatabase() {}
bool Restore_database() {}

class animal {}
class Alpaca {}
```

+++
### Use Consistent Capitalization - Good Sample
```C#
const int DaysInWeek = 7;
const int DaysInMonth = 30;

var songs = new List<string> { 'Back In Black', 'Stairway to Heaven' };
var artists = new List<string> { 'ACDC', 'Led Zeppelin' };

bool EraseDatabase() {}
bool RestoreDatabase() {}

class Animal {}
class Alpaca {}
```

+++
### Use Pronounceable Names
* Easier to investigate meaning and functions
* Easier to remember
* **Bad**

```C#
public class Employee
{
    public Datetime sWorkDate { get; set; } // what the heck is this
    public Datetime modTime { get; set; } // same here
}
```
* **Good**

```C#
public class Employee
{
    public Datetime StartWorkingDate { get; set; }
    public Datetime ModificationTime { get; set; }
}
```

+++
### Use Camelcase Notations
* Each word in the **middle of the phrase begins with a capital letter**
* [Wikipedia](https://en.wikipedia.org/wiki/Camel_case)
* **Bad**

```C#
var employeephone;

public double CalculateSalary(int workingdays, int workinghours)
{
    // some logic
}
```
* **Good**

```C#
var employeePhone;

public double CalculateSalary(int workingDays, int workingHours)
{
    // some logic
}
```

@snap[north-east]
@img[span-80](/Lectures/Lecture07/Assets/img/CamelCase.png)
@snapend

+++
### Other Naming Related Advices
* Code is writen by developer for developer
  * **Dont explain fundamentals** what everyone knows
* **One concept, one word**
* **Dont use synonyms**
  * Choose one of them and be consistent
* **Variable ends with noun** e.g. `Car car;`
  * Bool starts with *Is*, *Was*, *Has*... e.g. `bool isTestPage;`
* **Method starts with verb**
  * Says what it return `public List<Cell> GetFlaggedCells()`
  * What it does `public void ChangeCarCount(int carCount)`

---
## Clean Code Variables
* Avoid nesting too deeply and return early
* Avoid magic strings, numbers...
* Don't add unneeded context
* Use the same vocabulary for the same type of variable
* Use searchable names
* Use explanatory variables
* Use default arguments instead of short circuiting or conditionals

+++
### Avoid nesting too deeply and return early
* Too many `if else` statements make the **code hard to follow**
* **Exlicit is better than implicit**
* Use [Code Metrices](https://marketplace.visualstudio.com/items?itemName=Elisha.CodeMetrices) extension to monitor code complexity

+++
### Avoid nesting too deeply and return early - Bad Sample
```C#
public long Fibonacci(int index)
{
    if (index < 50)
    {
        if (index != 0)
        {
            if (index != 1)
            {
                return Fibonacci(index - 1) + Fibonacci(index - 2);
            }
            else
            {
                return 1;
            }
        }
        else
        {
            return 0;
        }
    }
    else
    {
        throw new System.ArgumentOutOfRangeException();
    }
}
```
@[1-2]
@[3-4]
@[20-24]
@[5-6,15-19]
@[7-14]
@[1-25]

+++
### Avoid nesting too deeply and return early - Good Sample
```C#
public long Fibonacci(int index)
{
    if (index == 0)
    {
        return 0;
    }

    if (index == 1)
    {
        return 1;
    }

    if (index > 50)
    {
        throw new System.ArgumentOutOfRangeException();
    }

    return Fibonacci(index - 1) + Fibonacci(index - 2);
}
```
@[1-2,18-19]
@[3-6]
@[8-11]
@[13-16]
@[1-19]

+++
### Avoid magic strings, numbers...
* It is a value
  * **Specified directly within application code**
  * **Have an impact** on the application’s behavior
* Frequently will **end up being duplicated** within the system
* Common source of bugs *(problem to update them)*
* **Bad**

```C#
if (userRole == "Admin")
{
    // logic in here
}
```
* **Good**

```C#
const string ADMIN_ROLE = "Admin"
if (userRole == ADMIN_ROLE)
{
    // logic in here
}
```

+++
### Don't add unneeded context
* If *class*, *object*, *assembly*... name tells you something
  * **Don't repeat** that in your *variable*, *property*, *method*... name
* **Bad**

```C#
public class Car
{
    public string CarMake { get; set; }
    public string CarModel { get; set; }
    public string CarColor { get; set; }
}
```
* **Good**

```C#
public class Car
{
    public string Make { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
}
```

+++
### Use searchable names
* Bad

```C#
var data = new { Name = "John", Age = 42, PersonAccess = 4};

// What the heck is 4 for?
if (data.PersonAccess == 4)
{
    // do edit ...
}
```
* Good

```C#
public enum PersonAccess : int
{
    ACCESS_READ = 1,
    ACCESS_CREATE = 2,
    ACCESS_UPDATE = 4,
    ACCESS_DELETE = 8
}

var person = new Person
{
    Name = "John",
    Age = 42,
    PersonAccess= PersonAccess.ACCESS_CREATE
};

if (person.PersonAccess == PersonAccess.ACCESS_UPDATE)
{
    // do edit ...
}
```

---
## Mnemonic Acronyms
* SOLID
* DRY
* KISS
* GRASP
* ⋮

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

---
## SOLID
* Mnemonic acronym for five design principles
* To make software designs more 
  * Understandable
  * Flexible
  * Maintainable
* Subset of principles promoted by *Robert C. Martin*

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

+++
## SOLID
* #### **S**ingle responsibility principle
* #### **O**pen–closed principle
* #### **L**iskov substitution principle
* #### **I**nterface segregation principle
* #### **D**ependency inversion principle

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

+++
### **S**ingle Responsibility Principle
* **Class have one responsibility**

@img[span-45](/Lectures/Lecture07/Assets/img/SingleReponsibilityPrincipe.jpg)

+++ 
### **S**OLID - Minimize modification problems
* There should **never be more than one reason for a class to change**
* *Issues*:
  * Class won't be **conceptually cohesive**
  * **Many reasons to change**
* It is important to **minimize amount of times you need to change a class**
* If too much functionality is in one class 
  * It can be **difficult to understand**, how modification will affect other dependent modules

+++
### **S**OLID - Bad Sample
```C#
class UserSettings
{
    private User User;

    public UserSettings(User user)
    {
        User = user;
    }

    public void ChangeSettings(Settings settings)
    {
        if (VerifyCredentials())
        {
            // ...
        }
    }

    private bool VerifyCredentials()
    {
        // ...
    }
}
```
@[3]
@[5-8]
@[10-16]
@[18-21]
@[3-21]


+++
### **S**OLID - Good Sample
```C#
class UserAuth
{
    private User user;

    public UserAuth(User user)
    {
        this.user = user;
    }

    public bool VerifyCredentials()
    {
        // ...
    }
}

class UserSettings
{
    private User user;
    private UserAuth auth;

    public UserSettings(User user)
    {
        this.user = user;
        auth = new UserAuth(user);
    }

    public void ChangeSettings(Settings settings)
    {
        if (auth.VerifyCredentials())
        {
            // ...
        }
    }
}
```
@[1-14]
@[3]
@[5-8]
@[10-13]
@[1-14]
@[14-34]
@[18-19]
@[21-26]
@[27-33]
@[14-34]

+++
### **O**pen–closed Principle
* Software entities *(classes, modules, methods...)*
  * **Open for extension**
  * **Closed for modification**
* Allow user to add **new functionalities without changing existing code**

+++
### S**O**LID - Bad Sample
```C#
abstract class AdapterBase
{
    protected string Name;

    public string GetName()
    {
        return Name;
    }
}

class AjaxAdapter : AdapterBase
{
    public AjaxAdapter()
    {
        Name = "ajaxAdapter";
    }
}

class NodeAdapter : AdapterBase
{
    public NodeAdapter()
    {
        Name = "nodeAdapter";
    }
}

class HttpRequester : AdapterBase
{
    private readonly AdapterBase adapter;

    public HttpRequester(AdapterBase adapter)
    {
        this.adapter = adapter;
    }

    public void Fetch(string url)
    {
        var adapterName = adapter.GetName();

        if (adapterName == "ajaxAdapter")
        {
            return MakeAjaxCall(url);
        }
        else if (adapterName == "httpNodeAdapter")
        {
            return MakeHttpCall(url);
        }
    }

    private bool MakeAjaxCall(string url)
    {
        // request and return promise
    }

    private bool MakeHttpCall(string url)
    {
        // request and return promise
    }
}
```
@[1-9]
@[11-17]
@[19-25]
@[27-28]
@[29]
@[31-34]
@[36-48]
@[50-53]
@[55-58]

+++
### S**O**LID - Good Sample
```C#
interface IAdapter
{
    bool Request(string url);
}

class AjaxAdapter : IAdapter
{
    public bool Request(string url)
    {
        // request and return promise
    }
}

class NodeAdapter : IAdapter
{
    public bool Request(string url)
    {
        // request and return promise
    }
}

class HttpRequester
{
    private readonly IAdapter adapter;

    public HttpRequester(IAdapter adapter)
    {
        this.adapter = adapter;
    }

    public bool Fetch(string url)
    {
        return adapter.Request(url);
    }
}
```
@[1-4]
@[6-12]
@[14-20]
@[22-35]

+++
### **L**iskov Substitution Principle*
* Official definition: *If `S` is a subtype of `T`, then objects of type `T` may be replaced with objects of type `S` without altering any of the desirable properties of that program.*

@img[span-50](/Lectures/Lecture07/Assets/img/LiskovSubstitutionPrinciple.jpg)

+++
### SO**L**ID - Bad Sample
* Mathematically, a square is a rectangle
* iI you model it using the "is-a" relationship via inheritance, you get into trouble

```C#
class Rectangle
{
    protected double width = 0;
    protected double height = 0;

    public Drawable Render(double area)
    {
        // ...
    }

    public void SetWidth(double width)
    {
        this.width = width;
    }

    public void SetHeight(double height)
    {
        this.height = height;
    }

    public double GetArea()
    {
        return width * height;
    }
}

class Square : Rectangle
{
    public double SetWidth(double width)
    {
        base.width = base.height = width;
    }

    public double SetHeight(double height)
    {
        base.width = base.height = height;
    }
}

Drawable RenderLargeRectangles(Rectangle[] rectangles)
{
    foreach (rectangle in rectangles)
    {
        rectangle.SetWidth(4);
        rectangle.SetHeight(5);

        // Will return 25 for Square. Should be 20.
        var area = rectangle.GetArea();

        rectangle.Render(area);
    }
}

var rectangles = new[] { new Rectangle(), new Rectangle(), new Square() };
RenderLargeRectangles(rectangles);
```
@[1-25]
@[27-38]
@[40-52]
@[54-56]

+++
### SO**L**ID - Good Sample

```C#
abstract class ShapeBase
{
    protected double width = 0;
    protected double height = 0;

    abstract public double GetArea();

    public Drawable Render(double area)
    {
        // ...
    }
}

class Rectangle : ShapeBase
{
    public void SetWidth(double width)
    {
        base.width = width;
    }

    public void SetHeight(double height)
    {
        base.height = height;
    }

    public double GetArea()
    {
        return Width * Height;
    }
}

class Square : ShapeBase
{
    private double length = 0;

    public double SetLength(double length)
    {
        length = length;
    }

    public double GetArea()
    {
        return Math.Pow(Length, 2);
    }
}

Drawable RenderLargeRectangles(Rectangle[] rectangles)
{
    foreach (rectangle in rectangles)
    {
        if (rectangle is Square)
        {
            rectangle.SetLength(5);
        }
        else if (rectangle is Rectangle)
        {
            rectangle.SetWidth(4);
            rectangle.SetHeight(5);
        }

        var area = rectangle.GetArea();
        rectangle.Render(area);
    }
}

var shapes = new[] { new Rectangle(), new Rectangle(), new Square() };
RenderLargeRectangles(shapes);
```
@[1-12]
@[14-30]
@[32-45]
@[47-64]
@[66-67]

+++
### **I**nterface Segregation Principle
* **Clients should not be forced to depend upon interfaces that they do not use**
* It's better to create more simplier interfaces than fat one

@img[span-40](/Lectures/Lecture07/Assets/img/ISP.jpg)

+++
### SOL**I**D - Bad Sample
```C#
public interface IEmployee
{
    void Work();
    void Eat();
}

public class Human : IEmployee
{
    public void Work()
    {
        // ....working
    }

    public void Eat()
    {
        // ...... eating in lunch break
    }
}

public class Robot : IEmployee
{
    public void Work()
    {
        //.... working much more
    }

    public void Eat()
    {
        //.... robot can't eat, but it must implement this method
    }
}
```
@[1-5]
@[7-18]
@[20-31]

+++
### SOL**I**D - Good Sample
* Not every worker is an employee, but every employee is an worker

```C#
public interface IWorkable
{
    void Work();
}

public interface IFeedable
{
    void Eat();
}

public interface IEmployee : IFeedable, IWorkable
{
}

public class Human : IEmployee
{
    public void Work()
    {
        // ....working
    }

    public void Eat()
    {
        //.... eating in lunch break
    }
}

// robot can only work
public class Robot : IWorkable
{
    public void Work()
    {
        // ....working
    }
}
```
@[1-4]
@[6-9]
@[11-13]
@[15-26]
@[28-35]

+++
### **D**ependency Inversion Principle
* High-level modules should not depend on low-level modules
  * Both should depend on abstractions
* Abstractions should not depend upon details
  * Details should depend on abstractions

@img[span-40](/Lectures/Lecture07/Assets/img/DependencyInversionPrinciple.jpg)

+++
### SOL**I**D - Bad Sample
```C#
public abstract class EmployeeBase
{
    public void Work()
    {
        // ....working
    }
}

public class Robot : EmployeeBase
{
    public void Work()
    {
        //.... working much more
    }
}

public class Manager
{
    private readonly Employee _employee;

    public Manager(Employee employee)
    {
        _employee = employee;
    }

    public void Manage()
    {
        _employee.Work();
    }
}
```
@[1-7]
@[9-15]
@[17-30]

+++
### SOL**I**D - Good Sample
```C#
public interface IEmployee
{
    void Work();
}

public class Human : IEmployee
{
    public void Work()
    {
        // ....working
    }
}

public class Robot : IEmployee
{
    public void Work()
    {
        //.... working much more
    }
}

public class Manager
{
    private readonly IEmployee _employee;

    public Manager(IEmployee employee)
    {
        _employee = employee;
    }

    public void Manage()
    {
        _employee.Work();
    }
}
```
@[1-4]
@[6-12]
@[14-20]
@[22-35]

---
## Don’t Repeat Yourself (DRY) Principe
* **Avoid duplicate code**
* Benefit
  * **Change code in one place**
  * **See the change in all instances**
* **Create abstractions** to remove duplicates
* Also know as *Single Source of Truth (SSOT)* principe
* *Open/Closed Principle* only works when DRY is followed
* *Single Responsibility Principle* relies on DRY

+++
### DRY - Bad Sample
```C#
public List<EmployeeData> ShowDeveloperList(Developers developers)
{
    foreach (var developers in developer)
    {
        var expectedSalary = developer.CalculateExpectedSalary();
        var experience = developer.GetExperience();
        var githubLink = developer.GetGithubLink();
        var data = new[] {
            expectedSalary,
            experience,
            githubLink
        };

        Render(data);
    }
}

public List<ManagerData> ShowManagerList(Manager managers)
{
    foreach (var manager in managers)
    {
        var expectedSalary = manager.CalculateExpectedSalary();
        var experience = manager.GetExperience();
        var githubLink = manager.GetGithubLink();
        var data =
        new[] {
            expectedSalary,
            experience,
            githubLink
        };

        Render(data);
    }
}
```
@[1-16]
@[3-4,15]
@[5-7]
@[8-12]
@[14]
@[1-16]
@[18-34]
@[20-21,33]
@[22-24]
@[25-30]
@[32]
@[18-34]

+++
### DRY - Good Sample

```
public List<EmployeeData> ShowList(Employee employees)
{
    foreach (var employee in employees)
    {
        var expectedSalary = employees.CalculateExpectedSalary();
        var experience = employees.GetExperience();
        var githubLink = employees.GetGithubLink();
        var data =
        new[] {
            expectedSalary,
            experience,
            githubLink
        };

        render(data);
    }
}
```
@[3-4,16]
@[5-7]
@[8-13]
@[15]
@[1-17]

+++
### DRY - Very Good Sample
* Compact version of the code


```C#
public List<EmployeeData> ShowList(Employee employees)
{
    foreach (var employee in employees)
    {
        render(new[] {
            employee.CalculateExpectedSalary(),
            employee.GetExperience(),
            employee.GetGithubLink()
        });
    }
}
```
@[1-11]
@[3-4,10]
@[5-9]
@[1-11]

---
## Keep it Simple, Stupid (KISS)
* **Avoid complexity** as much as you can
* **Implement new feature** as **simple** as you can
* Many variants
  * Keep it short and simple
  * Keep it simple and straightforward
  * Keep it simple sir
  * ⋮
* Noted by the U.S. Navy in 1960

@img[span-55](/Lectures/Lecture07/Assets/img/KISS-Principle.jpg)

---
## General Responsibility Assignment Software Patterns (GRASP)  Principle
* To make for **clear delineation of responsibilities**
* Assigns **types of roles** to classes and objects 
  * *Controller*
  * *Information Expert*
  * *Creator*
  * *High Cohesion*
  * *Low Coupling*
  * *Polymorphism*
  * *Protected Classes*
  * ⋮

+++
## Other Principles
* **You aren't gonna need it**
  * Not add functionality until deemed necessary
* **Worse is better**
  * Quality does not necessarily increase with functionality
* **Overengineering**
  * Product beeing unnecessarily complex or inefficient
* **If it ain't broke, don't fix it**
* ⋮

---
## Refactorization
Resharper


+++
(spagetovy kod niekde?)

---
## References:
[Clean Code: A Handbook of Agile Software Craftsmanship](https://www.amazon.com/Clean-Code-Handbook-Software-Craftsmanship/dp/0132350882)  
[C# 7.0 in a Nutshell: The Definitive Reference](https://www.amazon.com/C-7-0-Nutshell-Definitive-Reference/dp/1491987650)  
[Toptal - developers](https://www.toptal.com/developers)  
[Clean-code-dotnet](https://github.com/thangchung/clean-code-dotnet)  
[Cvuorinen.net](https://cvuorinen.net/)  
[Wikipedia](https://www.wikipedia.org/)  
[DZone.com](https://dzone.com/)  
[DevIQ](https://deviq.com/)

+++
## Refences to used images:
[clean-code-dotnet](https://github.com/thangchung/clean-code-dotnet)  
[Amazon.com](https://www.amazon.com/)  
[Wikipedia](https://www.wikipedia.org/)
