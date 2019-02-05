# .NET Standard and Language Integrated Query(LINQ)
## .NET Standard libraries, collections, MSSQL, XML
<div class="right">
[ Michal Orlicek <xorlic00@stud.fit.vutbr.cz> ]
</div>

---
## .NET Standard
* Formal specification of .NET APIs 
* Intended to be available on all .NET implementations
* Establishing greater uniformity in the .NET ecosystem
* [.NET Standard github](https://github.com/dotnet/standard)
* [Introduction to .NET Standard](https://blogs.msdn.microsoft.com/dotnet/2016/09/26/introducing-net-standard/)

+++
### .NET Standard enables
* Uniform **set of APIs** for all .NET implementations to implement, independent of workload
* Produce **portable libraries** that are *usable across .NET implementations*, using same set of APIs
* **Reduces conditional compilation** of *shared source* due to .NET APIs

+++
#### .NET Today

<div class="center" >
<img src="/Lectures/Lecture03/Assets/img/NetToday.png" />
</br>
</div>

+++
#### .NET Tomorrow

<div class="center" >
<img src="/Lectures/Lecture03/Assets/img/NetTomorrow.png" />
</br>
</div>

+++
### .NET Standard vs .NET Core
* **.NET Standard**
  * *specification* that *covers which APIs a .NET platform has to implement*
* **.NET Core**
  * **concrete .NET platform**
  * *implements the .NET Standard*

+++
### .NET Standard versions
* Higher versions **incorporate** all APIs from previous versions
* Once shipped, versions are frozen
* Specific .NET platform to .NET Standard
  * .NET Standard version depends on which version of .NET Standard the platform is implementing
* .NET Standard version choise
  * The higher the version, the more APIs are available to you
  * The lower the version, the more platforms you can run on

+++
#### .NET Standard Version Table

<div class="center" >
<img src="/Lectures/Lecture03/Assets/img/NetStandardVersionTable.png" />
</br>
</div>

+++
### Why .NET Standard 2.0 instead of 1.7?
* More than doubled the API surface
  * Added a compat shim that allows referencing existing binaries
    * Even if they weren't built against *.NET Standard*

+++
### .NET Standard Version Growing

| Version |  #APIs | Growth % |
|:--------|-------:|---------:|
| 1.0     |  7,949 |          |
| 1.1     | 10,239 |     +29% |
| 1.2     | 10,285 |      +0% |
| 1.3     | 13,122 |     +28% |
| 1.4     | 13,140 |      +0% |
| 1.5     | 13,355 |      +2% |
| 1.6     | 13,501 |      +1% |
| 2.0     | 32,638 |    +142% |

+++
### .NET API
* [.NET Standard API](https://docs.microsoft.com/sk-sk/dotnet/api/?view=netstandard-2.0)
* API(Application programming interface):
  * Set of namespaces(classes, structs, interfaces, enums, delegates)
  * Allow the creation of applications which access the features or data of an:
    * Operating system
    * Application
    * Other service..

---
## `System` Namespace
* `using System`
* [Documentation](https://docs.microsoft.com/sk-sk/dotnet/api/system?view=netstandard-2.0)
* Fundamental classes and base classes
* Define:
  * Commonly-used value and reference data types
  * Events and event handlers
  * Interfaces
  * Attributes
  * Processing exceptions

+++
## Data types
* `class Object` - ultimate base class of all classes in the .NET
* `class String` - represents a String
* `class Array` -  represents an Array
* `class Delegate` - represents a delegate
* `class Enum` - base class for enumerations
* `class Tuple` - provides methods for creating tuple objects

+++
## Sctruct types
* `struct Boolean`
* `struct Byte`, `struct SByte`
* `struct Char`
* `struct DateTime`
* `struct Decimal`, `struct Double`
* `struct Guid`
* `struct Int16`, `struct Int32`, `struct Int64`, `struct IntPtr`
* `struct UInt16`, `struct UInt32`, `struct UInt64`, `struct UIntPtr`
* `struct Nullable<T>`
* `struct void`


+++
## Type
* `class Type`
* Represents type declarations
  * class types
  * interface types
  * array types
  * value types
  * enumeration types
  * type parameters
  * generic type definitions

```C#
Type type = typeof(String);

MethodInfo methodInfo = 
type.GetMethod("Substring", new Type[] { typeof(int), typeof(int) });

Object result = methodInfo.Invoke("Hello, World!", new Object[] { 7, 5 });
Console.WriteLine("{0} returned \"{1}\".", methodInfo, result);
```

+++
## ValueType
* `class ValueType`
* Provides the base class for value types

```C#
public static bool IsFloat(ValueType value) 
{
    return (value is float | value is double | value is Decimal);
}
```

+++
## Convert
* `class Convert`
* Converts a base data type to another base data type

```C#
try {
  int intNumber = System.Convert.ToInt32(fooNumber);
}
catch (System.OverflowException) {
  System.Console.WriteLine(
    "Overflow in double to int conversion.");
}
```

+++?code=/Lectures/Lecture03/Assets/sln/Tests/ConvertTest.cs&lang=C#&title=Convert Sample
@[9-21]
@[12,17]
@[13,18]
@[14,19]
@[15,20]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture03/Assets/sln/Tests/Convert.cs)

+++
## Bit Converter
* `class BitConverter` 
* **Converts:**
  * *Base data types* to an *array of bytes*
    * `GetBytes(Boolean)`, `GetBytes(Int32)` `GetBytes(Char)`...
  * *Array of bytes* to *base data types*
    * `ToBoolean(Byte[], Int32)`, `ToInt32(Byte[], Int32)`, `ToChar(Byte[], Int32)`...

```C#
bool sample = true;
byte[] sampleByteArray = BitConverter.ToString(BitConverter.GetBytes(sample);
Console.WriteLine(BitConverter.ToString(sampleByteArray)); //01
```

+++?code=/Lectures/Lecture03/Assets/sln/Tests/BitConverterTest.cs&lang=C#&title=Bit Converter Sample
@[9-16]
@[11]
@[12]
@[13]
@[15]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture03/Assets/sln/Tests/BitConverterTest.cs)

+++
## URI
* Uniform Resource Identifier
  * String that identifies a particular resource
  * Predefined set of syntax rules

<div class="center" >
<img src="/Lectures/Lecture03/Assets/img/UriSyntax.png" />
</br>
</div>

+++
### URI examples

```URI
          userinfo     host        port
          ┌─┴────┐ ┌────┴────────┐ ┌┴┐ 
  https://john.doe@www.example.com:123/forum/questions/?tag=networking#top
  └─┬─┘ └───────┬────────────────────┘└─┬─────────────┘└──┬──────────┘└┬─┘
  scheme     authority                 path              query     fragment

  ldap://[2001:db8::7]/c=GB?objectClass?one
  └─┬┘ └───────┬─────┘└─┬─┘ └──────┬──────┘
 scheme    authority  path       query

  mailto:John.Doe@example.com
  └──┬─┘ └─────────┬────────┘
  scheme         path

  tel:+1-816-555-1212
  └┬┘ └──────┬──────┘
scheme     path

  telnet://192.0.2.16:80/
  └──┬─┘ └──────┬──────┘│
  scheme    authority  path
```

+++ 
### URI Standard
* `class Uri`- representation of URI
* `UriBuilder` - custom URI constructors
* Another classes:
  * `UriFormatException`, `UriTypeConverter`, `FtpStyleUriParser`, `HttpStyleUriParser`...
* Enums:
  * `UriComponents`, `UriFormat`, `UriHostNameType`...

```C#
var uri = new Uri("http://www.contoso.com/");
WebRequest webRequest = WebRequest.Create(uri);
```

+++?code=/Lectures/Lecture03/Assets/sln/Tests/UriTest.cs&lang=C#&title=Uri Sample
@[9-15]
@[11,12]
@[14]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture03/Assets/sln/Tests/UriTest.cs)

+++
## Console
* `class Console` - standard input, output, and error streams for console applications
* Struct:
  * `ConsoleKeyInfo`
* Enums:
  * `ConsoleKey`, `ConsoleSpecialKey`, `ConsoleSpecialKey`...

```C#
Console.WriteLine("Prints on ");
Console.WriteLine("New line");

Console.Write("Prints on ");
Console.Write("Same line");

Console.ReadLine();
```

+++?code=/Lectures/Lecture03/Assets/sln/Examples/ConsoleSample.cs&lang=C#&title=Console Sample
@[7-20]
@[9]
@[11-12,19]
@[13]
@[15-16]
@[18]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture03/Assets/sln/Examples/ConsoleSample.cs)

