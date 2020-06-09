**Sauf-O-Mat**

**Software Requirements Specification**

Version \<1.1\>                                             
 
 **Software Requirements Specification**
======================================

# 1. Introduction

## 1.1 Purpose

The purpose of this document gives a general description of the
OneTouch Project. It explains our vision and all features of the
product. Also it offers insights into the system of back- and frontend,
the interfaces in both ends for communication and the constraints of the
product.

## 1.2 Scope

This document is designed for internal use only and will outline the
development process of the project.

## 1.3 Definitions, Acronyms, and Abbreviations

|**Abbreviations**||
|---|---|
|SRS|Software Requirements Specification|
|API|Application Programming Interface|
|HTTPS|Hyper Text Transfer Protocol Secure|
|REST|Representational State Transfer|
|JSON|Javascript Object Notation|
|MQTT|Message Queuing Telemetry Transport|

## 1.4 References

|**Title|Date**|
|---|---|
|[Blog](https://onetouch940978896.wordpress.com/)|Stand 10/20/2019|
|[Github](https://github.com/TheLordXII/OneTouch)| Stand 10/20/2019|
|[Use Case Diagram](https://github.com/TheLordXII/OneTouch/blob/master/UseCaseDiagram.png)|Stand 10/20/2019|
|[YouTrack](https://onetouchnextgen.myjetbrains.com/youtrack/dashboard?id=5a3ea5e0-9f57-44b5-8273-cebf57afc28e)| Stand 06/06/2020|

## 1.5 Overview

The next chapters provide information about our vision based on the use
case diagram as well as more detailed requirements.

# 2. Overall Description

## 2.1 Vision

Our vision is a one touch Cocktail machine…. but with a social touch. We would not only like to offer the Hardware, that means the machine itself, but also an iOS-Application which allows you to customize your drink and see activities of your friends. Share your favorite drinks and get together!

We acknowledged that especially in IT people are used to not talk with each other… and a nice evening with drinks could sometimes maybe change that.

![Blog](https://onetouch940978896.wordpress.com/2019/10/02/example-post/#jp-carousel-22)

## 2.2 Use Case Diagram

Use Case Diagram:
![](https://github.com/TheLordXII/OneTouch/blob/master/UseCaseDiagram.png)

# 3. Specific Requirements 

## 3.1 Functionality

### [login](https://github.com/TheLordXII/OneTouch/blob/master/UCs/UC_login.md)

### [Get drink App](https://github.com/TheLordXII/OneTouch/blob/master/UCs/UC_GetDrinkApp.md)

### [Get surprise drink Machine](https://github.com/TheLordXII/OneTouch/blob/master/UCs/UC_GetDrinkMachine.md)

### [Database](https://github.com/TheLordXII/OneTouch/blob/master/UCs/UC_database.md)

### [Secure Data Transfer](https://github.com/TheLordXII/OneTouch/blob/master/UCs/UC_securelyTransferringData.md)

### [GUI App](https://github.com/TheLordXII/OneTouch/blob/master/UCs/UC_GUI_App.md)

### [GUI Pi](https://github.com/TheLordXII/OneTouch/blob/master/UCs/UC_GUI_Pi.md)

### [create new drink](https://github.com/TheLordXII/OneTouch/blob/master/UCs/additional_UC_CreateNewDrink.md)

### [watch statistics](https://github.com/TheLordXII/OneTouch/blob/master/UCs/additional_UC_ShowStatistics_UC.md)

### [CRUD Drinks](https://github.com/TheLordXII/OneTouch/blob/master/UCs/additional_UC_CRUDDrink.md)

### [CRUD Friends](https://github.com/TheLordXII/OneTouch/blob/master/UCs/additional_UC_CRUDFriends.md)

### [CRUD User](https://github.com/TheLordXII/OneTouch/blob/master/UCs/additional_UC_CRUDUser.md)

### [create new account](https://github.com/TheLordXII/OneTouch/blob/master/UCs/additional_UC_CreateAccount.md)

### [Get drink from list](https://github.com/TheLordXII/OneTouch/blob/master/UCs/additional_UC_GetDrinkFromListMachine.md)

## 3.2 Usability 
 
The concept behind this project is to a) have fun together and b) to not exclude someone. Therefore we have designed following concept. If you want to create and order custom drinks you will have to download the mobile Application for your iOS device and create a User account. If you don't have access to iOS or don't want to create an account you can still use the machine as a surprise drink vending machine to get a random drink, 'cause that's fun and stuff.

The user can use the machine with no learning time whatsoever, since the GUI on the machine is designed to have only one button to order a random drink. 

For full access to all functions a user will have to create an account, so that we can ensure that you can't spam requests so easily to the backend. If a user has access to the app itself, it should be no problem to order him-/herself a drink. 
In both cases a fundamental understanding of reading and letters is required. 

## 3.3 Reliability 

The machine and the service will be online 24/7 under normal circumstances. Of course there will be server maintenance and updates each month for about 2h, where the backend will be unreachable and the app including the machine not working. If an update for the app arrives, it will be patched in that specific time. 

## 3.4 Performance

### Speed

As with any physical system there are limitations in speed of operation. Since we want to transport fluids from point A to point B there is a limitation in the speed the pumps can do relative to their precision. A drink will need between 20-40 seconds to make depending on complexitiy and volume. 

Different users can order drinks at the same time but they will be made sequentially, when there is a glass under the drain. 

The backend communication uses http and mqtt which are both fast and lightweight protocols for intermachine communication. Requests to the database are handled via an REST-API, that is highly parallelized, which benefits speed greatly.

## 3.5 Supportability

We will use the following languages, which will also be well supported in the future: C#, XML, Node JS and Python.

The machine can be supported by anyone with a proper understanding of Linux and Electronics. 

The repository is public and we try to use best practices for coding. 

## 3.6 Design Constraints

### developing tools

+ IDE: Visual Studio, Visual Studio Code
+ main programming laguage: Xamarin C#, Node JS, Python
+ version control: github
+ project management tool: YouTrack, Codacy, Jenkins
+ API-Testing: Postman
+ server: windows server by strato
+ database: MS SQL
+ libraries: Mosquitto, Express, Paho, MVVM Light, Newtonsoft.JSON, NUnit

## 3.7 Online User Documentation and Help System Requirements

The app is self-explanatory.

## 3.8 Purchased Components

|product|number|link|
|---|---|---|
|Raspberry Pi 4|1|[raspberry pi](https://www.conrad.de/de/p/raspberry-pi-4-b-essentials-kit-4-gb-4-x-1-5-ghz-inkl-netzeil-inkl-gehaeuse-raspberry-pi-2142105.html)|
|Touchscreen for RP4|1|[touchscreen](https://www.conrad.de/de/p/raspberry-pi-rb-lcd-7-display-modul-17-8-cm-7-zoll-800-x-480-pixel-passend-fuer-raspberry-pi-1388955.html)|
|pumps (not working)|8|[pumps](https://www.amazon.de/Decdeal-Wasserpumpe-Teichpumpe-Aquarium-Modellbau/dp/B01FTL6H8S/ref=asc_df_B01FTL6H8S/?tag=googshopde-21&linkCode=df0&hvadid=215721993267&hvpos=1o3&hvnetw=g&hvrand=450397352909023812&hvpone=&hvptwo=&hvqmt=&hvdev=c&hvdvcmdl=&hvlocint=&hvlocphy=9041876&hvtargid=pla-378590261884&psc=1&th=1&psc=1)|
|usb hub|1|[usb hub](https://www.conrad.de/de/p/renkforce-7-2-port-usb-3-0-hub-mit-schnellladeport-mit-status-leds-schwarz-1268678.html)|
|big tube|1m|[tube](https://www.conrad.de/de/p/gardena-18055-22-19-mm-3-4-zoll-grau-schwarz-orange-gartenschlauch-1423064.html)|
|small tube|4m|[tube](https://www.conrad.de/de/p/reely-silikonkraftstoff-schlauch-innen-durchmesser-3-mm-transparent-milchig-1483814.html)|
|shrinking tube|1.2m|[shrinking tube](https://www.conrad.de/de/p/te-connectivity-atum-19-6-0-schrumpfschlauch-mit-kleber-schwarz-19-mm-schrumpfrate-3-1-1-2-m-1383129.html)|
|Server|1|[Server](https://www.strato.de)|
|Pumps|6|[pumps](https://www.amazon.de/Akozon-Membranpumpe-Elektrische-Saugpumpe-Maschine/dp/B07JLV7KDF/ref=pd_nav_hcs_rp_1/257-1272412-2379046?_encoding=UTF8&pd_rd_i=B07JLV7KDF&pd_rd_r=ce73e2b4-915b-41a0-b94f-0549ffd8de83&pd_rd_w=LB2Yk&pd_rd_wg=M5MQz&pf_rd_p=79a9a03b-2453-4f3e-ab18-e4dcc2190acb&pf_rd_r=9G565X1BE89612SMK2P1&psc=1&refRID=9G565X1BE89612SMK2P1)|
|5V PSU|1|[5V PSU](https://www.amazon.de/gp/product/B00MWQD43U/ref=ppx_yo_dt_b_asin_title_o01_s00?ie=UTF8&psc=1)|
|12V PSU|1|[12V PSU](https://www.amazon.de/gp/product/B01LLFEMQ0/ref=ppx_yo_dt_b_asin_title_o01_s00?ie=UTF8&psc=1)|
|8 Channel Relay|1|[8 Channel Relay](https://www.conrad.de/de/p/seeit-smtrelay08-1-st-passend-fuer-arduino-raspberry-pi-95842.html)|
|Soldering Tin|1|[Soldering Tin](https://www.conrad.de/de/p/stannol-hs10-fair-loetzinn-spule-sn99-3cu0-7-100-g-0-5-1414237.html)|
|Wire|1|[Wire](https://www.conrad.de/de/p/tru-components-kupferlackdraht-aussen-durchmesser-inkl-isolierlack-0-50-mm-23-1567049.html)|
|Pliers|1|[Pliers](https://www.conrad.de/de/p/knipex-multistrip-10-12-42-195-automatische-abisolierzange-0-03-bis-10-mm-7-bis-826997.html)|
|Isolating Tape|1|[Isolating Tape](https://www.conrad.de/de/p/3m-super-88-80610139521-isolierband-scotch-super-88-schwarz-l-x-b-6-m-x-19-mm-6-545578.html)|


## 3.9 Interfaces

### 3.9.1 User Interfaces

There is a GUI on the iOS app and also on the raspberry pi.
The raspberry pi has only one button, which lets you order a random drink.

The app consinsts of multiple views. There is a login screen with inputs for username and password. After login you will be presented a list view of drinks from which you can see details on select and order them ultimately. For Navigation there is a menu on the lefthand side to navigate between views. There is also a friends view to see your friends. 

### 3.9.2 Hardware Interfaces

Pumps are connected to the pi via gpio and the relay. If the pin is pulled to low the pump goes brrr.

### 3.9.3 Software Interfaces

App and Pi are connected via an REST API to the database. REST API listens on TCP Port 5000.

### 3.9.4 Communications Interfaces

HTTPS-Requests to the REST-API. REST-API does order drinks via MQTT on the Pi. 

## 3.10 Licensing Requirements

NA

## 3.11 Legal, Copyright, and Other Notices

NA

## 3.12 Applicable Standards

NA

# 4. Supporting Information

**For more information contact us on our blog.**
