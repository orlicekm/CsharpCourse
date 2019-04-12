@snap[north span-100]
# Model–View–ViewModel design pattern
@snapend

@snap[midpoint span-100]
## Applications architectures
@snapend

@snap[south-east span-30]
[ Michal Orlicek <xorlic00@stud.fit.vutbr.cz> ]
@snapend

---
## Architectural pattern
* **General**, **reusable** solution
* **To a commonly occurring problem in software architecture** within a given context
* Similar to software design pattern but **has a broader scope**
* To choose right architectural pattern is **must decision** in desktop application development

+++
### Common Architectural patterns
* *Layered pattern*
* *Client-server pattern*
* *Master-slave pattern*
* *Pipe-filter pattern*
* *Broker pattern*
* *Peer-to-peer pattern*
* *Event-bus pattern*
* *Interpreter pattern*
* *⋮*

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

+++
### Layered pattern
* For structure programs that can be **decomposed into groups of subtasks**
  * **Each of which is at a particular level of abstraction**
* Layer provides services to the next higher layer
* **Usage:**
  * *General desktop applications*
  * *E-commerce web applications*

@snap[east]
![](/Lectures/Lecture09/Assets/img/LayeredPattern.png)
@snapend

+++
### Client-server pattern
* Consists of **server and multiple clients**
* **Server provides services** to multiple clients
* **Clients request services** from the server
* **Usage:**
  * *Online applications*

@snap[east]
![](/Lectures/Lecture09/Assets/img/ClientServerPattern.png)
@snapend

+++
### Master-slave pattern
* Consists of **master and multiple slaves**
* The master 
  * **Distributes the work** among identical slaves
  * **Computes a final result** from the results which the slaves return
* **Usage:**
  * *Database replication*
  * *Peripherals connected to a bus*

![](/Lectures/Lecture09/Assets/img/MasterSlavePattern.png)

+++
### Pipe-filter pattern
* For structure systems which **produce and process a stream of data**
* **Each processing step is enclosed within a filter component**
* Data to be **processed is passed through pipes**
  * Pipes can be **used for buffering or for synchronization purposes**
* **Usage:**
  * *Compilers*
  * *Workflows in bioinformatics*

![](/Lectures/Lecture09/Assets/img/PipeFilterPattern.png)

+++
### Broker pattern
* For structure distributed **systems with decoupled components**
* **Components can interact with each other by remote service invocations**
* **Broker component is responsible for the coordination** of communication among components
* Servers publish their capabilities to a broker
* Clients request a capabilities from the broker
* **Usage:**
  * *Message broker softwares*

@img[span-30](/Lectures/Lecture09/Assets/img/BrokerPattern.png)

+++
### Peer-to-peer pattern
* Individual **components are known as peers**
  * **May act as a client or as a server or as both**
  * It can **change its role dynamically** with time
* **Usage:**
  * *File-sharing networks*
  * *Multimedia protocols*

@snap[east]
![](/Lectures/Lecture09/Assets/img/PeerToPerrPattern.png)
@snapend

+++
### Event-bus pattern
* **Deals with events** and has 4 major components:
  * *Event source*, *event listener*, *channel* and *event bus*
* **Sources publish messages to particular channels** on an event bus
* **Listeners subscribe to particular channels**
* Listeners are notified of messages that are published to a channel to which they have subscribed before
* **Usage:**
  * *Android development*
  * *Notification services*

@img[span-30](/Lectures/Lecture09/Assets/img/EvenmtBusPattern.png)

---
## Pre-MVVM Software Architectural patterns
* *Model-View-Controller*
* *Model-View-Presenter*
* *Presentation Model*

+++
### Model-View-Controller pattern
* Described in the context of Smalltalk at Xerox *in 1979*
* **MVC pattern** divides an interactive application into **3 parts**:
  * **Model** — contains the core functionality and data
  * **View** — displays the information to the user
  * **Controller** — handles the input from the user
