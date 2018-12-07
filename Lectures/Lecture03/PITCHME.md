# .NET Standard, LINQ
## .NET Standard libraries, collections, MSSQL, XML
<div class="right">
[ Michal Orlicek <xorlic00@stud.fit.vutbr.cz> ]
</div>

---
## .NET Standard
* Formal specification of .NET APIs 
* Intended to be available on all .NET implementations
* Establishing greater uniformity in the .NET ecosystem
* [.NET Standard github](https://github.com/dotnet/standard)
* [Introduction to .NET Standard](https://blogs.msdn.microsoft.com/dotnet/2016/09/26/introducing-net-standard/)

+++
### .NET Standard enables
* Uniform **set of APIs** for all .NET implementations to implement, independent of workload
* Produce **portable libraries** that are *usable across .NET implementations*, using this same set of APIs
* **Reduces conditional compilation** of *shared source* due to .NET APIs

+++
#### .NET Today

<div class="center" >
<img src="/Lectures/Lecture03/Assets/img/NetToday.png" />
</br>
</div>

+++
#### .NET Tomorrow

<div class="center" >
<img src="/Lectures/Lecture03/Assets/img/NetTomorrow.png" />
</br>
</div>

+++
### .NET Standard vs .NET Core
* **.NET Standard**
  * *specification* that *covers which APIs a .NET platform has to implement*
* **.NET Core**
  * **concrete .NET platform**
  * *implements the .NET Standard*

+++
### .NET Standard versions
* Higher versions **incorporate** all APIs from previous versions
* Once shipped, versions are frozen
* Specific .NET platform to .NET Standard
  * .NET Standard version depends on which version of .NET Standard the platform is implementing
* .NET Standard version choise
  * The higher the version, the more APIs are available to you
  * The lower the version, the more platforms you can run on

+++
#### .NET Standard Version Table

<div class="center" >
<img src="/Lectures/Lecture03/Assets/img/NetStandardVersionTable.png" />
</br>
</div>

+++
### Why .NET Standard 2.0 instead of 1.7?
* More than doubled the API surface
  * Added a compat shim that allows referencing existing binaries
    * Even if they weren't built against *.NET Standard*

+++
### .NET Standard Version Growing

| Version |  #APIs | Growth % |
|:--------|-------:|---------:|
| 1.0     |  7,949 |          |
| 1.1     | 10,239 |     +29% |
| 1.2     | 10,285 |      +0% |
| 1.3     | 13,122 |     +28% |
| 1.4     | 13,140 |      +0% |
| 1.5     | 13,355 |      +2% |
| 1.6     | 13,501 |      +1% |
| 2.0     | 32,638 |    +142% |

+++
### .NET API
* [.NET Standard API](https://docs.microsoft.com/sk-sk/dotnet/api/?view=netstandard-2.0)
* API(Application programming interface):
  * Set of namespaces(classes, structs, interfaces, enums, delegates)
  * Allow the creation of applications which access the features or data of an:
    * Operating system
    * Application
    * Other service..

---
## `System` Namespace
* `using System;`
* [Documentation](https://docs.microsoft.com/sk-sk/dotnet/api/system?view=netstandard-2.0)
* Fundamental classes and base classes
* Define:
  * Commonly-used value and reference data types
  * Events and event handlers
  * Interfaces
  * Attributes
  * Processing exceptions

+++
## URI
* Uniform Resource Identifier
  * String that identifies a particular resource
  * Predefined set of syntax rules

<div class="center" >
<img src="/Lectures/Lecture03/Assets/img/UriSyntax.png" />
</br>
</div>

+++
### URI examples

```URI
          userinfo     host        port
          ┌─┴────┐ ┌────┴────────┐ ┌┴┐ 
  https://john.doe@www.example.com:123/forum/questions/?tag=networking#top
  └─┬─┘ └───────┬────────────────────┘└─┬─────────────┘└──┬──────────┘└┬─┘
  scheme     authority                 path              query     fragment

  ldap://[2001:db8::7]/c=GB?objectClass?one
  └─┬┘ └───────┬─────┘└─┬─┘ └──────┬──────┘
 scheme    authority  path       query

  mailto:John.Doe@example.com
  └──┬─┘ └─────────┬────────┘
  scheme         path

  tel:+1-816-555-1212
  └┬┘ └──────┬──────┘
scheme     path

  telnet://192.0.2.16:80/
  └──┬─┘ └──────┬──────┘│
  scheme    authority  path
```

+++ 
### URI Standard
* `class Uri`- representation of URI
* `UriBuilder` - custom URI constructors
* Another classes:
  * `UriFormatException`, `UriTypeConverter`, `FtpStyleUriParser`, `HttpStyleUriParser`...
* Enums:
  * `UriComponents`, `UriFormat`, `UriHostNameType`...

```C#
var uri = new Uri("http://www.contoso.com/");
WebRequest webRequest = WebRequest.Create(uri);
```

+++?code=/Lectures/Lecture03/Assets/sln/Tests/UriTest.cs&lang=C#&title=Uri Sample
@[9-15]
@[11,12]
@[14]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture02/Assets/sln/Tests/UriTest.cs)

+++
## Console
* `class Console` - standard input, output, and error streams for console applications
* Struct:
  * `ConsoleKeyInfo`
* Enums:
  * `ConsoleKey`, `ConsoleSpecialKey`, `ConsoleSpecialKey`...

```C#
Console.WriteLine("Prints on ");
Console.WriteLine("New line");

Console.Write("Prints on ");
Console.Write("Same line");

Console.ReadLine();
```

+++?code=/Lectures/Lecture03/Assets/sln/Examples/ConsoleSample.cs&lang=C#&title=Console Sample
@[7-20]
@[9]
@[11-12,19]
@[13]
@[15-16]
@[18]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture02/Assets/sln/Examples/ConsoleSample.cs)

+++
## Array
* `class Array`
* Methods for creating, manipulating, searching, and sorting array
* Base class for all arrays in the *common language runtime*
* Is not part of the `System.Collections`
  * It is still considered a collection because it is based on the `IList` interface

```C#
// Creates and initializes a new three-dimensional Array of type Int32.
Array myArr = Array.CreateInstance( typeof(Int32), 2, 3, 4 );
for ( int i = myArr.GetLowerBound(0); i <= myArr.GetUpperBound(0); i++ )
  for ( int j = myArr.GetLowerBound(1); j <= myArr.GetUpperBound(1); j++ )
    for ( int k = myArr.GetLowerBound(2); k <= myArr.GetUpperBound(2); k++ )
      myArr.SetValue( (i*100)+(j*10)+k, i, j, k );
```

+++?code=/Lectures/Lecture03/Assets/sln/Tests/ArrayTest.cs&lang=C#&title=Array Sample
@[9-25]
@[11-19]
@[21]
@[22]
@[24]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture02/Assets/sln/Tests/ArrayTest.cs)

+++
## Bit Converter
* `class Array`
* **Converts:**
  * *Base data types* to an *array of bytes**
    * `GetBytes(Boolean)`, `GetBytes(Int32)` `GetBytes(Char)`...
  * *Array of bytes* to *base data types**
    * `ToBoolean(Byte[], Int32)`, `ToInt32(Byte[], Int32)`, `ToChar(Byte[], Int32)`...

```C#
bool sample = true;
byte[] sampleByteArray = BitConverter.ToString(BitConverter.GetBytes(sample);
Console.WriteLine(BitConverter.ToString(sampleByteArray)); //01
```

+++?code=/Lectures/Lecture03/Assets/sln/Tests/BitConverterTest.cs&lang=C#&title=Bit Converter Sample
@[9-16]
@[11]
@[12]
@[13]
@[15]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture02/Assets/sln/Tests/BitConverterTest.cs)

