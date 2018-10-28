# Introduction to object-oriented programming and advanced programming constructs
## Exceptions, events, delegates, lambda expressions and generics
<div class="right">
[ Michal Orlicek <xorlic00@stud.fit.vutbr.cz> ]
</div>

---
## Object Oriented Programming (OOP)
* First appearance in **SIMULA 67**
* Abstraction of real word 
* Real object (dog) has some properties (**length, color of coat, ...**) and an ability to do something (**bark, bite**)
* OOP Object interconnects data and behavior together
  * **Behavior** is described by **procedures** and **functions**, both called in OOP as **methods**
  * Data is stored in object's **member variable (field)**
  * **Methods** and **fields** together creates objects

+++?code=/Lectures/Lecture02/Assets/sln/Tests/Dog.cs&lang=C#&title=OOP Sample
@[3-14]
@[5-6]
@[8-11, 13]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture02/Assets/sln/Tests/Dog.cs)

+++
### Three principes of OOP
* OOP interconnects **data** and **logic**
  * **Encapsulation**
  * **Inheritance**
  * **Polymorphism**

+++
#### Encapsulation
* Hides implementation details
* Improves modularity
* Definitions:
  * A language mechanism for **restricting direct access** to some of the **object's components**
  * A language construct that **facilitates the bundling of data with the methods** (or other functions) operating on that data

+++
#### Inheritance
* Create objects that are built upon existing objects
* Specify a new implementation to maintain the same behavior
* Reuse code and to independently extend original software via public classes
* An *inherited class* is called a **subclass** of its **parent class** or **superclass**

