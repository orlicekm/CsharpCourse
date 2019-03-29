@snap[north span-100]
# Design patterns in C#
@snapend

@snap[midpoint span-100]
## Gang of Four patterns
@snapend

@snap[south-east span-30]
[ Michal Orlicek <xorlic00@stud.fit.vutbr.cz> ]
@snapend 

---
## Design Pattern
* **General repeatable solution to a commonly occurring problem** in software design
* It is **not a finished design** that can be transformed directly into code
* **Description or template** for how to solve a problem
  * Can be used in many different situations

+++
### Design Patterns Benefits
* **Speeds up the development** process by providing *tested, proven development paradigms*
* **Helps to prevent issues** that can cause major problems
* **Improves code readability** for coders and architects familiar with the patterns
* **Provide general solutions**, documented in a format that doesn't require specifics tied to a particular problem
* Allow developers to communicate **using well-known, well understood names** for software interactions
* Can be **improved over time**, making them more robust than ad-hoc designs

---
## Gang of Four 
* **GoF**
* Generally considered the **foundation for all other patterns**
* The authors of the *DesignPatternsBook* came to be known as the *Gang of Four*
  * The name of the book *Design Patterns: Elements of Reusable Object-Oriented Software* is too long for e-mail
  * So "*book by the gang of four*" became a shorthand name for it
 
@img[span-25](/Lectures/Lecture01/Assets/img/DesignPatterns.png)

+++
## GoF Pattern Groups
* 23+ patterns 
* Categirized into three groups
  * *Creational*
  * *Structural*
  * *Behavioral*

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

+++
### GoF Samples
* Samples in this lecture 
  * Can be runned from `ConsoleApp` in the solution
  * **From real world**
  * For better demonstration and understanding, they are **not .NET optimized**
    * Without *generics*, *delegates*, *reflection* and more...

---
## Creational Patterns
* *Abstract Factory*
* *Builder*
* *Factory Method*
* *Prototype*
* *Singleton*

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

---
##  Abstract Factory
* **Definition:** *Provide an interface for creating families of related or dependent objects without specifying their concrete classes*
* **Frequency of use:** *High*

+++
###  Abstract Factory - UML Diagram

![](/Lectures/Lecture06/Assets/img/AbstractFactory.gif)

+++
### Abstract Factory - Participants
* **AbstractFactory**  *(ContinentFactory)*
  * Declares an interface for operations that create abstract products
* **ConcreteFactory**  *(AfricaFactory, AmericaFactory)*
  * Implements the operations to create concrete product objects
* **AbstractProduct**  *(Herbivore, Carnivore)*
  * Declares an interface for a type of product object
* **Product**  *(Wildebeest, Lion, Bison, Wolf)*
  * Defines a product object to be created by the corresponding concrete factory
  * Implements the *AbstractProduct* interface
* **Client**  *(AnimalWorld)*
  * Uses interfaces declared by *AbstractFactory* and *AbstractProduct* classes

+++?code=/Lectures/Lecture06/Assets/sln/Samples/Creational/AbstractFactorySample.cs&lang=C#&title=Abstract Factory - Sample
@[5-6]
@[7-18]
@[9-12]
@[14-17]
@[7-18]
@[21-25]
@[27-38]
@[29-32]
@[34-37]
@[27-38]
@[40-51]
@[42-45]
@[47-50]
@[40-51]
@[53-55]
@[57-60]
@[62-64]
@[66-73]
@[75-77]
@[79-86]
@[88-103]
@[90-91]
@[93-97]
@[99-102]
@[88-103]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture06/Assets/sln/Samples/Creational/AbstractFactorySample.cs)

+++
### Abstract Factory - Sample Output

```
Lion eats Wildebeest
Wolf eats Bison
```

---
## Builder
* **Definition:** *Separate the construction of a complex object from its representation so that the same construction process can create different representations*
* **Frequency of use:** *Medium low*

+++
###  Builder - UML Diagram

![](/Lectures/Lecture06/Assets/img/Builder.gif)

