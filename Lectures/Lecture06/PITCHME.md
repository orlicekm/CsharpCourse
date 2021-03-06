﻿@snap[north span-100]
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
* **Provides general solutions**, documented in a format that doesn't require specifics tied to a particular problem
* Allows developers to communicate **using well-known, well understood names** for software interactions
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
* Categorized into three groups
  * *Creational*
  * *Structural*
  * *Behavioral*

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

+++
### GoF Samples
* Samples in this lecture 
  * Can be run from `ConsoleApp` in the solution
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
* **Definition:** *Provides an interface for creating families of related or dependent objects without specifying their concrete classes*
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
* **Definition:** *Separates the construction of a complex object from its representation so that the same construction process can create different representations*
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
* **Definition:** *Defines an interface for creating an object, but let subclasses decide which class to instantiate. Lets a class defer instantiation to subclasses*
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
* **Definition:** *Specifies the kind of objects to create using a prototypical instance, and create new objects by copying this prototype*
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
* **Definition:** *Ensures a class has only one instance and provide a global point of access to it*
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
* **Definition:** *Converts the interface of a class into another interface clients expect. Adapter lets classes work together that couldn't otherwise because of incompatible interfaces.*
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
* **Definition:** *Decouples an abstraction from its implementation so that the two can vary independently*
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
* **Definition:** *Composes objects into tree structures to represent part-whole hierarchies, lets clients treat individual objects and compositions of objects uniformly*
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
* **Definition:** *Attaches additional responsibilities to an object dynamically, provide a flexible alternative to subclassing for extending functionality*
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
* **Definition:** *Provides a unified interface to a set of interfaces in a subsystem, defines a higher-level interface that makes the subsystem easier to use*
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
* **Definition:** *Uses sharing to support large numbers of fine-grained objects efficiently*
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
* **Definition:** *Provides a surrogate or placeholder for another object to control access to it*
* **Frequency of use:** *Medium high*

+++
###  Proxy - UML Diagram

![](/Lectures/Lecture06/Assets/img/Proxy.gif)

+++
### Proxy - Participants part 1/2
* **Proxy**  *(MathProxy)*
  * Maintains a reference that lets the proxy access the real subject
    * Proxy may refer to a *Subject* if the *RealSubject* and *Subject* interfaces are the same
  * Provides an interface identical to *Subject*'s so that a proxy can be substituted for the real subject
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
* **Definition:** *Avoids coupling the sender of a request to its receiver by giving more than one object a chance to handle the request, chain the receiving objects and pass the request along the chain until an object handles it*
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
* **Definition:** *Encapsulates a request as an object, thereby letting you parameterize clients with different requests, queue or log requests, and support undoable operations*
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
* **Definition:** *Given a language, it defines a representation for its grammar along with an interpreter that uses the representation to interpret sentences in the language*
* **Frequency of use:** *Low*

+++
###  Interpreter - UML Diagram

![](/Lectures/Lecture06/Assets/img/Interpreter.gif)

+++
### Interpreter - Participants part 1/2
* **AbstractExpression**  *(Expression)*
  * Declares an interface for executing an operation
* **TerminalExpression**  *(ThousandExpression, HundredExpression, TenExpression, OneExpression)*
  * Implements an Interpret operation associated with terminal symbols in the grammar
  * An instance is required for every terminal symbol in the sentence
* **NonterminalExpression**  *(not used)*
  * One such class is required for every rule R ::= R1R2...Rn in the grammar
  * Maintains instance variables of type *AbstractExpression* for each of the symbols R1 through Rn
  * Implements an Interpret operation for nonterminal symbols in the grammar
    * Interpret typically calls itself recursively on the variables representing R1 through Rn

+++
### Interpreter - Participants part 2/2
* **Context**  *(Context)*
  * Contains information that is global to the interpreter
