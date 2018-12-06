# .NET Standard, LINQ
## Main .NET libraries, collections, MSSQL, XML
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
* **.NET Standard** is a *specification* that *covers which APIs a .NET platform has to implement*
* **.NET Core** is a concrete .NET *platform* and *implements the .NET Standard*

+++
### .NET Standard versions
* Higher versions *incorporate* all APIs from previous versions
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
### .NET API

---
## References:
[C# 7.0 in a Nutshell: The Definitive Reference](https://www.amazon.com/C-7-0-Nutshell-Definitive-Reference/dp/1491987650)  
[Microsoft documentation](https://docs.microsoft.com)
[.NET Standard web](http://immo.landwerth.net)
[.NET Standard github](https://github.com/dotnet/standard)

## Refences to used images:
[.NET Standard version table](http://immo.landwerth.net/netstandard-versions/)
[Introduction to .NET Standard](https://blogs.msdn.microsoft.com/dotnet/2016/09/26/introducing-net-standard/)