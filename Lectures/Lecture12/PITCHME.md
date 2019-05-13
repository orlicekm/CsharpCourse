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
* **Value types**
  * Must be assigned some value before use
  * (Field in a class can be declared without initialization)
* **Reference types**
  * Null value by default

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
## CPU Optimalization
* CPU **implements numerous performance optimizations**
* One of them is **cache**
  * It is just a memory with the most recently used data


+++
## CPU Cache
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
* How the two extra fields per every reference type instance **affect data locality:**
  * Image shows *how many instances of* `ValueTuple<int, int>` *and* `Tuple<int, int>` *can fit into single cache line*
    * For *64bit architecture*

![](/Lectures/Lecture12/Assets/img/CacheLines.png)

+++?code=/Lectures/Lecture12/Assets/sln/DataLocalityBenchmark/DataLocality.cs&lang=C#&title=Data Locality Benchmark
@[8-10]
@[12-13]
@[15-16]
@[18-23]
@[25-39]
@[41-55]
[Code sample](/Lectures/Lecture12/Assetssln/DataLocalityBenchmark/DataLocality.cs)

---
### Benchmark Output
| Method                | Jit       | Platform | Count | Mean      | Scaled | CacheMisses/Op |
|-----------------------|-----------|----------|-------|-----------|--------|----------------|
| IterateValueTypes     | LegacyJit | X86      | 100   | 68.96 ns  | 1.00   | 0              |
| IterateReferenceTypes | LegacyJit | X86      | 100   | 317.49 ns | **4.60**   | 0              |
| IterateValueTypes     | RyuJit    | X64      | 100   | 76.56 ns  | 1.00   | 0              |
| IterateReferenceTypes | RyuJit    | X64      | 100   | 252.23 ns | **3.29**   | 0              |

**As you can see the difference (Scaled column) is really significant!**

+++
### Benchmark Output Explanation
* **Why is CacheMisses/Op column empty?**
  * In value type benchmark I should get Cache Miss once every 8 loop iterations 
    * `(cacheLineSize / sizeOf(ValueTuple<int, int>) = 64 / 8 = 8)`
  * For 100 iterations like here, it should be 12 Cache Misses for Benchmark
    * `100 / 8 = 120 `
  * BenchmarkDotNet is using ETW to collect hardware counters
    * ETW is simply exposing what the hardware has to offer
    * Each Performance Monitoring Units (PMU) register is configured to count a specific event and given a sample-after value
  * But the PMU will notify ETW, which will notify BenchmarkDotNet every 4 000 events (4000 for my PC)
    * It this example the method was executed too few times to capture enough of events
  * **So if you want to capture some hardware counters with BenchmarkDotNet you need to perform plenty of iterations**


+++
### Benchmark Output - More Interations

| Method                | Jit    | Platform | Count       | Mean              | Scaled | CacheMisses/Op |
|-----------------------|--------|----------|-------------|-------------------|--------|----------------|
| IterateValueTypes     | RyuJit | X64      | 100 000 000 | 88,735,182.11 ns  | 1.00   | **3545088**     |
| IterateReferenceTypes | RyuJit | X64      | 100 000 000 | 280,721,189.70 ns | **3.16** | **8456940**   |

For the iteration of reference types cache misses were **2.38 times more common** (8456940 / 3545088)

+++
### Value, Reference Types Location

* **MYTH** - *Value types are located on the stack and reference types on the heap*
  * **FACT** -*Value types* can be allocated *both on the stack and the heap*
  * **FACT** - *Reference types* are always allocated on the managed *heap*

---
## Heap
* **Code heap**
* **Small object heap**
  * Classic heap
* **Large object heap**
  * Objects larger than 85KB
* **Process heap**


+++
## Garbage Collector (GC)
* John McCarthny 1959
* Searches for unnecessary objects
* CLR process

## Garbage Collector Benefits
* Enables you to develop your application **without having to free memory**
* **Allocates objects** on the managed heap efficiently
* **Reclaims objects** that are no longer being used
  * Clears their memory
  * Keeps the memory available for future allocations
* Provides **memory safety** by making sure that an object cannot use the content of another object

+++
### Reference counting GC
* **Pros**
  * **Can clean objects faster**
  * It **doesn't suspend** the running of program (usefull for RT systems)
* **Cons**
  * **Memory**
    * Have to remember number of references for every object
  * **Can not handle reference cycles**

+++ 
### Tracing GC
* **Pros**
  * **Suspends program** only when collecting
  * **Can handle reference cycles**
  * Partially **solves heap fragmentation**
* **Cons**
  * Have to suspend the program
  * Collecting is **nondeterministic** 

+++
### Garbage Collecting
![](/Lectures/Lecture12/Assets/img/GarbageCollecting.png)

+++
### Gargbage Collector Roots
* *Local variables*
* *GCHndlers*
  * *Pin*
  * *Static*
* *Registers*
* *F-Reachable queue*

+++
### Garbage Collector Generations
* **Generation 0**
  * Contains *short-lived objects*
     * E.g., temporary variable
  * Garbage collection occurs most frequentl
  * *Newly allocated objects*
  * Most objects are reclaimed for garbage collection and do not survive to the next generation