+++
### Builder - Participants
* **Builder**  *(VehicleBuilder)*
  * Specifies an abstract interface for creating parts of a *Product* object
* **ConcreteBuilder**  *(MotorCycleBuilder, CarBuilder, ScooterBuilder)*
  * Constructs and assembles parts of the product by implementing the *Builder* interface
  * Defines and keeps track of the representation it creates
  * Provides an interface for retrieving the product
* **Director**  *(Shop)*
  * Constructs an object using the *Builder* interface
* **Product**  *(Vehicle)*
  * Represents the complex object under construction, *ConcreteBuilder* builds the product's internal representation and defines the process by which it's assembled
  * Includes classes that define the constituent parts, including interfaces for assembling the parts into the final result

+++?code=/Lectures/Lecture06/Assets/sln/Samples/Creational/BuilderSample.cs&lang=C#&title=Builder - Sample
@[6-7]
@[8-28]
@[10]
@[13]
@[15-18]
@[20-22]
@[24-26]
@[8-28]
@[30-40]
@[35-38]
@[30-40]
@[42-52]
@[44]
@[46]
@[48-51]
@[42-52]
@[54-55]
@[56-59]
@[61-64]
@[66-69]
@[71-74]
@[76-79]
@[82-87]
@[89-107]
@[110-115]
@[117-135]
@[138-139]
@[143-148]
@[140-141, 150-156]
@[157-165]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture06/Assets/sln/Samples/Creational/BuilderSample.cs)

+++
### Builder - Sample Output

```
---------------------------
Vehicle Type: Scooter
 Frame  : Scooter Frame
 Engine : none
 #Wheels: 2
 #Doors : 0

---------------------------
Vehicle Type: Car
 Frame  : Car Frame
 Engine : 2500 cc
 #Wheels: 4
 #Doors : 4

---------------------------
Vehicle Type: MotorCycle
 Frame  : MotorCycle Frame
 Engine : 500 cc
 #Wheels: 2
 #Doors : 0
```

---
## Factory Method
* **Definition:** *Define an interface for creating an object, but let subclasses decide which class to instantiate. Lets a class defer instantiation to subclasses*
* **Frequency of use:** *High*

+++
###  Factory Method - UML Diagram

![](/Lectures/Lecture06/Assets/img/FactoryMethod.gif)

+++
### Factory Method - Participants
* **Product**  *(Page)*
  * Defines the interface of objects the factory method creates
* **ConcreteProduct**  *(SkillsPage, EducationPage, ExperiencePage)*
  * Implements the *Product* interface
* **Creator**  *(Document)*
  * Declares the factory method, which returns an object of type *Product*
  * May define a default implementation of the factory method that returns a default *ConcreteProduct* object
  * May call the factory method to create a *Product* object
* **ConcreteCreator*  *(Report, Resume)*
  * Overrides the factory method to return an instance of a ConcreteProduct

+++?code=/Lectures/Lecture06/Assets/sln/Samples/Creational/FactoryMethodSample.cs&lang=C#&title=Factory Method - Sample
@[6-23]
@[10-11]
@[13-14]
@[16-21]
@[6-23]
@[25-27]
@[29-43]
@[45-59]
@[61-75]
@[63]
@[65-69]
@[71]
@[74]
@[61-75]
@[77-85]
@[87-97]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture06/Assets/sln/Samples/Creational/FactoryMethodSample.cs)

+++
### Factory Method - Sample Output

```
Resume -------
 SkillsPage
 EducationPage
 ExperiencePage

Report -------
 IntroductionPage
 ResultsPage
 ConclusionPage
 SummaryPage
 BibliographyPage
```

---
## Prototype
* **Definition:** *Specify the kind of objects to create using a prototypical instance, and create new objects by copying this prototype*
* **Frequency of use:** *Medium*

+++
###  Prototype - UML Diagram

![](/Lectures/Lecture06/Assets/img/Prototype.gif)

+++
### Prototype - Participants
* **Prototype**  *(ColorPrototype)*
  * Declares an interface for cloning itself
