import socket
import threading
import configparser
import os.path

if not os.path.exists("config.ini"):
    open("config.ini", "w").write("[config]\nhost=127.0.0.1\nport=2202\njoined={} joined the room\nleft={} left the room\nslots=10")

config = configparser.ConfigParser()
config.read("config.ini")

host = config.get("config", "host")
port = config.getint("config", "port")
joined = config.get("config", "joined")
left = config.get("config", "left")
slots = config.getint("config", "slots")

clients = []
usernames = {}

s = socket.socket()
s.bind((host, port))
s.listen(slots)

def send(data):
    for client in clients:
        try:
            client.send(data.encode())
        except:
            remove(c)
                
def message_handler(c, addr):
    while True:
        try:
            data = c.recv(1024).decode()
            if data.startswith("USERNAME"):
                username = data.split("=")[1]
                send(joined.format(username))
                print(joined.format(username))
                usernames[c] = username
            else:
                print(f"[ROOM] {data}")
                send(data)
        except:
            remove(c)

def remove(c):
    if c in clients:
        clients.remove(c)
    
    if c in usernames:
        print(left.format(usernames[c]))
        send(left.format(usernames[c]))
        del usernames[c]

def console():
    while True:
        message = input()
        send(f"[CONSOLE] {message}")
        print(f"[CONSOLE] {message}")

print(f"Running on {host}:{port}")
threading.Thread(target=console).start()

while True:
    c, addr = s.accept()
    
    print(f"{addr[0]}:{addr[1]} connected")
    clients.append(c)
    
    threading.Thread(target=message_handler, args=(c, addr)).start()