* **Client**  *(InterpreterApp)*
  * Builds (or is given) an abstract syntax tree representing a particular sentence in the language that the grammar defines
    * The abstract syntax tree is assembled from instances of the *NonterminalExpression* and *TerminalExpression* classes
  * Invokes the Interpret operation

+++?code=/Lectures/Lecture06/Assets/sln/Samples/Behavioral/InterpreterSample.cs&lang=C#&title=Interpreter - Sample
@[6-7]
@[8-26]
@[10-11]
@[13-20]
@[22-23]
@[25]
@[8-26]
@[29-38]
@[31-34]
@[36-37]
@[29-38]
@[40-41]
@[42-45]
@[47-61]
@[63-67]
@[70-74]
@[77-87]
@[89-102]
@[105-115]
@[117-130]
@[133-143]
@[145-158]
@[161-171]
@[173-186]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture06/Assets/sln/Samples/Behavioral/InterpreterSample.cs)

+++
### Interpreter - Sample Output

```
MCMXXVIII = 1928
```

---
## Iterator
* **Definition:** *Provides a way to access the elements of an aggregate object sequentially without exposing its underlying representation*
* **Frequency of use:** *High*

+++
###  Iterator - UML Diagram

![](/Lectures/Lecture06/Assets/img/Iterator.gif)

+++
### Iterator - Participants
* **Iterator**  *(AbstractIterator)*
  * Defines an interface for accessing and traversing elements
* **ConcreteIterator**  *(Iterator)*
  * Implements the *Iterator* interface
  * Keeps track of the current position in the traversal of the aggregate
* **Aggregate**  *(AbstractCollection)*
  * Defines an interface for creating an *Iterator* object
* **ConcreteAggregate**  *(Collection)*
  * Implements the *Iterator* creation interface to return an instance of the proper *ConcreteIterator*

+++?code=/Lectures/Lecture06/Assets/sln/Samples/Behavioral/IteratorSample.cs&lang=C#&title=Iterator - Sample
@[6-7]
@[8-22]
@[10]
@[12-13]
@[15-21]
@[8-22]
@[25-28]
@[30-46]
@[32]
@[34]
@[36-40]
@[43-45]
@[30-46]
@[48-54]
@[56-57]
@[58-64]
@[66-69]
@[71-77]
@[84-86]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture06/Assets/sln/Samples/Behavioral/IteratorSample.cs)

+++
### Iterator - Sample Output

```
Iterating over collection:
Item A
Item B
Item C
Item D
```

---
## Mediator
* **Definition:** *Defines an object that encapsulates how a set of objects interact, promotes loose coupling by keeping objects from referring to each other explicitly, and it lets you vary their interaction independently*
* **Frequency of use:** *Medium low*

+++
###  Mediator - UML Diagram

![](/Lectures/Lecture06/Assets/img/Mediator.gif)

+++
### Mediator - Participants
* **Mediator**  *(IChatroom)*
  * Defines an interface for communicating with *Colleague objects*
* **ConcreteMediator**  *(Chatroom)*
  * Implements cooperative behavior by coordinating *Colleague objects*
  * Knows and maintains its colleagues
* **Colleague classes**  *(Participant)*
  * Each Colleague class knows its *Mediator* object
  * Each colleague communicates with its mediator whenever it would have otherwise communicated with another colleague

+++?code=/Lectures/Lecture06/Assets/sln/Samples/Behavioral/MediatorSample.cs&lang=C#&title=Mediator - Sample
@[6-7]
@[10]
@[12-17]
@[19-23]
@[25-30]
@[34-39]
@[41-56]
@[43]
@[45-49]
@[51-55]
@[41-56]
@[58-59]
@[60-63]
@[65-66]
@[68-71]
@[73-76]
@[79-91]
@[81-84]
@[86-90]
@[79-91]
@[93-105]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture06/Assets/sln/Samples/Behavioral/MediatorSample.cs)

+++
### Mediator - Sample Output