* **ConcretePrototype**  *(Color)*
  * Implements an operation for cloning itself
* **Client**  *(ColorManager)*
  * Creates a new object by asking a prototype to clone itself

+++?code=/Lectures/Lecture06/Assets/sln/Samples/Creational/PrototypeSample.cs&lang=C#&title=Prototype - Sample
@[6-7]
@[8-26]
@[10-20]
@[8-26]
@[29-32]
@[34-54]
@[36-45]
@[47-53]
@[34-54]
@[56-66]
@[58-59]
@[61-65]
@[56-66]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture06/Assets/sln/Samples/Creational/PrototypeSample.cs)


+++
### Prototype - Sample Output

```
Cloning color RGB: 255,  0,  0
Cloning color RGB: 128,211,128
Cloning color RGB: 211, 34, 20
```

---
## Singleton
* **Definition:** *Ensure a class has only one instance and provide a global point of access to it*
* **Frequency of use:** *Medium high*

+++
###  Singleton - UML Diagram

![](/Lectures/Lecture06/Assets/img/Singleton.gif)

+++
### Singleton - Participants
* **Singleton**  *(LoadBalancer)*
  * Defines an Instance operation that lets clients access its unique instance
  * Instance is a class operation
  * Responsible for creating and maintaining its own unique instance

+++?code=/Lectures/Lecture06/Assets/sln/Samples/Creational/SingletonSample.cs&lang=C#&title=Singleton - Sample
@[6-7]
@[8-25]
@[10-13]
@[15-16]
@[18-24]
@[8-25]
@[28-29]
@[34, 36-43]
@[33]
@[46-53]
@[55-68]
@[61]
@[62-63, 65]
@[64]
@[55-68]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture06/Assets/sln/Samples/Creational/SingletonSample.cs)

+++
### Singleton - Sample Output

```
Same instance

ServerIII
ServerII
ServerI
ServerII
ServerI
ServerIII
ServerI
ServerIII
ServerIV
ServerII
ServerII
ServerIII
ServerIV
ServerII
ServerIV
```

---
## Structural Patterns
* *Adapter*
* *Bridge*
* *Composite*
* *Decorator*
* *Facade*
* *Flyweight*
* *Proxy*

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

---
## Adapter
* **Definition:** *Convert the interface of a class into another interface clients expect. Adapter lets classes work together that couldn't otherwise because of incompatible interfaces.*
* **Frequency of use:** *Medium high*

+++
###  Adapter - UML Diagram

![](/Lectures/Lecture06/Assets/img/Adapter.gif)

+++
### Adapter - Participants
* **Target**  *(ChemicalCompound)*
  * Defines the domain-specific interface that *Client* uses
* **Adapter**  *(Compound)*
  * Adapts the interface *Adaptee* to the *Target* interface
* **Adaptee**  *(ChemicalDatabank)*
  * Defines an existing interface that needs adapting
* **Client**  *(AdapterApp)*
  * Collaborates with objects conforming to the *Target* interface

+++?code=/Lectures/Lecture06/Assets/sln/Samples/Structural/AdapterSample.cs&lang=C#&title=Adapter - Sample
@[5-6]
@[7-22]
@[9-11]
@[13-21]
@[7-22]
@[25-42]
@[27-31]
@[33-36]
@[38-41]
@[25-42]
@[44-45]
@[46]
@[49-52]
@[54-57, 69]
@[59-62]
@[64-68]
@[72-74]
@[75-94]
@[96-105]
@[107-116]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture06/Assets/sln/Samples/Structural/AdapterSample.cs)

+++
### Adapter - Sample Output

```
Compound: Unknown ------

Compound: Water ------
 Formula: H20
 Weight : 18.015
 Melting Pt: 0
 Boiling Pt: 100

Compound: Benzene ------
 Formula: C6H6
 Weight : 78.1134
 Melting Pt: 5.5
 Boiling Pt: 80.1

Compound: Alcohol ------
 Formula: C2H6O2
 Weight : 46.0688
 Melting Pt: -114.1
 Boiling Pt: 78.3
```

