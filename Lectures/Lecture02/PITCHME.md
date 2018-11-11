﻿# Introduction to object-oriented programming and advanced programming constructs
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

+++?code=/Lectures/Lecture02/Assets/sln/Example/Dog.cs&lang=C#&title=OOP Sample
@[3-14]
@[5-6]
@[8-11, 13]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture02/Assets/sln/Example/Dog.cs)

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
* An *inherited class* is called a **subclass** of its **parent class** or **superclass** or **base class**

+++?code=/Lectures/Lecture02/Assets/sln/Example/Animal;.cs&lang=C#&title=Inheritance Sample
@[3-6]
@[3-4, 6]
@[5]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture02/Assets/sln/Example/Animal.cs)

+++?code=/Lectures/Lecture02/Assets/sln/Example/Dog.cs&lang=C#&title=Inheritance Sample
@[3-14]
@[3-4, 14]
@[8-11]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture02/Assets/sln/Example/Dog.cs)

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
  * Name denotes instances of many different classes related by some common *base* class

---
## Types
* `class` - construction plan for an object
* `enum` - enum data type as known from other languages
* `interface` - mechanism to allow *subtype polymorphism*
* `struct` - value type, alternation to class, do *not allow inheritance*, only *subtyping*

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

+++
### Static / non static
* `static` - **only one** instance for program run
* *non static* - classes are **instanciated** during program run

+++
### Class can contains
| | |
|-|-|
|Preceding the keyword class |Attributes and class modifier |
|Following YourClass Name    |Generic type parameters, a base class, and interfaces|
|Within the braces           |Methods, properties, indexers, events, fields, constructors...|

+++
* **field** – a member variable
* **property** – an accessor for a field
* **method** - named procedure of function
* **event** - notifies object change
* **constructor** - **method** that run initialization code

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
* access - `public, internal, private, protected`
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
* access - `public, internal, private, protected`
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
* access - `public, internal, private, protected`
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
### Constructor
* Run initialization code on a class or struct
* Defined like a method
  * Method name and return type are reduced to the name of the enclosing type
* Constructors of *base* class are accessible

+++?code=/Lectures/Lecture02/Assets/sln/Example/Panda.cs&lang=C#&title=Constructor Sample
@[3-10]
@[6-7, 9]
@[5, 8]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture02/Assets/sln/Example/Panda.cs)

+++
#### Implicit parameterless constructor
* `public`, *parameterless*
* Generated by C# compiler automatically 
* If and only **if you do not define any constructors**

+++
#### Constructor modifiers
* Access - `public, internal, private, protected`
* Unsafe code - `unsafe, extern`

+++
#### Constructor overloading
* Type can have multiple constructors
* The same rules as method overloading
* Protects against code duplication and increases readability
* Keywords
  * `this` - refers to *this* type instance 
  * `base` - refers to *base* class type instance

+++?code=/Lectures/Lecture02/Assets/sln/Example/Cat.cs&lang=C#&title=Constructor Overloading Sample
@[3-21]
@[5-6]
@[8-11]
@[12-15]
@[8-15]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture02/Assets/sln/Example/Cat.cs)

+++
### Deconstructors
* Opposite to a constructor
* C# 7
* Deconstruction method must
  * Be called **Deconstruct**
  * Have one or more out parameters

+++?code=/Lectures/Lecture02/Assets/sln/Example/Rectangle.cs&lang=C#&title=Deconstructor Sample
@[3-18]
@[5]
@[7-11]
@[13-17]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture02/Assets/sln/Example/Rectangle.cs)

+++
#### Call deconstructor
```C#
var rect = new Rectangle (3, 4);
(float width, float height) = rect; // Deconstruction
Console.WriteLine (width + " " + height); // 3 4
```
or
```C#
float width, height;
rect.Deconstruct (out width, out height);
```
or
```C#
rect.Deconstruct (out var width, out var height);
```
or
```C#
(var width, var height) = rect;
```
or simply
```C#
var (width, height) = rect;
```

+++
### Finalizer
* Runs on instance that is no more referenced before is garbage collected
* `override`s `System.Object`'s method `Finalize()`

