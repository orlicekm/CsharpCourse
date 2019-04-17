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
## Serial computing
![](/Lectures/Lecture11/Assets/img/SerialComputing.png)

+++
## Parallel computing
![](/Lectures/Lecture11/Assets/img/ParallelComputing.png)

+++
### Parallel computing
* **Running multiple things at at the same time**
* **Used for achieving performance**
* Can be achieved using
  * *Mutliple processes*
  * *Multithreading*

+++
### Synchronous vs Asynchronous computing
* **Synchronous computing**
  * Blocking execution
  * Waiting for execution to finish
* **Asynchronous computing**
  * Nonblocking execution
  * I don't wait I get notified

+++
### Asynchronous computing
![](/Lectures/Lecture11/Assets/img/asynchronousVsSynchronous.png)

+++
### Parallel Programming Issues
* Shared resources
* Read/write synchronization
* Exceptions handling in threads
* UI thread access
* Debugging multiple threads
* Deadlock

---
## Process
* Process is the **instance of a computer program which is being executed**
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

+++
### Process Input/Output
* Accessing output via events:
  * `ErrorDataReceived` - output written to `stderr`
  * `OutputDataReceived` - output written to `stdout`
* Needs to be enabled via `BeginOutputReadLine()` or `BeginErrorReadLine()`
* Allows opening of file with associated executable
 * Set `FileName` to associated file and set `UseShellExecute` to `true`


```C#
var lineCount = 0;
var output = new StringBuilder();
process.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
{
    // Prepend line numbers to each line of the output.
    if (!string.IsNullOrEmpty(e.Data))
    {
        lineCount++;
        output.Append("\n[" + lineCount + "]: " + e.Data);
    }
});
process.Start();
process.BeginOutputReadLine();
```

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
### Thread vs Process
![](/Lectures/Lecture11/Assets/img/ThreadVsProcess.jpg)

+++
### Thread Life Cycle
![](/Lectures/Lecture11/Assets/img/threadlifecycle.png)

+++
### Lock statement
* For *safe access* to the resource from the concurrent context
* Simplification of a *Monitor synchronization primitive*
* While a `lock` is held
  * The **thread that holds the lock can acquire and release the lock again**
  * Any **other thread is blocked from acquiring the lock and waits until the lock is released**

+++?code=/Lectures/Lecture11/Assets/sln/Tests/LockTest.cs&lang=C#&title=Lock Sample
@[9-19]
@[24-30]
[Code sample](/Lectures/Lecture11/Assets/sln/Tests/LockTest.cs)

+++
### Mutex
* **Synchronization primitive**
  * Can be used for *interprocess synchronization*
* Provides the access to a single resource to one person at the time
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
* **Useful if multiple instances (N) of a resource** are shared among a set of users
  * As soon as all N resources are acquired, any new requester has to wait
  * Since there is no single lock to hold, there is no ownership of a semaphore
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
  * Thread which is trying to acquire the lock **waits in a loop repeatedly checking** until the lock becomes available
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
* Provides a **mechanism that synchronizes access to objects**
* Can be done by acquiring a significant lock
  * Is no different from `lock`
  * But the **monitor provides more control over the synchronization**
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
### Thread Pool
* A collection of threads which **can be used to execute tasks in background**
  * **Once the thread completes its task it is sent to the pool to a queue of waiting threads, where it can be reused**
  * Reusability avoids to create more threads and this enables **less memory consumption**
* `ThreadPool` Class in `System.Threading` namespace

+++
### Thread Pool - Initialization
![](/Lectures/Lecture11/Assets/img/threadpool1.png)

+++
### Thread Pool - Next uses
![](/Lectures/Lecture11/Assets/img/threadpool2.png)


+++?code=/Lectures/Lecture11/Assets/sln/Examples/ThreadPoolSample.cs&lang=C#&title=Thread Pool Sample
@[9-29]
@[11]
@[13-17]
@[15]
@[28-31]
@[30]
@[38-40]
@[19]
@[21-25]
@[23]
@[33-36]
@[35]
@[9-29]
[Code sample](/Lectures/Lecture11/Assets/sln/Examples/ThreadPoolSample.cs)
 compares how much time does it take to the thread object and to the thread pool to execute any methods

