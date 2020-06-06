import pygubu
import tkinter as tk
import os
from MQTTService import MqttService
import threading
import requests as REST
import random
from Models.GlobalQueue import globalQueue
from DrinkService import PumpService


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
        self.startDrinkService()

    def startMqtt(self):
        self.mqttService = MqttService()
        mqttThread = threading.Thread(target = self.mqttService.run, daemon = True)
        print('starting MQTITI loooooooooooooolz')
        mqttThread.start()

    def startDrinkService(self):
        self.drinkService = PumpService()
        drinkThread = threading.Thread(target = self.drinkService.run, daemon = True)
        print('starting DrinkService')
        drinkThread.start()

    def get_surprise_drink(self):
        #calculate surprise drink id
        drinkIndex = random.randint(0, self.drinkService.DrinksInList-1)
        #get DrinkID from Dict
        drinkID = self.drinkService.workingList.Data[drinkIndex].DrinkID
        drinkIDAsString = str(drinkID)
        #getIngredientDict for said drinkId
        payload = REST.get('https://onetouchnextgen.tech:5000/api/ingredientlist/' + drinkIDAsString, verify = False)
        if payload.status_code!=200:
            #problemo maximo
            print('getting IngredientInfo failed')
            return
        jsonString = payload.text
        globalQueue.put(jsonString, True)


if __name__ == '__main__':
    root = tk.Tk()
    app = App(root)
    #main loop der tk app ausführen
    root.mainloop()