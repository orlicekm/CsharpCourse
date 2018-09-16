# Introduction to the C# language and .NET Platform
## Language basics, syntax, instalation and introduction to Visual Studio
<div class="right">
[ Michal Orlicek <xorlic00@stud.fit.vutbr.cz> ]
</div>

---
<h2>Syllabus of lectures:</h2>
todo

+++
<h2>Syllabus of laboratories</h2>
todo

---
<h2>Literature to study</h2>
<img src="/Lectures/Lecture01/Assets/img/CsharpinNutshell.jpg" />
</br>ISBN 9781491987650

+++
<h2>Recommended literature</h2>
<div class="left">
<img src="/Lectures/Lecture01/Assets/img/PrincipesPatternsPracticesinCsharp.png" />
</br>ISBN 9780131857254
</div>
<div class="right">
<img src="/Lectures/Lecture01/Assets/img/CleanCode.png" />
</br>ISBN 9780132350884
</div>

+++
<h2>Recommended literature</h2>
<div class="left">
<img src="/Lectures/Lecture01/Assets/img/DesignPatterns.png" />
</br>ISBN 9780201633610
</div>
<div class="right">
<img src="/Lectures/Lecture01/Assets/img/UnitTesting.png" />
</br>ISBN 9781617290893
</div>

---
<div class="center" >
<img src="/Lectures/Lecture01/Assets/img/VisualStudioLogo.png" />
</br><a href="https://visualstudio.microsoft.com/vs/">Free download</a>
</div>

<!-- Links for fit, fekt? -->

+++
## Compare Visual Studio versions
|  Supported Features                | Community |  Professional | Enterprise |
| ---------------------------------- | --------- | ------------- | ---------- |
| Supported Usage scenarios          | ⚫⚫⚫◯  | ⚫⚫⚫⚫     | ⚫⚫⚫⚫   |
| Development Platform Support       | ⚫⚫⚫◯  | ⚫⚫⚫⚫     | ⚫⚫⚫⚫   |
| Integrated Development Environment | ⚫⚫⚫◯  | ⚫⚫⚫◯      | ⚫⚫⚫⚫  |
| Advanced Debugging and Diagnostics | ⚫⚫◯◯  | ⚫⚫◯◯      | ⚫⚫⚫⚫  |
| Testing Tools                      | ⚫◯◯◯  | ⚫◯◯◯       | ⚫⚫⚫⚫  |
| Cross-platform Development         | ⚫⚫◯◯  | ⚫⚫◯◯      | ⚫⚫⚫⚫  |
| Collaboration Tools and Features   | ⚫⚫⚫◯  | ⚫⚫⚫◯      | ⚫⚫⚫⚫  |


+++
<h2>Installation</h2>
<div class="center">
<ol type="1">
  <li>Download Visual Studio</li>
  <li>Install the Visual Studio installer</li>
  <li>Select workloads</li>
    <ul>
    <li>Select individual components</li>
    <li>Select language packs</li>
    </ul>
  <li>Start developing</li>
</ol>
</div>

<div class="right">
<a href="https://docs.microsoft.com/en-us/visualstudio/install/install-visual-studio?view=vs-2017">Installation guide</a>
</div>

---
## Recommended tools  
[**Resharper**](https://www.jetbrains.com/resharper/)  
Extends Visual Studio with code inspections. For most inspections provides quick-fixes to improve code in one way or another. Help safely organize code and move it around the solution.

+++
[**Azure DevOps**](https://visualstudio.microsoft.com/team-services/)  
Before Visual Studio Team Services. 
* Xloud-hosted private Git repos
* Agile planning
* Build managment
* Test Plans

+++
[**Code metrices**](https://marketplace.visualstudio.com/items?itemName=vkacmar.RoslynCodeMetrices)  
Visual Studio extension that helps to monitor the code complexity. As you type, the method complexity "health" is updated, and the complexity is shown near the method.

<!---
[**Postifx templates**](https://github.com/controlflow/resharper-postfix)  
Visual Studio extension. The basic idea is to prevent caret jumps backwards while typing C# code.
NOT UPDATED -->

+++
[**Mnemonic Templates**](https://github.com/JetBrains/mnemonics)  
Templates for ReSharper that let you quickly generate code and data structures by typing in names.

+++
[**LinqPad**](http://www.linqpad.net/)  
Program that is not just for LINQ queries, but any C# expression, statement block or program. Put an end to those hundreds of Visual Studio Console projects cluttering your source folder and join the revolution of LINQPad scripters and incremental developers.

+++
[**DotPeek**](https://www.jetbrains.com/decompiler/)  
Tool based on ReSharper's bundled decompiler. It can reliably decompile any .NET assembly into equivalent C# or IL code.

+++
[**MarkdownEditor**](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.MarkdownEditor)  
A full featured Markdown editor with live preview and syntax highlighting. Supports GitHub flavored Markdown.

+++
[**Entity Framework 6 Power Tools**](https://marketplace.visualstudio.com/items?itemName=ErikEJ.EntityFramework6PowerToolsCommunityEdition)  
Useful design-time utilities for EF 6, accessible through the Visual Studio Solution Explorer context menu when right-clicking on a file containing a derived DbContext class.

+++
[**OzCode**](https://www.oz-code.com/)  
Advanced debugging tools. Analyze your queries and see how items passed through the LINQ pipeline from the comfort of Visual Studio.

+++
[**GitFlow**](https://marketplace.visualstudio.com/items?itemName=vs-publisher-57624.GitFlowforVisualStudio2017)  
Team Explorer extension integrates GitFlow into your development workflow. It lets you easily create and finish feature, release and hotfix branches right from Team Explorer. 

---
## References:

[C# 7.0 in a Nutshell: The Definitive Reference](https://www.amazon.com/C-7-0-Nutshell-Definitive-Reference/dp/1491987650)  
[Visual Studio Documentation](https://docs.microsoft.com/en-us/visualstudio)  
[Microsoft Visual Studio](https://visualstudio.microsoft.com)  
[Resharper](https://www.jetbrains.com/resharper/)  
[IW5](https://github.com/FitIW/5)  


Google images