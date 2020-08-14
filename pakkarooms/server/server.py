import socket
import threading
import configparser
import os.path
import commands

if not os.path.exists("config.ini"):
    open("config.ini", "w").write("[config]\nhost=127.0.0.1\nport=2202\nslots=10")

config = configparser.ConfigParser()
config.read("config.ini")

host = config.get("config", "host")
port = config.getint("config", "port")
slots = config.getint("config", "slots")

clients = []
usernames = {}

sock = socket.socket()
sock.bind((host, port))
sock.listen(slots)

def get_user(username):
    for client in usernames:
        if usernames[client] == username:
            return client

def send(data):
    for client in clients:
        try:
            client.send(data)
        except:
            if hasattr(commands, "events"):
                if "on_error" in commands.events:
                    commands.events["on_error"](_clients, con, "senderror")
                
def message_handler(con, addr):
    while True:
        try:
            data = con.recv(1024).decode()
            if data.startswith("USERNAME"):
                username = data.split("=")[1]
                if not username in usernames.values() and len(username) > 2:
                    usernames[con] = username
                    if hasattr(commands, "events"):
                        if "on_join" in commands.events:
                            commands.events["on_join"](_clients, con)
                else:
                    remove(con)
            else:
                if data.split(": ")[1][0] == "/" and hasattr(commands, "commands"):
                    command = data.split(": ")[1].split(" ")[0][1:]

                    if hasattr(commands, "commands"):
                        if not command in commands.commands:
                            if hasattr(commands, "events"):
                                if "on_error" in commands.events:
                                    commands.events["on_error"](usernames, con, "commandnotfound")
                        else:
                            class msg:
                                command = data.split(": ")[1].split(" ")[0][1:]
                                args = data.split(": ")[1].split(" ")[1:]

                            commands.commands[command](_clients, con, msg)
                            print(f"[COMMAND] {usernames[con]} used the {msg.command} command")
                else:
                    if hasattr(commands, "events"):
                        if "on_message" in commands.events:
                            commands.events["on_message"](_clients, con, data.split(": ")[1])
        except:
            if hasattr(commands, "events"):
                if "on_error" in commands.events:
                    commands.events["on_error"](_clients, con, "unknown")

def remove(con):
    if con in clients:
        clients.remove(con)
    
    if con in usernames:
        if hasattr(commands, "events"):
            if "on_left" in commands.events:
                commands.events["on_left"](_clients, con)

        del usernames[con]

    con.close()

def console():
    while True:
        message = input()
        send(f"[CONSOLE] {message}".encode())
        print(f"[CONSOLE] {message}")

class _clients:
    clients = usernames
    send = send
    remove = remove
    get_user = get_user

print(f"Running on {host}:{port}")
threading.Thread(target=console).start()

while True:
    con, addr = sock.accept()
    
    print(f"{addr[0]}:{addr[1]} connected")
    clients.append(con)
    
    threading.Thread(target=message_handler, args=(con, addr)).start()