---
## Bridge
* **Definition:** *Decouple an abstraction from its implementation so that the two can vary independently*
* **Frequency of use:** *Medium*

+++
###  Bridge - UML Diagram

![](/Lectures/Lecture06/Assets/img/Bridge.gif)

+++
### Bridge - Participants
* **Abstraction**  *(BusinessObject)*
  * Defines the abstraction's interface
  * Maintains a reference to an object of type *Implementor*
* **RefinedAbstraction**  *(CustomersBusinessObject)*
  * Extends the interface defined by *Abstraction*
* **Implementor**  *(DataObject)*
  * Defines the interface for implementation classes
  * Doesn't have to correspond exactly to *Abstraction*'s interface
    * In fact the two interfaces can be quite different
    * Typically the *Implementation* interface provides only primitive operations, and *Abstraction* defines higher-level operations based on these primitives
* **ConcreteImplementor**  *(CustomersDataObject)*
  * Implements the *Implementor* interface and defines its concrete implementation

+++?code=/Lectures/Lecture06/Assets/sln/Samples/Structural/BridgeSample.cs&lang=C#&title=Bridge - Sample
@[6-7]
@[8-24]
@[10-11]
@[13-14]
@[16-23]
@[8-24]
@[27-28]
@[29-34]
@[36]
@[38-51]
@[53-67]
@[70-84]
@[72-75]
@[77-83]
@[70-84]
@[86-94]
@[88-93]
@[86-94]
@[96-97]
@[98-99]
@[101-109]
@[111-124]
@[126-139]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture06/Assets/sln/Samples/Structural/BridgeSample.cs)

+++
### Bridge - Sample Output

```
Jim Jones
Samual Jackson
Allen Good

------------------------
Customer Group: Chicago
Jim Jones
Samual Jackson
Allen Good
Ann Stills
Lisa Giolani
Henry Velasquez
------------------------
```

---
## Composite
* **Definition:** *Compose objects into tree structures to represent part-whole hierarchies, lets clients treat individual objects and compositions of objects uniformly*
* **Frequency of use:** *Medium high*

+++
###  Composite - UML Diagram

![](/Lectures/Lecture06/Assets/img/Composite.gif)

+++
### Composite - Participants
* **Component**  *(DrawingElement)*
  * Declares the interface for objects in the composition
  * Implements default behavior for the interface common to all classes, as appropriate
  * Declares an interface for accessing and managing its child components
  * (optional) defines an interface for accessing a component's parent in the recursive structure, and implements it if that's appropriate
* **Leaf**  *(PrimitiveElement)*
  * Represents leaf objects in the composition
  * Has no children
  * Defines behavior for primitive objects in the composition
* **Composite**  *(CompositeElement)*
  * Defines behavior for components having children
  * Stores child components
  * Implements child-related operations in the *Component* interface
* **Client**  *(CompositeApp)*
  * Manipulates objects in the composition through the *Component* interface

+++?code=/Lectures/Lecture06/Assets/sln/Samples/Structural/CompositeSample.cs&lang=C#&title=Composite - Sample
@[6-7]
@[10-15]
@[17-22]
@[24-28]
@[30-31]
@[35-47]
@[37-42]
@[44-46]
@[35-47]
@[49-50]
@[51-54]
@[56-72]
@[75-76]
@[77-78]
@[80-83]
@[85-88]
@[90-93]
@[95-102]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture06/Assets/sln/Samples/Structural/CompositeSample.cs)

+++
### Composite - Sample Output

```
-+ Picture
--- Red Line
--- Blue Circle
--- Green Box
---+ Two Circles
----- Black Circle
----- White Circle
```

---
## Decorator
* **Definition:** *Attach additional responsibilities to an object dynamically, provide a flexible alternative to subclassing for extending functionality*
* **Frequency of use:** *Medium*

+++
###  Decorator - UML Diagram

![](/Lectures/Lecture06/Assets/img/Decorator.gif)

