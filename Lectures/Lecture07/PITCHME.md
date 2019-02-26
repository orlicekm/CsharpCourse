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
## Clean code blabla


---
## Mnemonic Acronyms
* SOLID
* DRY
* KISS
* GRASP

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
```
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
```
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
```
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

+++
## Don’t repeat yourself (DRY)

+++
KISS, GRASP

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

+++
## Refences to used images:
[clean-code-dotnet](https://github.com/thangchung/clean-code-dotnet)  
[Amazon.com](https://www.amazon.com/)  
[Wikipedia](https://www.wikipedia.org/)