* **Generation 1**
  * Contains short-lived objects and serves as a *buffer between short-lived objects and long-lived objects*
* **Generation 2** 
  * Contains *long-lived objects*
    * E.g., object in a server application that contains static data that is live for the duration of the process

+++
### Garbage Collector Generations Sample 1/3
![](/Lectures/Lecture12/Assets/img/image_2.png)

+++
### Garbage Collector Generations Sample 2/3
![](/Lectures/Lecture12/Assets/img/image_4.png)

+++
### Garbage Collector Generations Sample 3/3
![](/Lectures/Lecture12/Assets/img/image_8.png)

+++
### Garbage Collector Invocation
* Generation 0 is full
* System wide memory pressure
* `GC.Collect()` 

+++
### Garbage Collector Versions
* *Mobile*
* *Workstation*
* *Server*

+++
### Bacground Garbage Collector
* Workstation .NET 4.0
* Server .NET 4.5
* Can be turned off
  * `<gcConcurrent enabled="False">`

+++
### Finalization
* Finalize queue
* F-reachable queue
* ResourceWrapper, IDispoze

---
## .NET Tips for saving Memory
* String.Empty
* Dispose Pattern
* WeakReference
* Large object heap compacting

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

+++
### String.Empty
* `String.Empty`
* **More effective** from .NET 2.0
* Readonly field in `String` class
* Immutable
* If "" is used
  * *Space have to be alocated*
  * *Constructor have to be called*

+++
### Dispose Pattern
* Ways
  * IDisposable
  * Destruktor
  * Using
  * CA2000, CA1816
  * GC.SuppressFinalize(this)
* We can control when an object frees resources

+++?code=/Lectures/Lecture12/Assets/sln/DisposeSample/Program.cs&lang=C#&title=Dispose Demo
@[40-50]
@[44]
@[45-48]
@[5-6]
@[9-13]
@[15-19]
@[21-24]
@[26-37]
[Code sample](/Lectures/Lecture12/Assetssln/DisposeSample/Program.cs)  
*Project-> Properties -> Code Analysis -> Enable Code Analysis on Build*

+++
### Weak Reference
Does **not protect the referenced object from collection by a garbage collector**

+++?code=/Lectures/Lecture12/Assets/sln/WeakReferenceSample/Program.cs&lang=C#&title=Weak Reference Demo
@[6-7]
@[8]
@[10-19]
@[12]
@[14]
@[21-32]
@[23, 26]
@[28, 30]
@[21-32]
@[16]
@[34-42]
@[37, 41]
@[39-40]
@[34-42]
@[18]
[Code sample](/Lectures/Lecture12/Assetssln/WeakReferenceSample/Program.cs)  

+++?code=/Lectures/Lecture12/Assets/sln/WeakReferenceGenericSample/Program.cs&lang=C#&title=Weak Reference Generic Demo
@[6-7]
@[8]
@[10-19]
@[12]
@[34-38]
@[36-37]
@[14]
@[21-32]
@[23]
@[24, 36]
@[28, 30]
@[21-32]
@[16]
@[40-48]
@[43]
@[45-46]
@[18]
[Code sample](/Lectures/Lecture12/Assetssln/WeakReferenceGenericSample/Program.cs)  

+++
### Large Object Heap Compacting
* From .Net 4.5.1
* Takes a lot of time

```C#
GCSettings.LargeObjectHeapCompactionMode = 	GCLargeObjectHeapCompactionMode.CompactOnce;
GC.Collect();
```

+++
### Large Object Support
* Ability to create objects larger than 2GB
  * Only for 64-Bit
  * `<gcAllowVeryLargeObjects enabled="true"/>`

+++?code=/Lectures/Lecture12/Assets/sln/LargeObjectSample/Program.cs&lang=C#&title=Large Object Sample
@[9]
@[10]
@[11]
@[12]
@[14]
[Code sample](/Lectures/Lecture12/Assetssln/LargeObjectSample/Program.cs)  

---
## Benchmark.net

---
## References:
[Pro .NET Performance: Optimize Your C# Applications](https://www.amazon.com/Pro-NET-Performance-Optimize-Applications/dp/1430244585)  
[C# 7.0 in a Nutshell: The Definitive Reference](https://www.amazon.com/C-7-0-Nutshell-Definitive-Reference/dp/1491987650)  
[Interactive Latencies](https://github.com/colin-scott/interactive_latencies)  
[Wikipedia - Reference counting](https://en.wikipedia.org/wiki/Reference_counting)  
[Wikipedia - Tracing garbage collection](https://en.wikipedia.org/wiki/Tracing_garbage_collection)  
[Microsoft Documentation - Implementing a Dispose method](https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-dispose)
[Adam Sitnik](https://adamsitnik.com/)  

+++
## Refences to used images:
[MSDN - The garbage collector](https://blogs.msdn.microsoft.com/floditt/2008/12/15/1-the-garbage-collector-in-x-and-the-clr/)
[Adam Sitnik](https://adamsitnik.com/)  