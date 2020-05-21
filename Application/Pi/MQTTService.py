import paho.mqtt.client as mqtt
import threading
from Models.GlobalQueue import globalQueue, queueLock


class MqttService(mqtt.Client):

    def on_connect(self, mqttc, obj, flags, rc):
        print("rc: "+str(rc))

    def on_message(self, mqttc, obj, msg):
        if self.isStartup == True:
            self.isStartup = False
            self.publish("machine/Drink", "ready", 0)
        else: 
            print(msg.topic+" "+str(msg.qos)+" "+str(msg.payload))
            #insert drink in global queue
            toQueue = str(msg.payload)[2:]
            toQueue = toQueue[:-1]
            if toQueue == "ready":
                pass
            else:
                globalQueue.put(toQueue, True)
                print("Vorne in der Queue: " + globalQueue.queue[0])
                self.publish("machine/Drink", "ready", 0)


    def on_publish(self, mqttc, obj, mid):
        print("mid: "+str(mid))

    def on_subscribe(self, mqttc, obj, mid, granted_qos):
        print("Subscribed: "+str(mid)+" "+str(granted_qos))

    def on_log(self, mqttc, obj, level, string):
        print(string)

    def run(self):
        self.isStartup = True
        self.connect("onetouchnextgen.tech", 1883)
        self.subscribe("machine/Drink", 0)
        rc = 0
        while rc == 0:
            rc = self.loop()
        return rc