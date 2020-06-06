import queue
import threading

queueLock = threading.Lock()
globalQueue = queue.Queue()