```C#
protected override void Finalize() {
  // Cleanup code
  ...
  base.Finalize();
}
```
or simply
```C#
class Dog {
  ~Dog()   {
    // Cleanup code
    ...
  }
}
```


+++
### Abstract class
* **Can never be instantiated**
* Only its concrete subclasses can be instantiated
* Cannot be sealed, thus must be possible to inherit from it
* Able to define abstract members:
  * Like virtual members, except they don’t provide a default implementation
  * Implementation must be provided by the subclass unless that subclass is also declared
abstract

+++
### Abstract class example
```C#
public abstract class Asset
{
 // Note empty implementation
 public abstract decimal NetValue { get; }
}

public class Stock : Asset
{
 public long SharesOwned;
 public decimal CurrentPrice;
 // Override like a virtual method.
 public override decimal NetValue => CurrentPrice * SharesOwned;
}
```

+++
### Virtual
* Can be overridden by subclasses wanting to provide a specialized implementation
* Activation uses mechanism of late binding which chooses the appropriate implementation during runtime
* Virtual can be:
  * Methods
  * Properties
  * Indexers
  * Events

+++ 
### Type compatibilty
* Easeup usage of *subtypes*, ergo *virtual methods*
* Compatibility of *types* of `class`, `struct` instances
* Determines, to which type reference can be assigned reference of another type

+++
#### Upcast
* Creates a *base* class reference from a *subclass* reference
* Only *members* provided by given *base* class can be accessed through upcasted reference

+++?code=/Lectures/Lecture02/Assets/sln/Example/UpCast.cs&lang=C#&title=Upcast Example
@[5-14]
@[8-13]
@[10]
@[11]
@[12]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture02/Assets/sln/Tests/UpCast.cs)

+++
#### Downcast
* Creates a *subclass* reference from a *base* class reference
* It **fails**, if *base* class instance is not compatible with *inherited* one

+++?code=/Lectures/Lecture02/Assets/sln/Example/DownCast.cs&lang=C#&title=Downcast Example
@[6-22]
@[9-14]
@[11]
@[12]
@[13]
@[17-21]
@[19]
@[20]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture02/Assets/sln/Tests/DownCast.cs)

+++
#### Operator `as`
* Downcasts
* Return `null` if fails

+++?code=/Lectures/Lecture02/Assets/sln/Example/AsOperator.cs&lang=C#&title=AS Operator Example
@[5-13]
@[8-12]
@[10]
@[11]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture02/Assets/sln/Tests/AsOperator.cs)

+++
#### Operator `is`
* Tests whether a reference conversion would
* Usually before downcast

+++?code=/Lectures/Lecture02/Assets/sln/Example/IsOperator.cs&lang=C#&title=IS Operator Example
@[5-13]
@[8-12]
@[10]
@[11]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture02/Assets/sln/Tests/IsOperator.cs)

+++?code=/Lectures/Lecture02/Assets/sln/Example/PatternMatching.cs&lang=C#&title=IS Pattern Matching Example
@[5-27]
@[8-16]
@[10]
@[11-12,14]
@[13,15]
@[19-26]
@[21]
@[22-23, 25]
@[24]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture02/Assets/sln/Tests/PatternMatching.cs)

+++
### Sealed
* Restricts
  * Inderitance of `class`
  * Override of *method*

```C#
class Animal { }
 
sealed class Cat : Animal { }
 
//Compile-time error
public class Kitten : Cat {}
```

+++
### System.Object
* Object (`System.Object`) is a common *base* class of all types
* Each type can be cast to `System.Object`
* `System.Object` methods:
  * ToString()
  * Equals()
  * GetHashCode()
  * GetType()
* To get instance type:
  * during *runtime* - `Object.GetType()`
  * during *compile time* - `typeof(object)`

+++
### Partial
* Allows split across multiple files
* Each participant must have the `partial` declaration
* Typically ised in WPF, Winforms
  * one file is auto-generated
  * one file is human edited

```C#
partial class PaymentForm // In auto-generated file
{
  ...
  partial void ValidatePayment (decimal amount);
}
partial class PaymentForm // In hand-authored file
{
  ...
  partial void ValidatePayment (decimal amount)
  {
    if (amount > 100)
    ...
  }
}
```

