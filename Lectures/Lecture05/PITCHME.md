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
* MS Test
* Nunit
* xUnit
* ⋮

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

+++
### MS Test
* Integrated in Visual Studio

+++
### Nunit
* Most used

+++
### xUnit
* Successor of Nunit

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
## References:
[C# 7.0 in a Nutshell: The Definitive Reference](https://www.amazon.com/C-7-0-Nutshell-Definitive-Reference/dp/1491987650)  
[The Art of Unit Testing](https://www.amazon.de/Art-Unit-Testing-Roy-Osherove/dp/1617290890)  


+++
## Refences to used images:
