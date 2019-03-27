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

+++
### Single Concept per Test
* Tests are laser focused 
* Not testing miscellaenous
 * Non-related things

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
### Functional Testing Types
* **Unit** testing
* **Integration** testing
* **System** testing
* **Sanity** testing
* **Smoke** testing
* **Interface** testing
* **Regression** testing
* **Beta/Acceptance** testing
* ⋮

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

+++
### Non-functional Testing Types

* **Stress** testing
* **Volume** testing
* **Security** testing
* **Compatibility** testing
* **Install** testing
* **Recovery** testing
* **Reliability** testing
* **Usability** testing
* **Compliance** testing
* **Localization** testing
* ⋮

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

+++
### Unit Testing
* **Very low level**
* Testing individual 
  * *Methods* and *functions* of the classes
  * *Components* or *modules* used by your software
* Typically **done by the programmer**
* Generaly quite **cheap to automate**
* Can be **run very quickly**
  * Can be run by a continuous integration server
* Requires a detailed knowledge of the internal program design and code
* Requires developing test driver modules or test harnesses

+++
### Smoke Testing
* Right **after a new build** is made
* Typically **done by the testing team**
* **Check basic functionality** of the application
* Meant to be **quick to execute**
* **Ensures**
  * That **no major issue exists**
  * That **the build is stable**
  * That no show stopper defect exists
    * Which will prevent the testing team to test the application in detail
* Detailed level of testing is carried out further
* If testers find that the major critical functionality is broken down at the initial stage itself
  * Then testing team can reject the build and inform accordingly to the development team

+++
### Integration Testing
* Verify that **different modules or services** used by your application **works well together**
* Modules are typically 
  * *Code modules*
  * *Individual applications*
  * *Client and server applications* on a network
  * ⋮
* **More expensive** to run as they require multiple parts of the application to be up and running
* Especially **relevant to client/server and distributed systems**

+++
### User Interface (UI) Testing
* To **validate the UI as per the business requirement**
* **Validates**
  * The *size of the buttons* and *input field* present on the screen
  * *Alignment* of all text, tables and content in the tables
  * The *menu* of the application
    * After selecting different menu and menu items
  * That the *page* does not *fluctuate* and the *alignment remains same* after hovering the mouse on the menu or sub-menu
  * Other UI functionalities...

+++
### Acceptance Testing
* Also called **User Acceptance Testing (UAT)**
* **Formal tests**
* **Performed by the client**
* Verifies **if a system satisfies its business requirements**
* **Requires the entire application** to be up and running
* Focuses on **replicating user behaviors**
  * Can go further and measure the performance of the system
* Client accepts the software only when all the features and functionalities work as expected
* **Last phase** of the testing, after which the software goes into production

---
## Code Coverage
* **Metric** that can **help understand how much of your source is tested**
* Can **help assess the quality of test suite**
* **Code coverage tools**
  * Use one or more criteria to determine how your code was exercised or not
  * During the execution of your test suite
* Visual studio contains *Code Metrics Window*
  * `View->Other Windows->Code Metrics Results`

+++
### Common Metrics
* **Metrics:**
  * **Function coverage:** how many of the functions defined have been called
  * **Statement coverage:** how many of the statements in the program have been executed
  * **Branches coverage:** how many of the branches of the control structures (if statements for instance) have been executed
  * **Condition coverage:** how many of the boolean sub-expressions have been tested for a true and a false value
  * **Line coverage:** how many of lines of source code have been tested
  * ⋮
* Metrics are **related, but distinct**
* Usually **represented as the number** of *items actually tested, the items found in your code, and a coverage percentage* (items tested / items found)

---
## Testing Attributes Tips
* `InternalsVisibleTo` for testing internal
* `Ignore` for not working tests
* `Deployment` to publish file into testing director
* ⋮


---
## Continuous Integration
* **Development practice** that requires developers to **integrate code into a shared repository** several times a day
* Helps **detect errors quickly**, and locate them more easily
* Each check-in can be **verified by an automated build**, allowing to detect problems

@img[span-80](/Lectures/Lecture05/Assets/img/CI.png)

