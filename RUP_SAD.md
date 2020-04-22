## One Touch Next Gen
Software Architecture Document


## Table of Contents
1.	Introduction	
1.1	Purpose	
1.2	Scope	
1.3	Definitions, Acronyms, and Abbreviations	
1.4	References	
1.5	Overview	
2.	Architectural Representation	
3.	Architectural Goals and Constraints	
4.	Use-Case View	
5.	Logical View	
5.1	Overview	
5.2	Architecturally Significant Design Packages	
6.	Process View	
7.	Deployment View	
8.	Implementation View	
8.1	Overview	
8.2	Layers	
9.	Data View (optional)	
10.	Size and Performance	
11.	Quality	
 
# Software Architecture Document 
# 1.	Introduction
The introduction of the Software Architecture Document provides an overview of the entire Software Architecture Document. It includes the purpose, scope, definitions, acronyms, abbreviations, references, and overview of the Software Architecture Document.
## 1.1	Purpose
This document provides a comprehensive architectural overview of the system, using a number of different architectural views to depict different aspects of the system. It is intended to capture and convey the significant architectural decisions which have been made on the system.
## 1.2	Scope
This document describes the architecture of the mobile application from the OneTouch project including all necessary infrastructure.
## 1.3	Definitions, Acronyms, and Abbreviations
|**Abbreviations**||
|---|---|
|SRS|Software Requirements Specification|
|SAD|Software Architecture Document|
|RUP|Rational Unified Process|
## 1.4	References
|**Title|Date**|
|---|---|
|[Blog](https://onetouch940978896.wordpress.com/)|Stand 10/20/2019|
|[Github](https://github.com/TheLordXII/OneTouch)| Stand 10/20/2019|
|[Use Case Diagram](https://github.com/TheLordXII/OneTouch/blob/master/UseCaseDiagram.png)|Stand 10/20/2019|
|[SRS](https://github.com/TheLordXII/OneTouch/blob/master/SRS.md)|Stand 10/20/2019|
## 1.5	Overview
All necessary architectural details will be described in the following sections. This includes a database diagram, which gives an overview about the project structure.
Furthermore, the architectural representation, goals and constraints are clarified in this document.
# 2.	Architectural Representation 
The OneTouch application will consist of an application working directly on the rasberry pi and an application for mobiles. The mobile application will be developed in C# in Xamarin. Both applications will be using a SQL database. The SAD will describe the Architecture of the mobile app. 

the mvvm architecture in Xamarin:
![](https://github.com/TheLordXII/OneTouch/blob/master/mvvmXamarin.png)

# 3.	Architectural Goals and Constraints 
Xamarin uses a Model-View-Viewmodel- architecture. This should lead to a clear distinction between data, logic and views.

# 4.	Use-Case View 
![](https://github.com/TheLordXII/OneTouch/blob/master/UseCaseDiagram.png)
To look at the detailed Use Case descritions please visit the [SRS](https://github.com/TheLordXII/OneTouch/blob/master/SRS.md).

# 5.	Logical View 
tbd
## 5.1	Overview
tbd
## 5.2	Architecturally Significant Design Packages
tbd
# 6.	Process View 
tbd
# 7.	Deployment View 
tbd
# 8.	Implementation View 
tbd
## 8.1	Overview
tbd
## 8.2	Layers
tbd
# 9.	Data View (optional)
![](https://github.com/TheLordXII/OneTouch/blob/master/Database/DBSchema.png)
# 10.	Size and Performance 
tbd
# 11.	Quality 
tbd