+++
### Decorator - Participants
* **Component**  *(LibraryItem)*
  * Defines the interface for objects that can have responsibilities added to them dynamically
* **ConcreteComponent**  *(Book, Video)*
  * Defines an object to which additional responsibilities can be attached
* **Decorator**  *(Decorator)*
  * Maintains a reference to a *Component* object and defines an interface that conforms to *Component*'s interface
* **ConcreteDecorator**  *(Borrowable)*
* Adds responsibilities to the component

+++?code=/Lectures/Lecture06/Assets/sln/Samples/Structural/DecoratorSample.cs&lang=C#&title=Decorator - Sample
@[6-7]
@[8-24]
@[10-12]
@[14-16]
@[18-23]
@[8-24]
@[27-32]
@[34-53]
@[36-44]
@[46-52]
@[34-53]
@[55-56]
@[57-68]
@[70-77]
@[80-93]
@[82-87]
@[89-92]
@[80-93]
@[95-96]
@[97]
@[99-102]
@[104-108]
@[110-114]
@[116-120]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture06/Assets/sln/Samples/Structural/DecoratorSample.cs)

+++
### Decorator - Sample Output

```
Book ------
Author: Worley
Title: Inside ASP.NET
# Copies: 10

Video -----
Director: Spielberg
Title: Jaws
# Copies: 23
Playtime: 92


Making video borrowable:

Video -----
Director: Spielberg
Title: Jaws
# Copies: 21
Playtime: 92

borrower: Customer #1
borrower: Customer #2
```

---
## Facade
* **Definition:** *Provide a unified interface to a set of interfaces in a subsystem, defines a higher-level interface that makes the subsystem easier to use*
* **Frequency of use:** *High*

+++
###  Facade - UML Diagram

![](/Lectures/Lecture06/Assets/img/Facade.gif)

+++
### Facade - Participants
* **Facade**  *(MortgageApplication)*
  * Knows which subsystem classes are responsible for a request
  * Delegates client requests to appropriate subsystem objects
* **Subsystem classes**  *(Bank, Credit, Loan)*
  * Implement subsystem functionality
  * Handle work assigned by the *Facade* object
  * Have no knowledge of the facade and keep no reference to it

+++?code=/Lectures/Lecture06/Assets/sln/Samples/Structural/FacadeSample.cs&lang=C#&title=Facade - Sample
@[5-6]
@[7-17]
@[9]
@[11-16]
@[7-17]
@[20-27]
@[29-36]
@[38-45]
@[47-55]
@[57-77]
@[59-61]
@[63-65, 77]
@[67-76]
@[57-77]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture06/Assets/sln/Samples/Structural/FacadeSample.cs)

+++
### Facade - Sample Output

```
Ann McKinsey applies for $125,000.00 loan

Check bank for Ann McKinsey
Check loans for Ann McKinsey
Check credit for Ann McKinsey

Ann McKinsey has been Approved
```

---
## Flyweight
* **Definition:** *Use sharing to support large numbers of fine-grained objects efficiently*
* **Frequency of use:** *Low*

+++
###  Flyweight - UML Diagram

![](/Lectures/Lecture06/Assets/img/Flyweight.gif)

+++
### Flyweight - Participants part 1/2
* **Flyweight**  *(Character)*
  * Declares an interface through which flyweights can receive and act on extrinsic state
* **ConcreteFlyweight**  *(CharacterA, CharacterB, ..., CharacterZ)*
  * Implements the *Flyweight* interface and adds storage for intrinsic state, if any
  * Must be sharable
  * Any state it stores must be intrinsic, that is, it must be independent of the *ConcreteFlyweight* object's context
* **UnsharedConcreteFlyweight**  *(not used)*
  * Not all *Flyweight* subclasses need to be shared
  * The Flyweight interface enables sharing, but it doesn't enforce it
    * It is common for *UnsharedConcreteFlyweight* objects to have *ConcreteFlyweight* objects as children at some level in the flyweight object structure (as the Row and Column classes have)

