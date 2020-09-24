import plugins
import json

@plugins.event
def on_message(clients, con, msg):
    clients.send(f"{clients.clients[con]}: {msg}".encode())
    print(f"[ROOM] {clients.clients[con]}: {msg}")

@plugins.event
def on_join(clients, con):
    with open("bans.json", "r") as f:
        bans = json.load(f)
        if clients.get_address(clients.clients[con])[0] in bans["bans"]:
            con.send("You are banned from this room".encode())
            return clients.remove(con)

    clients.send(f"{clients.clients[con]} joined the room".encode())
    print(plugins.colors.YELLOW + f"{clients.clients[con]} joined the room" + plugins.colors.RESET)

@plugins.event
def on_left(clients, con):
    clients.send(f"{clients.clients[con]} left the room".encode())
    print(plugins.colors.YELLOW + f"{clients.clients[con]} left the room" + plugins.colors.RESET)

@plugins.event
def on_error(clients, con, error):
    if error == "commandnotfound":
        con.send("Command not found".encode())
    else:
        clients.remove(con)

@plugins.command
def ping(clients, con, msg):
    con.send("Pong!".encode())

@plugins.command
def msg(clients, con, msg):
    username = msg.args[0]
    user = clients.get_user(username)
    message = " ".join(msg.args[1:])

    user.send(f"[PRIVATE MESSAGE] {clients.clients[con]}: {message}".encode())
    con.send(f"[PRIVATE MESSAGE] -> {username}: {message}".encode())

@plugins.command
def admin(clients, con, msg):
    username = msg.args[0]

    with open("administrators.json", "r") as f:
        administrators = json.load(f)

        if not clients.get_address(username)[0] in administrators["administrators"]:
            return con.send("You don't have permissions".encode())

        administrators["administrators"].append(clients.get_address(username)[0])
        
    with open("administrators.json", "w") as f:
        json.dump(administrators, f, indent=4)

    clients.send(f"{username} is now the room administrator".encode())
    print(f"[ADMIN] {username} is now the room administrator")

@plugins.command
def kick(clients, con, msg):
    username = msg.args[0]
    user = clients.get_user(username)

    with open("administrators.json", "r") as f:
        administrators = json.load(f)["administrators"]

        if not clients.get_address(username)[0] in administrators:
            return con.send("You don't have permissions".encode())

        user.send(f"You've been kicked by {clients.clients[con]}".encode())
        clients.send(f"{username} has been kicked by {clients.clients[con]}".encode())
        print(f"[KICK] {username} has been kicked by {clients.clients[con]}")

        clients.remove(user)

@plugins.command
def ban(clients, con, msg):
    username = msg.args[0]
    user = clients.get_user(username)

    with open("administrators.json", "r") as f:
        administrators = json.load(f)["administrators"]

        if not clients.get_address(username)[0] in administrators:
            return con.send("You don't have permissions".encode())

        user.send(f"You've been banned by {clients.clients[con]}".encode())
        clients.send(f"{username} has been banned by {clients.clients[con]}".encode())
        print(f"[BAN] {username} has been banned by {clients.clients[con]}")

        clients.remove(user)

    with open("bans.json", "r") as f:
        bans = json.load(f)
        bans["bans"].append(clients.get_address(username)[0])

    with open("bans.json", "w") as f:
        json.dump(bans, f, indent=4)

@plugins.console_command
def say(clients, msg):
    clients.send(f"[CONSOLE] {' '.join(msg.args)}".encode())
    print(f"[CONSOLE] {' '.join(msg.args)}")