---
## Task
* *Is an object that represents some work that should be done*
  * Usually **executes asynchronously**
* Can **tell you if the work is completed** and if the operation returns a result
* Can **give you the result**
* `Task` Class in `System.Threading.Tasks` namespace

+++
### Properties of Task
| Property      | Description                                                           |
|:-------------:|:----------------------------------------------------------------------|
| `Exception`   | Returns any exceptions that caused the task to end early              |
| `Status`      | Returns the Tasks status                                              |
| `IsCancelled` | Returns true if the Task was cancelled                                |
| `IsCompleted` | Returns true if the task is completed successfully                    |
| `IsFaulted`   | Returns true if the task is stopped due to unhandled exception        |
| `Factory`     | Provides acess to TaskFactory class, can be used that to create Tasks |

+++
### Methods in Task

| Methods          | Purpose                                                              |
|:------------------:|:--------------------------------------------------------------------|
| `ConfigureAwait`   | You can use Await keyword for the Task to complete                   |
| `ContinueWith`     | Creates continuation tasks.                                          |
| `Delay`            | Creates a task after specified amount of time                        |
| `Run`              | Creates a Task and queues it to start running                        |
| `RunSynchronously` | Runs a task Synchronously                                            |
| `Start`            | Starts a task                                                        |
| `Wait`             | Waits for the task to complete                                       |
| `WaitAll`          | Waits until all tasks are completed                                  |
| `WaitAny`          | Waits until any one of the tasks in a set completes                  |
| `WhenAll`          | Creates a Task that completes when all specified tasks are completed |
| `WhenAny`          | Creates a Task that completes when any specified tasks completes     |

+++?code=/Lectures/Lecture11/Assets/sln/Examples/TaskSample.cs&lang=C#&title=Task Sample
@[8-16]
@[10-11, 14]
@[12-13]
@[15]
@[8-16]
[Code sample](/Lectures/Lecture11/Assets/sln/Examples/TaskSample.cs)
 will print “Hi” 50 times to the console

+++?code=/Lectures/Lecture11/Assets/sln/Tests/TaskReturnsValueTest.cs&lang=C#&title=Task Returning Value Sample
@[8]
@[9]
@[8, 14]
@[9, 15]
@[8-16]
[Code sample](/Lectures/Lecture11/Assets/sln/Tests/TaskReturnsValueTest.cs)

+++?code=/Lectures/Lecture11/Assets/sln/Tests/ChildTaskTest.cs&lang=C#&title=Child Tasks Sample
@[11-12, 21]
@[13]
@[14-15]
@[16-17]
@[18-19]
@[20]
@[11-21]
@[23]
@[24-25]
@[26]
@[28]
@[11-28]
[Code sample](/Lectures/Lecture11/Assets/sln/Tests/ChildTaskTest.cs)  
*Final task* runs only after the *parent* is finished, and the *parent* finishes when all three *children* are finished

+++?code=/Lectures/Lecture11/Assets/sln/Examples/TaskFactorySample.cs&lang=C#&title=Task Factory Sample
@[10-11]
@[13-14, 20]
@[15]
@[16-18]
@[19]
@[13-20]
@[22, 27]
@[23-26]
@[22-27]
@[29]
@[10-29]
[Code sample](/Lectures/Lecture11/Assets/sln/Examples/TaskFactorySample.cs)

---
### Async and Await keywords
* `async`, `await`
* Simple and easy **keywords to transform code from synchronous to asynchronous**
* **Code markers**
  * **Marks code positions from where the control should resume after a task completes**

+++
### Async Await Benefits
* **Increase the performance and responsiveness** of application
* **Organize code in a neat and readable way**
  * **Less code**
  * Code will be **more maintainable** than using the previous asynchronous programming methods such as using plain tasks or threads
* `async` / `await` is the newer replacement to `BackgroundWorker`, which has been used on *Windows Forms desktop applications*
* Use of the **latest upgrades of the language** features
  * `async` / `await` was introduced in C# 5
  * There have been some improvements added (e.g., foreach async and generalized async type)