```
To a Beatle: Yoko to John: 'Hi John!'
To a Beatle: Paul to Ringo: 'All you need is love'
To a Beatle: Ringo to George: 'My sweet Lord'
To a Beatle: Paul to John: 'Can't buy me love'
To a non-Beatle: John to Yoko: 'My sweet love'
```

---
## Memento
* **Definition:** *Without violating encapsulation, captures and externalize an object's internal state so that the object can be restored to this state later*
* **Frequency of use:** *Low*

+++
###  Memento - UML Diagram

![](/Lectures/Lecture06/Assets/img/Memento.gif)

+++
### Memento - Participants
* **Memento**  *(Memento)*
  * Stores internal state of the *Originator* object
  * May store as much or as little of the originator's internal state as necessary at its originator's discretion
  * Protect against access by objects of other than the originator
  * Mementos have effectively two interfaces
    * **Caretaker** sees a narrow interface to the Memento -- it can only pass the memento to the other objects
    * **Originator**, in contrast, sees a wide interface, one that lets it access all the data necessary to restore itself to its previous state
      * Ideally, only the originator that produces the memento would be permitted to access the memento's internal state
* **Originator**  *(SalesProspect)*
  * Creates a memento containing a snapshot of its current internal state
  * Uses the memento to restore its internal state
* **Caretaker**  *(Caretaker)*
  * Responsible for the memento's safekeeping
  * Never operates on or examines the contents of a memento

+++?code=/Lectures/Lecture06/Assets/sln/Samples/Behavioral/MementoSample.cs&lang=C#&title=Memento - Sample
@[5-6]
@[9-14]
@[16-20]
@[22-25]
@[27-28]
@[32-33]
@[34-36]
@[38-46]
@[48-56]
@[58-66]
@[68-72]
@[74-80]
@[83-84]
@[85-90]
@[92-94]
@[97-100]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture06/Assets/sln/Samples/Behavioral/MementoSample.cs)

+++
### Memento - Sample Output

```
Name:   Noel van Halen
Phone:  (412) 256-0990
Budget: 25000

Saving state --

Name:   Leo Welch
Phone:  (310) 209-7111
Budget: 1000000

Restoring state --

Name:   Noel van Halen
Phone:  (412) 256-0990
Budget: 25000
```

---
## Observer
* **Definition:** *Defines a one-to-many dependency between objects so that when one object changes state, all its dependents are notified and updated automatically*
* **Frequency of use:** *High*

+++
###  Observer - UML Diagram

![](/Lectures/Lecture06/Assets/img/Observer.gif)

+++
### Observer - Participants
* **Subject**  *(Stock)*
  * Knows its observers
  * Any number of *Observer* objects may observe a subject
  * Provides an interface for attaching and detaching *Observer* objects
* **ConcreteSubject**  *(IBM)*
  * Stores state of interest to *ConcreteObserver*
  * Sends a notification to its observers when its state changes
* **Observer**  *(IInvestor)*
  * Defines an updating interface for objects that should be notified of changes in a subject
* **ConcreteObserver**  *(Investor)*
  * Maintains a reference to a *ConcreteSubject* object
  * Stores state that should stay consistent with the subject's
  * Implements the *Observer* updating interface to keep its state consistent with the subject's

+++?code=/Lectures/Lecture06/Assets/sln/Samples/Behavioral/ObserverSample.cs&lang=C#&title=Observer - Sample
@[6-7]
@[10-13]
@[15-19]
@[23-24]
@[25-26]
@[28-32]
@[34-45]
@[47]
@[49-52]
@[54-57]
@[59-63]
@[66-72]
@[74-77]
@[79-94]
@[81-86]
@[88]
@[90-93]
@[79-94]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture06/Assets/sln/Samples/Behavioral/ObserverSample.cs)

+++
### Observer - Sample Output

```
Notified Sorros of IBM's change to $120.10
Notified Berkshire of IBM's change to $120.10

Notified Sorros of IBM's change to $121.00
Notified Berkshire of IBM's change to $121.00

Notified Sorros of IBM's change to $120.50
Notified Berkshire of IBM's change to $120.50

Notified Sorros of IBM's change to $120.75
Notified Berkshire of IBM's change to $120.75
```

---
## State
* **Definition:** *Allows an object to alter its behavior when its internal state changes, the object will appear to change its class*
* **Frequency of use:** *Medium*

+++
###  State - UML Diagram

![](/Lectures/Lecture06/Assets/img/State.gif)

+++
### State - Participants
* **Context**  *(Account)*
  * Defines the interface of interest to clients
  * Maintains an instance of a *ConcreteState* subclass that defines the current state
* **State**  *(State)*
  * Defines an interface for encapsulating the behavior associated with a particular state of the *Context*
* **Concrete State**  *(RedState, SilverState, GoldState)*
  * Each subclass implements a behavior associated with a state of *Context*

+++?code=/Lectures/Lecture06/Assets/sln/Samples/Behavioral/StateSample.cs&lang=C#&title=State - Sample
@[5-6]
@[9-10]
@[12-18]
@[22-23]
@[24-28]
@[30-34]
@[36-40]
@[42-44]
@[47-48]
@[49]
@[51-56]
@[58-64]
@[66-70]
@[72-76]
@[78-81]
@[83-86]
@[89-108]
@[110-127]
@[128-133]
@[136]
@[183-184]
@[185-191]
@[193-194]
@[196-203]
@[205-211]
@[213-219]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture06/Assets/sln/Samples/Behavioral/StateSample.cs)

+++
### State - Sample Output

```
Deposited $500.00 ---
 Balance = $500.00
 Status = SilverState


Deposited $300.00 ---
 Balance = $800.00
 Status = SilverState


Deposited $550.00 ---
 Balance = $1,350.00
 Status = GoldState


Interest Paid ---
 Balance = $1,417.50
 Status = GoldState

Withdrew $2,000.00 ---
 Balance = ($582.50)
 Status = RedState

No funds available for withdrawal!
Withdrew $1,100.00 ---
 Balance = ($582.50)
 Status = RedState
```

---
## Strategy
* **Definition:** *Defines a family of algorithms, encapsulate each one, and make them interchangeable, lets the algorithm vary independently from clients that use it*
* **Frequency of use:** *Medium high*


+++
###  Strategy - UML Diagram

![](/Lectures/Lecture06/Assets/img/Strategy.gif)

+++
### Strategy - Participants
* **Strategy**  *(SortStrategy)*
  * Declares an interface common to all supported algorithms
  * Context uses this interface to call the algorithm defined by a *ConcreteStrategy*
* **ConcreteStrategy**  *(QuickSort, ShellSort, MergeSort)*
  * Implements the algorithm using the *Strategy* interface
* **Context**  *(SortedList)*
  * Is configured with a *ConcreteStrategy* object
  * Maintains a reference to a *Strategy* object
  * May define an interface that lets *Strategy* access its data

+++?code=/Lectures/Lecture06/Assets/sln/Samples/Behavioral/StrategySample.cs&lang=C#&title=Strategy - Sample
@[6-7]
@[10-11]
@[13-17]
@[19-26]
@[30-33]
@[35-42]
@[44-51]
@[53-60]
@[62-63]
@[64-65]
@[67-70]
@[72-75]
@[77-83]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture06/Assets/sln/Samples/Behavioral/StrategySample.cs)

+++
### Strategy - Sample Output

```
QuickSorted list
 Anna
 Jimmy
 Samual
 Sandra
 Vivek

ShellSorted list
 Anna
 Jimmy
 Samual
 Sandra
 Vivek

MergeSorted list
 Anna
 Jimmy
 Samual
 Sandra
 Vivek
```

---
## Template Method
* **Definition:** *Defines the skeleton of an algorithm in an operation, deferring some steps to subclasses, lets subclasses redefine certain steps of an algorithm without changing the algorithm's structure*
* **Frequency of use:** *Medium*

