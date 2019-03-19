@snap[north span-100]
# Application Testing and Continous Integration in C#
@snapend

@snap[midpoint span-100]
## xUnit and Software Testing Types
@snapend

@snap[south-east span-30]
[ Michal Orlicek <xorlic00@stud.fit.vutbr.cz> ]
@snapend 

---
## Testing Frameworks
* Usually **libraries**
  * **Identifies testing code**
  * **Encapsulates test runs**
  * **Verificates the expectations**

+++
## Testing Frameworks
* **MSTest**
  * Integrated in Visual Studio
* **NUnit**
  * Most used
* **xUnit**
  * Successor of Nunit
* ⋮

+++
### .NET Core Testing Projects

![](/Lectures/Lecture05/Assets/img/FrameworkProjects.png)


+++?code=/Lectures/Lecture05/Assets/sln/Sample/Calculator.cs&lang=C#&title=Code Sample
@[3-9]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture08/Assets/sln/Sample/Calculator.cs)

+++?code=/Lectures/Lecture05/Assets/sln/MSTest.Tests/CalculatorTests.cs&lang=C#&title=MSTest Sample
@[6-8, 24]
@[9]
@[11-13, 23]
@[14-16]
@[18-19]
@[21-22]
@[11-23]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture08/Assets/sln/MSTest.Tests/CalculatorTests.cs)

+++?code=/Lectures/Lecture05/Assets/sln/NUnit.Tests/CalculatorTests.cs&lang=C#&title=NUnit Sample
@[6-7, 23]
@[8]
@[10-12, 22]
@[13-15]
@[17-18]
@[20-21]
@[10-22]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture08/Assets/sln/NUnit.Tests/CalculatorTests.cs)

+++?code=/Lectures/Lecture05/Assets/sln/xUnit.Tests/CalculatorTests.cs&lang=C#&title=xUnit Sample
@[6-7, 23]
@[8]
@[10-12, 22]
@[13-15]
@[17-18]
@[20-21]
@[10-22]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture08/Assets/sln/xUnit.Tests/CalculatorTests.cs)

+++
### xUnit
* **Used in this course**
* *Free*, *Open source*, *Community-focused*
* Testing *C#*, *F#*, *VB.NET* and other .NET languages
* Written by the original inventor of *NUnit*
* Works with *ReSharper*, *CodeRush*, *TestDriven.NET* and *Xamarin*
* Part of the *.NET Foundation*
* [GitHub](https://github.com/xunit/xunit)
* [Web](https://xunit.github.io/)


@snap[north-east]
![](/Lectures/Lecture05/Assets/img/xunit.png)
@snapend

---
## Test Runners
* Tools that can **run testing frameworks**
* Addtional functions:
  * *Filtering* and *searching* tests
  * *Showing history* of test runs
  * Integrates *code coverage analyzation*
  * Defining test sets

+++
### Ways to Run
1. From **console**
   * Requires `xunit.runner.console` NuGet package
2. From **IDE**
  * Mosted used in *Visual Studio*
    * *Test Explorer* (native)
      * `Test -> Windows -> Test Explorer`
    * *Resharper - Unit Test Explorer* (paid plugin)
      * `ReSharper -> Windows -> Unit Tests`

+++
### Test Explorer
![](/Lectures/Lecture05/Assets/img/TestExplorer.gif)

+++
### Resharper - Unit Test Explorer
![](/Lectures/Lecture05/Assets/img/ResharperUnitTest.gif)

---
## Tests Sequence
* **MS test**:
  1. *ClassInitialize* - Executed one time before first test
  2. *TestInitialize* - Executed before every test
  3. *Test* - Executed test code
  4. *TestTearDown* - Executed after every test
  5. *ClassTearDown* - Executed one time after last test
* **Other testing frameworks have similar logic**

+++
### AAA Pattern - Test Code Sequence
* **Arrange, Act, Assert**
  * The pattern for arranging and formatting code
* **Arrange** all necessary preconditions and inputs
  * Initializes objects that are passed to the method under test
* **Act** on the object or method under test
  * Invokes the method or object under test with the arranged parameters
* **Assert** that the expected results have occurred
  * Included in every framework
  * Verifies that the action of the method under test behaves as expected

+++?code=/Lectures/Lecture05/Assets/sln/xUnit.Tests/CalculatorTests.cs&lang=C#&title=AAA Sample
@[10-12, 22]
@[13-15]
@[17-18]
@[20-21]
@[13-21]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture08/Assets/sln/xUnit.Tests/CalculatorTests.cs)

+++
### AAA Pattern Benefits
* Clearly **separates** what is being tested from the setup and verification steps
* Clarifies and **focuses** attention on a historically successful and generally **necessary set of test steps**
* Makes some **test smells more obvious**
  * Assertions intermixed with *Act* code
  * Test methods that try to test too many different things at once

+++
### Given-When-Then - Test Code Sequence
* **Formula** 
* Template intended to guide the writing of acceptance tests
  * *Given* some context
  * *When* some action is carried out
  * *Then* a particular set of observable consequences should obtain
* **Sample**
  * Given my bank account is in credit, and I made no withdrawals recently,
  * When I attempt to withdraw an amount less than my card's limit,
  * Then the withdrawal should complete without errors or warnings

---
## xUnit - Shared Content between Tests
* It is common for unit test classes to **share setup and cleanup code**
  * Called *test context*
* **Several methods for sharing** this setup and cleanup code
  1. Constructor and Dispose
  2. Class Fixtures
  3. Collection Fixtures

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

+++
### Constructor and Dispose
* Shared setup and cleanup code **without sharing object instances**
* Cleanes test context for every test
* xUnit.net **creates a new instance of the test class for every test that is run**

+++?code=/Lectures/Lecture05/Assets/sln/xUnit.Tests/StackTests.cs&lang=C#&title=Constructor and Dispose Sample
@[7-8]
@[9-12]
@[19]
@[14-17]
@[21-29]
@[31-37]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture08/Assets/sln/xUnit.Tests/StackTests.cs)

