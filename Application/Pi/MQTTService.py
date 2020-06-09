import paho.mqtt.client as mqtt
from Models.GlobalQueue import globalQueue

class MqttService(mqtt.Client):
    @staticmethod
    def on_connect(self, mqttc, obj, flags, rc):
        print("rc: "+str(rc))

    @staticmethod
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

    @staticmethod
    def on_publish(self, mqttc, obj, mid):
        print("mid: "+str(mid))

    @staticmethod
    def on_subscribe(self, mqttc, obj, mid, granted_qos):
        print("Subscribed: "+str(mid)+" "+str(granted_qos))

    @staticmethod
    def on_log(self, mqttc, obj, level, string):
        print(string)

    @staticmethod
    def run(self):
        self.isStartup = True
        self.connect("onetouchnextgen.tech", 1883)
        self.subscribe("machine/Drink", 0)
        rc = 0
        while rc == 0:
            rc = self.loop()
        return rc