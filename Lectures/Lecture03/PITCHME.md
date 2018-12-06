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
* [.NET Sstandard API](https://docs.microsoft.com/sk-sk/dotnet/api/?view=netstandard-2.0)
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
### URI
* Uniform Resource Identifier
  * string that identifies a particular resource
  * predefined set of syntax rules

<div class="center" >
<img src="/Lectures/Lecture03/Assets/img/UriSyntax.png" />
</br>
</div>

+++
### URI examples

```URI
          userinfo     host        port
          ┌─┴────┐ ┌────┴────────┐ ┌┴┐ 
  https://john.doe@www.example.com:123/forum/questions/?tag=networking&order=newest#top
  └─┬─┘ └───────┬────────────────────┘└─┬─────────────┘└──┬───────────────────────┘└┬─┘  
  scheme     authority                 path              query                      fragment

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
### URI in .NET Standard
* `Uri`- object representation of URI
* `UriBuilder` - custom URI constructors
* Another classes:
  * `UriFormatException`, `UriTypeConverter`, `FtpStyleUriParser`, `HttpStyleUriParser`...
* Enums:
  * `UriComponents`, `UriFormat`, `UriHostNameType`...

```C#
Uri siteUri = new Uri("http://www.contoso.com/");
WebRequest wr = WebRequest.Create(siteUri);
```

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