+++
## Garbage Collector
* `class GC`
* Controls garbage collector
  * Service that automatically reclaims unused memory

```C#
void MakeSomeGarbage()
{
    for(int i = 0; i < 1000; i++)
    {
        var o = new Object();
    }
}

MakeSomeGarbage();
GC.Collect();
```

+++
## Math
* `class Math`
* Provides constants and static methods for
  * Trigonometric mathematical functions
  * Logarithmic mathematical functions
  * Other common mathematical functions

```C#
double circleRadius = 4.2;
double circlePerimeter = ((2 * Math.PI) * circleRadius);
double circleArea = Math.PI * (Math.Pow(circleRadius, 2));
```

+++
## Random
* `class Random`
* Represents a pseudo-random number generator
* Device that produces a sequence of numbers that meet certain statistical requirements for randomness

```C#
Random random = new Random();
for (var i = 1; i <= 10; i++)
    Console.WriteLine("{0,15:N0}", random.Next());
// The example output
//         1,733,189,596
//           566,518,090
//         1,166,108,546
//         1,931,426,514
//         1,341,108,291
//         1,012,698,049
//           890,578,409
//         1,377,589,722
//         2,108,384,181
//         1,532,939,448
```

+++
## Version
* `class Version`
* Represents the version number of 
  * Assembly
  * Operating system
  * Common language runtime

