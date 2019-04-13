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

+++
### Lock statement
* For *safe access* to the resource from the concurrent context
* Simplification of a *Monitor synchronization primitive*
* While a `lock` is held
  * The **thread that holds the lock can again acquire and release the lock**
  * Any **other thread is blocked from acquiring the lock and waits until the lock is released**

+++?code=/Lectures/Lecture11/Assets/sln/Tests/LockTest.cs&lang=C#&title=Lock Sample
@[9-19]
@[24-30]
[Code sample](/Lectures/Lecture11/Assets/sln/Tests/LockTest.cs)

+++
### Mutex
* **Synchronization primitive**
  * Can be used for *interprocess synchronization*
* Provides one person to access a single resource at a time
  * Others must wait in a queue
* `Mutex` Class in `System.Threading` namespace
* Sample shows how mutex is used to synchronize access to a protected resource

+++?code=/Lectures/Lecture11/Assets/sln/Examples/MutexSample.cs&lang=C#&title=Mutex Sample
@[8]
@[10-11, 21]
@[12-13, 20]
@[15-19]
@[10-21]
@[23-24, 27]
@[25-26]
@[29-30, 36]
@[31]
@[32]
@[33]
@[34]
@[35]
@[29-36]
[Code sample](/Lectures/Lecture11/Assets/sln/Examples/MutexSample.cs)

+++
### Semaphore
* **Limits the number of threads that can access a resource or pool of resources concurrently**
* **Useful if multiple instances (N) of a resource** is to be shared among a set of users
  * As soon as all N resources are acquired, any new requester has to wait
  * Since there is no single lock to hold, there is as such no ownership of a semaphore
* `Semaphore` Class in `System.Threading` namespace

+++?code=/Lectures/Lecture11/Assets/sln/Examples/SemaphoreSample.cs&lang=C#&title=Semaphore Sample
@[8-9]
@[11-12]
@[13-16]
@[18-23]
@[25-27]
@[29-33]
@[35]
@[38-39, 55]
@[40-42]
@[44-51]
@[53-54]
@[38-55]
[Code sample](/Lectures/Lecture11/Assets/sln/Examples/SemaphoreSample.cs)

+++
### SpinLock
* **Provides a mutual exclusion lock primitive**
  * Thread is trying to acquire the lock **waits in a loop repeatedly checking** until the lock becomes available
* *"An aggressive mutex"*
  * **As soon as the resource is free, they go and grab it**
  * In process of spinning, they **consume many CPU cycles**
    * On a uni-processor machine, they are useless and perform very badly
* `SpinLock` Struct in `System.Threading` namespace

+++?code=/Lectures/Lecture11/Assets/sln/Examples/SpinLockSample.cs&lang=C#&title=SpinLock Sample
@[13-14]
@[37-38]
@[16-20, 35]
@[21-22, 34]
@[23]
@[24-28]
@[29-33]
@[19-35]
@[40-42]
[Code sample](/Lectures/Lecture11/Assets/sln/Examples/SpinLockSample.cs)

+++
### Monitor
* Provides a mechanism that synchronizes access to objects
* Can be done by acquiring a significant lock
  * Is no different from `lock`
  * But the monitor class provides more control over the synchronization
* `Monitor` Class in `System.Threading` namespace
* Methods for the synchronize access 
  * `Monitor.Enter `
  * `Monitor.TryEnter`
  * `Monitor.Exit`

+++?code=/Lectures/Lecture11/Assets/sln/Examples/MonitorSample.cs&lang=C#&title=Monitor Sample
@[8]
@[10-11, 30]
@[12-15]
@[17-18, 25]
@[19-24]
@[26-27, 29]
@[28]
@[10-30]
[Code sample](/Lectures/Lecture11/Assets/sln/Examples/MonitorSample.cs)

+++
### ThreadPool

---
## Task

+++
### Async await

---
Thread sleep vs task delay
Concurrent collection (fail vyhledavani v listu, update dictionary)
Api sample
Rozsirit repository o asynch metody
Value task
Brenchmark dotnet - s kozolovkou ktora to spusti

---
## References:
[C# 7.0 in a Nutshell: The Definitive Reference](https://www.amazon.com/C-7-0-Nutshell-Definitive-Reference/dp/1491987650)  
[Simplify Complexities](https://freethreads.net/)
[Microsoft documentation](https://docs.microsoft.com)  
[Wikipedia](https://en.wikipedia.org)  

+++
## Refences to used images:
[Wikipedia](https://en.wikipedia.org)  
