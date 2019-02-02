# .NET Standard and Language Integrated Query(LINQ)
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
* Produce **portable libraries** that are *usable across .NET implementations*, using same set of APIs
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
## Data types
* `class Object` - ultimate base class of all classes in the .NET
* `class String` - represents a String
* `class Array` -  represents an Array
* `class Delegate` - represents a delegate
* `class Enum` - base class for enumerations
* `class Tuple` - provides methods for creating tuple objects

+++
## Sctruct types
* `struct Boolean`
* `struct Byte`, `struct SByte`
* `struct Char`
* `struct DateTime`
* `struct Decimal`, `struct Double`
* `struct Guid`
* `struct Int16`, `struct Int32`, `struct Int64`, `struct IntPtr`
* `struct UInt16`, `struct UInt32`, `struct UInt64`, `struct UIntPtr`
* `struct Nullable<T>`
* `struct void`


+++
## Type
* `class Type`
* Represents type declarations
  * class types
  * interface types
  * array types
  * value types
  * enumeration types
  * type parameters
  * generic type definitions

```C#
Type type = typeof(String);

MethodInfo methodInfo = 
type.GetMethod("Substring", new Type[] { typeof(int), typeof(int) });

Object result = methodInfo.Invoke("Hello, World!", new Object[] { 7, 5 });
Console.WriteLine("{0} returned \"{1}\".", methodInfo, result);
```

+++
## ValueType
* `class ValueType`
* Provides the base class for value types

```C#
public static bool IsFloat(ValueType value) 
{
    return (value is float | value is double | value is Decimal);
}
```

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
@[12,17]
@[13,18]
@[14,19]
@[15,20]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture03/Assets/sln/Tests/Convert.cs)

+++
## Bit Converter
* `class BitConverter` 
* **Converts:**
  * *Base data types* to an *array of bytes*
    * `GetBytes(Boolean)`, `GetBytes(Int32)` `GetBytes(Char)`...
  * *Array of bytes* to *base data types*
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
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture03/Assets/sln/Tests/BitConverterTest.cs)

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
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture03/Assets/sln/Tests/UriTest.cs)

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
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture03/Assets/sln/Examples/ConsoleSample.cs)

+++
## GC
* `class GC`
* Controls garbage collector
  * Service that automatically reclaims unused memory

```C#
void MakeSomeGarbage()
{
    for(int i = 0; i < 1000; i++)
    {
        var o = new Object();
    }
}

MakeSomeGarbage();
GC.Collect();
```

+++
## Math
* `class Math`
* Provides constants and static methods for
  * Trigonometric mathematical functions
  * Logarithmic mathematical functions
  * Other common mathematical functions

```C#
double circleRadius = 4.2;
double circlePerimeter = ((2 * Math.PI) * circleRadius);
double circleArea = Math.PI * (Math.Pow(circleRadius, 2));
```

+++
## Random
* `class Random`
* Represents a pseudo-random number generator
* Device that produces a sequence of numbers that meet certain statistical requirements for randomness

```C#
Random random = new Random();
for (var i = 1; i <= 10; i++)
    Console.WriteLine("{0,15:N0}", random.Next());
// The example output
//         1,733,189,596
//           566,518,090
//         1,166,108,546
//         1,931,426,514
//         1,341,108,291
//         1,012,698,049
//           890,578,409
//         1,377,589,722
//         2,108,384,181
//         1,532,939,448
```

+++
## Version
* `class Version`
* Represents the version number of 
  * Assembly
  * Operating system
  * Common language runtime

```C#
// Get the operating system version.
OperatingSystem operatingSystem = Environment.OSVersion;
Version version = operatingSystem.Version;
Console.WriteLine("Operating System: {0} ({1})", operatingSystem.VersionString, version.ToString());
```

```C#
// Get the common language runtime version.
Version version = Environment.Version;
Console.WriteLine("CLR Version {0}", version.ToString());
```

+++
## Another important classes
* `class Buffer` - Manipulates arrays of primitive types
* `class Environment` - Information about the current environment and platform
* `class Lazy<T>` - Support for lazy initializatio
* `class StringComparer` - Represents a string comparison operation
* `class Attribute` - Represents the base class for custom attributes
* `class SerializableAttribute` - Indicates that a class can be serialized
* `class Nullable` - supports a value type that can be assigned null e.g. `int?`
* `class WeakReference` - references an object while still allowing that object to be reclaimed by GC

+++
### `System` Namespace Exceptions
* 50+ basic exceptions
* `Exception` - base class for all exceptions
* `SystemException` - base class for system exceptions

+++
## Delegates
Action
Func<TResult>
Comparison<T>
AsyncCallback
EventHandler
EventHandler<TEventArgs>


---
System Collections


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