+++
#### Test Class as Context Sample
```C#
public class StackTests
{
    public class EmptyStack
    {
        private readonly Stack<int> stackSUT;

        public EmptyStack()
        {
            stackSUT = new Stack<int>();
        }

        // ... tests for an empty stack ...
    }

    public class SingleItemStack
    {
        private readonly Stack<int> stackSUT;

        public SingleItemStack()
        {
            stackSUT = new Stack<int>();
            stackSUT.Push(42);
        }

        // ... tests for a single-item stack ...
    }
}
```
@[1-2]
@[3-13]
@[3-4, 13]
@[5]
@[7-10]
@[12]
@[3-13]
@[15-26]

+++
### Class Fixtures
* Creates a single test context and **share it among all the tests in the class**
* **Cleans it up after all the tests in the class have finished**
* Fixture instance will be created before any of the tests have run
  * Once all the tests have finished, it will clean up the fixture object by calling `Dispose`

+++
### Steps to Use Class Fixtures
* **Create the fixture class** and put the startup code in the fixture class constructor
* If the fixture class needs to perform cleanup, **implement** `IDisposable` **on the fixture class**, and put the cleanup code in the `Dispose()` method
* **Inherit interface** `IClassFixture<>` in the test class
* **If the test class needs access to the fixture instance, add it as a constructor argument**, and it will be provided automatically

+++
#### Class Fixtures 1/2
```C#
public class DatabaseFixture : IDisposable
{
    public DatabaseFixture()
    {
        Db = new SqlConnection("MyConnectionString");

        // ... initialize data in the test database ...
    }

    public void Dispose()
    {
        // ... clean up test data from the database ...
    }

    public SqlConnection Db { get; private set; }
}
```
@[1-2, 16]
@[3-8]
@[10-13]
@[15]

+++
#### Class Fixtures 2/2
```C#
public class MyDatabaseTests : IClassFixture<DatabaseFixture>
{
    DatabaseFixture fixture;

    public MyDatabaseTests(DatabaseFixture fixture)
    {
        this.fixture = fixture;
    }

    // ... write tests, using fixture.Db to get access to the SQL Server ...
}
```
@[1-2, 11]
@[3]
@[5-8]
@[10]

+++
### Collection Fixtures
* Creates a single test context and **share it among tests in several test classes**
* **Cleans is up after all the tests in the test classes have finished**
* Share a fixture object **among multiple test classes**
* **Example:**
  * *Database* - initialize a database with a set of test data, and then leave that test data in place for use by multiple test classes

+++ 
### Steps to Use Collection Fixtures
* **Create the fixture clas**s, and put the startup code in the fixture class constructor
* If the fixture class needs to perform cleanup, **implement** `IDisposable` **on the fixture class**, and put the cleanup code in the `Dispose()` method
* **Create the collection definition class**, decorating it with the `[CollectionDefinition]` attribute, giving it a unique name that will identify the test collection
* **Inherit interface** `ICollectionFixture<>` in the collection definition class
* **Add the** `[Collection]` **attribute to all the test classes** that will be part of the collection, using the unique name you provided to the test collection definition class's `[CollectionDefinition]` attribute
* **If the test classes need access to the fixture instance, add it as a constructor argument**, and it will be provided automatically


+++
#### Collection Fixtures Sample 1/3
```C#
public class DatabaseFixture : IDisposable
{
    public DatabaseFixture()
    {
        Db = new SqlConnection("MyConnectionString");

        // ... initialize data in the test database ...
    }

    public void Dispose()
    {
        // ... clean up test data from the database ...
    }

    public SqlConnection Db { get; private set; }
}
```
@[1-2, 16]
@[3-8]
@[10-13]
@[15]