+++
### Flyweight - Participants part 2/2
* **FlyweightFactory**  *(CharacterFactory)*
  * Creates and manages flyweight objects
  * Ensures that flyweight are shared properly
  * When a client requests a flyweight, the *FlyweightFactory* objects assets an existing instance or creates one, if none exists
* **Client**  *(FlyweightApp)*
  * Maintains a reference to flyweight(s)
  * Computes or stores the extrinsic state of flyweight(s)

+++?code=/Lectures/Lecture06/Assets/sln/Samples/Structural/FlyweightSample.cs&lang=C#&title=Flyweight - Sample
@[6-7]
@[8-26]
@[10-12]
@[14]
@[16-17]
@[19-25]
@[8-26]
@[29-30]
@[31-32]
@[34-35]
@[36-41]
@[42-60]
@[62]
@[66-76]
@[78-94]
@[80-87]
@[89-93]
@[78-94]
@[96-112]
@[114]
@[116-132]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture06/Assets/sln/Samples/Structural/FlyweightSample.cs)

+++
### Flyweight - Sample Output

```
A (pointsize 11)
A (pointsize 12)
Z (pointsize 13)
Z (pointsize 14)
B (pointsize 15)
B (pointsize 16)
Z (pointsize 17)
B (pointsize 18)
```

---
## Proxy
* **Definition:** *Provide a surrogate or placeholder for another object to control access to it*
* **Frequency of use:** *Medium high*

+++
###  Proxy - UML Diagram

![](/Lectures/Lecture06/Assets/img/Proxy.gif)

+++
### Proxy - Participants part 1/2
* **Proxy**  *(MathProxy)*
  * Maintains a reference that lets the proxy access the real subject
    * Proxy may refer to a *Subject* if the *RealSubject* and *Subject* interfaces are the same
  * Provides an interface identical to *Subject*'s so that a proxy can be substituted for for the real subject
  * Controls access to the real subject and may be responsible for creating and deleting it
  * Other responsibilites depend on the kind of proxy:
    * **Remote proxies** are responsible for encoding a request and its arguments and for sending the encoded request to the real subject in a different address space
    * **Virtual proxies** may cache additional information about the real subject so that they can postpone accessing it
    * **Protection proxies** check that the caller has the access permissions required to perform a request

+++
### Proxy - Participants part 2/2
* **Subject**  *(IMath)*
  * Defines the common interface for *RealSubject* and *Proxy* so that a *Proxy* can be used anywhere a *RealSubject* is expected
* **RealSubject**  *(Math)*
  * Defines the real object that the proxy represents

+++?code=/Lectures/Lecture06/Assets/sln/Samples/Structural/ProxySample.cs&lang=C#&title=Proxy - Sample
@[5-6]
@[7-17]
@[20-26]
@[28-29]
@[30-48]
@[51-52]
@[53]
@[55-73]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture06/Assets/sln/Samples/Structural/ProxySample.cs)

+++
### Proxy - Sample Output

```
4 + 2 = 6
4 - 2 = 2
4 * 2 = 8
4 / 2 = 2
```

---
## Behavioral Patterns
* *Chain of Responsibility*
* *Command*
* *Interpreter*
* *Iterator*
* *Mediator*
* *Memento*
* *Observer*
* *State*
* *Strategy*
* *Template Method*
* *Visitor*

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

---
## Chain of Responsibility
* **Definition:** *Avoid coupling the sender of a request to its receiver by giving more than one object a chance to handle the request, chain the receiving objects and pass the request along the chain until an object handles it*
* **Frequency of use:** *Medium low*

+++
###  Chain of Responsibility - UML Diagram

![](/Lectures/Lecture06/Assets/img/ChainOfResponsibility.gif)

+++
### Chain of Responsibility - Participants
* **Handler**  *(Approver)*
  * Defines an interface for handling the requests
  * (optional) implements the successor link
* **ConcreteHandler**  *(Director, VicePresident, President)*
  * Handles requests it is responsible for
  * Can access its successor
  * If the *ConcreteHandler* can handle the request, it does so; otherwise it forwards the request to its successor
