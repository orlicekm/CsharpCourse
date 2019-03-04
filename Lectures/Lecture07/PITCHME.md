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

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

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
if (data.PersonAccess == 4) // What the heck is 4 for?
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

+++
### Use explanatory variables
* **Bad**

```C#
const string Address = "One Infinite Loop, Cupertino 95014";
var cityZipCodeRegex = @"/^[^,\]+[,\\s]+(.+?)\s*(\d{5})?$/";
var matches = Regex.Matches(Address, cityZipCodeRegex);
if (matches[0].Success == true && matches[1].Success == true)
{
    SaveCityZipCode(matches[0].Value, matches[1].Value);
}
```
* **Good**
  * Decrease dependence on regex by naming subpatterns

```C#
const string Address = "One Infinite Loop, Cupertino 95014";
var cityZipCodeWithGroupRegex = 
  @"/^[^,\]+[,\\s]+(?<city>.+?)\s*(?<zipCode>\d{5})?$/";
var matchesWithGroup = Regex.Match(Address, cityZipCodeWithGroupRegex);
var cityGroup = matchesWithGroup.Groups["city"];
var zipCodeGroup = matchesWithGroup.Groups["zipCode"];
if(cityGroup.Success == true && zipCodeGroup.Success == true)
{
    SaveCityZipCode(cityGroup.Value, zipCodeGroup.Value);
}
```

+++
### Use default arguments instead of short circuiting or conditionals
* **Bad**

```C#
public void CreateMicrobrewery(string name = null)
{
    var breweryName = !string.IsNullOrEmpty(name) ? name : "Hipster Brew Co.";
    // ...
}
```
* **Good**

```C#
public void CreateMicrobrewery(string breweryName = "Hipster Brew Co.")
{
    // ...
}
```

---
## Clean code - Methods
* Avoid side effects
* Avoid type-checking
* Avoid flags in parameters
* Limit the amounts of parameters
* Method should do one thing
* Method callers and callees should be close
* Encapsulate conditionals
* Remove dead code

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

+++
### Avoid Side Effects
* **Side effect**
  * If it does **anything other than take a value in and return another value** or values
  * E.g. writing to file, modifying some global variable...
* **Intead of side effects create service** that does it
  * One and only

+++
### Avoid Side Effects - Bad Sample 
```C#
public string SplitIntoFirstAndLastName(string name)
{
    return name.Split(" ");
}

var name = 'Ryan McDermott';
var newName = SplitIntoFirstAndLastName(name);

Console.PrintLine(name); // 'Ryan McDermott';
Console.PrintLine(newName); // ['Ryan', 'McDermott'];
```
@[1-4]
@[6-7]
@[9-10]
@[1-10]

+++
### Avoid Side Effects - Good Sample
```C#
// Global variable referenced by following function.
// If we had another function that used this name, now it'd be an array and it could break it.
var name = 'Ryan McDermott';

public string SplitIntoFirstAndLastName()
{
   return name.Split(" ");
}

SplitIntoFirstAndLastName();

Console.PrintLine(name); // ['Ryan', 'McDermott'];
```
@[1-3]
@[5-8]
@[10]
@[12]
@[1-12]

+++
### Avoid Conditionals
* **Use polymorphism**
* Why?
  * Method, class... should only do one thing
  * if statements does more than one thing

+++
### Avoid Conditionals - Bad Sample
```
class Airplane
{
    // ...

    public double GetCruisingAltitude()
    {
        switch (type)
        {
            case '777':
                return GetMaxAltitude() - GetPassengerCount();
            case 'Air Force One':
                return GetMaxAltitude();
            case 'Cessna':
                return GetMaxAltitude() - GetFuelExpenditure();
        }
    }
}
```
@[1-2,17]
@[3-6,16]
@[7-8,15]
@[9-10]
@[11-12]
@[13-14]
@[1-17]

+++
### Avoid Conditionals - Good Sample
```C#
interface IAirplane
{
    // ...

    public double GetCruisingAltitude();
}

class Boeing777 : IAirplane
{
    // ...

    public double GetCruisingAltitude()
    {
        return GetMaxAltitude() - GetPassengerCount();
    }
}

class AirForceOne : IAirplane
{
    // ...

    public double GetCruisingAltitude()
    {
        return GetMaxAltitude();
    }
}

class Cessna : IAirplane
{
    // ...

    public double GetCruisingAltitude()
    {
        return GetMaxAltitude() - GetFuelExpenditure();
    }
}
```
@[1-6]
@[8-16]
@[18-26]
@[28-36]