```C#
// Get the operating system version.
OperatingSystem operatingSystem = Environment.OSVersion;
Version version = operatingSystem.Version;
Console.WriteLine("Operating System: {0} ({1})", operatingSystem.VersionString, version.ToString());
```

```C#
// Get the common language runtime version.
Version version = Environment.Version;
Console.WriteLine("CLR Version {0}", version.ToString());
```

+++
## Another important classes
* `class Buffer` - manipulates arrays of primitive types
* `class Environment` - information about the current environment and platform
* `class Lazy<T>` - support for lazy initializatio
* `class StringComparer` - represents a string comparison operation
* `class Attribute` - represents the base class for custom attributes
* `class SerializableAttribute` - indicates that a class can be serialized
* `class Nullable` - supports a value type that can be assigned null e.g. `int?`
* `class WeakReference` - references an object while still allowing that object to be reclaimed by GC

+++
## `System` Namespace Exceptions
* **50+ basic exceptions**
  * `class Exception` - base class for all exceptions
  * `class SystemException` - base class for system exceptions
  * ⋮

+++
## Action and Func delegates
* **Action** -  method that does not return a value
```C#
delegate void Action(); //has no parameters
delegate void Action<in T>(T obj); //has one parameter
delegate void Action<in T1,in T2>(T1 arg1, T2 arg2); //has two parameters
⋮
```

* **Func** - method that has no parameters and returns a value of the type specified by the TResult parameter
```C#
delegate TResult Func<out TResult>(); //has no parameters
delegate TResult Func<in T,out TResult>(T arg); //has one parameter
delegate TResult Func<in T1,in T2,out TResult>(T1 arg1, T2 arg2); //has two params
⋮
```

+++
## Event handlers
* Methods that will handle an *event*
  * `delegate void EventHandler(object sender, EventArgs e)`
    * Event that has **no data**
  * `delegate void EventHandler<TEventArgs>(object sender, TEventArgs e)`
    * Event that **provides data**
  * `delegate void ConsoleCancelEventHandler(object sender, ConsoleCancelEventArgs e)`
  * `delegate System.Reflection.Assembly ResolveEventHandler(object sender, ResolveEventArgs args)`
  * `delegate void UnhandledExceptionEventHandler(object sender, UnhandledExceptionEventArgs e)`
  * ⋮

+++
## Another important delegates
* `delegate int Comparison<in T>(T x, T y)` 
  * Method that compares two objects of the same type
* `delegate void AsyncCallback(IAsyncResult ar)` 
  * Method to be called when a corresponding asynchronous operation completes