---
## Struct
* Similar to a class, with the following key differences:
  * A `struct` is a **value type**, whereas a class is a **reference type**
  * A `struct` does not support inheritance (other than implicitly deriving from `System.ValueType`)
* Can have all the members a class can, except:
  * A parameterless constructor
  * Field initializers
  * A finalizer
  * Virtual or protected members
* Each constructor has to initialize all `struct`'s members
* Cannot initialize members in declaration

```C#
public struct Point
{
  int x, y;
  public Point (int x, int y)
  {
    this.x = x; 
    this.y = y;
  }
}
...
Point p1 = new Point (1, 1); // p1.x and p1.y will be 1
Point p2 = new Point (); // p2.x and p2.y will be 0
```

---
## Enums, Flags 
* `enum` is a *value type*
  * creates an enumeration of named numerical values (int, 0,1...)
  * underlying type can be changed to `long`

* `enum` with the attribute `flags`
  * *single variable* may contain *multiple values*

```C#
private enum HorseColor { Siml = 0, Palomino = 5, Ryzak = 10 }

HorseColor color = HorseColor.Siml;
int colorNumber = (int)HorseColor.Ryzak;

HorseColor.TryParse("Ryzak", out HorseColor color);

[Flags] public enum HorseType { None = 0, Racing = 1, 
Breeding = 2, ForSosages = 4, Dead = 8 }

HorseType type = HorseType.Racing | HorseType.Breeding;
type |= HorseType.ForSosages;
Console.WriteLine(type); //Racing, Breeding, ForSosages
```

---
## Interface
* Declares only *specification*, not *implementation* of its members
* All members are `public`
* `class` or `struct` can implement **multiple** `interface`s
* Implementation is provided by `class` or `struct` that implementats particular `interface`
* `interface` can declare
  * methods
  * properties
  * events
  * indexers

```C#
// Defined in System.Collections
public interface IEnumerator
{
  bool MoveNext();
  object Current { get; }
  void Reset();
}
```

+++
#### `interface` vs `abstract`

* Use *inheritance* for types that share its implementation
* Use `interface` for types that have independent implementations
* A `class`, or `struct` can implement multiple interfaces

```C#
abstract class Animal { }
abstract class Bird : Animal { }
abstract class Insect : Animal { }

interface IFlying {}
interface ICarnivore {}

// Concrete classes:
class Ostrich : Bird { }
class Eagle : Bird, IFlying, ICarnivore { }
class Bee : Insect, IFlying { }
class Flea : Insect, ICarnivore { }
```

* Because animals might share some implementation of their taxonomy, it is possible to declare `Bird` and `Insect` as `abstract class`.
* But, their food intake and whether they fly or not might differ. It is best to declare these properties as `interfaces`, `IFlying` and `ICarnivore`.

+++
#### `class` vs `interface`
* `class` is considered to be *type*
  * *Data* are stored in member variables
  * *Operations* are declared in methods
* `interface` 
  * describes `class` members
  * behavior is defined in `class` that implements it
* *Multiple inheritance* is not supported
* *Multiple* `interface` *implementation* is supported

```C#
 public interface IBoy {
    string Name {get;}
  }

  public class Boy: IBoy {
    public string Name { }
  }
```

+++
#### Type Safety and Security
* **Strongly typed language**
  * *type* has to be known in *compile time*
* Support of Intellisence in Visual Studio
* Keyword `dynamic` overcomes type safety mechanisms, and type is resolved in *runtime*
* Benefits:
  * Elimination of type issues in  *compile time*
  * Sandboxing protects object state against outer modifications

---
## Exceptions
* Built-in error handling
* Helps to clean-up code
* `try` block
  * Must be followed by:
    * `catch` block
    * `finally` block
    * or both
* `catch` block
  * Executes when an error occurs in the `try` block
  * Has access to an Exception object that contains information about the error
* `finally` block
  * Executes after execution leaves the try block (or if present, the catch block)
  * Whether or not an error occurred

+++
### try, catch, finally example
```C#
try
{
 ... // exception may get thrown within execution of this block
}
catch (ExceptionA ex)
{
 ... // handle exception of type ExceptionA
}
catch (ExceptionB ex)
{
 ... // handle exception of type ExceptionB
}
finally
{
 ... // cleanup code
}
```