+++
### Avoid Type-checking - Bad Sample
```C#
public Path TravelToTexas(object vehicle)
{
    if (vehicle.GetType() == typeof(Bicycle))
    {
        (vehicle as Bicycle).PeddleTo(new Location("texas"));
    }
    else if (vehicle.GetType() == typeof(Car))
    {
        (vehicle as Car).DriveTo(new Location("texas"));
    }
}
```
@[1-2,11]
@[3-6]
@[7-10]
@[1-11]

+++
### Avoid Type-checking - Good Sample
```C#
public Path TravelToTexas(Traveler vehicle)
{
    vehicle.TravelTo(new Location("texas"));
}
```

* or

```C#
// pattern matching
public Path TravelToTexas(object vehicle)
{
    if (vehicle is Bicycle bicycle)
    {
        bicycle.PeddleTo(new Location("texas"));
    }
    else if (vehicle is Car car)
    {
        car.DriveTo(new Location("texas"));
    }
}
```
@[1-4]
@[5-7,16]
@[8-11]
@[12-15]
@[1-16]

+++
### Avoid Flags in Parameters
* Indicates that the method has more than one responsibility
* Split into two methods

+++
### Avoid Flags in Parameters - Sample
* **Bad**

```C#
public void CreateFile(string name, bool temp = false)
{
    if (temp)
    {
        Touch("./temp/" + name);
    }
    else
    {
        Touch(name);
    }
}
```
* **Good**

```C#
public void CreateFile(string name)
{
    Touch(name);
}

public void CreateTempFile(string name)
{
    Touch("./temp/"  + name);
}
```
@[1-11]
@[12-20]

+++
### Limit the Amounts of Parameters
* **Makes testing easier**
* More than three leads to a combinatorial explosion
  * Have to test tons of different cases with each separate argument
* Number of arguments
  * **Zero** arguments is the **ideal case**
  * **One or two** arguments is **ok**
  * **Three or more*** should be **avoided**
* Use tuples or create object to compress arguments into one
* **Bad**

```C#
public void CreateMenu(string title, string body, 
               string buttonText, bool cancellable)
{
    // ...
}
```

+++
### Limit the Amounts of Parameters - Good Sample
```C#
pubic class MenuConfig
{
    public string Title { get; set; }
    public string Body { get; set; }
    public string ButtonText { get; set; }
    public bool Cancellable { get; set; }
}

var config = new MenuConfig();
config.Title = "Foo";
config.Body = "Bar";
config.ButtonText = "Baz";
config.Cancellable = true;

public void CreateMenu(MenuConfig config)
{
    // ...
}
```
@[1-7]
@[9-13]
@[15-18]
@[1-18]

+++
### Method Should Do One Thing
* Method, class, interface... should do one thing
  * **Most important rule in software engineering**
* More than one thing
  * Harder to compose, test, and reason about
* One thing
  * **Refactored easier**
  * Code will read much **cleaner, more understable**

+++
### Method Should Do One Thing - Good Sample
```C#
public void SendEmailToListOfClients(string[] clients)
{
    foreach (var client in clients)
    {
        var clientRecord = db.Find(client);
        if (clientRecord.IsActive())
        {
            Email(client);
        }
    }
}
```
@[1-2, 11]
@[3-4, 10]
@[5-9]
@[1-11]

+++
### Method Should Do One Thing - Bad Sample
```C#
public void SendEmailToListOfClients(string[] clients)
{
    var activeClients = ActiveClients(clients);
    // Do some logic
}

public List<Client> ActiveClients(string[] clients)
{
    return db.Find(clients).Where(s => s.Status == "Active");
}
```
@[1-5]
@[7-10]
@[1-10]

+++
### Method Callers and Callees Should be Close
* If a function calls another
  * **Keep those functions vertically close** in the source file
* Ideally **keep the caller right above the callee**
* We tend to **read code from top-to-bottom**
  * Make your code read that way