* `delegate TOutput Converter<in TInput,out TOutput>(TInput input)` 
  * Method that converts an object from one type to another type

---
## `System.Collections` Namespace
* `using System.Collections`
* [Documentation](https://docs.microsoft.com/en-us/dotnet/api/system.collections?view=netstandard-2.0)
* Contains interfaces and classes that define various collections
* Define:
  * Lists
  * Queues
  * Bit arrays
  * Hash tables
  * Dictionaries

+++
## ArrayList 
* `class ArrayList`
* Using an array whose size is dynamically increased as required
* Implements the `IList` interface
  * `interface IList`
  * Defines non-generic collection of objects that can be individually accessed by index

+++?code=/Lectures/Lecture03/Assets/sln/Examples/ArrayListSample.cs&lang=C#&title=ArrayList Sample
@[8-25]
@[11-14]
@[17-19]
@[21-24]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture03/Assets/sln/Examples/ArrayListSample.cs)

+++
## Stack
* `class Stack`
* Simple last-in-first-out non-generic collection of objects
* Implements the `ICollection` interface
  * `interface ICollection`
  * Defines *size*, *enumerators*, and *synchronization* methods for all nongeneric collections
* Implements the `IEnumerable` interface
  * `interface IEnumerable`
  * Exposes an *enumerator*, which supports a simple iteration over a non-generic collection

+++?code=/Lectures/Lecture03/Assets/sln/Examples/StackSample.cs&lang=C#&title=Stack Sample
@[8-24]
@[11-14]
@[17-18]
@[20-23]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture03/Assets/sln/Examples/StackSample.cs)

+++
## Queue
* `class Queue`
* First-in, first-out collection of objects
* Implements the `ICollection` interface
* Implements the `IEnumerable` interface

+++?code=/Lectures/Lecture03/Assets/sln/Examples/QueueSample.cs&lang=C#&title=Queue Sample
@[8-24]
@[11-14]
@[17-18]
@[20-23]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture03/Assets/sln/Examples/QueueSample.cs)

+++
## Hashtable
* `class Hashtable`
* Collection of key/value pairs that are organized based on the hash code of the key
* Implements the `IDictionary` interface
  * `interface IDictionary`
  * Nongeneric collection of key/value pairs

+++?code=/Lectures/Lecture03/Assets/sln/Tests/HashtableTest.cs&lang=C#&title=Hashtable Sample
@[10-24]
@[13, 17-21]
@[22]
@[23]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture03/Assets/sln/Tests/HashtableTest.cs)

+++
## Another Collections 
* `class BitArray`
  * Compact array of bit values, which are represented as Booleans
* `class SortedList`
  * Collection of key/value pairs that are sorted by the keys 

```C#
bool[] boolArray = new bool[5] { true, false, true, true, false };
BitArray bitArray = new BitArray( boolArray );

foreach ( var bit in bitArray ) {
    Console.Write(bit);
}
```

```C#
SortedList sortedList = new SortedList();
sortedList.Add("Third", "!");
sortedList.Add("Second", "World");
sortedList.Add("First", "Hello");
```

+++
## Base classes
* collection `abstract` **base classes**:
  * `class CollectionBase` - for a strongly typed collection
  * `class DictionaryBase` - for a strongly typed collection of key/value pairs
  * `class ReadOnlyCollectionBase` - for a strongly typed non-generic read-only collection

---
## `System.Collections.Generic` Namespace
* `using System.Collections.Generic`
* [Documentation](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic?view=netstandard-2.0)
* Contains interfaces and classes that define generic collections
* Allow users to create strongly typed collections
  * Provide better type safety and performance

+++
## Generic List
* `class List<T>`
* **Strongly typed** list of objects that can be accessed by index
* Provides methods to
  * Search
  * Sort
  * Manipulate 
* **Type Parameter** `T`
  * The type of elements in the list
* `class SortedList<TKey,TValue>`
  * Key/value pairs that are sorted by key based on the associated `IComparer<T>` implementation
  * `class IComparer<T>`

