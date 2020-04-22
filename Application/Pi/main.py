import tkinter as tk
import pygubu
import gpiozero
import time

class Application:
    def __init__(self, master):

        #1: Create a builder
        self.builder = builder = pygubu.Builder()

        #2: Load an ui file
        builder.add_from_file("S:\OneTouch\Application\Pi\PiUI.ui") #D:\OneTouch\OneTouch\Application\Pi\ unter Surface
                                        #S:\OneTouch\Application\Pi\
                                        #für Ausführung unter Pi nur PiUI.ui

        #3: Create the widget using a master as parent
        self.mainwindow = builder.get_object("mainwindow", master)

        builder.connect_callbacks(self)

        #Connecting to Pumps :D
        # Bus 001 Device 006: ID 2109:2813 VIA Labs, Inc. 
        # Bus 001 Device 005: ID 2109:2813 VIA Labs, Inc. 
        # Bus 002 Device 007: ID 2109:0813 VIA Labs, Inc. 
        # Bus 002 Device 006: ID 2109:0813 VIA Labs, Inc. 
        # das sind die neuen Geräte nach Anstecken des Hubs an den Pi 
        # leider kann er die Pumpe nicht finden D:
        Combobox_1


    def on_Button_1_click(self):
        pump = GPIODevice(27)
        pump.On()
        sleep(2)
        pump.Off()
        print("something should happen")


if __name__ == '__main__':
    root = tk.Tk()
    app = Application(root)
    root.mainloop()