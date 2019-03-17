@snap[north span-100]
# Application Testing and Continous Integration in C#
@snapend

@snap[midpoint span-100]
Smoke, Unit, Integration, UI and Acceptance testing
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

+++
sample 1

+++
sample 2

+++
### Class Fixtures
* Creates a single test context and share it among all the tests in the class
* Cleans it up after all the tests in the class have finished
* Fixture instance will be created before any of the tests have run
  * Once all the tests have finished, it will clean up the fixture object by calling `Dispose`

+++
### Steps to use class fixtures:
  * Create the fixture class, and put the startup code in the fixture class constructor
  * If the fixture class needs to perform cleanup, implement IDisposable on the fixture class, and put the cleanup code in the Dispose() method
  * Add IClassFixture<> to the test class
  * If the test class needs access to the fixture instance, add it as a constructor argument, and it will be provided automatically

+++
sample 1

---
## Test types

---
## Testing tips

---
## Tests clean code

??? xunit theory?


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