* To **separate internal representations** of information
* **Usage:**
  * *Architecture for World Wide Web applications in major programming languages*
  * *Web frameworks*

+++
### Model-View-Controller overview
![](/Lectures/Lecture09/Assets/img/MVCpattern.png)

+++
### Model-View-Presenter pattern
* Introduced *in 1996*
* **MVP pattern** builds on *MVC* but places **special constraints on the controller**
  * **Called the presenter**

+++
### Model-View-Presenter overview
![](/Lectures/Lecture09/Assets/img/MVPpattern.png)

+++
### Presentation Model pattern
* *In 2004*, Martin Fowler published his description of the Presentation Model
* Represents the state and behavior of the presentation **independently of the GUI controls** used in the interface
  * **MVVM is a specialized form of this pattern**

+++
### Presentation Model overview
![](/Lectures/Lecture09/Assets/img/PresentationModelPattern.png)

---
### Model–View–ViewModel
* **Software architectural pattern**
* **MVVM**
  * *Model*
  * *ViewModel*
  * *View*

@snap[east]
@img[span-80](/Lectures/Lecture09/Assets/img/mvvm.png)
@snapend

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

---
### MVVM Benefits
* **Separation of concerns**
  * Designer and developer can work on the project simultaneously
* **Speed and performance enhancements**
* **Testable code**
* **Maintainable code**
* **Easier code extensibility**
* **Reusable components**
* **Flexibility**
  * E.g., changing UI without having refactor other logic

+++
### MVVM Drawbacks
* **Overkill** for simple applications
* **Memory consumption** with data binding in very large applications
* **More lines of code**
  * But it is better arranged

---
### MVVM Usage
* **XAML**
  * *WPF*
  * *UWP*
  * *Xamarin*
  * *Silverlight*
  * *WP*
  * *⋮*
* **Web client**
  * *AngularJS*
  * *knockout.js*
  * *⋮*
* **⋮**

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

+++
### MVVM XAML Usage
* **View** (*XAML*)

@snap[east]
![](/Lectures/Lecture09/Assets/img/UsageXAML1.png)
@snapend

