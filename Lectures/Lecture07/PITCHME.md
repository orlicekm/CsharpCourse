@snap[north span-100]
# Clean code in C#
@snapend

@snap[midpoint span-100]
## SOLID, Refactorization
@snapend

@snap[south-east span-30]
[ Michal Orlicek <xorlic00@stud.fit.vutbr.cz> ]
@snapend

---
## Clean Code
* Code that
  * *Easy to understand*
  * *Easy to change*
* **Subjective**
* [Clean Code Book](https://www.amazon.com/Clean-Code-Handbook-Software-Craftsmanship/dp/0132350882)
* [Clean Code .NET](https://github.com/thangchung/clean-code-dotnet)

@snap[east]
@img[span-60](/Lectures/Lecture07/Assets/img/clean-code.jpg)
@snapend

+++
* *Clean code is code that has been taken care of. Someone has taken the time to keep it simple and orderly. They have paid appropriate attention to details. They have cared.* — Robert C. Martin 
* *If you want your code to be easy to write, make it easy to read.* — Robert C. Martin
* *Clean code always looks like it was written by someone who cares. There is nothing obvious you can do to make it better.* — Michael Feathers
* *Clean code is simple and direct. Clean code reads like well-written prose. Clean code never obscures the designers’ intent but rather is full of crisp abstractions and straightforward lines of control.* — Grady Booch
* *Any fool can write code that a computer can understand. Good programmers write code that humans can understand.* — Martin Fowler

+++
### Clean Code
* **Easily accessible to others**
  * Straightforward
  * Clear intent
  * Good abstractions
  * No surprises
  * Good naming
  * ⋮
* **Is made for the real-world**
  * Clear error-handling strategy
  * ⋮
* **Author clearly cares for the software and other developers**
* **Is minimal**
* **Is good at what it does**
* **Is easy to test**
* ⋮

+++
### Clean Code Measurement
![](/Lectures/Lecture07/Assets/img/clean-code-measurement.jpg)

---
## Clean code blabla

---
## SOLID
* Mnemonic acronym for five design principles
* To make software designs more 
  * Understandable
  * Flexible
  * Maintainable
* Subset of principles promoted by *Robert C. Martin*

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

+++
## SOLID
* #### **S**ingle responsibility principle
* #### **O**pen–closed principle
* #### **L**iskov substitution principle
* #### **I**nterface segregation principle
* #### **D**ependency inversion principle

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

+++
### **S**ingle responsibility principle
* **Class have one responsibility**
* **Never be more than one reason for a class to change**
* Issue:
  * Class won't be conceptually cohesive
  * Many reasons to change
* It is important to **minimize amount of times you need to change a class**
* If too much functionality is in one class 
    *It can be difficult to understand, how modification will affect other dependent modules

![](/Lectures/Assets/img/SingleReponsibilityPrincipe.jpg)

+++ 
### **S**ingle responsibility principle - Minimizing
+++
### **O**pen–closed principle

+++
### **L**iskov substitution principle

+++
### **I**nterface segregation principle

+++
### **D**ependency inversion principle


+++
KISS, GRASP?

---
## Refactorization
Resharper


+++
(spagetovy kod niekde?)

---
## References:
[Clean Code: A Handbook of Agile Software Craftsmanship](https://www.amazon.com/Clean-Code-Handbook-Software-Craftsmanship/dp/0132350882)  
[C# 7.0 in a Nutshell: The Definitive Reference](https://www.amazon.com/C-7-0-Nutshell-Definitive-Reference/dp/1491987650)  
[Toptal - developers](https://www.toptal.com/developers)
[Clean-code-dotnet](https://github.com/thangchung/clean-code-dotnet)
[Cvuorinen.net](https://cvuorinen.net/)  
[DZone.com](https://dzone.com/)

+++
## Refences to used images:
[clean-code-dotnet](https://github.com/thangchung/clean-code-dotnet)
[Amazon.com](https://www.amazon.com/)