+++
###  Template Method - UML Diagram

![](/Lectures/Lecture06/Assets/img/TemplateMethod.gif)

+++
### Template Method - Participants
* **AbstractClass**  *(DataObject)*
  * Defines abstract primitive operations that concrete subclasses define to implement steps of an algorithm
  * Implements a template method defining the skeleton of an algorithm
    * The template method calls primitive operations as well as operations defined in *AbstractClass* or those of other objects
* **ConcreteClass**  *(CustomerDataObject)*
  * Implements the primitive operations ot carry out subclass-specific steps of the algorithm

+++?code=/Lectures/Lecture06/Assets/sln/Samples/Behavioral/TemplateMethodSample.cs&lang=C#&title=Template Method - Sample
@[6-7]
@[8-15]
@[18-19]
@[23-29]
@[31-32]
@[34-37]
@[39-45]
@[49-68]
@[51-52, 59]
@[53-54]
@[56-58]
@[61-62, 67]
@[63-64]
@[65-66]
@[49-68]
@[70-71, 89]
@[72-80]
@[82-88]
@[70-89]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture06/Assets/sln/Samples/Behavioral/TemplateMethodSample.cs)

+++
### Template Method - Sample Output

```
Categories ----
Beverages
Condiments
Confections
Dairy Products
Grains/Cereals
Meat/Poultry
Produce
Seafood

Products ----
Chai
Chang
Aniseed Syrup
Chef Anton's Cajun Seasoning
Chef Anton's Gumbo Mix
Grandma's Boysenberry Spread
Uncle Bob's Organic Dried Pears
Northwoods Cranberry Sauce
Mishi Kobe Niku
```

---
## Visitor
* **Definition:** *Represents an operation to be performed on the elements of an object structure, lets you define a new operation without changing the classes of the elements on which it operates*
* **Frequency of use:** *Low*

+++
###  Visitor - UML Diagram

![](/Lectures/Lecture06/Assets/img/Visitor.gif)

+++
### Visitor - Participants part 1/2
* **Visitor**  *(Visitor)*
  * Declares a Visit operation for each class of *ConcreteElement* in the object structure
    * The operation's name and signature identifies the class that sends the Visit request to the visitor
      * That lets the visitor determine the concrete class of the element being visited, then the visitor can access the elements directly through its particular interface
* **ConcreteVisitor**  *(IncomeVisitor, VacationVisitor)*
  * Implements each operation declared by *Visitor*
    * Each operation implements a fragment of the algorithm defined for the corresponding class or object in the structure
  * Provides the context for the algorithm and stores its local state
    * This state often accumulates results during the traversal of the structure

+++
### Visitor - Participants part 2/2
* **Element**  *(Element)*
  * Defines an Accept operation that takes a visitor as an argument
* **ConcreteElement**  *(Employee)*
  * Implements an Accept operation that takes a visitor as an argument
* **ObjectStructure**  *(Employees)*
  * Can enumerate its elements
  * May provide a high-level interface to allow the visitor to visit its elements
  * May either be a Composite or a collection such as a list or a set

+++?code=/Lectures/Lecture06/Assets/sln/Samples/Behavioral/VisitorSample.cs&lang=C#&title=Visitor - Sample
@[6-7]
@[8-19]
@[22-25]
@[27-28, 37]
@[29-36]
@[39-40, 50]
@[41-49]
@[52-55]
@[57-58]
@[59-65]
@[67-69]
@[71-74]
@[77-78]
@[79]
@[81-84]
@[86-89]
@[91-95]
@[98-104]
@[106-112]
@[114-120]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture06/Assets/sln/Samples/Behavioral/VisitorSample.cs)

+++
### Visitor - Sample Output

```
Clerk Hank's new income: $27,500.00
Director Elly's new income: $38,500.00
President Mike's new income: $49,500.00

Clerk Hank's new vacation days: 17
Director Elly's new vacation days: 19
President Mike's new vacation days: 24
```

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