+++?code=/Lectures/Lecture03/Assets/sln/Tests/GenericListTest.cs&lang=C#&title=Generic List Sample
@[9-18]
@[21-27]
@[30-36]
@[39-44]
@[47-54]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture03/Assets/sln/Tests/GenericListTest.cs)

+++
## Generic Stack
* `class Stack<T>`
* Variable size 
* Last-in-first-out collection 
  * Instances of the **same specified type**

+++?code=/Lectures/Lecture03/Assets/sln/Tests/GenericStackTest.cs&lang=C#&title=Generic Stack Sample
@[9-19]
@[11-16]
@[18]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture03/Assets/sln/Tests/GenericStackTest.cs)

+++
## Generic Queue
* `class Queue<T>`
* Variable size 
* First-in, first-out collection
* Collection of instances of the **same specified type**

+++?code=/Lectures/Lecture03/Assets/sln/Tests/GenericQueueTest.cs&lang=C#&title=Generic Queue Sample
@[9-19]
@[11-16]
@[18]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture03/Assets/sln/Tests/GenericQueueTest.cs)

+++
## Generic Dictionary
* `class Dictionary<TKey,TValue>`
* Variable size 
* First-in, first-out collection
* Collection of instances of the **same specified type**
* `class Dictionary<TKey,TValue>.KeyCollection`
  * Collection of keys in dictionary
* `class Dictionary<TKey,TValue>.ValueCollection`
  * Collection of values in dictionary
* `class SortedDictionary<TKey,TValue>`
  * Dictionary that is sorted on the key
* **Type Parameters** 
  * `TKey` - the type of the keys in the dictionary
  * `TValue` - the type of the values in the dictionary

+++?code=/Lectures/Lecture03/Assets/sln/Tests/GenericDictionaryTest.cs&lang=C#&title=Generic Dictionary Sample
@[9-20]
@[11-16]
@[18-19]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture03/Assets/sln/Tests/GenericDictionaryTest.cs)

+++ 
## HashSet
* `class HashSet<T>` 
* Set of values
* Contains no duplicate elements
* Elements are in no particular order
* Provides high-performance set operations
* `class SortedSet<T>`
  * Hashset that is maintained in sorted order

+++?code=/Lectures/Lecture03/Assets/sln/Tests/HashSetTest.cs&lang=C#&title=HashSet Sample
@[9-18]
@[11-13]
@[15-17]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture03/Assets/sln/Tests/HashSetTest.cs)

+++
## Generic Interfaces
|  Interface | Description |
|:-:|:- |
| `ICollection<T>` | Defines methods for generic collections |
| `IDictionary<TKey,TValue>` | Define methods for generic dictionaries |
| `IList<T>` | Define methods for generic lists |
| `ISet<T>` | Define methods for generic sets |
| `IReadOnlyCollection<T>` | Define methods for generic read-only collections |
| `IReadOnlyDictionary<TKey,TValue>` | Define methods for generic read-only dictionaries |
| `IReadOnlyList<T>` | Define methods for generic read-only lists |
| `IComparer<T>` | Defines a method that a type implements to compare two objects |
| `IEnumerable<T>` | Exposes the enumerator, which supports a simple iteration over a collection of a specified type |


---
## `System.IO` Namespace
* `using System.IO`
* [Documentation](https://docs.microsoft.com/en-us/dotnet/api/system.io?view=netstandard-2.0)
* Types that provide **file and directory support**
* Types that allow **reading** and **writing to files**
  * Data streams

+++
## Path
  * `class Path`
  * *Operations* on `string` instances that contain file or directory path information
  * Performed in a cross-platform manner

```C#
string path1 = @"c:\temp\MyTest.txt";
string path2 = @"c:\temp\MyTest";
string path3 = @"temp";

if (Path.HasExtension(path1)) 
{
    Console.WriteLine("{path1} has an extension.");
}

if (!Path.HasExtension(path2)) 
{
    Console.WriteLine("{path2} has no extension.");
}

Console.WriteLine($"The full path of {path3} is {Path.GetFullPath(path3)}.");
Console.WriteLine($"{Path.GetTempPath()} is the location for temporary files.");
Console.WriteLine($"{Path.GetTempFileName()} is a file available for use.");
```

+++
## Static vs Instance
* Classes that provides static methods
  * **Directory**
  * **File**
* Classes that provides properties and instance methods
  * **FileSystemInfo** (`abstract` base class)
    * **DirecoryInfo**
    * **FileInfo**
* *Static methods* perform *security checks on all methods*
* For **one action** is **static variant** better than instance one
* For **reuse** is better **instance one**, because the security check will not always be necessary

+++
## Directory and File
* `class Directory` and `class File`
* `static` methods
* **Directory**
  * *Creating*, *moving*, *deleting*, *renaming*, *copying* directories
  * *Enumerating* through subdirectories and subfiles
* **File**
  * *Creating*, *moving*, *deleting*, *renaming* *copying* files
  * *Opening* and *appending* to a file
  * Creation of `FileStream` objects

+++?code=/Lectures/Lecture03/Assets/sln/Examples/DirectorySample.cs&lang=C#&title=Directory Sample
@[8-21]
@[10-11]
@[13-20]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture03/Assets/sln/Examples/DirectorySample.cs)

