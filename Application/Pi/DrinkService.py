from Models.GlobalQueue import globalQueue
from tkinter import messagebox
import json
import requests as REST
from Models import Schema
from Models import DictToObj
from gpiozero import LED
from time import sleep

class PumpService(object):
    def __init__(self):
        """Konstruktor, diese Klasse mappt Ingredients auf Pumpen."""
        print('DrinkService running')
        self.pump1 = LED(23)
        self.pump1.on()
        self.pump2 = LED(14)
        self.pump2.on()
        self.pump3 = LED(4)
        self.pump3.on()
        self.pump4 = LED(15)
        self.pump4.on()
        self.pump5 = LED(18)
        self.pump5.on()
        self.pump6 = LED(17)
        self.pump6.on()

        #flüssigkeiten anziehen
        self.pump1.off()
        sleep(0.6)
        self.pump1.on()
        self.pump2.off()
        sleep(0.6)
        self.pump2.on()
        self.pump3.off()
        sleep(0.6)
        self.pump3.on()
        self.pump4.off()
        sleep(0.6)
        self.pump4.on()
        self.pump5.off()
        sleep(0.6)
        self.pump5.on()
        self.pump6.off()
        sleep(0.6)
        self.pump6.on()

    def run(self):
        self.getDrinkList()
        self.getPumpConfig()
        self.checkQueue()


    def checkQueue(self):
        while True:
            if globalQueue.not_empty:
                self.makeDrink()

    def getDrinkList(self):
        payload = REST.get('https://onetouchnextgen.tech:5000/api/drinks', verify = False)
        if payload.status_code != 200:
            #problemo maximo
            print('getting DrinkList failed')
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
        except jsonObject:
            print('Obtaining and parsing the file you requested failed')

    def getPumpConfig(self):
        payload = REST.get('https://onetouchnextgen.tech:5000/api/machine/config', verify = False)
        if payload.status_code != 200:
            #problemo maximio
            print('getting Config failed')
        try:
            jsonString = payload.text
            self.config = json.loads(jsonString)
            print(jsonString)
        except self.config:
            print('Obtaining and parsing the file you requested failed')

    def makeDrink(self):
        #nutzer muss bestätigen dass ein Glas da steht
        ingredients = json.loads(globalQueue.get(True))
        ingredientsList = DictToObj.ConvertDictToObj(ingredients)
        counter = 0
        #actual get the fookin drink
        messagebox.showinfo('Information', 'Make sure a glass is standing under the drain')
        for ingrFromList in ingredientsList.Data:
            #determine pump
            for ingrFromConf in self.config:
                counter+=1
                if ingrFromList.Name == self.config[ingrFromConf]:
                    #use that pump with the value for that pump
                    if counter == 1:
                        print('pump1')
                        self.activatePump1(ingrFromList.How_Much)
                    elif counter == 2:
                        print('pump2')
                        self.activatePump2(ingrFromList.How_Much)
                    elif counter == 3:
                        print('pump3')
                        self.activatePump3(ingrFromList.How_Much)
                    elif counter == 4:
                        print('pump4')
                        self.activatePump4(ingrFromList.How_Much)
                    elif counter == 5:
                        print('pump5')
                        self.activatePump5(ingrFromList.How_Much)
                    else:
                        print('pump6')
                        self.activatePump6(ingrFromList.How_Much)
                if counter == 6:
                    #zurücksetzen
                    counter = 0
        globalQueue.task_done()
    
    def activatePump1(self, volume):
        self.pump1.off()
        sleep(0.584*volume)
        self.pump4.on()

    def activatePump2(self, volume):
        self.pump2.off()
        sleep(0.584*volume)
        self.pump2.on()

    def activatePump3(self, volume):
        self.pump3.off()
        sleep(0.584*volume)
        self.pump3.on()

    def activatePump4(self, volume):
        self.pump4.off()
        sleep(0.584*volume)
        self.pump4.on()

    def activatePump5(self, volume):
        self.pump5.off()
        sleep(0.584*volume)
        self.pump5.on()

    def activatePump6(self, volume):
        self.pump6.off()
        sleep(0.584*volume)
        self.pump6.on()

