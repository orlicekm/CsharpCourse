@snap[north span-100]
# Asynchronous and parallel programming in C#
@snapend

@snap[midpoint span-100]
## Processes, Threads, Tasks
@snapend

@snap[south-east span-30]
[ Michal Orlicek <xorlic00@stud.fit.vutbr.cz> ]
@snapend

---
## Process
* Process is the **instance of a computer program that is being executed**
  * Contains the program code and its activity
  * Different processes do not share resources
* Class `Process` is in the `System.Diagnostics` namespace
* Provides **access to local and remote processes**
* Enables to **start and stop local system processes**

+++
### Processes in Task Manager
![](/Lectures/Lecture11/Assets/img/TaskManager.png)

+++?code=/Lectures/Lecture11/Assets/sln/Examples/ProcessSample.cs&lang=C#&title=Process Sample
@[7-10]
@[9]
@[12-15]
@[14]
@[17-26]
@[19-20, 23]
@[21-22]
@[25]
@[17-26]
[Code sample](/Lectures/Lecture11/Assets/sln/Examples/ProcessSample.cs)

+++?code=/Lectures/Lecture11/Assets/sln/Tests/ProcessSampleTest.cs&lang=C#&title=Process Sample Tests
@[10-12]
@[15-23]
@[17]
@[18]
@[20]
@[22]
@[15-23]
@[26-34]
@[37-45]
[Code sample](/Lectures/Lecture11/Assets/sln/Examples/ProcessSampleTest.cs)

---
## Thread
* **Way for a program to split itself into two or more simultaneous runs**
  * Thread is contained inside a process
  * Different threads in the same process **share same resources**
  * Threads are *lightweight*, in terms of the system resources 
* `Thread` Class in `System.Threading` namespace
  * **Creates and controls a thread**
    * **Sets its priority**
    * **Sets its status**

+++
### Multithreaded Process
![](/Lectures/Lecture11/Assets/img/Multithreaded_process.png)

---
## Task

---
### Async await

Lock
Mutex
Spinlock
Monitor
Semafor
Thread sleep vs task delay
Tread pool
Concurrent collection (fail vyhledavani v listu, update dictionary)
Api sample
Rozsirit repository o asynch metody
Value task
Brenchmark dotnet - s kozolovkou ktora to spusti

---
## References:
[C# 7.0 in a Nutshell: The Definitive Reference](https://www.amazon.com/C-7-0-Nutshell-Definitive-Reference/dp/1491987650)    
[Microsoft documentation](https://docs.microsoft.com)  

+++
## Refences to used images:
