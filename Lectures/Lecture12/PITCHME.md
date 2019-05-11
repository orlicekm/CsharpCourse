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
## Memory types
* **Instruction memory**
* **Stack**
  * By default 1MB
  * FILO (First In, Last Out)
* **Heap**
  * Divided into 3 generations
  * `new` to alocate
  * Managed by Garbage Collector

+++
### Value types
* bool
* byte
* char
* decimal
* double
* enum
* float
* int
* long
* sbyte
* short
* struct
* uint
* ulong
* ushort

+++
### Reference types
* String
* All arrays, even if their elements are value types
* Class
* Delegates

---
## References:
[C# 7.0 in a Nutshell: The Definitive Reference](https://www.amazon.com/C-7-0-Nutshell-Definitive-Reference/dp/1491987650)  

+++
## Refences to used images:
