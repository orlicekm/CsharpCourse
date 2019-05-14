@snap[north span-100]
# Multiplatform development, .NET Core, application containerization
@snapend

@snap[midpoint span-100]
## Docker, Kubernetes
@snapend

@snap[south-east span-30]
[ Michal Orlicek <xorlic00@stud.fit.vutbr.cz> ]
@snapend

---
## .NET Multiplatform History
* *2004* **Mono**
  * Independent framework on Linux
  * Focus on mobile developmen
* *2007* **SilverLight**
  * Browser plugin
  * No longer supported
* *2011* **Portable class library (PCL)**
  * Deprecated
  * Needs to recompile
* *2016* **.NET Core**
  * Focus on Cloud and web development0
* *2017* **.NET Standard**

---
## .NET Standard
* Open source
* Versioned common **Set of base class libraries API**
* Replacement for Portable class libraries
* Eliminates condition compisation and recompile library
* More to .NET Standard was in **3rd lecture**

+++
### .NET Standard support
* *.NET Framework*
* *.NET Core*
* *Xamarin*
* *Mono*
* *Universal Windows Platform*

---
## .NET Core
* **Cross platform **
  * Multiple OS supported
* **Portable**
  * Side by side deployment
* **Open source**
  * Managed by Microsoft
  * [.NET Core Github](https://github.com/dotnet/core)
  * [.NET Core Libraries GitHub](https://github.com/dotnet/corefx)
* Consistent across architectures 
  * The same behavior (x86, x64, Arm)
* Composition
  * Reference only whats necessary
* Command-line tools


+++
### .NET Core Platfoms Support
* OS (for .NET Core 2.1)
  * **Windows** 7 SP1+ (server 2008 R2)
  * **MacOS** 10.12+
  * **Linux** (Ubuntu 14.04, Fedora, Redhat, Debian, OpenSuse)
* Only Vendror supported versions
  * Each new version shifts supported OS versions

+++
### .NET Core CLI Tools
* Cross platform toolchain for developing .NET Applications
* [Target Frameworks](https://docs.microsoft.com/en-us/dotnet/standard/frameworks)

```C#
dotnet new -help
dotnet new -l
dotnet new console -lang C#
dotnet run --project ./testapp.csproj
dotnet testapp.dll
dotnet publish -c Release -r win10-x64
```


---
### Multiplatform User Interfaces
* **Xamarin**
  * Mobile and desktop platforms
  * *iPhone*, *Android*, *Windows*
* **Mono**
  * The only Windows Forms Linux implementation
  * More platforms than .Net Core
  * Subset of APIs
* **HTML based UI**
  * Completely independedn UI
  * (ofen used with JavaScript)

---
### Porting to Cross platform
* **Portability Analyser**
  * *Console Application*
  * *Visual Studio extension*
* **Reports API compatibility**

---
### Multitargeting
* Define multiple frameworks for backward compatibility

```XML
<PropertyGroup>
    <TargetFramework>netcoreapp2.0</TargetFramework>
</PropertyGroup>

<PropertyGroup>
    <TargetFrameworks>netcoreapp2.0;net461</TargetFrameworks>
</PropertyGroup>
```

+++
## IDE
* Microsoft Visual Studio
* Microsoft Visual Studio Code
* Microsoft Visual Studio for Mac (Xamarin Studio)
* JetBrains Rider
* ⋮

+++
## .NET Multiplatform Tips
* Use *.NET Standard* project only
* Use Xamarin or HTML based UI
* Do not port old WPF or Windows Forms applications


---
## Containerization
* Containers provide a **lightweight way to isolate the application** from the rest of the host system
* Sharing just the kernel
* Using resources given to your application
* **.NET Core**

+++
## Docker
* [Docs](https://docs.docker.com/)
* Open platform for **developing**, **shipping**, and **running** applications
* **Separate applications from infrastructure** so software can be delivered quickly

+++
### Image
* **Ordered collection of filesystem changes** 
* Form the basis of a container
* Doesn't have a state
* Read-only
* Can be based on another image

+++ 
### Container
* **Runnable instance of an image**
* Multiple containers can be instantiated
  * Isolated from one another
* Each container instance has its own filesystem, memory, and network interface

+++
### Registries
* **Collection of image repositories**

![](/Lectures/Lecture13/Assets/img/TaxaonomyInDocker.png)

+++
### Dockerfile
* **File that defines a set of instructions that creates an image**
* Each instruction in the Dockerfile creates a layer in the image
  * When you rebuild the image only the layers that have changed are rebuilt
* Allows to distribute the instructions on how to create the image

+++
### Containerize .NET Core Prerequisites
* *.NET Core SDK* (2.2) - [link](https://dotnet.microsoft.com/download)
* *Docker Community Edition* - [link](https://www.docker.com/products/docker-desktop)
* Temporary working directory for the Dockerfile and .NET Core example app

---
## References:
[Docker Docs](https://docs.docker.com/)
[Microsoft Docs - Introduction to .NET and Docker](https://docs.microsoft.com/en-us/dotnet/core/docker/intro-net-docker)
[C# 7.0 in a Nutshell: The Definitive Reference](https://www.amazon.com/C-7-0-Nutshell-Definitive-Reference/dp/1491987650)  
