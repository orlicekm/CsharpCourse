# Introduction to the C# language and .NET Platform
## Language basics, syntax, instalation and introduction to Visual Studio
<div class="right">
[ Michal Orlicek <xorlic00@stud.fit.vutbr.cz> ]
</div>

---
## Syllabus of lectures:  
* to do

+++
## Syllabus of laboratories  
* to do

---
# Literature

+++
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
## Welcome to the Visual Studio

* Integrated development environment (IDE)
* Available for Windows and Mac
* Feature-rich program that can be used for many aspects of software development:
    * editor
    * debugger
    * builder 
    * completion tools
    * graphical designers
    * etc..

+++

<div class="center">
<img src="/Lectures/Lecture01/Assets/img/VisualStudioIde.jpg" />
</div>

<!-- create a program? -->
<!-- basic components tour? -->
<!-- popular productivity features?-->
<!-- debug in vs? -->
<!-- customize vs? -->


+++
## Comparation of Visual Studio versions
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
### [Resharper](https://www.jetbrains.com/resharper/)  
Extends Visual Studio with code inspections. For most inspections provides quick-fixes to improve code in one way or another. Helps safely organize code and move it around the solution. For more details see [features](https://www.jetbrains.com/resharper/features/).

+++
### [Azure DevOps](https://visualstudio.microsoft.com/team-services/)  
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
### [Code metrices](https://marketplace.visualstudio.com/items?itemName=vkacmar.RoslynCodeMetrices)  
Visual Studio extension that helps to monitor the code complexity. As you type, the method complexity "health" is updated, and the complexity is shown near the method.

<!---
#### [Postifx templates](https://github.com/controlflow/resharper-postfix)  
Visual Studio extension. The basic idea is to prevent caret jumps backwards while typing C# code.
NOT UPDATED -->

+++
### [Mnemonic Templates](https://github.com/JetBrains/mnemonics)  
Templates for ReSharper that let you quickly generate code and data structures by typing in names.

+++
### [LinqPad](http://www.linqpad.net/)  
Program that is not just for LINQ queries, but any C# expression, statement block or program. Put an end to those hundreds of Visual Studio Console projects cluttering your source folder and join the revolution of LINQPad scripters and incremental developers.

+++
### [DotPeek](https://www.jetbrains.com/decompiler/)  
Tool based on ReSharper's bundled decompiler. It can reliably decompile any .NET assembly into equivalent C# or IL code.

+++
### [MarkdownEditor](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.MarkdownEditor)  
A full featured Markdown editor with live preview and syntax highlighting. Supports GitHub flavored Markdown.

+++
### [Entity Framework 6 Power Tools](https://marketplace.visualstudio.com/items?itemName=ErikEJ.EntityFramework6PowerToolsCommunityEdition)  
Useful design-time utilities for EF 6, accessible through the Visual Studio Solution Explorer context menu when right-clicking on a file containing a derived DbContext class.

+++
### [OzCode](https://www.oz-code.com/)  
Advanced debugging tools. Analyze your queries and see how items passed through the LINQ pipeline from the comfort of Visual Studio.

+++
### [GitFlow](https://marketplace.visualstudio.com/items?itemName=vs-publisher-57624.GitFlowforVisualStudio2017)  
Team Explorer extension integrates GitFlow into your development workflow. It lets you easily create and finish feature, release and hotfix branches right from Team Explorer.  For more deails about git recommends [Pro Git book](https://git-scm.com/book/en/v2).

---
# Why To Choose .NET?

+++
## Productivity
* To develop high quality applications faster
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
* Community, MVPs, support organization...

+++
## Open source
* [**.NET Foundation**](https://dotnetfoundation.org/)
* Independent, Innovative, Commencially-friendly
* Google, JetBrains, Red Hat, Samsung, Unity...

---
# .NET Platform

+++
<h2>Language interoperability</h2>

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
### Garbage collector
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

+++?code=/Lectures/Lecture01/Assets/code/HelloWorld.cs&lang=C#&title=Hello World Sample
@[1]
@[3-4, 15]
@[5-6, 14]
@[7-8, 13]
@[9]
@[11]
@[12]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture01/Assets/code/HelloWorld.cs)

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

[List of all Keywords](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/)

+++
## Contextual Keywords
* Specific meaning in a limited program context
* Can be used as identifiers outside that context

[List of all Contextual Keywords](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/)

+++
## Literals
* Data inserted in code
* E.g., `42, Hello World, 3.14159`

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
  * **Do not use block comments!!!**
* Documenting 
  ```C#
  /// <summary>
  /// Documents class, method...
  /// </summary>
  ```

---
## Data types
* tells the compiler or interpreter how the programmer intends to use the data
* **Value type**
  * Directly contains data
  * Each variable have their own copy of the data
  * It is not possible for operations on variable to affects another
* **Reference types** (objects)
  * Store references to their data
  * Multible variables can reference the same object
  * It is possible for operations on variable to affect another

[Documentation](https://docs.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/types-and-variables)

+++
## Value Types
* **Simple Types**
  * Signed integral: `sbyte, short, int, long`
  * Unsigned integral: `byte, ushort, uint, ulong`
  * Unicode characters: `char`
  * IEEE floating point: `float, double`
  * High-precision decimal: `decimal`
  * Boolean: `bool`
* **Enum types**
  * User-defined types of the form `enum E {...}`
* **Struct types**
  * User-defined types of the form `struct S {...}`
* **Nullable value types**
  * Extensions of all other value types with a `null` value

+++
### Literals notation
* Classical
  * E.g., `127`, `42`, etc...
* Hexadecimal
  * E.g., `0x7F`, `0x2A`, etc... 
* Decimal 
  * `'.'` character as a delimiter
  * `'e'` character as an exponent
* Rules
  * If literal contains `'.'`, or `'e'` than data type is decimal
  * Else data type is the smallest one that fits `int, uint, long, ulong`

+++
### Numerical data types specification
Using specific character as a suffix

```C#
 Console.WriteLine(1f.GetType());  // Float   (float)
 Console.WriteLine(1d.GetType());  // Double  (doulbe)
 Console.WriteLine(1m.GetType());  // decimal (decimal)
 Console.WriteLine(1u.GetType());  // UInt32  (uint)
 Console.WriteLine(1L.GetType());  // Int64   (long)
 Console.WriteLine(1ul.GetType()); // UInt64  (ulong) 
```

+++
### Numerical data types casting
* Transformation of **integral type** to **integral type**:
  * *implicit* when *target type* can accommodate the whole range of *source type*
  * *explicit* otherwise
* Transformation of **decimal type** to **decimal type**:
  * `float` can be *implicitly* casted to `double`
  * `double` has to be casted *explicitly* to `float`
* Transformation of **integral type** to **decimal type**:
  * Casting is *implicit*
* Transformation of **decimal type** to **integral type**:
  * Casting has to be *explicit* 
    * Lost precision
    * Truncation can occur

---
## Arithmetic operations
* `+` addition
* `-` subtraction
* `*` multiplication
* `/` division
* `++` incrementation
* `--` decrementation

+++
### Byte, sbyte, short, ushort types
* 8 and 16 bits types do not have arithmetical operations
  * E.g., `byte, sbyte, short, ushort`
  * Compiler does implicit cast to large type `int, uint`
  ```C#
  short x = 1, y = 1;
  short z = x + y;    // Compile-time error
  ```
  * Solution is to do explicit cast
  ```C#
  short x = 1, y = 1;
  short z = (short)(x + y); // OK
  ```

+++
### Numerical Overflow
* Overflow of integral types
  ```C#
  int a = int.MinValue;
  a--;
  Console.WriteLine(a == int.MaxValue); // True
  ```
* Usage of `checked` keyword or compiler option **/checked+**
  ```C#
  int a = int.MinValue;
  var i = checked(a--); // throw OverflowException
  Console.WriteLine(i == int.MaxValue);
  ```

+++
### Truncation and precision loss
* `float` and `double` are stored in binary form
  * which means only multiples of 2 are stored precisely
```C#
float f1 = 0.09f * 100f;
float f2 = 0.09f * 99.999999f;
Assert.False(f1>f2);
```
* `decimal` is stored in decimal form, but it has still a limitted precision
  ```C#
  decimal m = 1M  /  6M;                          // 0.1666666666666666666666666667M
  double  d = 1.0 / 6.0;                          // 0.16666666666666666
  decimal notQuiteWholeM = m + m + m + m + m + m; // 1.0000000000000000000000000002M
  double  notQuiteWholeD = d + d + d + d + d + d; // 0.99999999999999989      
  Console.WriteLine(notQuiteWholeM == 1M);        // False
  Console.WriteLine(notQuiteWholeD < 1.0);        // True
  ```

+++
## Bitwise operations
| Operator |   Meaning   |      Example     |   Result    |
| -------- | ----------- | ---------------- | ----------- |
|    `~`   |     Not     |         `~0xfU`  | 0xfffffffOU |
|    `&`   |     And     |   `0xf0 & 0x33`  | 0x30        |
|  <code>&#124;</code> |      Or     |<code>0xf0 &#x7c; 0x33</code> | 0xf3        |
|    `^`   |     Xor     | `0xff00 ^ 0x00ff`| 0xffff      |
|   `<<`   |  Left shift |  `0x20 << 2`     | 0x80        |
|   `>>`   | Right shift |  `0x20 >> 1`     | 0x10        |
 
+++
## Nullable value types
* Do not have to be declared before they can be used
* For each non-nullable value type `T` there is a corresponding nullable value type `T?
  * Which can hold an **additional value**, `null`
* E g. `int?` can hold
  * Any 32-bit integee
  * `null`

+++
## Boolean type
* `System.Boolean`/`bool`
* Store logical values 
  * `true` or `false`
* `sizeof(bool) == sizeof(uint8) == sizeof(sbyte)`
* Nothing can be casted to `bool`
* Operators:
  * Equality `==`, `!=`
  * Conditional operators `&&`, `||`
  ```C#
  public bool UseUmbrela(bool rainy, bool sunny, bool windy) {
    return !windy && (rainy || sunny);
  }
  ```
* Often used for *Lazy evaluation* 

+++
## Character type
* `System.Char`/`char`
* Literal is denoted by a single-quote, e.g., `'a'`
* Can be cast to integral type
  * *Implicit* cast to `ushort`
  * *Explicit* cast to others

+++
##  Reference types
* **Class types**
  * Ultimate base class of all other types: `object`
  * Unicode strings: `string`
  * User-defined types of the form `class C {...}`
* **Interface types**
  * User-defined types of the form `interface I {...}`
* **Array types**
  * Single- and multi-dimensional, e.g., `int[]` and `int[,]`
* **Delegate types**
  * User-defined types of the form `delegate int D(...)`
* Supports generics, whereby they can be parameterized with other types.

+++
### Class
* **data structure** that contains:
  * Data members (*fields*)
  * Function members (*methods*, *properties* and others). 
* Supports
  * Single inheritance 
  * Polymorphism 
* Can extend and specialize base classes

+++
### Struct
* Similar to a class type
* **Unlike classes**, *structs* are value types and do not typically require heap allocation
* Struct types do not support
  * User-specified inheritance
  * Struct types implicitly inherit from type `object`

+++
### Interface
* **Contract** as a named set of public function members
* A *class* or *struct* that implements an interface must provide implementations of the interface’s function members
* An interface may inherit from multiple base interfaces, and a class or struct may implement multiple interfaces

+++
### Delegate
* **References to methods** with a particular parameter list and return type
* Makes it possible to treat methods as entities that can be assigned to variables and passed as parameters
* Are analogous to function types provided by functional languages
  * They are also similar to the concept of function pointers found in some other languages
  * Unlike function pointers, delegates are object-oriented and **type-safe**

+++
### String
* `System.String` / `string`
* Represents sequence of characters
* Reference data type
* Literal is denote by double-quotes. e.g., `"string value"`
* Verbatim string is denote by `@` prefix, e.g.,
  ```C#
  @"Multi-line
  string"
  ```
* Use `string.Empty` to assigned empty strings instead of `""`

+++
#### String concatenation
* `+` operator
* Not all operands needs to be strings themselves
* Non string operands get called `ToString()` method on them
  ```C#
  string s = "a" + 5; // a5
  ```
* For multiple string concatenation operations avoid usage of `+`, use:
  * `System.Text.StringBuilder`
  * `s = System.String.Format("{0} times {1} = {2}", i, j, (i*j));`
  * `s = $"{i} times {j} = {i*j}";`

<!-- special charakters? (@, $)-->
<!-- table of escape sequences? -->

+++
### Array
* Represents fixed length data structure of homogeneous items
* Stored in sequential block of memory
* Do not have to be declared before it can be used
* Initialization
  * Value types - default value
  * Reference types - `null`
* Access out of array range throws `IndexOutOfRangeException`
* Instead, array types are constructed by following a type name with square brackets
  * `int[]` single-dimensional array of int
  * `int[,]` two-dimensional array of int (matrix)
  * `int[][]` is a single-dimensional array of single-dimensional array of int

+++?code=/Lectures/Lecture01/Assets/code/Array.cs&lang=C#&title=Array Sample
@[7-10]
@[12-22]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture01/Assets/code/Array.cs)

--- 
### Variables
* Including *fields*, *array elements*, *local variables*, and *parameters* represents storage locations
* Has a type that determines what values can be stored in the variable

+++
#### Variable types
| Type | Value |
| ---- | ----- |
| **Non-nullable** type | value of that *exact type* |
| **Nullable**  type| *null* value value or of that *exact type* |
| **Object** | *null* reference, a reference to an *object* of any reference type, or a reference to a *boxed value* of any value type|
| **Class** type | *null* reference, a reference to an *instance of that class* type, or a reference to an instance of a class *derived* from that class type|
| **Interface** type | *null* reference, a reference to an *instance of a class* type that *implements* that interface type, or a reference to a *boxed* value of a value type that implements that interface type|
| **Array** type | *null* reference, a reference to an *instance of that array* type, or a reference to an *instance of a compatible array* type|
| **Delegate** type | *null* reference or a reference to an *instance of a compatible delegate* type|

+++  
### Stack vs Heap
* **Stack**
  * Allocated block of memory for *local variables, parameters*
* **Heap**
  * Storage for *reference data types*
  * Managed by *Garbage Collector*  
* Local variable has to be *assigned before reading*
* Method has to be *called with all arguments*
* All other values are initialized automatically

+++
### Default values
|    Type   | Default value  |  
| --------- | -------------- | 
| Reference | `null`         |
| Numerical | `0`            |
| Enums     | `0`            |
| Char      | `'\0'`         |
| Boolean   | `false`        |

+++?code=/Lectures/Lecture01/Assets/code/DefaultValue.cs&lang=C#&title=Default Value Sample
@[8-9]
@[10-11]
@[5, 12]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture01/Assets/code/DefaultValue.cs)

+++
## Boxing/Unboxing
* C#'s type system is unified such that a value of any type can be treated as an `object`
* Every type in C# directly or indirectly derives from the `object` class type, and `object` is the ultimate *base class* of all types
* Values of reference types are treated as objects simply by viewing the values as type object
* Values of value types are treated as objects by performing **boxing** and **unboxing** operations

+++?code=/Lectures/Lecture01/Assets/code/Boxing.cs&lang=C#&title=Boxing Sample
@[7]
@[8]
@[9]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture01/Assets/code/Boxing.cs)

---
## Parameters
* Parameters can be passed to a method as:
  * Value
    * Going in
  * Ref reference
    * Going in
  * Out reference
    * Going out
    * Variable does not need to be initialized before method call
    * Variable needs to be assigned before return from a method

+++?code=/Lectures/Lecture01/Assets/code/ValueParameter.cs&lang=C#&title=Value Parameter Sample
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture01/Assets/code/ValueParameter.cs)

+++?code=/Lectures/Lecture01/Assets/code/RefParameter.cs&lang=C#&title=Ref Parameter Sample
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture01/Assets/code/RefParameter.cs)

+++?code=/Lectures/Lecture01/Assets/code/OutParameter.cs&lang=C#&title=Out Parameter Sample
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture01/Assets/code/OutParameter.cs)

+++
### Parameter with `params[]`
* Can be used only with the *last parameter* in a method signature
* Has to be declared as an array
* Used to pass multiple variables of the same type
  ```C#
  void Foo(int x = 2) { … }
  ```
  ```C#
  Foo();
  ```

+++
### Named parameters
* Usually used with method calls on methods with *multiple optional parameters*
* Reduce the number of method overrides
  ```C#
  void Foo(int x = 2, int y = 3) { … }
  ```
  ```C#
  Foo(y:4, x:4);
  Foo(y: ++a, x: --a); 
  Foo(y: 1);
  ```

---
## Operators
* *unary, binary, ternary*
* *Binary* operators use **infix** notation, operator is in between operands
* **Primary expression**
  * Used to build the language
  * `Math.Log(1)` contains two primary operators `.` and `()`

+++
### Table of operators
| Category        | Operator symbol | Operator name               | Example        | User overloadable |
|-----------------|-----------------|-----------------------------|----------------|-------------------|
| Primary         | .               | Member access               | x.y            | No                |
|                 | -> (unsafe)     | Pointer to struct           | x->y           | No                |
|                 | ()              | Function cal                | x()            | No                |
|                 | []              | Array/Index                 | a[x]           | via indexer       |
|                 | ++              | Post-increment              | x++            | No                |
|                 | --              | Post-decrement              | x--            | No                |
|                 | new             | Create instance             | new x()        | No                |
|                 | stackalloc      | Unsafe stack allocation     | stackalloc(10) | No                |
|                 | typeof          | Get type from identifier    | typeof(int)    | No                |
|                 | checked         | Integral overflow check on  | checked(x)     | No                |
|                 | unchecked       | Integral overflow check off | unchecked(x)   | No                |
|                 | default         | Default value               | default(int)   | No                |
|                 | await           | Await                       | await myTask   | No                |

+++
| Category        | Operator symbol | Operator name               | Example        | User overloadable |
|-----------------|-----------------|-----------------------------|----------------|-------------------|
| Unary           | sizeof          | Get size of struct          | sizeof(int)    | No                |
|                 | +               | Positive value of           | +x             | Yes               |
|                 | -               | Negative value of           | -x             | Yes               |
|                 | !               | Not                         | !x             | Yes               |
|                 | ++              | Pre-increment               | ++x            | Yes               |
|                 | --              | Pre-decrement               | --x            | Yes               |
|                 | ()              | Cast                        | (int)x         | No                |
|                 | * (unsafe)      | Value at address            | *x             | No                |
|                 | &(unsafe)       | Address of value            | &x             | No                |

+++
| Category        | Operator symbol | Operator name               | Example        | User overloadable |
|-----------------|-----------------|-----------------------------|----------------|-------------------|
| Multi-privative | *               | Multiply                    | x * y          | Yes               |
|                 | /               | Divide                      | x / y          | Yes               |
|                 | %               | Remainder                   | x % y          | Yes               |
| Additive        | +               | Add                         | x+y            | Yes               |
|                 | -               | Subtract                    | x-y            | Yes               |
| Shift           | <<              | Shift left                  | x<<y           | Yes               |
|                 | >>              | Shift right                 | x>>y           | Yes               |
| Relational      | <               | Less than                   | x<y            | Yes               |
|                 | >               | Greater than                | x>y            | Yes               |
|                 | <=              | Less than or equals to      | x<=y           | Yes               |
|                 | >=              | Greater than or exuals to   | x>=y           | Yes               |

+++
| Category        | Operator symbol | Operator name               | Example        | User overloadable |
|-----------------|-----------------|-----------------------------|----------------|-------------------|
| Relational      | is              | Type is or is subclass of   | x is y         | No                |
|                 | as              | Type conversion             | x as y         | No                |
| Logical And     | &               | And                         | x & y          | Yes               |
| Logical Xor     | ^               | Exclusive Or                | x ^ y          | Yes               |
| Logical Or      | &#x7c;          | Or                          | x &#x7c; y     | Yes               |
| Conditional And | &&              | Conditional And             | x && y         | Via &             |
| Conditional Or  | &#x7c;&#x7c;    | Conditional or              |x &#x7c;&#x7c; y| Via &             |
| Null coalescing | ??              | Null coalescing             | x ??           | No                |
| Conditional     | ?:              | Conditional                 | isTrue? x : y  | No                |
| Assignment      | =               | Assign                      | x = y          | No                |
|                 | *=              | Multiply self by            | x*=2           | Via *             |

+++
| Category        | Operator symbol | Operator name               | Example        | User overloadable |
|-----------------|-----------------|-----------------------------|----------------|-------------------|
| Assignment      | /=              | Divide self by              | x/=2           | Via /             |
|                 | +=              | Add self by                 | x+=2           | Via +             |
|                 | -=              | Substract from self         | x-=2           | Via -             |
|                 | <<=             | Shift self left by          | x<<=2          | Via <<            |
|                 | >>=             | Shift self right by         | x>>=2          | Via >>            |
|                 | &=              | Add self by                 | x&=2           | Via &             |
|                 | ^=              | Exclusive-Or self by        | x^=2           | Via ^             |
|                 | &#x7c;=         | Or self by                  | x &#x7c;=2     | Via &#x7c;        |
| Lambda          | =>              | Lambda                      | x => x+1       | No                |

+++
## Expressions
* Returns some value after computation
* The simplest expression is *constant* or *variable*, e.g., `5`
* Expression can be combined using operators
  ```C#
  5*4
  ```
  ```C#
  (5*4)+1
  ```

+++
### Void expression
* *Do not have a value*
* Cannot be combined with other operators
* E.g., `{}, return, etc...`

+++
### Assigning expression
* E.g., `x=x+5`
* Can be part of another expression
  ```
  y = 5 * (x = 2);
  ```
* Can be used to initialize multiple variables:
  ```
  a = b = c = d = e = 0;
  ```
* Combination of operators
  * `x+=5`, the same meaning as `x=x+5`

+++
### Priority and assignment
* Priority is evaluated by the *priority of operators*
* *The same priority* operators are evaluated starting with *the most left one*
* Left-associative operators
  * `8/4/2` equals `(8/4)/2`
* Right-associative operators
  ```
  x = y = 3;
  ```

---
## Statements - Selection
* Used to define a program control flow
* `if`
* `switch`
* Conditional (ternary) operand `?:`

+++?code=/Lectures/Lecture01/Assets/code/If.cs&lang=C#&title=If Sample
@[7-11]
@[12-15]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture01/Assets/code/If.cs)

+++?code=/Lectures/Lecture01/Assets/code/Switch.cs&lang=C#&title=Switch Sample
@[9-10, 26]
@[11-14]
@[15-22]
@[23-25]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture01/Assets/code/Switch.cs)

+++?code=/Lectures/Lecture01/Assets/code/TernaryOperand.cs&lang=C#&title=Ternary Operand Sample
@[7-9]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture01/Assets/code/TernaryOperand.cs)

+++
## Statements - Cycles
* `while`
* `do while`
* `for`
* `foreach`


+++?code=/Lectures/Lecture01/Assets/code/While.cs&lang=C#&title=While Sample
@[7-12]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture01/Assets/code/While.cs)

+++?code=/Lectures/Lecture01/Assets/code/DoWhile.cs&lang=C#&title=Do While Sample
@[7-12]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture01/Assets/code/DoWhile.cs)

+++?code=/Lectures/Lecture01/Assets/code/For.cs&lang=C#&title=For Sample
@[7-10]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture01/Assets/code/For.cs)

+++?code=/Lectures/Lecture01/Assets/code/Foreach.cs&lang=C#&title=Foreach Sample
@[7-10]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture01/Assets/code/ForEach.cs)

+++
## Statements - Jump statements
* `break`
* `continue`
* `goto`
* `return`
* `throw`


+++?code=/Lectures/Lecture01/Assets/code/Break.cs&lang=C#&title=Break Sample
@[7-15]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture01/Assets/code/Break.cs)

+++?code=/Lectures/Lecture01/Assets/code/Continue.cs&lang=C#&title=Continue Sample
@[7-14]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture01/Assets/code/Continue.cs)

+++?code=/Lectures/Lecture01/Assets/code/Goto.cs&lang=C#&title=Goto Sample
@[7-14]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture01/Assets/code/Goto.cs)

+++?code=/Lectures/Lecture01/Assets/code/Return.cs&lang=C#&title=Return Sample
@[5-9]
@[11-16]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture01/Assets/code/Return.cs)

+++?code=/Lectures/Lecture01/Assets/code/Goto.cs&lang=C#&title=Goto Sample
@[7-14]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture01/Assets/code/Goto.cs)

+++?code=/Lectures/Lecture01/Assets/code/Throw.cs&lang=C#&title=Throw Sample
@[7-17]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture01/Assets/code/Throw.cs)

+++
## Statements - Others
* `using`
  * Encapsulated usage of disposable resource
* `lock`
  * For safe access to resource from concurrent context
  * Simplification of Monitor synchronization primitive

+++?code=/Lectures/Lecture01/Assets/code/Using.cs&lang=C#&title=Using Sample
@[7-10]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture01/Assets/code/Using.cs)
  
+++?code=/Lectures/Lecture01/Assets/code/Lock.cs&lang=C#&title=Lock Sample
@[5, 9-13]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture01/Assets/code/Lock.cs)

---
## Namespaces
* Groups classes and interfaces to named groups
* Namespace `System.Security.Cryptography` contains class e.g., RSA
* Usage of types from given namespace

  ```C#
  System.Security.Cryptography.RSA rsa = System.Security.Cryptography.RSA.Create();
  ```
* Directive `using`

  ```C#
  using System.Security.Cryptography;
  public class Namespaces
  {
    public void Method()
    {
      RSA rsa = RSA.Create(); // Don't need fully qualified name
    }
  }
  ```

+++

### Keyword `namespace`

```C#
namespace Outer.Middle.Inner
{
  class Class1 { ... }
  class Class2 { ... }
}
```
 Same as:

```C#
namespace Outer
{  
  namespace Middle
  {
    namespace Inner
    {
      class Class1 { ... }
      class Class2 { ... }
    }
  }
}
```

+++
### Namespaces - Rules
* Names declared in an outer scope are implicitly imported into inner one

```C#
namespace Outer
{
  namespace Middle
  {
    internal class Class1 { ... }
  
    namespace Inner
    {
      internal class Class2 : Class1 { ... }
    }
  }
}
```

+++ 
### Repetition of namespaces
* Namespace name can be repeated until a collision of names of inner types occurs
* The same namespace can be declared in multiple places
  
```C#
namespace Outer.Middle.Inner
{
  class Class1 {}
}
```
```C#
namespace Outer.Middle.Inner
{
  class Class2 { }
}
```

+++
### Inner `using` directives
* `using` can be used in inner namespace to limit its scope
  
```C#
namespace N1
{
  class Class1 { }
}
namespace N2
{
  using N1;
  class Class2 : Class1 { }
}
namespace N2
{
  class Class3 : Class1 { } // Compile-time error
}
```

<!-- git basics? -->
<!-- git flow? -->

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
[C# in depth](http://csharpindepth.com)  
and Google images...