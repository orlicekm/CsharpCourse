@snap[north span-100]
# Windows Presentation Foundation (WPF)
@snapend

@snap[midpoint span-100]
## Component Creating, Application Styling
@snapend

@snap[south-east span-30]
[ Michal Orlicek <xorlic00@stud.fit.vutbr.cz> ]
@snapend

---
## What is Windows Presentation Foundation (WPF)
* "New" graphical system for Windows
* Enables creation of "Rich-media" application
* Clear separation of roles
  * *UI* (XAML) 
  * *Business logic* (C#, VB.NET)
* Based on technologies like *HTML, CSS, Flash*
* Hardware acceleration

+++
### WPF Vector Graphics
* All application writen with WPF are **Direct3D enabled**
 * **Vector based** engine ensures performance
 * *Rendering* is accelerated by *graphics card*
 * Benefits
   * Low CPU utilization -> low power consumption
   * Quality "rich-media UI"
 * *Vector graphics* enables: *zooming, resolution changes, rotations...* without any quality loss
 * WPF implements
   * *float point system* of logical pixels
   * *32-bit ARGB* color spectrum

+++
### WPF Rendering
* Works on the lowest layer with **shapes** not **pixels** 
* *Shapes* are represented by *vectors* and can be *easily manipulated*
* Developer defines a shape and lets WPF render it in the most optimal way
* WPF contains multiple predefined shapes
  * E.g. `Line, Rectangle, Ellipse, Path` etc...
* *Shapes* are used inside *panels* and multiplicity of other WPF component contents

+++
### WPF Text Model
* Supports a wide range of *typographic* and *text rendering* functions
* *International fonts* and *composite fonts*
* WPF rendering engines use *ClearType* technologies
  * Fonts are *pre-rendered* and *stored in video memory*


+++
### WPF Animations
* Supports timed animation
  * **Timers** are *initialized and managed by WPF*
  * Changes are coordinated by **Storyboard**
* Animations can be initialized
  * By *external events*
  * On *user inputs*
* Animations are *defined by XAML* declarations

+++
### WPF Audio & Video
* Supports incorporation of *audio* and *video* into UI
* *Audio support* utilizes a thin layer based on *Win32* and *WMP* functions
* *Video support* uses native formats *WMV, MPEG* and subset of *AVI*
* Interaction between *video* and *animations*
  * Combination of *video* and *animations* creates dynamic content
  * *Animations* can be synchronized with media

---
### WPF – Styles
* **Style** is a *set of properties* applied to the *content*
  * Defines *changes in rendering*
  * Concept is the same as with *CSS*
  * E.g. change *button's text's font*
* Used for **visual state standardization** to set the same set of properties for particular items
* WPF styles contain specific properties for UI creation
  * E.g. *begin a set of visual effects* as a *reaction to a user action*

+++
### WPF - Templates
* Enables **complex changes to UI** state of any WPF items
* **Available templates**
  * `ControlTemplate` – UI style sharing across multiple controls 
  * `ItemsPanelTemplate` – panel look, 
    * E.g. `ListBox`
  * `DataTemplate` – item look inside a panel
  * `HierarchicalDataTemplate` - object look inside panels with hierarchical structure
    * E.g. `TreeView`

---
### WPF - Commands
* `Command` is an abstract and *loosely-coupled* version of `event`
* E.g., *Copy, Cut, Paste, Save, etc...*
* Reduces the necessary code amount
* Enables UI changes without a need to change *back-end* logic
* Commands have *action, source, target and binding*

+++
### Commands Benefits
* Wide range of *predefined commands*
* Provide **automated support for user input actions**
* Most of the components have **built-in support** for them
  * E.g. `button` has property `Command`
* *Clean Code* without *Code-behind*
* **Command design pattern**
  * Launches *action*
  * *Checks* if the action is permited to launch

---
## XAML
* **XAML** - e**X**tensible **A**pplication **M**arkup **L**anguage
* UI Declaration is based on **XAML**
* **Declarative language**
* Declares *behavior* and *interaction* of UI componets
* Form of *serialization of object hierarchy*
* *.NET namespaces* are represented by *XML namespaces*
* Typicaly closely connected with *Code-behind* class

+++
### XAML - Basics
* **XAML** is based on **XML**
* *Declaration* and *initiation* of *.NET objects*
* Used **to separate *UI* from *Code-behind***
  * *Backend* from *frontend*
* Contains element hierarchy representing visual objects
* These objects are called *user interface elements* or *UI elements*

+++
#### Hello WPF Sample
![](/Lectures/Lecture10/Assets/img/HelloWPF.png)

+++?code=/Lectures/Lecture10/Assets/sln/HelloWpf/MainWindow.xaml&lang=XML&title=Hello WPF XAML
@[1,13]
@[2]
@[3-7]
@[5,6,8]
@[9]
@[10,12]
@[11]
[Code sample](/Lectures/Lecture10/Assets/sln/HelloWpf/MainWindow.xaml)

+++?code=/Lectures/Lecture10/Assets/sln/HelloWpf/MainWindow.xaml.cs&lang=C#&title=Hello WPF XAML Code Behind
@[8-14]
@[8]
@[10-13]
@[12]
@[8-14]
[Code sample](/Lectures/Lecture10/Assets/sln/HelloWpf/MainWindow.xaml.cs)

+++
#### Hello WPF Explanation
* Declarations
  * *Window/UserControl/…* - inheritance
  * `x:Class` - class containing *Code-behind*
  * `xmlns:x` - mandatory namespace for XAML
  * `xmlns:d` - optional *design time* functionality
  * `mc:Ignorable` - ingnoration of namespaces in *runtime*
  * `xmlns` - namespace with build-in components in WPF
* *Root element* `Windows` declares a partial class
* `Width, Height, Title` are *properties*
* *Element* `Button` declares item button

+++
### Elements & Attributes - Object properties 
* *UI Elements* have common subset of *properties* and *functions*
  * E.g., `Width, Height, Cursor, Tag` properties
* Declaration of XML *element* in XAML
  * Same effect as calling *parameterless constructor*
* Setting of *Attribute* on the element 
  * Same as *assigment to a property* of the same name.  
* **Atribut** – simple property
* **Element** – *UI Element*, complex property, class initialization

+++
### Propertie elements
* Not all *properties* has to contain `string` only
* **Properties can contain instances of other objects**
* XAML defines syntactical notation for *complex property* definition called **propertie elements**
* Form *TypeName.PropertyName* contained inside *TypeName* element

```XAML
<Grid>
   <Grid.ColumnDefinitions>
      <ColumnDefinition Width="1*"/>
      <ColumnDefinition Width="2*"/>
   </Grid.ColumnDefinitions>
</Grid>
```


---
## References:
[C# 7.0 in a Nutshell: The Definitive Reference](https://www.amazon.com/C-7-0-Nutshell-Definitive-Reference/dp/1491987650)  

+++
## Refences to used images:
