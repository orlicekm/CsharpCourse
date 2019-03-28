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

+++?code=/Lectures/Lecture06/Assets/sln/Samples/Behavioral/AbstractFactory.cs&lang=C#&title=Abstract Factory - Sample
@[5-21]
@[9-12]
@[14-17]
@[5-21]
@[23-27]
@[29-40]
@[31-34]
@[36-39]
@[29-40]
@[42-53]
@[44-47]
@[49-52]
@[42-53]
@[55-58]
@[59-62]
@[64-66]
@[68-75]
@[77-79]
@[81-88]
@[90-105]
@[92-93]
@[95-99]
@[101-104]
@[90-105]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture06/Assets/sln/Samples/Behavioral/AbstractFactory.cs)

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

+++?code=/Lectures/Lecture06/Assets/sln/Samples/Behavioral/Builder.cs&lang=C#&title=Builder - Sample
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
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture06/Assets/sln/Samples/Behavioral/Builder.cs)

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

+++?code=/Lectures/Lecture06/Assets/sln/Samples/Behavioral/FactoryMethod.cs&lang=C#&title=Factory Method - Sample
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
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture06/Assets/sln/Samples/Behavioral/FactoryMethod.cs)

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

+++?code=/Lectures/Lecture06/Assets/sln/Samples/Behavioral/Prototype.cs&lang=C#&title=Prototype - Sample
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
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture06/Assets/sln/Samples/Behavioral/Prototype.cs)


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

+++
### Singleton - Sample

+++
### Singleton - Sample Output

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