+++ 
### Method Callers and Callees Should be Close - Bad Sample
```C#
class PerformanceReview 
{
    private readonly Employee _employee;

    public PerformanceReview(Employee employee) 
    {
        _employee = employee;
    }

    private IEnumerable<PeersData> LookupPeers() 
    {
        return db.lookup(_employee, 'peers');
    }

    private ManagerData LookupManager() 
    {
        return db.lookup(_employee, 'manager');
    }

    private IEnumerable<PeerReviews> GetPeerReviews() 
    {
        var peers = LookupPeers();
        // ...
    }

    public PerfReviewData PerfReview() 
    {
        GetPeerReviews();
        GetManagerReview();
        GetSelfReview();
    }

    public ManagerData GetManagerReview() 
    {
        var manager = LookupManager();
    }

    public EmployeeData GetSelfReview() 
    {
        // ...
    }
}

var  review = new PerformanceReview(employee);
review.PerfReview();
```
@[1-2]
@[3]
@[5-8]
@[10-13]
@[15-18]
@[20-24]
@[26-31]
@[33-36]
@[38-41]
@[44-45]

+++ 
### Method Callers and Callees Should be Close - Good Sample
```C#
class PerformanceReview 
{
    private readonly Employee _employee;

    public PerformanceReview(Employee employee) 
    {
        _employee = employee;
    }

    public PerfReviewData PerfReview() 
    {
        GetPeerReviews();
        GetManagerReview();
        GetSelfReview();
    }

    private IEnumerable<PeerReviews> GetPeerReviews() 
    {
        var peers = LookupPeers();
        // ...
    }

    private IEnumerable<PeersData> LookupPeers() 
    {
        return db.lookup(_employee, 'peers');
    }

    private ManagerData GetManagerReview() 
    {
        var manager = LookupManager();
        return manager;
    }

    private ManagerData LookupManager() 
    {
        return db.lookup(_employee, 'manager');
    }

    private EmployeeData GetSelfReview() 
    {
        // ...
    }
}

var review = new PerformanceReview(employee);
review.PerfReview();
```
@[1-2]
@[3]
@[5-8]
@[10-15]
@[17-21]
@[23-26]
@[28-32]
@[34-37]
@[39-42]
@[45-46]

+++
### Encapsulate Conditionals
* **Bad**

```C#
if (article.state == "published")
{
    // ...
}
```
* **Good**

```C#
if (article.IsPublished())
{
    // ...
}
```

+++
### Remove dead code
* No **reason to keep** it in codebase
* If it's not being called, get rid of it
* **It will still be safe in version history**
* **Bad**

```C#
public void OldRequestModule(string url)
{
    // ...
}

public void NewRequestModule(string url)
{
    // ...
}
```
* **Good**

```C#
public void RequestModule(string url)
{
    // ...
}

var request = RequestModule(requestUrl);
InventoryTracker("apples", request, "www.inventory-awesome.io");
```

---
## Clean Code - Objects, Classes and Data Structures
* Small blocks of code 
* Avoid usage of a Singleton pattern
* Use getters and setters
* Use private/protected members when possible
* Use extension methods
* Prefer composition over inheritance

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

+++
### Small Blocks of Code 
* **Method** should be less than **10 lines**
* **Class** should be less than **100 lines**
* One level of abstraction
* One responsibility