+++
### Async and Await Structure
* Changes to turn normal code into asynchronous using `async` / `wait`:
  * **Method definition should include the keyword `async`**
    * Keyword by itself doesn't do anything except **enabling use of the keyword `await`** within the method
  * Method **return type should change** to return either `void` or `Task` or `Task<T>`
    * `T` is the return data type e.g.,
    ```C#
    public async Task<String> GetUserNameAsync(){ }
    ``` 
  * According to the naming convention, an asynchronous **method name should end with the word *Async***

+++?code=/Lectures/Lecture11/Assets/sln/Examples/AsyncAwaitSample.cs&lang=C#&title=Async Await Sample
@[8-9, 15]
@[10]
@[11]
@[13-14]
@[8-15]
@[17-20]
@[22-23, 28]
@[24]
@[25]
@[26]
@[27]
@[22-28]
[Code sample](/Lectures/Lecture11/Assets/sln/Examples/AsyncAwaitSample.cs)

+++
### Async Await Sample Output

```
Started CPU Bound asynchronous task on a background thread
Doing some synchronous work
Finished Task. Total of $70 after tax of 20% is $84 
```

+++
#### Async Await Exception Handling 1/2

```C#
public async void Foo()
{
    var x = await DoSomethingAsync(); // throw in here
}

public void DoFoo()
{
    try
    {
        Foo();
    }
    catch (ProtocolException ex)
    {
          // The exception will never be caught.
    }
}
```

* Async void methods have different error-handling semantics. When an exception is thrown out of an async Task or async Task method, that exception is captured and placed on the Task object. With async void methods, there is no Task object, so any exceptions thrown out of an async void method will be raised directly on the SynchronizationContext that was active when the async void method started. *


+++
#### Async Await Exception Handling @/2

```C#
public async void DoFoo()
{
    try
    {
        await Foo();
    }
    catch (ProtocolException ex)
    {
          // The exception will be caught
    }
}
```

or

```C#
public void DoFoo()
{
    try
    {
        Foo().Wait();
    }
    catch (ProtocolException ex)
    {
          // The exception will be caught
    }
} 
```

---
## Thread vs Task
* Task provides following powerful features over thread
  1. If system has multiple tasks then it make use of the CLR thread pool internally
    *  Also reduce the context switching time among multiple threads
  2. Task can return a result
  3. Wait on a set of tasks, without a signaling construct
  4. Tasks can be chained together to execute one after the other
  5. Establish a parent/child relationship when one task is started from another task
  6. Child task exception can propagate to parent task
  7. Task supports cancellation through the use of cancellation tokens
  8. Asynchronous implementation is easy in task, using `async` and `await` keywords

+++
### Thread.Sleep vs Task.Delay
* Use both to suspend the execution of a program for a given timespan
* **`Thread.Sleep()`**
  * **Will suspend the current thread until the given amount of time**
  * There is **nothing what can be done to abort this**
    * Except waiting until the time elapse or application resets
  * **Suspends the thread that's making the call**
* **`Task.Delay()`**
  * **Creates a task which will complete after a time delay**
  * It is **not blocking the calling thread**
  * Since the timer controls the delay, it **can be canceled anytime**

---
## Task-base Pattern
![](/Lectures/Lecture11/Assets/img/TaskBasedPattern.png)

+++
### Support in .NET
* I/O handling classes
  * `StreamReader`, `StreamWriter`- for streams and files access
  * `HttpClient`, `WebClient` - for accessing web resources

+++
### Usage in School Sample
* With `await`/`async` knowledge, *UnitOfWork* and *Repository* pattern can be extended with async methods
  * E.g., **UnitOfWork**
    ```C#
      Task CommitAsync();
      Task CommitAsync(CancellationToken cancellationToken);
      ⋮
    ```
  * E.g., **Repository**
    ```C#
      Task<TEntity> GetByIdAsync(TKey id);
      ⋮
    ```

---
## Synchronized Collections 
* Provided in namespace `System.Collections.Concurrent`
  * `BlockingCollection<T>` - ordered collection
  * `ConcurrentQueue<T>` - queue
  * `ConcurrentBag<T>` - unordered collection 
  * `ConcurrentStack<T>` - stack

