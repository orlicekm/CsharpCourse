@snap[north span-100]
# Model–View–ViewModel design pattern
@snapend

@snap[midpoint span-100]
## Desktop applications architecture, MVVM, Mapper
@snapend

@snap[south-east span-30]
[ Michal Orlicek <xorlic00@stud.fit.vutbr.cz> ]
@snapend

---
## Desktop Applications Architecture
* TODO
co sem?

* Historical patterns?
  * MVC
  * MVP
  * Presentation Model


---
### Model–View–ViewModel
* **Software architectural pattern**
* **MVVM**
  * Model
  * ViewModel
  * View

@snap[east]
@img[span-80](/Lectures/Lecture08/Assets/img/mvvm.png)
@snapend

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

+++
### MVVM Benefits
* **Separation of concerns**
  * Designer and developer can work on the project simultaneously
* **Speed and performance enhancements**
* **Unit testing**
* **Reusable components**
* **Flexibility**
  * E.g changing UI without having refactor other logic

+++
### MVVM Drawbacks
* **Overkill** for simple applications
* **Memory consumption** with data binding in very large applications

+++
## Model
* Represents the **actual data and information**
* **Holds the information, but not behaviors or services** that manipulate the information
  * **Business logic is encapsulated** in other classes that act on the model
  * Not always true
    * E. g. some *Models* may contain validation

+++
## View
* **Presentation of the data**
* Only thing the end user really interacts with
* Contains *behaviors*, *events* and *data-bindings*
  * Mapped to *properties*, *method calls*, and *commands*
* It is **not responsible for maintaining its state**
  * It will synchronize this with the *ViewModel*
* In *XAML* (in this course)


+++
## ViewModel 
* **Presentation Separation**
  * *View* separate from the *Model*
  * 

+++
frameworks

---
### Mapper

automapper
repozitar
unit of work

---
## References:
[C# 7.0 in a Nutshell: The Definitive Reference](https://www.amazon.com/C-7-0-Nutshell-Definitive-Reference/dp/1491987650)  
[Wintellect LLC](https://www.wintellect.com/)
[Tutorialspoint](https://www.tutorialspoint.com)
[Sagitec blog](http://www.sagitec.com/blog)

+++
## Refences to used images:
[Wintellect LLC](https://www.wintellect.com/)