+++?code=/Lectures/Lecture03/Assets/sln/Examples/FileSample.cs&lang=C#&title=File Sample
@[8-16]
@[10]
@[12-13]
@[15]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture03/Assets/sln/Examples/FileSample.cs)

+++
## DirecoryInfo and FileInfo
* `class DirectoryInfo` and `class FileInfo`
* Properties and instance methods
* **DirectoryInfo**
  * *Creating*, *moving*, *deleting*, *renaming*, *copying* directories
  * *Enumerating* through subdirectories and subfiles
* **File**
  * *Creating*, *moving*, *deleting*, *renaming* *copying* files
  * *Opening* and *appending* to a file
  * Creation of `FileStream` objects

+++?code=/Lectures/Lecture03/Assets/sln/Examples/DirectoryInfoSample.cs&lang=C#&title=DirectoryInfo Sample
@[8-34]
@[10-11]
@[12-13,29-33]
@[14-20]
@[22-24]
@[26-28]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture03/Assets/sln/Examples/DirectoryInfoSample.cs)

+++?code=/Lectures/Lecture03/Assets/sln/Examples/FileInfoSample.cs&lang=C#&title=FileInfo Sample
@[8-20]
@[10]
@[12-13]
@[15-16]
@[18-19]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture03/Assets/sln/Examples/FileInfoSample.cs)

+++
## Data Streams
* `Stream Class` 
* Abstract base class of all streams
* **Abstraction of a sequence of bytes**, such as
    * *File**
    * *Input/output device**
    * *Inter-process communication pipe**
    * *TCP/IP socket**
    * ⋮
* **Fundamental operations**
  * *Reading* - ransfer of data from a stream into a data structure,
  * *Writing* - transfer of data from a data structure into a stream.
  * *Seeking*(optional) - querying and modifying the current position within a stream

+++
## File Stream
* `class FileStream`
* Stream for a file
* **Synchronous** and **asynchronous**
* **Read** and **write** operations

```C#
using (FileStream fileStream = File.OpenRead(@"c:\test.txt"))
{
    byte[] b = new byte[1024];
    UTF8Encoding encoding = new UTF8Encoding(true);
    while (fileStream.Read(b,0,b.Length) > 0)
    {
        Console.WriteLine(encoding.GetString(b));
    }
}
```

+++
## Stream Writer and Stream Reader
* `class StreamWriter` and `class StreamReader`
* Reads characters from a byte stream
* Writes characters to a stream
* In a **particular encoding**

+++?code=/Lectures/Lecture03/Assets/sln/Examples/StreamWriterSample.cs&lang=C#&title=StreamWriter Sample
@[8-30]
@[10-11, 23-29]
@[12-15, 22]
@[16-21]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture03/Assets/sln/Examples/StreamWriterSample.cs)

+++?code=/Lectures/Lecture03/Assets/sln/Examples/StreamReaderSample.cs&lang=C#&title=StreamReader Sample
@[8-31]
@[10-11, 24-30]
@[12-15, 23]
@[16-22]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture03/Assets/sln/Examples/StreamReaderSample.cs)