* **ViewModel** (*C#*)

![](/Lectures/Lecture09/Assets/img/UsageXAML2.png)

+++
### MVVM Web Usage
* **ViewModel** (*JavaScript*)

![](/Lectures/Lecture09/Assets/img/UsageWeb1.png)

* **View** (*HTML*)

![](/Lectures/Lecture09/Assets/img/UsageWeb2.png)


---
## The Model
* Represents the **actual data and information**
* **Holds the information, but not behaviors or services** that manipulate the information
  * **Business logic is encapsulated** in other classes that act on the model
  * Not always true
    * E.g., some *Models* may contain validation

+++?code=/Lectures/Lecture09/Assets/sln/School.BL/Models/DetailModels/StudentDetailModel.cs&lang=C#&title=Model Sample
@[6-11]
[Code sample](/Lectures/Lecture10/Assets/sln/School.BL/Models/StudentDetailModel.cs)

+++
## The View
* **Presentation of the data**
* Only thing the end user really interacts with
* Contains *behaviors*, *events* and *data-bindings*
  * Mapped to *properties*, *method calls*, and *commands*
* It is **not responsible for maintaining its state**
  * It will synchronize this with the *ViewModel*
* In *XAML* (in this course)

+++?code=/Lectures/Lecture09/Assets/sln/School.App/Views/StudentView.xaml&lang=XML&title=View Sample
@[1-13]
@[15-19]
@[21-27]
@[36-48]
@[49]
@[51-61]
[Code sample](/Lectures/Lecture10/Assets/sln/School.App/Views/StudentView.xaml)

+++
## The ViewModel 
* **Presentation Separation**
  * *View* separate from the *Model*
  * *ViewModel* acts as the liaison
* **Holds context** of the actual *View*
* **Exposes methods, commands, and other points** that help maintain the state of the *View*
* **Manipulates the Model** as the result of actions on the view, and trigger events in the *View*

+++
### View-ViewModel

![](/Lectures/Lecture09/Assets/img/View-ViewModel.png)

+++?code=/Lectures/Lecture09/Assets/sln/School.App/ViewModels/StudentViewModel.cs&lang=C#&title=ViewModel Sample
@[14-17]
@[19-34]
@[36-39]
@[41-42]
@[44-51]
@[53-58]
@[60-63]
@[65-72]
@[74-78]
@[80-83]
@[85-94]
[Code sample](/Lectures/Lecture10/Assets/sln/School.App/ViewModels/StudentViewModel.cs)

---
## View or ViewModel First
* **The Chicken or the Egg?**
* In general
  * There is *no need to attach multiple ViewModels to a single View*
  * *Single ViewModel might be used by multiple Views*
    * E.g., a wizard, that has three Views but all bind to the same ViewModel that drives the process

+++
### View First
* **View** is what **drives the creation** or discovery of the view model
* Very **common method** for managing *Views* and *ViewModels*
* In this scenario *View*:
  * Typically binds to the *ViewModel* as a resource
  * Uses a locator pattern, or has the *ViewModel* injected via e.g. MEF

+++
### ViewModel First
* **ViewModel is responsible for creating** the *View* and binding itself to the *View*

---
## View Model Locator
* Desides **which ViewModel will be used for the View**
  * Often return other *ViewModel* implementation in design time
* Controls life cycle of viewmodel

+++
### View Model Locator Sample 1/4
![](/Lectures/Lecture09/Assets/img/ViewModelLocator.png)

+++?code=/Lectures/Lecture09/Assets/sln/School.App/ViewModelLocator.cs&lang=C#&title=View Model Locator Sample 2/4
@[10-11]
@[12-14]
@[16-17, 26]
@[18-20]
@[22-25]
@[16-26]
@[28-30]
@[32-45]
[Code sample](/Lectures/Lecture10/Assets/sln/School.App/ViewModelLocator.cs)

+++?code=/Lectures/Lecture09/Assets/sln/School.App/Views/StudentView.xaml&lang=XML&title=View Model Locator Sample 3/4
@[11-12]
[Code sample](/Lectures/Lecture10/Assets/sln/School.App/Views/StudentView.xaml)

+++?code=/Lectures/Lecture09/Assets/sln/School.App/App.xaml&lang=XML&title=View Model Locator Sample 4/4
@[18]
[Code sample](/Lectures/Lecture10/Assets/sln/School.App/App.xaml)

---
### ViewModels Bad Communication
![](/Lectures/Lecture09/Assets/img/MessengerBad.png)

+++
### ViewModels Good Communication
![](/Lectures/Lecture09/Assets/img/MessengerGood.png)

+++
## Messanger
* **Mediator design pattern**F
* **Communication bettween viewmodels**
* Implementatin:

![](/Lectures/Lecture09/Assets/img/MessengerImplemetation.png)

+++?code=/Lectures/Lecture09/Assets/sln/School.App/IMessenger.cs&lang=C#&title=IMessenger Implementation
@[5-6, 10]
@[7]
@[8]
@[9]
@[5-10]
[Code sample](/Lectures/Lecture10/Assets/sln/School.App/IMessenger.cs)

+++?code=/Lectures/Lecture09/Assets/sln/School.App/Messenger.cs&lang=C#&title=Messenger Implementation
@[7-8]
@[9]
@[11-12]
@[14-15, 28]
@[16]
@[18-19, 27]
@[20-21, 24]
@[22]
@[23]
@[26]
@[14-28]
@[30-31, 35]
@[32]
@[33]
@[34]
@[30-35]
@[37-38, 48]
@[41-43, 47]
@[44]
@[45]
@[39, 46]
@[37-48]
[Code sample](/Lectures/Lecture10/Assets/sln/School.App/Messenger.cs)

+++?code=/Lectures/Lecture09/Assets/sln/School.App/ViewModels/StudentViewModel.cs&lang=C#&title=Messenger Sample 1/3
@[53-58]
@[57]
[Code sample](/Lectures/Lecture10/Assets/sln/School.App/ViewModels/StudentViewModel.cs)

+++?code=/Lectures/Lecture09/Assets/sln/School.App/Messages/SelectStudentMessage.cs&lang=C#&title=Messenger Sample 2/3
@[5-6, 13]
@[7-12]
[Code sample](/Lectures/Lecture10/Assets/sln/School.App/Messages/SelectStudentMessage.cs)

+++?code=/Lectures/Lecture09/Assets/sln/School.App/ViewModels/AddressViewModel.cs&lang=C#&title=Messenger Sample 3/3
@[20, 23, 30]
@[28]
@[66-70]
[Code sample](/Lectures/Lecture10/Assets/sln/School.App/ViewModels/AddressViewModel.cs)

+++
### Messenger Recapitulation
![](/Lectures/Lecture09/Assets/img/MVVMLightMessenger.png)

---
## IoC Terms

![](/Lectures/Lecture09/Assets/img/IOCprinciples-and-patterns.png)

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

+++
### Inversion of Control
* **Design principle**
* Recommends *inversion of different kinds of controls* in object oriented design
  * Control means any additional responsibilities
* To achieve loose coupling between the application classes

+++
### Dependency Inversion
* **Principle**
* Suggests that *high-level modules should not depend on low level modules*
  * **Both should depend on abstraction**
* Helps in achieving loose coupling between the classes
* It is recommended to use DIP and IoC together

+++
### Dependency Injection
* **Design pattern** which **implements IoC principle**
* To invert the creation of dependent objects

+++
### IoC Container
* **Framework**
* *Manage automatic dependency injection* throughout the application
  * Developers do not need to put more time and effort on it

+++
### Tightly Coupled Classes to Losely ones
* Loosely coupled classes cannot be achieved only by using IoC
  * Along with IoC also needs to used DIP, DI and IoC container

![](/Lectures/Lecture09/Assets/img/ioc-steps.png)


+++
### Container Support
* All the containers must provide easy support for the following
* **Register**
  * Container must know which dependency to instantiate when it encounters a particular type
  * Basically, it must include some way to register type-mapping
* **Resolve**
  * Container creates objects for developer, he does not create them manually
  * Container must include some methods to resolve the specified type
  * Container creates an object of specified type, injects required dependencies if any and returns it
* **Dispose**
  * Container must manage the lifetime of dependent objects
  * Most IoC containers include different lifetimemanagers to manage an object's lifecycle and dispose it

+++
### Containers
* There are many open source or commercial containers available
  * [Dependency injection in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-2.2)
  * [*Castle Windsor*](http://www.castleproject.org/)
  * [*Unity*](https://github.com/unitycontainer/unity)
  * [*StructureMap*](http://structuremap.github.io/)
  * [*Ninject*](http://www.ninject.org/)
  * ⋮

---
## MVVM Light
* Light but useful set of features
  * Simple IoC
  * ViewModelBase
  * RelayCommand
  * Messenger
  * ObservableObject

+++
### MVVM Light Sample projects
* `Lecture09` solution
* Without MVVM Light Framework
  * `School.App`
  * `School.BL`
* With MVVM Light Framework
  * `School.FrameworkApp`
  * `School.FrameworkBL`

+++?code=/Lectures/Lecture09/Assets/sln/School.FrameworkApp/ViewModelLocator.cs&lang=C#&title=MVVM Light Simple IoC
@[14-15]
@[16]
@[21-23]
@[26-28]
@[18-19]
@[30-42]
[Code sample](/Lectures/Lecture10/Assets/sln/School.FrameworkApp/ViewModelLocator.cs)

+++?code=/Lectures/Lecture09/Assets/sln/School.FrameworkApp/ViewModels/AddressViewModel.cs&lang=C#&title=MVVM Light ViewModelBase
@[16]
@[36-44]
@[42]
[Code sample](/Lectures/Lecture10/Assets/sln/School.FrameworkApp/ViewModels/AddressViewModel.cs)

+++?code=/Lectures/Lecture09/Assets/sln/School.FrameworkApp/ViewModels/StudentViewModel.cs&lang=C#&title=MVVM Light RelayCommand 1/2
@[23]
@[32]
@[62-66]
@[29-31]
@[84-93]
[Code sample](/Lectures/Lecture10/Assets/sln/School.FrameworkApp/ViewModels/StudentViewModel.cs)

+++?code=/Lectures/Lecture09/Assets/sln/School.FrameworkApp/ViewModels/AddressViewModel.cs&lang=C#&title=MVVM Light RelayCommand 2/2
@[16]
@[31]
@[56-66]
[Code sample](/Lectures/Lecture10/Assets/sln/School.FrameworkApp/ViewModels/AddressViewModel.cs)


+++?code=/Lectures/Lecture09/Assets/sln/School.FrameworkApp/ViewModels/StudentViewModel.cs&lang=C#&title=MVVM Light Messenger 1/2
@[23]
@[84-93]
@[925]
[Code sample](/Lectures/Lecture10/Assets/sln/School.FrameworkApp/ViewModels/StudentViewModel.cs)

+++?code=/Lectures/Lecture09/Assets/sln/School.FrameworkApp/ViewModels/AddressViewModel.cs&lang=C#&title=MVVM Light Messenger 2/2
@[16]
@[30]
@[68-72]
[Code sample](/Lectures/Lecture10/Assets/sln/School.FrameworkApp/ViewModels/AddressViewModel.cs)

+++?code=/Lectures/Lecture09/Assets/sln/School.FrameworkBL/Models/Base/ModelBase.cs&lang=C#&title=MVVM Light ObservableObject 1/2
@[6-9]
@[6]
[Code sample](/Lectures/Lecture10/Assets/sln/School.FrameworkBL/Models/Base/ModelBase.cs)

+++?code=/Lectures/Lecture09/Assets/sln/School.FrameworkBL/Models/DetailModels/StudentListModel.cs&lang=C#&title=MVVM Light ObservableObject 2/2
@[5-14]
@[7]
@[9-13]
@[12]
[Code sample](/Lectures/Lecture10/Assets/sln/School.FrameworkBL/Models/DetailModels/StudentListModel.cs)

+++
### Other MVVM Frameworks
* *Prism*
* *Catel*
* *ReactiveUI*
* *Caliburn.Micro*
* ⋮

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

+++
### Prism
* [GitHub](https://github.com/PrismLibrary/Prism)
* Commands
* Event aggregation
* Region management
* ⋮

+++
### Catel
* [GitHub](https://github.com/Catel/Catel)
* Automatic implementation INPC
  * Reflection
* Convertors
* Services
* Binding
* R# Support
* ⋮

+++
### ReactiveUI
* [GitHub](https://github.com/reactiveui/reactiveui)
* ReactiveObject
* MessageBus
* Binding
* Service locator
* ⋮

+++ 
### Caliburn.Micro
* [GitHub](https://github.com/Caliburn-Micro/Caliburn.Micro)
* Viewmodel-first framework 
* More than just MVVM
  * Full application framework


---
## References:
[C# 7.0 in a Nutshell: The Definitive Reference](https://www.amazon.com/C-7-0-Nutshell-Definitive-Reference/dp/1491987650)  
[TutorialsTeacher.com](https://www.tutorialsteacher.com/)  
[Wintellect LLC](https://www.wintellect.com/)  
[Tutorialspoint](https://www.tutorialspoint.com)  
[Sagitec blog](http://www.sagitec.com/blog)  
[Wikipedia](https://en.wikipedia.org/)

+++
## Refences to used images:
[TutorialsTeacher.com](https://www.tutorialsteacher.com/)  
[Towards Data Science](https://towardsdatascience.com/)  
[Wintellect LLC](https://www.wintellect.com/)  
[DotNetPattern.com](http://dotnetpattern.com)  