import plugins

@plugins.event
def on_message(clients, con, msg):
    clients.send(f"{clients.clients[con]}: {msg}".encode())
    print(f"[ROOM] {clients.clients[con]}: {msg}")

@plugins.event
def on_join(clients, con):
    clients.send(f"{clients.clients[con]} joined the room".encode())
    print(f"{clients.clients[con]} joined the room")

@plugins.event
def on_left(clients, con):
    clients.send(f"{clients.clients[con]} left the room".encode())
    print(f"{clients.clients[con]} left the room")

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
def kick(clients, con, msg):
    username = msg.args[0]
    user = clients.get_user(username)

    user.send(f"You've been kicked by {clients.clients[con]}".encode())
    clients.send(f"{username} has been kicked by {clients.clients[con]}".encode())
    print(f"[KICK] {username} has been kicked by {clients.clients[con]}")

    clients.remove(user)