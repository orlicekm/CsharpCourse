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
@[6-8, 21]
@[9-11, 20]
@[12-13]
@[15-16]
@[18-19]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture08/Assets/sln/MSTest.Tests/CalculatorTests.cs)


+++?code=/Lectures/Lecture05/Assets/sln/NUnit.Tests/CalculatorTests.cs&lang=C#&title=NUnit Sample
@[6-7, 20]
@[8-10, 19]
@[11-12]
@[14-15]
@[17-18]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture08/Assets/sln/NUnit.Tests/CalculatorTests.cs)

+++?code=/Lectures/Lecture05/Assets/sln/xUnit.Tests/CalculatorTests.cs&lang=C#&title=xUnit Sample
@[6-7, 20]
@[8-10, 19]
@[11-12]
@[14-15]
@[17-18]
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


@snap[east-north]
![](/Lectures/Lecture05/Assets/img/xunit.png)
@snapend

---
## Test Runners
* Tools that can run testing frameworks
* Addtional functions:
  * Filtering and searching tests
  * Defining test sets
  * Showing history of test runs
  * Integrates code coverage analyzation

+++
### Test Runnes - Ways
* From console
* From IDE
* Mosted used in Visual Studio:
  * Test Explorer (native)
  * Resharper (paid plugin)

---
### Tests Sctructure
* Test Classes
* The AAA pattern
  * Arrange - Act - Assert

+++
Given when then

---
## Tests Sequence
* **MS test**:
  1. *ClassInitialize* - Executed one time before first test
  2. *TestInitialize* - Executed before every test
  3. *Test* - Executed test code
  4. *TestTearDown* - Executed after every test
  5. *ClassTearDown* - Executed one time after last test
* **Other frameworks**
  * **Same logic**

---
## Assert

---
## Test types

---
## Testing tips

---
## Tests clean code


---
## References:
[C# 7.0 in a Nutshell: The Definitive Reference](https://www.amazon.com/C-7-0-Nutshell-Definitive-Reference/dp/1491987650)  
[The Art of Unit Testing](https://www.amazon.de/Art-Unit-Testing-Roy-Osherove/dp/1617290890)  
[xUnit.net](https://xunit.github.io/)  
[DZone](https://dzone.com/)

+++
## Refences to used images:
