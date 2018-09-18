# Introduction to the C# language and .NET Platform
## Language basics, syntax, instalation and introduction to Visual Studio
<div class="right">
[ Michal Orlicek <xorlic00@stud.fit.vutbr.cz> ]
</div>

---
<h2>Syllabus of lectures:</h2>
todo

+++
<h2>Syllabus of laboratories</h2>
todo

---
<h2>Literature to study</h2>
<img src="/Lectures/Lecture01/Assets/img/CsharpinNutshell.jpg" />
</br>ISBN 9781491987650

+++
<h2>Recommended literature</h2>
<div class="left">
<img src="/Lectures/Lecture01/Assets/img/PrincipesPatternsPracticesinCsharp.png" />
</br>ISBN 9780131857254
</div>
<div class="right">
<img src="/Lectures/Lecture01/Assets/img/CleanCode.png" />
</br>ISBN 9780132350884
</div>

+++
<h2>Recommended literature</h2>
<div class="left">
<img src="/Lectures/Lecture01/Assets/img/DesignPatterns.png" />
</br>ISBN 9780201633610
</div>
<div class="right">
<img src="/Lectures/Lecture01/Assets/img/UnitTesting.png" />
</br>ISBN 9781617290893
</div>

---
<div class="center" >
<img src="/Lectures/Lecture01/Assets/img/VisualStudioLogo.png" />
</br><a href="https://visualstudio.microsoft.com/vs/">Free download</a>
</div>

<!-- Links for fit, fekt? -->

+++
## Compare Visual Studio versions
|  Supported Features                | Community |  Professional | Enterprise |
| ---------------------------------- | --------- | ------------- | ---------- |
| Supported Usage scenarios          | ⚫⚫⚫◯  | ⚫⚫⚫⚫     | ⚫⚫⚫⚫   |
| Development Platform Support       | ⚫⚫⚫◯  | ⚫⚫⚫⚫     | ⚫⚫⚫⚫   |
| Integrated Development Environment | ⚫⚫⚫◯  | ⚫⚫⚫◯      | ⚫⚫⚫⚫  |
| Advanced Debugging and Diagnostics | ⚫⚫◯◯  | ⚫⚫◯◯      | ⚫⚫⚫⚫  |
| Testing Tools                      | ⚫◯◯◯  | ⚫◯◯◯       | ⚫⚫⚫⚫  |
| Cross-platform Development         | ⚫⚫◯◯  | ⚫⚫◯◯      | ⚫⚫⚫⚫  |
| Collaboration Tools and Features   | ⚫⚫⚫◯  | ⚫⚫⚫◯      | ⚫⚫⚫⚫  |


+++
<h2>Installation</h2>
<div class="center">
<ol type="1">
  <li>Download Visual Studio</li>
  <li>Install the Visual Studio installer</li>
  <li>Select workloads</li>
    <ul>
      <li>Select individual components</li>
      <li>Select language packs</li>
    </ul>
  <li>Start developing</li>
</ol>
</div>

<div class="right">
<a href="https://docs.microsoft.com/en-us/visualstudio/install/install-visual-studio?view=vs-2017">Installation guide</a>
</div>

---
# Recommended tools  

+++
[**Resharper**](https://www.jetbrains.com/resharper/)  
Extends Visual Studio with code inspections. For most inspections provides quick-fixes to improve code in one way or another. Help safely organize code and move it around the solution. For more details see [features](https://www.jetbrains.com/resharper/features/).

+++
[**Azure DevOps**](https://visualstudio.microsoft.com/team-services/)  
Before Visual Studio Team Services. 
<div class="left">
  <ul>
    <li>Cloud-hosted private Git repos
    <li>Agile planning
    <li>Build managment
    <li>Test Plans
  </ul>
</div>

+++
[**Code metrices**](https://marketplace.visualstudio.com/items?itemName=vkacmar.RoslynCodeMetrices)  
Visual Studio extension that helps to monitor the code complexity. As you type, the method complexity "health" is updated, and the complexity is shown near the method.

<!---
[**Postifx templates**](https://github.com/controlflow/resharper-postfix)  
Visual Studio extension. The basic idea is to prevent caret jumps backwards while typing C# code.
NOT UPDATED -->

+++
[**Mnemonic Templates**](https://github.com/JetBrains/mnemonics)  
Templates for ReSharper that let you quickly generate code and data structures by typing in names.

+++
[**LinqPad**](http://www.linqpad.net/)  
Program that is not just for LINQ queries, but any C# expression, statement block or program. Put an end to those hundreds of Visual Studio Console projects cluttering your source folder and join the revolution of LINQPad scripters and incremental developers.

+++
[**DotPeek**](https://www.jetbrains.com/decompiler/)  
Tool based on ReSharper's bundled decompiler. It can reliably decompile any .NET assembly into equivalent C# or IL code.

+++
[**MarkdownEditor**](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.MarkdownEditor)  
A full featured Markdown editor with live preview and syntax highlighting. Supports GitHub flavored Markdown.

+++
[**Entity Framework 6 Power Tools**](https://marketplace.visualstudio.com/items?itemName=ErikEJ.EntityFramework6PowerToolsCommunityEdition)  
Useful design-time utilities for EF 6, accessible through the Visual Studio Solution Explorer context menu when right-clicking on a file containing a derived DbContext class.

+++
[**OzCode**](https://www.oz-code.com/)  
Advanced debugging tools. Analyze your queries and see how items passed through the LINQ pipeline from the comfort of Visual Studio.

+++
[**GitFlow**](https://marketplace.visualstudio.com/items?itemName=vs-publisher-57624.GitFlowforVisualStudio2017)  
Team Explorer extension integrates GitFlow into your development workflow. It lets you easily create and finish feature, release and hotfix branches right from Team Explorer.  For more deails about git recommends [Pro Git book](https://git-scm.com/book/en/v2).

---
# Why To Choose .NET?

+++
## Productivity
* Develop high quality applications faster
* Modern language constructs
  *  Generics
  *  Language Integrated Query (LINQ)
  *  Asynchronous programming
* Extensive class libraries
* Common APIs
* Multi-language support

+++
## Amost every platform
* iOS
* Android
* Windows
* Windows server
* Linux
* Microservises on cloud

+++
## Performance
<div class="center">
Applications provide better response times and require less compute power. </br>
<img src="/Lectures/Lecture01/Assets/img/Performance.png" />
</br>Comparation of web application frameworks with tasks like JSON serialization, database access, and server side template rendering.
</div>

+++
## Security
* Immediate security benefits via its managed runtime
* Prevent critical issues like bad pointer manipulation
* Quick releases when threats are discovered

+++
## Large ecosystem
* Libraries from the [NuGet package manager](https://www.nuget.org/)
* Visual studio [marketplace](https://marketplace.visualstudio.com/)
* [Extensive partners network](https://vspartner.com/Directory)
* Comumunity, MVPs, support organization...

+++
## Open source
* [**.NET Foundation**](https://dotnetfoundation.org/)
* Independent, Innovative, Commencially-friendly
* Google, JetBrains, Red Hat, Samsung, Unity...

---
# .NET Platform

+++
##Provides language interoperability

<div class="center-right">
<img src="/Lectures/Lecture01/Assets/img/Common_Language_Infrastructure.png" />
</div>

+++
## Architecture
<div class="center">
<img src="/Lectures/Lecture01/Assets/img/dot_net_architecture.jpg" />
</div>

+++
## CLR - Common Language Runtime
* The virtual machine component of Microsoft's .NET framework 
* Manages the execution
* Just-in-time compilation
* Similar to Java Virtual Machine

<div class="center">
<img src="/Lectures/Lecture01/Assets/img/dot_net_clr.png" />
</div>

+++
## Benefits
* Performance improvements
* Easy use of components developed in other languages
* Extensible types provided by a class library
* Inheritance, interfaces, and overloading for OOP
* Free threading
* Structured exception handling
* Custom attributes
* Garbage collection
* Delegates instead of function pointers

+++
## Garbage collector
* Automated memory management without need of programmer intervention
* Based on reachability from GC roots
* 3 generations
<div class="center">
<img src="/Lectures/Lecture01/Assets/img/gc_generations.png" />
</div>

+++
<div class="center">
<img src="/Lectures/Lecture01/Assets/img/gc_collecting.png" />
</div>

+++
## Standard Libraries
|  Library               | Namespaces | 
|------------------------| ---------- |
| Base Class Library     | System, System.Collections, System.Collections.Generic, System.Diagnostics, System.IO, System.Text, System.Threading... |
| Runtime Infrastructure Library  | System, System.Reflection, System.Runtime.CompilerServices, System.Runtime.InteropServices... |
| Network Library | System, System.Net, System.Net.Sockets...  |
| Reflection Library | System.Globalization, System.Reflection...  | 
| XML Library  | System.Xml  |
| ⋮        | ⋮  |

+++
## Application models
<div class="center">
<img src="/Lectures/Lecture01/Assets/img/dot_net_libraries.png" />
</div>

+++
## In The Nutshell
<div class="center">
<img src="/Lectures/Lecture01/Assets/img/Csh_in_nutshell_framework.png" />
</div>

---
# C# Basics

+++
## C# is
* Multi-paradigm programming language
* Strong typing
* Object oriented (class-based)
* Imperative, declarative
* Functional, generic
* Based on c++

+++?code=/Lectures/Lecture01/Assets/code/HelloWorld.cs&lang=C#&title=Hello World
@[1]
@[3-4, 15]
@[5-6, 14]
@[7-8, 13]
@[9]
@[11]
@[12]

[Code sample](/Lectures/Lecture01/Assets/code/HelloWorld.cs)

+++
## Identifiers
* Name given to entities such as variables, methods, classes, etc.
* Tokens which uniquely identify an element
* `value` is a identifier:  
  ```C#
  int value;
  ```
* Reserved keywords can not be used unless prefix `@` is added  
  ```C#
  int @class;
  ```
+++
## Keywords
* Reserved words that have special meaning
* Meaning can not be changed
* Can not be directly used as identifies
* `long` is a keyword:
  ```C#
  long count;
  ```
* [List of all Keywords](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/)

+++
## Contextual Keywords
* specific meaning in a limited program context
* an be used as identifiers outside that context
* [List of all Contextual Keywords](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/)

+++
## Literals
* Data inserted in code
* E.g:
  ```
  42
  Hello World
  3.14159
  ```
+++
## Delimiters
* Characters used for code structuralization
* Curly brackets `{, }`
  * Creates code blocks
  * Used to *impart a scope*
* Semicolon `;`
  * Delimits statements
  * Statement can be written in multiple lines.
  ```C#
  Console.WriteLine
    (1 + 2 + 3 + 4 + 5);
  ```

+++
## Operators
  * Used to combine multiple expressions
  * E.g., `. () * + -`

+++
## Comments
* Line
  ```C#
  // line comment
  ```
* Block
  ```C#
  /* Comment can be split
  into multiple lines */
  ```
  * **Do not use block comments!**
* Documenting 
  ```C#
  /// <summary>
  /// Documents class, method ...
  /// </summary>
  ```

+++


---
## References:

[C# 7.0 in a Nutshell: The Definitive Reference](https://www.amazon.com/C-7-0-Nutshell-Definitive-Reference/dp/1491987650)  
[Visual Studio Documentation](https://docs.microsoft.com/en-us/visualstudio)  
[Microsoft Visual Studio](https://visualstudio.microsoft.com)  
[Microsoft](https://www.microsoft.com)  
[Resharper](https://www.jetbrains.com/resharper)  
[Wikipedia](https://en.wikipedia.org)  
[Programiz](https://www.programiz.com)
[IW5](https://github.com/FitIW/5)  


Google images