from Models.GlobalQueue import globalQueue
from tkinter import messagebox
import json
import requests as REST
from Models import Schema
from Models import DictToObj

class PumpService:
    def __init__(self):
        """Konstruktor, diese Klasse mappt Ingredients auf Pumpen."""
        print('DrinkService running')

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
                print(drink)
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
                        #activatePump1(ingr.How_Much)
                    elif counter == 2:
                        print('pump2')
                        #activatePump2(ingr.How_Much)
                    elif counter == 3:
                        print('pump3')
                        #activatePump3(ingr.How_Much)
                    elif counter == 4:
                        print('pump4')
                        #activatePump4(ingr.How_Much)
                    elif counter == 5:
                        print('pump5')
                        #activatePump5(ingr.How_Much)
                    else:
                        print('pump6')
                        #activatePump6(ingr.How_Much)
                if counter == 6:
                    #zurücksetzen
                    counter = 0
        globalQueue.task_done()