+++
### Exception `thrown`
* If exception is in `try` statement:
  * Execution is passed to the compatible `catch` block
  * If the `catch` block successfully finishes
    * If present, Execution is passed to `finally` block
    * Execution moves to the next statement after the `try` statement
* If exeption isn't in `try statement:
  * Execution jumps back to the caller of the function and test is repeated
* If no function takes responsibility for the exception, an error dialog box is displayed to the user, and the program terminates

+++
### The `catch` block
* Specifies what type of exception to catch
  * This must either be `System.Exception` or a subclass of `System.Exception`
* Can handle multiple exception types with multiple catch clauses
* Only one catch clause executes for a given exception
  * Only one catch clause executes for a given exception
  *  If you want to catch more general exceptions you must put the more specific handlers first

+++
#### Multiple `catch` clauses example

```C#
class Test
{
  static void Main (string[] args)
  {
    try
    {
      byte b = byte.Parse (args[0]);
      Console.WriteLine (b);
    }
    catch (IndexOutOfRangeException ex)
    {
      Console.WriteLine ("Please provide at least one argument");
    }
    catch (FormatException ex)
    {
      Console.WriteLine ("That's not a number!");
    }
    catch (OverflowException ex)
    {
      Console.WriteLine ("You've given me more than a byte!");
    }
  }
}
```

+++
* Exception can be caught without specifying a variable
  ```C#
  catch (OverflowException) // no variable
  {
  ...
  }
  ```
* Furthermore, you can omit both the variable and the type
  ```C# 
  ```C# 
  {
    ...
  }
++
* Always executes
  * Whether or not an exception is thrown
  * Whether or not the `try` block runs to completion
* Typically used for cleanup code

+++
#### The `finally` block example

```C#
static void ReadFile()
{
  StreamReader reader = null; // In System.IO namespace
  try
  {
    reader = File.OpenText ("file.txt");
    if (reader.EndOfStream) return;
    Console.WriteLine (reader.ReadToEnd());
  }
  finally
  {
    if (reader != null) reader.Dispose();
  }
}
```

+++
### Throwing Exceptions Example
```C#
class Test
{
  static void Display (string name)
  {
    if (name == null)
      throw new ArgumentNullException (nameof (name));
    Console.WriteLine (name);
  }

  static void Main()
  {
    try { Display (null); }
    catch (ArgumentNullException ex)
    {
      Console.WriteLine ("Caught the exception");
    }
  }
}
```
### Rethrow examples
* Rethrow same exception
```C#
try { ... }
catch (Exception ex)
{
  // Log error
  ...
  throw; // Rethrow same exception
}
```C#
{
  ... // Parse a DateTime from XML element data
}
catch (FormatException ex)
{
  throw new XmlException ("Invalid DateTime", ex);
}

+++
### Key Properties of `System.Exception`

* `StackTrace`
  * A string representing all the methods that are called from the origin of the exception to the catch block
* `Message`
  * A string with a description of the error
* `InnerException`
  * InnerException may have another InnerException

+++
### Common Exception Types
* `System.ArgumentException`
  * Thrown when a function is called with a bogus argument
* `System.ArgumentNullException`
  * Subclass of `ArgumentException`
  * Thrown when a function argument is (unexpectedly) null
* `System.ArgumentOutOfRangeException`
  * Subclass of `ArgumentException`
  * When a (usually numeric) argument is out of radge (usually too big or too small)
* `System.InvalidOperationException`
  * Thrown when the state of an object is unsuitable for a method to successfully execute
* `System.NotSupportedException`
  * Thrown to indicate that a particular functionality is not supported
* `System.NotImplementedException`
  * Thrown to indicate that a function has not yet been implemented
* `System.ObjectDisposedException`
  * Thrown when the object upon which the function is called has been disposed
* `NullReferenceException`
  * The CLR throws this exception
  * Thrown when you attempt to access a member of an object whose value is null
---
## References:
[C# 7.0 in a Nutshell: The Definitive Reference](https://www.amazon.com/C-7-0-Nutshell-Definitive-Reference/dp/1491987650)  