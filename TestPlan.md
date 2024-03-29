# Test plan

## 1.	Introduction
### 1.1	Purpose
The purpose of the Iteration Test Plan is to gather all of the information necessary to plan and control the test effort for a given iteration. 
It describes the approach to testing the software.
This Test Plan supports the following objectives:
-	Identifies the items that should be targeted by the tests.
-	Identifies the motivation for and ideas behind the test areas to be covered.
-	Outlines the testing approach that will be used.
-	Identifies the required resources and provides an estimate of the test efforts.

### 1.2	Scope
This document describes the used unit test.

### 1.3	Intended Audience
This document is meant for internal use primarily.

### 1.4	Document Terminology and Acronyms
- **SRS**	Software Requirements Specification
- **n/a**	not applicable
- **tbd**	to be determined

### 1.5	 References
- [GitHub](https://github.com/TheLordXII/OneTouch)
- [Blog](https://onetouch940978896.wordpress.com/2019/10/02/example-post/)
- [Software Requirements Specification](https://github.com/TheLordXII/OneTouch/blob/master/SRS.md)
- [Software Architecture Document](https://github.com/TheLordXII/OneTouch/blob/master/SAD.md)


## 2.	Evaluation Mission and Test Motivation
### 2.1	Background
n/a
### 2.2	Evaluation Mission
n/a
### 2.3	Test Motivators
n/a

## 3.	Target Test Items
n/a

## 4.	Outline of Planned Tests
### 4.1	Outline of Test Inclusions
n/a
### 4.2	Outline of Other Candidates for Potential Inclusion
n/a

## 5.	Test Approach
### 5.1	Testing Techniques and Types
#### 5.1.1	Function and Database Integrity Testing
n/a

#### 5.1.2	Unit Testing
|||
|---|---|
|Technique Objective|Every service request shall be done correctly. Possible exceptions are caught correctly.|
|Technique|Unit testing the viewmodel, view and services|
|Oracles|user enter valid data, for example a valid username and a valid password|
|Required Tools|NUnit|
|Success Criteria|successful scenarios, all tests will pass, no strange behaviour will occur|
|Special Consideration|-|
#### 5.1.3	Business Cycle Testing
n/a

#### 5.1.4	User Interface Testing
|||
|---|---|
|Technique Objective|Every interaction with the frontend should function as intended.|
|Technique|feature file testing (blogsite because it doesn't work with Xamarin)|
|Oracles|information is shown as expected|
|Required Tools|Selenium, Cucumber|
|Success Criteria|Expected behavior and passing tests|
|Special Consideration|-|

#### 5.1.5	Performance Profiling 
n/a

#### 5.1.6	Load Testing
n/a

#### 5.1.7	Stress Testing
n/a
 
#### 5.1.8	Volume Testing
n/a

#### 5.1.9	Security and Access Control Testing
tbd

#### 5.1.10	Failover and Recovery Testing
n/a

#### 5.1.11	Configuration Testing
n/a

#### 5.1.12	Installation Testing
tbd

### 5.2 API Testing
API Testing ist used to ensure that the communication between the front- and the backend is working as expected. The Tests ensure that the communication between App, machine and database is working as wanted and expected.

API Testing is commonly a part of Integration Testing which means that multiple parts of the application are tested together.

[Postman Monitor](https://web.postman.co/monitors/1ea9423e-3dc1-4900-ad73-56155b32e9b4?job=1eaac985-f4a4-4210-a235-e879c38a64cd&result=success&result=failure&result=error&result=abort&trigger=api&trigger=schedule&trigger=webhook&workspace=5ad1e596-49b8-4a6d-8a4c-b2f52073be8e)

|||
|---|---|
|Technique Objective|Test the API and the backend automatically|
|Technique|Write a Postman collection of API queries and test, automated by a monitor, if the reply status code is the wanted one.|
|Oracles|The steps of the test will be documented in the console of the Postman monitor. The result will also be visualized in the monitor overview.|
|Required Tools|[Postman](https://www.postman.com/)|
|Success Criteria|All the API tests pass.|
|Special Consideration|-|

![](https://github.com/TheLordXII/OneTouch/blob/master/PostmanTestResult.png)

## 6.	Entry and Exit Criteria
### 6.1	Test Plan
#### 6.1.1	Test Plan Entry Criteria
n/a
#### 6.1.2	Test Plan Exit Criteria
n/a

## 7.	Deliverables
### 7.1	Test Evaluation Summaries
n/a
### 7.2	Reporting on Test Coverage
There is no way to get code coverage on a Xamarin app.

### 7.3	Perceived Quality Reports
n/a
### 7.4	Incident Logs and Change Requests
With the help of Jenkins we will integrate a check into github for pull requests.

### 7.5	Smoke Test Suite and Supporting Test Scripts
n/a
### 7.6	Additional Work Products
n/a
#### 7.6.1	Detailed Test Results
n/a
#### 7.6.2	Additional Automated Functional Test Scripts
[Unit Test Code](https://github.com/TheLordXII/OneTouch/tree/master/Application/MobileApp/OneTouchUnitTests/Tests)
[Feature Files Code](https://github.com/TheLordXII/OneTouch/blob/master/Cucumber/Cucumber/TestSteps.cs)

#### 7.6.3	Test Guidelines
n/a
#### 7.6.4	Traceability Matrices
n/a

## 8.	Testing Workflow
The developers can and should run the tests in their IDE.
After every push and merge request Jenkins builds and tests the application automatically.

## 9.	Environmental Needs
What system did you use
to test?
Sonar? Other? Integration
with other tools?
### 9.1	Base System Hardware
|Resource|Quantity|Name and Type|
|---|---|---|
|Database Server|1|Strato Server|
|Client Test PC|1|zB MacBookPro 2019|

### 9.2	Base Software Elements in the Test Environment
|Software Element Name|Version|Type and Notes|
|---|---|---|
|Mac OS Catalina|10.15.x|Operating System|
|Windows|10|Operating System|
|Chrome||Internet Browser|
|SQL Server||database|


### 9.3	Productivity and Support Tools
|Tool Category|Brand name|
|---|---|
|Code Hoster|Github|
|CI Service|Jenkins|
|API Test|Postman|

## 10.	Responsibilities, Staffing, and Training Needs
### 10.1	People and Roles
This table shows the staffing assumptions for the test effort.
|Role|Minimum Resources Recommended(number of full-time roles allocated)|Specific Responsibilities or Comments|
|---|---|---|
|Test Manager|1|Provides management oversight.  Responsibilities include:  planning and logistics  agree mission  identify motivators acquire appropriate resources present management reporting advocate the interests of testevaluate effectiveness of test effort|
|Test Designer|1|Defines the technical approach to the implementation of the test effort.  Responsibilities include: define test approach define test automation architecture verify test techniques define testability elements structure test implementation|
|Tester|1|Implements and executes the tests. Responsibilities include: implement tests and test suites execute test suites log results analyze and recover from test failures document incidents|
|Test System Administrator|1|Ensures test environment and assets are managed and maintained. Responsibilities include: 	administer test management system install and support access to, and recovery of, test environment configurations and test labs|
|Database Administrator|1|Ensures test data (database) environment and assets are managed and maintained. Responsibilities include: support the administration of test data and test beds (database)|
|Implementer|1|Implements and unit tests the test classes and test packages. Responsibilities include: creates the test components required to support testability requirements as defined by the designer|

### 10.2	Staffing and Training Needs
n/a

## 11.	Iteration Milestones
|Milestone|Planned start Date|actual start date|planned end date|actual end date|
|---|---|---|---|---|
|First Unit Tests|06.05.20|08.05.20|12.05.20|10.05.20|
|Tests integrated in CI|12.05.20|12.05.20|19.05.20|no integration possible|
|20% coverage|13.05.20||27.05.20|no calculation possible|
## 12. Risks, Dependencies, Assumptions and Constaints
n/a

## 13. Management Process and Procedures
n/a
