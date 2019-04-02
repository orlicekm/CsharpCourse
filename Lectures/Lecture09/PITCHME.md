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
## Architectural Pattern
* **General**, **reusable** solution
* **To a commonly occurring problem in software architecture** within a given context
* Similar to software design pattern but **have a broader scope**
* Choose right architectural pattern is **must decision** in desktop application development

+++
### Common Architectural Patterns
* *Layered pattern*
* *Client-server pattern*
* *Master-slave pattern*
* *Pipe-filter pattern*
* *Broker pattern*
* *Peer-to-peer pattern*
* *Event-bus pattern*
* *Model-view-controller pattern*
* *Blackboard pattern*
* *Interpreter pattern*
* *⋮

+++
### Layered pattern
* For structure programs that can be **decomposed into groups of subtasks**
  * **Each of which is at a particular level of abstraction**
* Layer provides services to the next higher layer
* **Usage:**
  * *General desktop applications*
  * *E commerce web applications*

@snap[south-east]
![](/Lectures/Lecture09/Assets/img/LayeredPattern.png)
@snapend

+++
### Client-server pattern
* Consists of **server and multiple clients**
* **Server provides services** to multiple clients
* **Clients request services** from the server
* **Usage:**
  * *Online applications*

@snap[south-east]
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

@snap[south-east]
![](/Lectures/Lecture09/Assets/img/MasterSlavePattern.png)
@snapend

+++
## Pre-MVVM Software Architectural Patterns
* MVC
* MVP
* Presentation Model

---
### Model–View–ViewModel
* **Software architectural pattern**
* **MVVM**
  * Model
  * ViewModel
  * View

@snap[east]
@img[span-80](/Lectures/Lecture09/Assets/img/mvvm.png)
@snapend

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

+++
### MVVM Benefits
* **Separation of concerns**
  * Designer and developer can work on the project simultaneously
* **Speed and performance enhancements**
* **Unit testing**
* **Reusable components**
* **Flexibility**
  * E.g changing UI without having refactor other logic

+++
### MVVM Drawbacks
* **Overkill** for simple applications
* **Memory consumption** with data binding in very large applications

+++
## Model
* Represents the **actual data and information**
* **Holds the information, but not behaviors or services** that manipulate the information
  * **Business logic is encapsulated** in other classes that act on the model
  * Not always true
    * E. g. some *Models* may contain validation

+++
## View
* **Presentation of the data**
* Only thing the end user really interacts with
* Contains *behaviors*, *events* and *data-bindings*
  * Mapped to *properties*, *method calls*, and *commands*
* It is **not responsible for maintaining its state**
  * It will synchronize this with the *ViewModel*
* In *XAML* (in this course)


+++
## ViewModel 
* **Presentation Separation**
  * *View* separate from the *Model*
  * 

+++
frameworks

ViewModelLocator
Messanger
Mvvm light
IoC/DI containter mby?

todo -> rename subtitle

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