+++
## Continuous Integration Benefits
* Significantly **less back-tracking to discover where things went wrong**
* It's **cheap**
* Increases **visibility** enabling greater communication
* **Less time debugging** and **more time adding features**
* Solid foundation
* Stops waiting to find out if your code’s going to work
* Reduce integration problems

+++
## Continuous Deployment
* Refers to the **release into production of software that passes the automated tests**
* Closely **related to Continuous Integration**
* *"Essentially, it is the practice of releasing every good build to users”* - Jez Humble, author of Continuous Delivery
* **Low-risk** releases

---
## Azure Devops
* [Web](https://azure.microsoft.com/en-us/services/devops/)
* [Effective DevOps Book](https://www.amazon.com/Effective-DevOps-Building-Collaboration-Affinity/dp/1491926309/)
* Provides **development collaboration tools**:
  * *Azure Boards*
  * *Azure Repos*
  * *Azure Pipelines*
  * *Azure Test Plans*
  * *Azure Artifacts*
  * *Wiki*
  * ⋮

@snap[north-east]
@img[span-30](/Lectures/Lecture05/Assets/img/devopsLogo.png)
@snapend

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

+++
### Dashboards

@img[span-70](/Lectures/Lecture05/Assets/img/AzureDashboards.jpg)

---
## Azure Boards
* **Tracking tasks, features, and bugs** associated with project
  * Work item types
* Integration with GitHub

@snap[north-east span+40]
![](/Lectures/Lecture05/Assets/img/AzureBoards.png)
@snapend

+++
### Boards Sample Screen
![](/Lectures/Lecture05/Assets/img/AzureBoardsSample.jpg)

+++
### Boards Processes
![](/Lectures/Lecture05/Assets/img/AzureProcesses.png)

+++
### Scrum Work Item Types
![](/Lectures/Lecture05/Assets/img/ScrumTypes.png)

+++
### Workflow customization

@img[span-70](/Lectures/Lecture05/Assets/img/AzureWorkFlow.jpg)

---
## Azure Repos
* Free private **Git repositories**, pull requests, and code search
@img[span-70](/Lectures/Lecture05/Assets/img/AzureReposSample.jpg)

@snap[north-east span+40]
![](/Lectures/Lecture05/Assets/img/AzureRepos.png)
@snapend

+++
## GitFlow
* **Branching model** for Git
* Created by Vincent Driessen
* Benefits
  * *Parallel Development*
  * *Collaboration*
  * *Release Staging Area*
  * *Support For Emergency Fixes*

+++
### How GitFlow Works 1/5
* New development is built in **feature branches**

@img[span-35](/Lectures/Lecture05/Assets/img/GitFlow1.png)

+++
### How GitFlow Works 2/5
* Feature branches are branched off of the **develop branch**
* Finished features and fixes are merged back into the **develop branch**

@img[span-35](/Lectures/Lecture05/Assets/img/GitFlow2.png)

+++
### How GitFlow Works 3/5
* When it is time to make a release, a **release branch** is created off of **develop**

@img[span-35](/Lectures/Lecture05/Assets/img/GitFlow3.png)

+++
### How GitFlow Works 4/5
* When the release is finished, the **release branch** is merged into **master and** into **develop** too

@img[span-35](/Lectures/Lecture05/Assets/img/GitFlow4.png)

+++
### How GitFlow Works 5/5
* **Hotfix branches** are used to create emergency fixes

@img[span-35](/Lectures/Lecture05/Assets/img/GitFlow5.png)

+++
## GitLab Flow

@snap[west]
@img[span-75](/Lectures/Lecture05/Assets/img/GitLabFlow1.png)
@snapend

@snap[east]
@img[span-75](/Lectures/Lecture05/Assets/img/GitLabFlow2.png)
@snapend

+++
## GitHub Flow

![](/Lectures/Lecture05/Assets/img/GitHubFlow.png)

---
## Azure Pipelines
* **Builds and deployments automatization**
* Integration with GitHub

@img[span-70](/Lectures/Lecture05/Assets/img/AzurePipelinesSample.jpg)

@snap[north-east span+40]
![](/Lectures/Lecture05/Assets/img/AzurePipelines.png)
@snapend

+++
### Azure Pipelines Benefits
* **Any language**
* **Any platform**
* Cloud deployment
* Push images to container registries
* Extensible
* Advanced workflows and features
  * Support for YAML
  * Test integration
  * Release gates
  * Reporting
  * ⋮

+++
### Simple Pipeline Creation 1/5
* **Open Pipelines**
* If there is no pipeline created, **clink on "New pipeline" button**

![](/Lectures/Lecture05/Assets/img/Pipe1.png)

+++
### Simple Pipeline Creation 2/5
* **Select repository and branch** for pipeline
* There is also option for classic editor without YAML

@img[span-45](/Lectures/Lecture05/Assets/img/Pipe2.png)

+++ 
### Simple Pipeline Creation 3/5
* **Select predefined configurations**
* Configurations can be customized
  * Also *.yml file* can be edited

@img[span-40](/Lectures/Lecture05/Assets/img/Pipe3.png)

+++
### Simple Pipeline Creation 4/5
* **Hit Run** and pipeline will be runned
* My build pipeline for simple WPF app:

![](/Lectures/Lecture05/Assets/img/Pipe4.png)

+++
### Simple Pipeline Creation 5/5
* **Release pipeline**
  * Way how to deploy your code
  * Contains a lot of templates
  
![](/Lectures/Lecture05/Assets/img/Pipe5.png)

---
## Azure Test Plans
* todo

@snap[north-east span+40]
![](/Lectures/Lecture05/Assets/img/AzureTestPlans.png)
@snapend

---
## Azure Artifacts
* **Integrated package management** to (CI/CD) pipelines
* Dhare *Maven*, *npm*, and *NuGet* packages from public and private sources
* Unlimited size
* Stored in cloud
* It is not part of basic access level

@snap[north-east span+40]
![](/Lectures/Lecture05/Assets/img/AzureArtifacts.png)
@snapend

+++
## Azure Artifacts Screen

@img[span-70](/Lectures/Lecture05/Assets/img/AzureArtifactsSample.jpg)

---
## References:
[C# 7.0 in a Nutshell: The Definitive Reference](https://www.amazon.com/C-7-0-Nutshell-Definitive-Reference/dp/1491987650)  
[The Art of Unit Testing](https://www.amazon.de/Art-Unit-Testing-Roy-Osherove/dp/1617290890)  
[Agile Principles, Patterns, and Practices in C#](https://www.amazon.com/Agile-Principles-Patterns-Practices-C/dp/0131857258)  
[Effective DevOps: Building a Culture of Collaboration, Affinity, and Tooling at Scale](https://www.amazon.com/Effective-DevOps-Building-Collaboration-Affinity/dp/1491926309/)  
[CodingBlocks.NET - How to Write Amazing Unit Tests](https://www.codingblocks.net/podcast/how-to-write-amazing-unit-tests/)  
[Atlassian - Continuous delivery](https://www.atlassian.com/continuous-delivery)  
[Software Testing Help](https://www.softwaretestinghelp.com/)  
[Azure DevOps](https://azure.microsoft.com/en-us/services/devops/)  
[Microsoft Docs](https://docs.microsoft.com/en-us/)  
[Agile Alliance](https://www.agilealliance.org/)  
[Introducing GitFlow](https://datasift.github.io/gitflow/IntroducingGitFlow.html)  
[WikiWikiWeb](http://wiki.c2.com/)  
[ThoughtWorks](https://www.thoughtworks.com/)  
[GitLab Docs](https://docs.gitlab.com/)  
[xUnit.net](https://xunit.github.io/)  
[DZone](https://dzone.com/)

+++
## Refences to used images:
[xUnit.net](https://xunit.github.io/)  
[CodeProject](https://www.codeproject.com/)  
[Azure DevOps](https://azure.microsoft.com/en-us/services/devops/)  
[APPFAB TECHNOLOGY](http://appfab.technology/)  
[Introducing GitFlow](https://datasift.github.io/gitflow/IntroducingGitFlow.html)  
[GitLab Docs](https://docs.gitlab.com/)  