+++
##### Inheritance and subtyping
* In some languages inheritance and subtyping agree
* Generally in statically-typed class-based OO languages, such as (C++, C#, Java), whereas in others they differ
  * **subtyping** *establishes an is-a relationship*
  * **inheritance**:
    * only *reuses implementation and establishes* a **syntactic relationship**
    * not necessarily a **semantic relationship**, inheritance does not ensure behavioral subtyping
* To distinguish these concepts, **subtyping** is also known as **interface inheritance**
 whereas inheritance as defined here is known as implementation inheritance or code inheritance
* Still, inheritance is a commonly used mechanism for establishing subtype relationships

+++
#### Polymorphism
* Is the provision of a *single interface* to *entities of different types*
* A polymorphic type is one whose operations can also be applied to values of some other type, or types

+++
##### Polymorphism types
* **Ad hoc polymorphism**:
  * **Function overloading**
  * *Function denotes different and potentially heterogeneous implementations* depending on a limited range of *individually specified types and combinations*
* **Parametric polymorphism**:
  * Code is written *without mention of any specific type* and thus *can be used transparently with any number of new types*
  * This is often known as **generics** in OOP, and *polymorphism* in functional programming
* **Subtyping** (*subtype polymorphism* or *inclusion polymorphism*):
  * Name denotes instances of many different classes related by some common superclass

---
## Types
* `class` - construction plan for an object
* `enum` - enum data type as known from other languages
* `interface` - mechanism to allow *subtype polymorphism*
* `struct` - value type, alternation to class, do *not allow inheritance*, only *subtyping*

+++//todo
### Class nieco
* **instance** - concrete object, instance of a *class*
* **field** – a member variable inside a class
* **property** – an accessor for a field
* **method** - named procedure of function, encapsulated in a class

+++
### Identificators
  * `null` - a reference that  *points to nowhere*
  * `this` - a reference to a *current instance* of an object
  * `base` - a reference to a *subtype* of a *supper class*

+++
### Access modifiers
* used for limiting access to *implementation details*
* ensure *encapsulation* and leads to safe code
* if a modifier is omitted, the most restrictive one is used

+++
| Modifier | Visibility |
|-|-|
|`private` | visible only *inside of class* |
|`protected` | visible only *inside of class*, and all *inherited types* |
|`public` | visible from *everywhere* |
|`internal` | visible only inside a *same assembly*, or *friendly assembly* |
|`protected internal` | visible only inside a *same assembly*, or *friendly assembly*, only for *inherited types* |

---
## Class
* Most common kind of reference type
* Construction plan for an object
* Encapsulates *data* and *behavior*
  ```C#
  class YourClassName
  {
  }
  ```
  * `static` - only *one* instance for program run
  * *non static* - classes are *instanciated* during program run

+++
### Class can contains
| | |
|-|-|
|Preceding the keyword class |Attributes and class modifier |
|Following YourClass Name    |Generic type parameters, a base class, and interfaces|
|Within the braces           |Methods, properties, indexers, events, fields, constructors...|

+++
### Field
* Variable that is a member of a *class* or *struct**
* Initialization
  * Optional
  * Noninitializatialized has a *default* value (`0, \0, null, false`)
  * Before a constructor call
  ```C#
  class Octopus
  {
    string name;
    public int Age = 10;
  }
  ```

+++
#### Field modifiers
* `static`
* access - `public, internal, private, protected, internal protected`
* inheritance - `new`
* unsafe code - `unsafe`
* `readonly` - cannot be changed after construction
* threading - `volatile`

+++
### Method
* *Procedures* and *functions* are in OOP called *methods*
* Can access members of `class` or `struct`
* Can
  * *accept parameters* - *values*, *reference types*, `ref`
  * *return result* - in return type (`return`), or `ref` or `out` parameters

+++
#### Method modifiers
* `static`
* access - `public, internal, private, protected, internal protected`
* inheritance - `new, virtual, abstract, override, sealed, partial`
* unsafe code - `unsafe, extern`
* asynchronous - `async`

+++
#### Method types
* Method contains only one expression
* Classical method:
  ```C#
  int Foo(int x) { return x * 2; }
  ```
* Expression-bodied metod:
  ```C#
  int Foo(int x) => x * 2;
  ```
* Method can have an empty return type (`void`)
  ```C#
  void Foo(int x) => Console.WriteLine(x);
  ```

+++
* Return type is not a part of the signature
  ```C#
  void Foo (int x) {...}
  int  Foo (int x) {...} // Compile-time error
  ```
* Method overloads can have different return types
  ```C#
  int    Foo (int x) {...}
  double Foo (double x) {...} // OK
  ```

+++
#### Local methods
* Define a method inside another method
* Is visible only to the enclosing method
* Can access the local variables and parameters of the enclosing method
  ```C#
  void WriteCubes()
  {
    Console.WriteLine (Cube (3));
    Console.WriteLine (Cube (4));
    Console.WriteLine (Cube (5));
    int Cube (int value) => value * value * value;
  }
  ```

+++
### Property
* Similar to a *field*, but **it encloses it with access methods**
* It is a safety mechanism that unifies *read* and *write* operations
* Hides *implementation details*

+++
#### Read-only and calculated property
* *Read-only* if it specifies only a *get* accessor
* *Write-only* if it specifies only a set accessor
  * Rarely used

+++
#### Get and set accessibility
* *Get* and *set* accessors can have different access levels
* Typical use:
  * *public* property 
  * *internal* or *private* access modifier on the *setter*
  ```C#
  private decimal y;
  public decimal Y
  {
    get { return y; }
    private set { y = Math.Round (value, 2); }
  }
  ```

+++
#### Property modifiers
* `static`
* access - `public, internal, private, protected, internal protected`
* inheritance - `new, virtual, abstract, override, sealed`
* unsafe code - `unsafe, extern`

+++
#### Property types
* Autogenerated property:
  ```C#
  public string Name {get; set;}
  ```
* Full property (with the backing field):
  ```C#
  private string _name;
  public string Name {
    get { return _name; }
    set { _name = value; }
  }
  ```

+++
#### Expression-bodied property

* With only get accessor:
  ```C#
  public string Name => _name;
  ```
* With set accessor:
  ```C#
  public string Name {
    get => return _name;
    set => _name = value;
  }
  ```

+++
## Constructor

---
## References:
[C# 7.0 in a Nutshell: The Definitive Reference](https://www.amazon.com/C-7-0-Nutshell-Definitive-Reference/dp/1491987650)  

+++
## Refences to used images:
