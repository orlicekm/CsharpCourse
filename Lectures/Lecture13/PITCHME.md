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
## IDEs
* Microsoft Visual Studio
* Microsoft Visual Studio Code
* Microsoft Visual Studio for Mac (Xamarin Studio, Monodevelop)
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
* *.NET Core SDK 2.2* - [link](https://dotnet.microsoft.com/download)
* *Docker Community Edition* - [link](https://www.docker.com/products/docker-desktop)
* Temporary working directory for the Dockerfile and .NET Core example app

---
## Docker Containerization Sample
1. Create simple .NET Core 2.2 Application

+++?code=/Lectures/Lecture13/Assets/sln/ContainerizationSample/Program.cs&lang=C#&title=Sample App
@[7-8, 17]
@[9]
@[10]
@[11-12, 16]
@[13-14]
@[15]
[Code sample](/Lectures/Lecture11/Assets/sln/ContainerizationSample/Program.cs)  
This app runs indefinitely!

+++
### Open Solution Folder in Commandline
1. Try `dotnet run`
   * Use the cancel command `CTRL + C` to stop it
2. Publish .NET Core app
   * Erite `dotnet publish -c Release`
   * Compiles app to the publish folder in the output folder
     * `\ContainerizationSample\bin\Release\netcoreapp2.2\publish\`

+++
### Create the Dockerfile
1. Create plaintext file named `Dockerfile` in working directory (without extension)
2. Write this text to the file
  ```C#
  FROM mcr.microsoft.com/dotnet/core/runtime:2.2
  
  COPY ContainerizationSample/bin/Release/netcoreapp2.2/publish/ ContainerizationSample/
  
  ENTRYPOINT ["dotnet", "ContainerizationSample/ContainerizationSample.dll"]
  ```
3. Save the file

+++?code=/Lectures/Lecture13/Assets/sln/Dockerfile&title=Dockerfile

* `FROM` command tells Docker to **pull down the image tagged 2.2** from the mcr.microsoft.com/dotnet/core/runtime repository
* `COPY` command tells Docker to **copy the specified folder to a folder in the container**
* `ENTRYPOINT` command tells Docker to **configure the container to run as an executable**

+++
### Build Image
1. Run `docker build -t myimage .`
2. Run `docker images`

```
>docker build -t myimage .
Sending build context to Docker daemon  3.551MB
Step 1/3 : FROM mcr.microsoft.com/dotnet/core/runtime:2.2
 ---> e4ab7c996edf
Step 2/3 : COPY ContainerizationSample/bin/Release/netcoreapp2.2/publish/ ContainerizationSample/
 ---> 3359c63a3d14
Step 3/3 : ENTRYPOINT ["dotnet", "ContainerizationSample/myapp.dll"]
 ---> Running in 89f6c998c871
Removing intermediate container 89f6c998c871
 ---> 0b02def176f4
Successfully built 0b02def176f4
Successfully tagged myimage:latest

>docker images
REPOSITORY                              TAG                 IMAGE ID            CREATED             SIZE
myimage                                 latest              0b02def176f4        17 seconds ago      181MB
mcr.microsoft.com/dotnet/core/runtime   2.2                 e4ab7c996edf        2 days ago          181MB
```

+++
### Create Container
1. Create new container that is stopped
  * `docker create myimage` or `docker create --name="mycontainer" myimage`
  * First option creates container with random name
2. To see list of all containers
   * `docker ps -a`

```
CONTAINER ID        IMAGE               COMMAND                  CREATED             STATUS              PORTS               NAMES
4509a1eb7686        myimage             "dotnet Containeriza…"   11 seconds ago      Created                                 mycontainer
```

+++
### Work with Container
1. `docker start mycontainer` to start container
2. `docker ps` shows containers that are running


 ```
 CONTAINER ID        IMAGE               COMMAND                  CREATED             STATUS              PORTS               NAMES
 965797f01ea0        myimage             "dotnet Containeriza…"   12 seconds ago      Up 3 seconds                            mycontainer
 ```

3. `docker attach mycontainer` peek at the output stream
  * `CTRL + C` is used to detach from container
  * `--sig-proxy=false` parameter ensures that `CTRL + C` will not stop the process in the container
  * You can try to reattach to verify that it's still running
4. `docker stop` deletes a container

+++
### Single Run
* `docker run -it --rm myimage`
  * Eliminates the need to run docker create and then docker start
  * Automatically delete the container when the container stops
  * Automatically use the current terminal to connect to the container
   

---
## Docker and Orchestrator support in Visual Studio
* Can be enabled during project creation
* To an existing project by selecting
  * `Add > Docker Support in Solution Explorer`
  * `Add > Container Orchestrator Support`

+++
![](/Lectures/Lecture13/Assets/img/Docker.png)

+++
![](/Lectures/Lecture13/Assets/img/Docker2.png)

---
## References:
[Docker Docs](https://docs.docker.com/)  
[Microsoft Docs - Introduction to .NET and Docker](https://docs.microsoft.com/en-us/dotnet/core/docker/intro-net-docker)  
[C# 7.0 in a Nutshell: The Definitive Reference](https://www.amazon.com/C-7-0-Nutshell-Definitive-Reference/dp/1491987650)  
