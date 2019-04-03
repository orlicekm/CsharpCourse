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
* Similar to software design pattern but **have a broader scope**
* Choose right architectural pattern is **must decision** in desktop application development

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

+++
### Layered pattern
* For structure programs that can be **decomposed into groups of subtasks**
  * **Each of which is at a particular level of abstraction**
* Layer provides services to the next higher layer
* **Usage:**
  * *General desktop applications*
  * *E commerce web applications*

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
* **MVC pattern** divides an interactive application in to **3 parts**:
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
* Represent the state and behavior of the presentation **independently of the GUI controls** used in the interface
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
* **ViewModel** (*C#*)
![](/Lectures/Lecture09/Assets/img/UsageXAML1.png)

* **View** (*XAML*)
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

+++
## The View
* **Presentation of the data**
* Only thing the end user really interacts with
* Contains *behaviors*, *events* and *data-bindings*
  * Mapped to *properties*, *method calls*, and *commands*
* It is **not responsible for maintaining its state**
  * It will synchronize this with the *ViewModel*
* In *XAML* (in this course)


+++
## The ViewModel 
* **Presentation Separation**
  * *View* separate from the *Model*
  * *ViewModel* acts as the liaison
* **Holds context** of the actual *View*
* **Exposes methods, commands, and other points** that help maintain the state of the *View*
* **Manipulates the Model** as the result of actions on the view, and trigger events in the *View*

---
todo samples to view, model, viewmodel

---
ViewModelLocator
Messanger
IoC/DI containter mby?

---
frameworks
Mvvm light

---
## References:
[C# 7.0 in a Nutshell: The Definitive Reference](https://www.amazon.com/C-7-0-Nutshell-Definitive-Reference/dp/1491987650)  
[Wintellect LLC](https://www.wintellect.com/)  
[Tutorialspoint](https://www.tutorialspoint.com)  
[Sagitec blog](http://www.sagitec.com/blog)  
[Wikipedia](https://en.wikipedia.org/)

+++
## Refences to used images:
[Towards Data Science](https://towardsdatascience.com/)  
[Wintellect LLC](https://www.wintellect.com/)  