* **Client**  *(ChainApp)*
  * Initiates the request to a *ConcreteHandler* object on the chain

+++?code=/Lectures/Lecture06/Assets/sln/Samples/Behavioral/ChainOfResponsibilitySample.cs&lang=C#&title=Chain of Responsibility - Sample
@[5-6]
@[7-26]
@[9-15]
@[17-25]
@[7-26]
@[29-39]
@[31-36]
@[38]
@[29-39]
@[41-51]
@[45-47]
@[48-49]
@[41-51]
@[53-63]
@[65-77]
@[79-91]
@[81-86]
@[88-90]
@[79-91]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture06/Assets/sln/Samples/Behavioral/ChainOfResponsibilitySample.cs)

+++
### Chain of Responsibility - Sample Output

```
Director Larry approved request# 2034
President Tammy approved request# 2035
Request# 2036 requires an executive meeting!
```

---
## Command
* **Definition:** *Encapsulate a request as an object, thereby letting you parameterize clients with different requests, queue or log requests, and support undoable operations*
* **Frequency of use:** *Medium high*

+++
###  Command - UML Diagram

![](/Lectures/Lecture06/Assets/img/Command.gif)

+++
### Command - Participants
* **Command**  *(Command)*
  * Declares an interface for executing an operation
* **ConcreteCommand**  *(CalculatorCommand)*
  * Defines a binding between a *Receiver* object and an action
  * Implements *Execute* by invoking the corresponding operation(s) on *Receiver*
* **Client**  *(CommandApp)*
  * Creates a *ConcreteCommand* object and sets its receiver
* **Invoker**  *(User)*
  * Asks the command to carry out the request
* **Receiver**  *(Calculator)*
  * Knows how to perform the operations associated with carrying out the request

+++?code=/Lectures/Lecture06/Assets/sln/Samples/Behavioral/CommandSample.cs&lang=C#&title=Command - Sample
@[6-7]
@[8-24]
@[10-11]
@[13-17]
@[19-23]
@[8-24]
@[27-31]
@[33-34]
@[35-46]
@[47-55]
@[57-65]
@[68-80]
@[83-84]
@[85]
@[87-107]
@[110-111]
@[112-114]
@[116-124]
@[127-136]
@[138-148]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture06/Assets/sln/Samples/Behavioral/CommandSample.cs)

+++
### Command - Sample Output

```
Current value = 100 (following + 100)
Current value =  50 (following - 50)
Current value = 500 (following * 10)
Current value = 250 (following / 2)

---- Undo 4 levels
Current value = 500 (following * 2)
Current value =  50 (following / 10)
Current value = 100 (following + 50)
Current value =   0 (following - 100)

---- Redo 3 levels
Current value = 100 (following + 100)
Current value =  50 (following - 50)
Current value = 500 (following * 10)
```

---
## Interpreter

+++
###  Interpreter - UML Diagram

![](/Lectures/Lecture06/Assets/img/Interpreter.gif)

+++
### Interpreter - Participants

+++?code=/Lectures/Lecture06/Assets/sln/Samples/Behavioral/InterpreterSample.cs&lang=C#&title=Interpreter - Sample
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture06/Assets/sln/Samples/Behavioral/InterpreterSample.cs)

+++
### Interpreter - Sample Output

---
## Iterator

+++
###  Iterator - UML Diagram

![](/Lectures/Lecture06/Assets/img/Iterator.gif)

+++
### Iterator - Participants

+++?code=/Lectures/Lecture06/Assets/sln/Samples/Behavioral/IteratorSample.cs&lang=C#&title=Iterator - Sample
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture06/Assets/sln/Samples/Behavioral/IteratorSample.cs)

+++
### Iterator - Sample Output

---
## Mediator

+++
###  Mediator - UML Diagram

![](/Lectures/Lecture06/Assets/img/Mediator.gif)

+++
### Mediator - Participants