+++
#### Collection Fixtures Sample 2/3
```C#
[CollectionDefinition("Database collection")]
public class DatabaseCollection : ICollectionFixture<DatabaseFixture>
{
    // This class has no code, and is never created. Its purpose is simply
    // to be the place to apply [CollectionDefinition] and all the
    // ICollectionFixture<> interfaces.
}
```

+++
#### Collection Fixtures Sample 3/3
```C#
[Collection("Database collection")]
public class DatabaseTestClass1
{
    DatabaseFixture fixture;

    public DatabaseTestClass1(DatabaseFixture fixture)
    {
        this.fixture = fixture;
    }
}
```

```C#
[Collection("Database collection")]
public class DatabaseTestClass2
{
    // ...
}
```

---
## Running Tests in Parallel -  xUnit
* From *xUnit.net version 2*
* **Test collections decides witch tests can run against each other in parallel**
* By default, **each test class is a unique test collection**
* **Tests within the same test class will not run in parallel** against each other
* If multiple test classes should not be run in parallel against one another, then place them into the same test collection


+++
#### Running Tests in Parallel Sample 1/3 
```C#
\\ Total time approximately 8 seconds

public class TestClass1
{
    [Fact]
    public void Test1()
    {
        Thread.Sleep(3000);
    }

    [Fact]
    public void Test2()
    {
        Thread.Sleep(5000);
    }
}
```

+++
#### Running Tests in Parallel Sample 2/3 
```C#
\\ Total time approximately 5 seconds

public class TestClass1
{
    [Fact]
    public void Test1()
    {
        Thread.Sleep(3000);
    }
}

public class TestClass2
{
    [Fact]
    public void Test2()
    {
        Thread.Sleep(5000);
    }
}
```

+++
#### Running Tests in Parallel Sample 3/3 
```C#
\\ Total time approximately 8 seconds

[Collection("Our Test Collection #1")]
public class TestClass1
{
    [Fact]
    public void Test1()
    {
        Thread.Sleep(3000);
    }
}

[Collection("Our Test Collection #1")]
public class TestClass2
{
    [Fact]
    public void Test2()
    {
        Thread.Sleep(5000);
    }
}
```

---
### Theories vs. Facts
* xUnit support **two different major types of tests**
* Why are tests named facts?
  * **Facts** 
    * Tests which are **always true**
    * They test **invariant conditions**
  * **Theories**
    * Tests which are only **true for a particular set of data**

+++?code=/Lectures/Lecture05/Assets/sln/Sample/NumberValidator.cs&lang=C#&title=Theory Sample 1/2
@[3-4, 9]
@[5-8]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture08/Assets/sln/Sample/NumberValidator.cs)

+++?code=/Lectures/Lecture05/Assets/sln/xUnit.Tests/NumberValidatorTests.cs&lang=C#&title=Theory Sample 2/2
@[6-7, 18]
@[8]
@[10-15, 17]
@[16]
@[10-17]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture08/Assets/sln/xUnit.Tests/NumberValidatorTests.cs)

---
## Test types
* **Several ways** how to split tests
  * *Manual* vs. *Automated*
  * *Functional* vs. *Non-functional*
  * *Automation testing*
  * *Agile testing*
  * ⋮

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

+++
### Manual vs. Automated testing
* **Manual**
  * **In person**
  * **By clicking** through the application
  * Very **expensive** as it requires someone to set up an environment
  * It can be prone to **human error**
* **Automated**
  * **By a machine**
  * Executes a **test script** that has been written in advance
  * Tests can vary a lot in **complexity**
  * Quality of automated tests **depends on how well scripts have been written**

+++
### Manual vs. Automated testing performance
![](/Lectures/Lecture05/Assets/img/ManualvsAutomated.png)

+++
### Testing types
* Unit testing
* Integration testing
* System testing
* Sanity testing
* Smoke testing
* Interface testing
* Regression testing
* Beta/Acceptance testing
* Performance Testing
* Load testing
* Stress testing
* Volume testing
* Security testing
* Compatibility testing
* Install testing
* Recovery testing
* Reliability testing
* Usability testing
* Compliance testing
* Localization testing
* ⋮

---
Code coverage?

---
## Testing tips

---
## Tests clean code




---
## References:
[C# 7.0 in a Nutshell: The Definitive Reference](https://www.amazon.com/C-7-0-Nutshell-Definitive-Reference/dp/1491987650)  
[The Art of Unit Testing](https://www.amazon.de/Art-Unit-Testing-Roy-Osherove/dp/1617290890)  
[Microsoft Docs](https://docs.microsoft.com/en-us/)  
[Agile Alliance](https://www.agilealliance.org/)  
[WikiWikiWeb](http://wiki.c2.com/)  
[xUnit.net](https://xunit.github.io/)  
[DZone](https://dzone.com/)

+++
## Refences to used images:
[xUnit.net](https://xunit.github.io/)  
[CodeProject](https://www.codeproject.com/)