+++
## Convert
* `class Convert`
* Converts a base data type to another base data type

```C#
try {
  int intNumber = System.Convert.ToInt32(fooNumber);
}
catch (System.OverflowException) {
  System.Console.WriteLine(
    "Overflow in double to int conversion.");
}
```

+++?code=/Lectures/Lecture03/Assets/sln/Tests/ConvertTest.cs&lang=C#&title=Convert Sample
@[9-21]
@[12-17]
@[13-18]
@[14-19]
@[15-20]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture02/Assets/sln/Tests/Convert.cs)

+++
## Delegate


+++ 
## Enum

+++
## GC

+++
## Math

+++
## Nullable

+++
## Object

+++
## Random

+++
## SerializableAttribute

+++
## String

+++
## Tuples

+++
## Type

+++
## ValueType

+++
## Version

...
STRUCTS

+++
## Another important classes
* Buffer


+++
### `System` Namespace Exceptions
* 50+ basic exceptions
* `Exception` - base class for all exceptions
* `SystemException` - base class for system exceptions



++++
  * `AggregateException` - errors that occur during application execution
  * `ApplicationException` - base class for application-defined exceptions
  * `SystemException` - base class for system exceptions
    * `AccessViolationException` - when there is an attempt to read or write protected memory 
    * `AppDomainUnloadedException` - when an attempt is made to access an unloaded application domain
    * `ArgumentException` - thrown when one of the arguments provided to a method is not valid
    * `ArgumentNullException` - thrown when a `null` reference is passed to a method that does not accept it
    * `ArgumentOutOfRangeException` - thrown when the value of an argument is outside the allowable range
    * `ArithmeticException` - thrown for errors in an arithmetic, casting, or conversion operation
    * `ArrayTypeMismatchException` - thrown when an attempt is made to store an element of the wrong type within an array
    * `BadImageFormatException` - thrown when the file image of a dynamic link library (DLL) or an executable program is invalid
    * `CannotUnloadAppDomainException` - thrown when an attempt to unload an application domain fails

+++
### System Namespace classes
| Class |  Description |
|---------|--------|
| AppDomain | Application domain (isolated environment where applications execute) |
| ApplicationException |  base class for application-defined exceptions |
| SystemException | serves as the base class for system exceptions namespace |



---
## References:
[C# 7.0 in a Nutshell: The Definitive Reference](https://www.amazon.com/C-7-0-Nutshell-Definitive-Reference/dp/1491987650)  
[Microsoft documentation](https://docs.microsoft.com)
[Microsoft documentation github](https://github.com/MicrosoftDocs)
[.NET Standard web](http://immo.landwerth.net)
[.NET Standard github](https://github.com/dotnet/standard)
[ Wikipedia](https://en.wikipedia.org)

+++
## Refences to used images:
[.NET Standard version table](http://immo.landwerth.net/netstandard-versions/)
[Introduction to .NET Standard](https://blogs.msdn.microsoft.com/dotnet/2016/09/26/introducing-net-standard/)