+++?code=/Lectures/Lecture06/Assets/sln/Samples/Behavioral/MediatorSample.cs&lang=C#&title=Mediator - Sample
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture06/Assets/sln/Samples/Behavioral/MediatorSample.cs)

+++
### Mediator - Sample Output

---
## Memento

+++
###  Memento - UML Diagram

![](/Lectures/Lecture06/Assets/img/Memento.gif)

+++
### Memento - Participants

+++?code=/Lectures/Lecture06/Assets/sln/Samples/Behavioral/MementoSample.cs&lang=C#&title=Memento - Sample
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture06/Assets/sln/Samples/Behavioral/MementoSample.cs)

+++
### Memento - Sample Output

---
## Observer

+++
###  Observer - UML Diagram

![](/Lectures/Lecture06/Assets/img/Observer.gif)

+++
### Observer - Participants

+++?code=/Lectures/Lecture06/Assets/sln/Samples/Behavioral/ObserverSample.cs&lang=C#&title=Observer - Sample
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture06/Assets/sln/Samples/Behavioral/ObserverSample.cs)

+++
### Observer - Sample Output

---
## State

+++
###  State - UML Diagram

![](/Lectures/Lecture06/Assets/img/State.gif)

+++
### State - Participants

+++?code=/Lectures/Lecture06/Assets/sln/Samples/Behavioral/StateSample.cs&lang=C#&title=State - Sample
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture06/Assets/sln/Samples/Behavioral/StateSample.cs)

+++
### State - Sample Output

---
## Strategy

+++
###  Strategy - UML Diagram

![](/Lectures/Lecture06/Assets/img/Strategy.gif)

+++
### Strategy - Participants

+++?code=/Lectures/Lecture06/Assets/sln/Samples/Behavioral/StrategySample.cs&lang=C#&title=Strategy - Sample
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture06/Assets/sln/Samples/Behavioral/StrategySample.cs)

+++
### Strategy - Sample Output

---
## Template Method

+++
###  Template Method - UML Diagram

![](/Lectures/Lecture06/Assets/img/TemplateMethod.gif)

+++
### Template Method - Participants

+++?code=/Lectures/Lecture06/Assets/sln/Samples/Behavioral/TemplateMethodSample.cs&lang=C#&title=Template Method - Sample
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture06/Assets/sln/Samples/Behavioral/TemplateMethodSample.cs)

+++
### Template Method - Sample Output

---
## Visitor

+++
###  Visitor - UML Diagram

![](/Lectures/Lecture06/Assets/img/Visitor.gif)

+++
### Visitor - Participants

+++?code=/Lectures/Lecture06/Assets/sln/Samples/Behavioral/VisitorSample.cs&lang=C#&title=Visitor - Sample
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture06/Assets/sln/Samples/Behavioral/VisitorSample.cs)

+++
### Visitor - Sample Output

---
## References:
[C# 7.0 in a Nutshell: The Definitive Reference](https://www.amazon.com/C-7-0-Nutshell-Definitive-Reference/dp/1491987650)  
[Agile Principles, Patterns, and Practices in C#](https://www.amazon.de/Agile-Principles-Patterns-Practices-C/dp/0131857258)  
[Design Patterns. Elements of Reusable Object-Oriented Software](https://www.amazon.de/Patterns-Elements-Reusable-Object-Oriented-Software/dp/0201633612)
[Data & Object Factory](https://www.dofactory.com/)  
[SourceMaking.com](https://sourcemaking.com/)  
[WikiWikiWeb](http://wiki.c2.com/)  
[Wikipedia](https://en.wikipedia.org)  

+++
## Refences to used images:
[Agile Principles, Patterns, and Practices in C#](https://www.amazon.de/Agile-Principles-Patterns-Practices-C/dp/0131857258)  
[Design Patterns. Elements of Reusable Object-Oriented Software](https://www.amazon.de/Patterns-Elements-Reusable-Object-Oriented-Software/dp/0201633612)  
[Data & Object Factory](https://www.dofactory.com/)  
[Amazon.com](https://www.amazon.com/)  