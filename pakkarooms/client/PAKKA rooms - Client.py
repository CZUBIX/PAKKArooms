import queue
import socket
import threading
import configparser
import os.path

if not os.path.exists("config.ini"):
    open("config.ini", "w").write("[autocomplete]\nenable=false\nhost=127.0.0.1\nport=2202\nusername=PAKKArooms")

config = configparser.ConfigParser()
config.read("config.ini")

if config.getboolean("autocomplete", "enable"):
    host = config.get("autocomplete", "host")
    port = config.getint("autocomplete", "port")
    username = config.get("autocomplete", "username")
else:
    host = input("Host: ")
    port = int(input("Port (default is 2202): ") or 2202)
    username = input("Username: ")

s = socket.socket()
s.connect((host, port))
    
def message_handler(s):
    while True:
        data = s.recv(1024).decode()
        if data:
            print(data)

s.send(f"USERNAME={username}".encode())
while True:
    threading.Thread(target=message_handler, args=(s,)).start()
    
    message = input()
    s.send(f"{username}: {message}".encode())