+++
### Concurrent Dictionary Sample
```C#
// Create the dictionary
ConcurrentDictionary<int, int> dictionary = new ConcurrentDictionary<int, int>();
 
// Add [1, 2] and [2, 3]
dictionary.GetOrAdd(1, 2);
dictionary.GetOrAdd(2, 3);
 
// This will succeed
Assert.IsTrue(((ICollection<KeyValuePair<int, int>>) dictionary)
.Remove(new KeyValuePair<int, int>(1, 2)));
 
// Let's get the value from 2 and confirm it's 3.
int value;
dictionary.TryGetValue(2, out value);
 
Assert.AreEqual(value, 3);
 
// Meanwhile, imagine this runs on another thread...
dictionary.AddOrUpdate(2, 4, (k, v) => 4);
 
// This remove will fail as value still equals 3, but the dictionary now contains 4!
Assert.IsFalse(((ICollection<KeyValuePair<int, int>>)dictionary)
.Remove(new KeyValuePair<int, int>(2, value)));
 
// The dictionary keeps it's key nice and safe.
Assert.IsTrue(dictionary.ContainsKey(2));
```
@[1-2]
@[4-6]
@[8-10]
@[12-14]
@[16]
@[18-19]
@[21-23]
@[25-26]

---
## Value Task
* `System.Threading.Tasks` namespace
* Task vs value task:
  * `Task<T>` is a **class**
    * Causes the **unnecessary overhead** of its allocation when the result is immediately available
  * `ValueTask<T>` is a **structure**
    * Introduced to **prevent the allocation** of a `Task` object **in case the result of the async operation is already available** at the time of awaiting

+++
## Value Task Benefits
#### **Performance increase**
  * `Task<T>` example:
    * Requires heap allocation
    * Takes 120ns with JIT
      ```C#
      async Task<int> TestTask(int d)
      {
          await Task.Delay(d);
          return 10;
      }
      ```
    * Analog `ValueTask<T>` example
      * No heap allocation if the result is known
      * Takes 65ns with JIT
       ```C#
      async ValueTask<int> TestValueTask(int d)
      {
          await Task.Delay(d);
          return 10;
      }
      ```

+++
## Value Task Benefits
#### **Increased implementation flexibility**
* `ValueTask<T>` implementations are more free to choose between being synchronous or asynchronous without impacting callers
  * For example:
    ```C#
    interface IFoo<T>
    {
        ValueTask<T> BarAsync();
    }
    ⋮
    IFoo<T> thing = getThing();
    var x = await thing.BarAsync();
    ```
  * With `ValueTask`, the code above will work with either **synchronous or asynchronous implementations**

+++
#### Synchronous Implementation:
```C#
class SynchronousFoo<T> : IFoo<T>
{
    public ValueTask<T> BarAsync()
    {
        var value = default(T);
        return new ValueTask<T>(value);
    }
}
```

#### Asynchronous Implementation
```C#
class AsynchronousFoo<T> : IFoo<T>
{
    public async ValueTask<T> BarAsync()
    {
        var value = default(T);
        await Task.Delay(1);
        return value;
    }
}
```

---
## References:
[C# 7.0 in a Nutshell: The Definitive Reference](https://www.amazon.com/C-7-0-Nutshell-Definitive-Reference/dp/1491987650)  
[Microsoft documentation](https://docs.microsoft.com)  
[Learn CSharp Tutorials](http://www.learncsharptutorial.com/)  
[Simplify Complexities](https://freethreads.net/)  
[Microsoft TechNet](https://technet.microsoft.com/)  
[RIP Tutorial](https://riptutorial.com/)  
[Csharp Star](https://www.csharpstar.com/)  
[thagy.com](http://thargy.com/)  
[CodinGame](https://www.codingame.com)  
[C# Corner](https://www.c-sharpcorner.com/)  
[Wikipedia](https://en.wikipedia.org)  

+++
## Refences to used images:
[Learn CSharp Tutorials](http://www.learncsharptutorial.com/)  
[Eloquent JavaScript](https://eloquentjavascript.net/)  
[Tech Differences](https://techdifferences.com/)  
[Wikipedia](https://en.wikipedia.org)  
