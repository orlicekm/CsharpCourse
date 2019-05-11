@snap[north span-100]
# Performance analyzing and memory managment in C#
@snapend

@snap[midpoint span-100]
## Garbage Collector
@snapend

@snap[south-east span-30]
[ Michal Orlicek <xorlic00@stud.fit.vutbr.cz> ]
@snapend
---
## Memory Types
* **Instruction memory**
* **Stack**
  * By default 1MB
  * FILO (First In, Last Out)
* **Heap**
  * Divided into 3 generations
  * `new` to alocate
  * Managed by Garbage Collector

---
## Data Types
* Value types
* Reference types

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

---
### Value Types
* `bool`
* `byte`
* `char`
* `decimal`
* `double`
* `enum`
* `float`
* `int`
* `long`
* `sbyte`
* `short`
* `struct`
* `uint`
* `ulong`
* `ushort`

+++
### Reference Types
* `string`
* `class`
* `delegate`
* `interface`
* All arrays, even if their elements are value types

+++
### Custom Types
* **Custom value types**
  * Using `struct` and `enum`
* **Custom reference types**
  * Using `class`, `delegate` and `interface`

+++
### Memory Layout - Reference Types
* **Every instance of a reference type has extra two fields that are used internally by CLR**
  * `ObjectHeader`
    * *Bitmask*, which is used by CLR to store some additional information
    * E.g., if lock on a given object instance is taken
  * `MethodTable`
    * *Pointer to the Method Table*, which is a set of metadata about given type
    * E.g., If you call a virtual method, then CLR jumps to the Method Table
      * Obtains the address of the actual implementation and performs the actual call
* Both hidden fields **size is equal to the size of a pointer**
  * *32 bit architecture -> 8 bytes* overhead 
  * *64 bit architecture -> 16 bytes** overhead

+++
### Memory Layout - Reference Types

![](/Lectures/Lecture12/Assets/img/ReferenceTypes_MemoryLayout.png)

+++
### Memory Layout - Value Types
* **Value Types don’t have any additional overhead members**
  *  They are more limited in terms of features
  *  You cannot derive from `struct`, `lock` it or write finalizer for it

+++
### Memory Layout - Value Types

![](/Lectures/Lecture12/Assets/img/ValueTypes_MemoryLayout.png)

---
## CPU Cache
* CPU **implements numerous performance optimizations**
* One of them is **cache**
  * It is just a memory with the most recently used data

![](/Lectures/Lecture12/Assets/img/Cache.png)

+++
### Cache Miss
* **Multithreading affects CPU cache performance**
* This **sample is for single core**
  * Whenever you try to read a value:
    1. *CPU checks the first level of cache* (L1)
       * If the value is there, it's is being returned
    2. *CPU checks the second level of cache* (L2)
       * If the value is there, it’s being copied to L1 and returned
    3. *CPU checks L3* (if it’s present)
    4. *If the data is not in the cache*
       * CPU goes to the main memory and copies it to the cache
       * This is called **cache miss**

+++
### Cache Miss - Latency
* Going to **main memory is really expensive** when compared to referencing cache

| **Operation**         | **Time** |
|-----------------------|--------|
| L1 cache reference    | 1ns    |
| L2 cache reference    | 4ns    |
| Main memory reference | 100 ns |

+++
### Data Locality Principles
* **Spatial**
  * *If a particular storage location is referenced at a particular time, then it is likely that nearby memory locations will be referenced in the near future.*
* **Temporal**
  * *If at one point a particular memory location is referenced, then it is likely that the same location will be referenced again in the near future.*

+++
### CPU - Data Locality Principles
* CPU is **taking advantage of this knowledge**
* Whenever CPU copies a value from main memory to cache
  * It is **copying whole cache line, not just the value**
* A cache line is usually 64 bytes, so it is well prepared

+++
### CPU Cache - .NET Types



---
---
Benchmark.net

---
## References:
[C# 7.0 in a Nutshell: The Definitive Reference](https://www.amazon.com/C-7-0-Nutshell-Definitive-Reference/dp/1491987650)  
[Interactive Latencies](https://github.com/colin-scott/interactive_latencies)  
[Adam Sitnik](https://adamsitnik.com/)  

+++
## Refences to used images:
[Adam Sitnik](https://adamsitnik.com/)