+++
## Another readers and writers
|  Class | Description |
|:-:|:- |
| `StringReader` | Reads from a string |
| `StringWriter` | Writes to a string(stored in `StringBuilder`) |
| `TextReader` | Reads a sequential series of characters(`abstract`) |
| `TextWriter` | Writes a sequential series of characters(`abstract`) |
| `BinaryReader` | Reads primitive data types as binary values in a specific encoding |
| `BinaryWriter` | Writes primitive types in binary to a stream and supports writing strings in a specific encoding |

---
## `System.Numerics` Namespace
* `using System.Numerics`
* [Documentation](https://docs.microsoft.com/en-us/dotnet/api/system.numerics?view=netstandard-2.0)
* Numeric types that complement the numeric primitives

+++ 
## BigInteger
* `struct BigInteger`
* Nonprimitive integral type that supports arbitrarily large integers
* Has no lower or upper bound
* Can contain the value of any integer

```C#
BigInteger number = BigInteger.Pow(UInt64.MaxValue, 3);
Console.WriteLine(number);

// The example displays the following output:
// 6277101735386680762814942322444851025767571854389858533375
```

+++
## Complex
* `struct Complex`
* Represents a complex number

```C#
Complex complex1 = new Complex(12, 6);
Complex complex2 = 3.14;
Complex complex3 = (Complex) 12.3m;
Complex complex4 = Complex.Pow(Complex.One, -1);
Complex complex5 = Complex.One + Complex.One;

Console.WriteLine(c1);
Console.WriteLine(c2);
Console.WriteLine(c3);
Console.WriteLine(c4);
Console.WriteLine(c5);

// The example displays the following output:
// (12, 6)
// (3.14, 0)
// (12.3, 0)
// (1, 0)
// (2, 0)
```

---
## `System.Reflection` Namespace
* `using System.Reflection`
* [Documentation](https://docs.microsoft.com/en-us/dotnet/api/system.reflection?view=netstandard-2.0)
* Contains types that retrieve information about *assemblies*, *modules*, *members*, *parameters*, and other entities in managed code by examining their metadata
* Manipulate instances of loaded types

+++?code=/Lectures/Lecture03/Assets/sln/Tests/ReflectionTest.cs&lang=C#&title=ReflectionTest Sample
@[8-14]
@[16-39]
@[19-25]
@[21]
@[23-24]
@[28-38]
@[30-32]
@[34-37]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture03/Assets/sln/Tests/ReflectionTest.cs)


---
## `System.Text` Namespace
* `using System.Text`
* [Documentation](https://docs.microsoft.com/en-us/dotnet/api/system.text?view=netstandard-2.0)
* Classes that represent ASCII and Unicode character encodings
  * Abstract base classes for converting blocks of characters to and from blocks of bytes
* Helper class that manipulates and formats `String` objects without creating intermediate instances of `String`

+++
## Encoding
* `class Encoding`
* `abstract`
* process of **transforming a set of Unicode characters into a sequence of bytes**
* Provides the following implementations:
  * `class ASCIIEncoding`
  * `class UTF7Encoding`
  * `class UTF8Encoding`
  * `class UnicodeEncoding`
  * `class UTF32Encoding`
* **Decoder**
  * `class Decoder`
  * `abstract`
  * Converts a sequence of encoded bytes into a set of characters

+++?code=/Lectures/Lecture03/Assets/sln/Examples/EncodingSample.cs&lang=C#&title=EncodingSample Sample
@[10]
@[12-14]
@[16-17]
@[19-20]
@[22-25]
@[27-29, 31-33]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture03/Assets/sln/Examples/EncodingSample.cs)

+++
## StringBuilder
* `class StringBuilder`
* **String-like object** whose value is a **mutable** sequence of characters
  * Maintains a *buffer* to accommodate expansions to the string
  * New data is appended to the *buffer* if room is available; otherwise, a new, larger *buffer* is allocated

+++
### String vs. StringBuilder
* *Each operation that appears to modify a `String` object actually creates a new string*
* **`String` is better when**
  * **Number of changes** that your app will make to a string **is small**
  * App is performing a **fixed number of concatenation operations**
    * Compiler might combine them into single one
  * App performs **extensive search operations** while building string
    * E.g. `IndexOf`, `StartWith`
* **`StringBuilder` is better when**
  * App makes an **unknown number of changes** to a string at design time
    * E.g. loop to concatenate a random number of strings that contain user input
  * When you expect your app to make a **significant number of changes** to a string

+++?code=/Lectures/Lecture03/Assets/sln/Tests/StringBuilderTest.cs&lang=C#&title=StringBuilder Sample
@[9-28]
@[11-13]
@[15-16]
@[18-19]
@[21-22]
@[24-25]
@[27]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture03/Assets/sln/Tests/StringBuilderTest.cs)