+++
### Avoid Usage of a Singleton Pattern
* Singleton is an [Anti-pattern](https://en.wikipedia.org/wiki/Singleton_pattern)
  * Generally **used as a global instance**
    * Hide the dependencies of application in code
  * Violate the single responsibility principle
    * **Control it's own creation and lifecycle**
  * Cause code to be tightly coupled
  * Carry state around for the lifetime of the application
* **Avoid `static` keyword** for the same reasons as Singleton

+++
### Use Getters and Setters
* Use properties instead of variables with getter, setter methods
* **Bad**

```C#
private int myProperty;

public int GetMyProperty()
{
    return myProperty;
}

public void SetMyProperty(int value)
{
    myProperty = value;
}
```
* **Good**

```C#
public int MyProperty { get; set; }
```

+++
### Use Private/Protected Members when Possible
* **Reduce Public** as much as possible
* *Public* should be only member, which is intended to work with them outside
* *Private* should be every specific member, which does not have to exist in inherited instance
* *Protected* shoud be every member, which should be also used in inherited instance

```C#
// Usually you do not want to give another classes the way,
// how to update your ID. Only class itself can update it's own ID.
protected GUID Id { get; private set; }
```

+++ 
### Use Extension Methods
* Useful and commonly used in many libraries
* Allows **code to be expressive and less verbose**

```C#
public static List<T> FluentAdd<T>(this List<T> list, T item)
{
    list.Add(item);
    return list;
}

public static List<T> FluentClear<T>(this List<T> list)
{
    list.Clear();
    return list;
}
```

+++
### Prefer Composition over Inheritance
* **Prefer composition over inheritance** where you can
* **Inheritance should be used when**
  * Inheritance represents an *is-a* relationship and not a *has-a* relationship
    * E. g. Human -> Animal vs. User -> UserDetails
  * Code from the base classes can be reused
    * E. g. humans can move like all animals
  * To make global changes to derived classes by changing a base class
    * E. g. change the caloric expenditure of all animals when they move
         
+++
### Prefer Composition over Inheritance - Bad Sample
```C#
class Employee
{
    private string Name { get; set; }
    private string Email { get; set; }

    public Employee(string name, string email)
    {
        Name = name;
        Email = email;
    }

    // ...
}

// Bad because Employees "have" tax data.
// EmployeeTaxData is not a type of Employee
class EmployeeTaxData extends Employee
{
    private string Name { get; }
    private string Email { get; }

    public EmployeeTaxData(string name, string email, string ssn, string salary)
    {
         // ...
    }

    // ...
}
```
@[1-13]
@[15-28]

+++
### Prefer Composition over Inheritance - Good Sample
```C#
class EmployeeTaxData
{
    public string Ssn { get; }
    public string Salary { get; }

    public EmployeeTaxData(string ssn, string salary)
    {
        Ssn = ssn;
        Salary = salary;
    }

    // ...
}

class Employee
{
    public string Name { get; }
    public string Email { get; }
    public EmployeeTaxData TaxData { get; }

    public Employee(string name, string email)
    {
        Name = name;
        Email = email;
    }

    public void SetTax(string ssn, double salary)
    {
        TaxData = new EmployeeTaxData(ssn, salary);
    }

    // ...
}
```
@[1-13]
@[15-33]

---
## Clean Code - Error Handling
* Thrown errors are a good thing
* Means that the runtime has successfully identified
  * That something in your program has gone wrong
  * Stopping function execution on the current stack
  * Killing the process
  * Notifying you with a stack trace

+++
### Clean Code - Error Handling
* Do not use `throw exeption` in catch block
* Do not ignore caught errors
* Use multiple catch block instead of conditions

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

+++
### Do Not Use `throw exeption` in Catch Block
* If you need to re-throw, **use just `throw`**
* **Save the stack trace**
* **Bad**

```C#
try
{
    // Do something..
}
catch (Exception exception)
{
    // Any action something like roll-back or logging etc.
    throw exception;
}
```

+++
### Do Not Use `throw exeption` in Catch Block - Good Sample

```C#
try
{
    // Do something..
}
catch (Exception exception)
{
    // Any action something like roll-back or logging etc.
    throw;
}
```

+++
### Do Not Ignore Caught Errors
* Doing nothing **does not give you the ability to ever fix or react**
* **Bad**

```C#
try
{
    FunctionThatMightThrow();
}
catch (Exception exception)
{
    // silent exception
}
```

+++
### Do Not Ignore Caught Errors - Good Sample

```C#
try
{
    FunctionThatMightThrow();
}
catch (Exception exception)
{
    NotifyUserOfError(exception);

    // Another option
    ReportErrorToService(exception);
}
```

+++
### Use Multiple Catch Block Instead of Conditions
* If you need to take action according to type of the exception
  * **Use multiple catch block** for exception handling
* **Bad**

```C#
try
{
    // Do something..
}
catch (Exception exception)
{

    if (exception is TaskCanceledException)
    {
        // Take action for TaskCanceledException
    }
    else if (exception is TaskSchedulerException)
    {
        // Take action for TaskSchedulerException
    }
}
```

+++
### Use Multiple Catch Block Instead of Conditions - Good Sample

```C#
try
{
    // Do something..
}
catch (TaskCanceledException exception)
{
    // Take action for TaskCanceledException
}
catch (TaskSchedulerException exception)
{
    // Take action for TaskSchedulerException
}
```

---
## Clean Code - Formatting
* `.editorconfig` file
* Resharper formatting

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

+++
### .editorconfig File
* To enforce consistent coding styles for everyone 
* Precedence over global Visual Studio text editor settings
* Either the project or solution
* [Documentation](https://docs.microsoft.com/en-us/visualstudio/ide/create-portable-custom-editor-options?view=vs-2017)

+++?code=/Lectures/Lecture07/Assets/sln/Lecture07/.editorconfing&title=Editorconfing File Sample
@[1]
@[3-9]
@[11-21]
@[23-32]
@[34-43]
[Code sample](/Lectures/Lecture07/Assets/sln/Lecture07/.editorconfig)

+++
### Resharper Formatting
* In VS 2017 go to ReSharper -> Options -> Code Inspection and Code Editing
* [Official site](https://www.jetbrains.com/resharper/)


@img[span-60](/Lectures/Lecture07/Assets/img/ResharperFormatting.gif)

---
## Clean Code -  Comments
* *Every time you write a comment, you should grimace and feel the failure of your ability of expression.* ― Robert C. Martin, The Robert C. Martin Clean Code Collection
* **Use commends when**
  * *Explaining strange or test code*
    * Include the source in the documentation
  * *TODO comments*
    * Only in feature branch, not in master
  * *To highlight essential code*
* Otherwise do not use commends

+++
## Clean Code -  Comments
* Avoid positional markers
* Do not leave commented out code in your codebase
* Do not have journal comments
* Only comment things that have business logic complexity

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

+++
### Avoid Positional Markers
* Just add noise
* **Bad**

```C#
////////////////////////////////////////////////////////////////////
// Scope Model Instantiation
////////////////////////////////////////////////////////////////////
var model = new[]
{
    menu: 'foo',
    nav: 'bar'
};

////////////////////////////////////////////////////////////////////
// Action setup
////////////////////////////////////////////////////////////////////
void Actions()
{
    // ...
};
```

+++
### Avoid Positional Markers - Sample
* **Bad**

```C#
#region Scope Model Instantiation
var model = {
    menu: 'foo',
    nav: 'bar'
};
#endregion
#region Action setup
void Actions() {
    // ...
};
#endregion
```
* **Good**

```C#
var model = new[]
{
    menu: 'foo',
    nav: 'bar'
};

void Actions()
{
    // ...
};
```

+++
### Do Not Leave Commented Out Code in Your Codebase
* Old code exists in version control history
* **Bad**

```C#
doStuff();
// doOtherStuff();
// doSomeMoreStuff();
// doSoMuchStuff();
```
* **Good**

```C#
doStuff();
```

+++
### Don Not Have Journal Comments
* Use version control
* **Bad**

```C#
/**
 * 2018-12-20: Removed monads, didn't understand them (RM)
 * 2017-10-01: Improved using special monads (JP)
 * 2016-02-03: Removed type-checking (LI)
 * 2015-03-14: Added combine with type-checking (JR)
 */
public int Combine(int a,int b)
{
    return a + b;
}
```
* **Good**

```C#
public int Combine(int a,int b)
{
    return a + b;
}
```

+++
### Only Comment Things That Have Business Logic Complexity
* Comments are an apology
* Comments are not a requirement
* Good code mostly documents itself

+++
### Only Comment Things That Have Business Logic Complexity
* **Bad Sample**

```C#
public int HashIt(string data)
{
    // The hash
    var hash = 0;

    // Length of string
    var length = data.length;

    // Loop through every character in data
    for (var i = 0; i < length; i++)
    {
        // Get character code.
        const char = data.charCodeAt(i);
        // Make the hash
        hash = ((hash << 5) - hash) + char;
        // Convert to 32-bit integer
        hash &= hash;
    }
}
```

+++
### Only Comment Things That Have Business Logic Complexity
* **Better but Still Bad Sample**

```C#
public int HashIt(string data)
{
    var hash = 0;
    var length = data.length;
    for (var i = 0; i < length; i++)
    {
        const char = data.charCodeAt(i);
        hash = ((hash << 5) - hash) + char;
        
        // Convert to 32-bit integer
        hash &= hash;
    }
}
```

+++
### Only Comment Things That Have Business Logic Complexity
* **Good**

```C#
public int Hash(string data)
{
    var hash = 0;
    var length = data.length;

    for (var i = 0; i < length; i++)
    {
        var character = data[i];
        // use of djb2 hash algorithm as it has a good compromise
        // between speed and low collision with a very simple implementation
        hash = ((hash << 5) - hash) + character;

        hash = ConvertTo32BitInt(hash);
    }
    return hash;
}

private int ConvertTo32BitInt(int value)
{
    return value & value;
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


### Resharper Refactoriazation
* 60+ refactorings 
* 450+ context actions
* **Safely organize code**
* **Move code around the solution**
* Distribute responsibility
* Decouple
* Decrease complexity
* Simply use alternative syntax

@snap[east]
@img[span-60](/Lectures/Lecture07/Assets/img/refactoring.png)
@img[span-60](/Lectures/Lecture07/Assets/img/refactor.png)
@snapend

---
## Legacy Code Refactorization Example

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
