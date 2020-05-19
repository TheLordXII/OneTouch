import pygubu
import tkinter as tk
import os
from gpiozero import LED
from Services.MQTTService import MqttService
import threading
import requests as REST
import json
import random
from Models import Schema
from Models import DictToObj


class App():
    def __init__(self,master):
        #master für die app festlegen
        self.master = master
        #builder erstellen
        self.builder = builder = pygubu.Builder()
        #ui quelle laden
        path = os.path.dirname(os.path.abspath(__file__))
        path = path + os.path.sep + 'interface.ui' #geht halt nur auf mac und raspbian os
        builder.add_from_file(path)
        #Ein widget erstellen, der master wird als parent benutzt
        self.mainwindow = builder.get_object('mainwindow', self.master)
        #callbacks
        builder.connect_callbacks(self)
        self.startMqtt()
        self.getDrinkList()
        self.getPumpConfig()

    def startMqtt(self):
        self.mqttService = MqttService()
        runThread = threading.Thread(target = self.mqttService.run)
        print('starting MQTITI loooooooooooooolz')
        runThread.start()

    def getDrinkList(self):
        payload = REST.get('https://onetouchnextgen.tech:5000/api/drinks', verify = False)
        if payload.status_code != 200:
            #problemo maximo
            print('getting DrinkList failed')
        #inhalt wird als string angezeigt
        try:
            jsonString = payload.text
            jsonObject = json.loads(jsonString)
            schema = Schema.DataList()
            drinkList = schema.deserialize(jsonObject)
            #drinkList ist dict schema spezifiziert das Aussehen des dict
            #deserialisierung nach Object -> dictionaries sind schwul wie scheiße und generell hardcore dumm
            self.workingList = DictToObj.ConvertDictToObj(drinkList)
            self.DrinksInList = 0
            for drink in self.workingList.Data:
                self.DrinksInList += 1
        except:
            print('Obtaining and parsing the file you requested failed')

    def getPumpConfig(self):
        payload = REST.get('https://onetouchnextgen.tech:5000/api/machine/config', verify = False)
        if payload.status_code != 200:
            #problemo maximio
            print('getting Config failed')
        try:
            jsonString = payload.text
            self.config = json.loads(jsonString)
        except:
            print('Obtaining and parsing the file you requested failed')
        
    def get_surprise_drink(self):
        #calculate surprise drink id
        drinkIndex = random.randint(0, self.DrinksInList-1)
        #get DrinkID from Dict
        drinkID = self.workingList.Data[drinkIndex].DrinkID
        drinkIDAsString = str(drinkID)
        #getIngredientDict for said drinkId
        payload = REST.get('https://onetouchnextgen.tech:5000/api/ingredientlist/' + drinkIDAsString, verify = False)
        if payload.status_code!=200:
            #problemo maximo
            print('getting IngredientInfo failed')
            return
        try:
            jsonString = payload.text
            ingredients = json.loads(jsonString)
            #make the integers in ingredients access
            ingredientsList = DictToObj.ConvertDictToObj(ingredients)
            #actual get the fookin drink
            for ingr in ingredientsList.Data:
                #determine pump
                for ingrName in self.config:
                    if ingr.Name == self.config[ingrName]:
                        #use that pump with the value for that pump
                        print(ingr.How_Much)
                        
        except:
            print('Parsing Ingredients in to Object failed')



if __name__ == '__main__':
    root = tk.Tk()
    app = App(root)
    #main loop der tk app ausführen
    root.mainloop()