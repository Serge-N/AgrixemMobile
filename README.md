# Agrixem Mobile

Techonology | Selected Option
------------ | -------------
**Client** | The University of Zambia, School of Engineering
**Type** | Mobile Application
**Mode** | Cross platiform
**Service API**|  Representational state transfer (REST)
**Framework** | Xamarin
**Alternatives** | Flutter, React Native
**Authentication** |Jwt Token with Claims
**Others** | Google Maps API

# Description
When a tracking an animal, be it a goat or cattle, you have to follow footsteps and droppings. Doing so is tiresome.
Hence the need for an application that shows you where you are and where the animal is in realtime.

This very feature is also implemented by the Single Page Application (SPA). The implementation on moblie device is because of its portabilty. The need to process only that we are interested in rather than the whole SPA.

An electronic device attached to an animal makes a HTTP POST which contains Global Positioning System (GPS) cordinates of the animal to a backend server. Posting of essential data is done a regular time interval. Network provision is done using a General Packet Radio Services (GPRS) chip. 2G still covers most of our country. The information is then requested by mobile application. Keep in mind that all animals despite the farm or type are posting data to the same REST endpoint. 

The application was only designed with one feature in mind, showing locations of both the animal and you. Your location is updated in realtime while that of the animal is updated periodically at the backend. To update the animal location on a gntle tap can be given on the map. Just like the SPA, this is also an MVP.

# How it looks
![Menu](AgrixemMobile/AgrixemMobile/AgrixemMobile/screenshoots/menu.png)

![Settings](AgrixemMobile/AgrixemMobile/AgrixemMobile/screenshoots/settings.png)

###### Images might be updated as quickly as the source code.
