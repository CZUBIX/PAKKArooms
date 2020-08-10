import socket
import threading
import configparser
import os.path
import plugins
import commands

if not os.path.exists("config.ini"):
    open("config.ini", "w").write("[config]\nhost=127.0.0.1\nport=2202\njoined={} joined the room\nleft={} left the room\ncommandnotfound=command not found\nslots=10")

config = configparser.ConfigParser()
config.read("config.ini")

host = config.get("config", "host")
port = config.getint("config", "port")
joined = config.get("config", "joined")
left = config.get("config", "left")
commandnotfound = config.get("config", "commandnotfound")
slots = config.getint("config", "slots")

clients = []
usernames = {}

sock = socket.socket()
sock.bind((host, port))
sock.listen(slots)

def send(data):
    for client in clients:
        try:
            client.send(data.encode())
        except:
            remove(client)
                
def message_handler(con, addr):
    while True:
        try:
            data = con.recv(1024).decode()
            if data.startswith("USERNAME"):
                username = data.split("=")[1]
                send(joined.format(username))
                print(joined.format(username))
                usernames[con] = username
            else:
                if data.split(": ")[1][0] == "/":
                    command = data.split(": ")[1].split(" ")[0][1:]

                    if not command in commands.commands:
                        con.send(commandnotfound.encode())
                    else:
                        class msg:
                            con = con
                            command = data.split(": ")[1].split(" ")[0][1:]
                            args = data.split(": ")[1].split(" ")[1:]

                        commands.commands[command](msg)
                        print(f"[COMMAND] {usernames[con]} used the {msg.command} command")
                else:
                    print(f"[ROOM] {data}")
                    send(data)
        except:
            remove(con)

def remove(con):
    if con in clients:
        clients.remove(con)
    
    if con in usernames:
        print(left.format(usernames[con]))
        send(left.format(usernames[con]))
        del usernames[con]

def console():
    while True:
        message = input()
        send(f"[CONSOLE] {message}")
        print(f"[CONSOLE] {message}")

print(f"Running on {host}:{port}")
threading.Thread(target=console).start()

while True:
    con, addr = sock.accept()
    
    print(f"{addr[0]}:{addr[1]} connected")
    clients.append(con)
    
    threading.Thread(target=message_handler, args=(con, addr)).start()