---
## `System.Text.RegularExpressions` Namespace
* `using System.Text.RegularExpressions`
* [Documentation](https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions?view=netstandard-2.0)
* [Online regex tester](http://regexstorm.net/tester)
* Provide access to the .NET Framework regular expression engine
* **Regex Class**
  * `class Regex`
  * Represents an immutable regular expression

+++
## Regex Sample
* **For example`\b(?<word>\w+)\s+(\k<word>)\b`**
  * Regular expression to check for repeated occurrences of words in a string
  * Can be interpreted as:
 
| Pattern | Description |
|:-:|:- |
| `\b` | Start the match at a word boundary |
| `(?<word>\w+)` | Match one or more word characters up to a word boundary. Name this captured group `word` |
| `\s+` | Match one or more white-space characters |
| `(\k<word>)` | Match the captured group that is named `word` |
| `\b` | Match a word boundary |

+++?code=/Lectures/Lecture03/Assets/sln/Tests/RegexTest.cs&lang=C#&title=Regex Sample
@[10-27]
@[12-14]
@[16-17]
@[19-20]
@[22-26]
[Code sample](https://github.com/orlicekm/CsharpCourse/blob/master/Lectures/Lecture03/Assets/sln/Tests/RegexTest.cs)

---
## `System.Linq` Namespace
* `using System.Linq`
* [Documentation](https://docs.microsoft.com/en-us/dotnet/api/system.linq?view=netstandard-2.0)
* Classes and interfaces that support queries that use **Language-Integrated Query** (LINQ)
* The `Enumerable` class contains LINQ standard query operators that operate on objects that implement `IEnumerable<T>`
* The `Queryable` class contains LINQ standard query operators that operate on objects that implement `IQueryable<T>`

+++
## Language integrated query
* **Type safety**
* **Lazy Evaluation**
* **Syntaxes**
  * **Fluent** - using extension methods
  * **Query** - using keywords

+++
### Fluent syntax
```C#
string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" }; 
IEnumerable<string> query = names 
  .Where(n => n.Contains("a")) 
  .OrderBy(n => n.Length) 
  .Select(n => n.ToUpper()); 

foreach (string name in query) Console.WriteLine(name);
```

@snap[south]
![LinqFluentSyntax](/Lectures/Lecture03/Assets/img/LinqFluentSyntax.png)
@snapend

+++
### Query syntax diagram

```C#
string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" }; 

IEnumerable<string> query =
    from n in names
    where n.Contains("a") // Filter elements
    orderby n.Length // Sort elements
    select n.ToUpper(); // Translate each element (project)
```

+++
@snap[North]
### Query syntax diagram
@snapend
@snap[midpoint]
![LinqFluentSyntax](/Lectures/Lecture03/Assets/img/LinqQuerySyntax.png)
@snapend

+++
IW5 prednaska, ICS zadanie, dotaz na sql, xml etc..

----
xml
xpath

---
another namespaces
(system.net?)



---
## References:
[C# 7.0 in a Nutshell: The Definitive Reference](https://www.amazon.com/C-7-0-Nutshell-Definitive-Reference/dp/1491987650)  
[Microsoft documentation](https://docs.microsoft.com)
[Microsoft documentation github](https://github.com/MicrosoftDocs)
[.NET Standard web](http://immo.landwerth.net)
[.NET Standard github](https://github.com/dotnet/standard)
[Regex Storm](http://regexstorm.net/tester)
[Wikipedia](https://en.wikipedia.org)

+++
## Refences to used images:
[.NET Standard version table](http://immo.landwerth.net/netstandard-versions/)
[Introduction to .NET Standard](https://blogs.msdn.microsoft.com/dotnet/2016/09/26/introducing-net-standard/)