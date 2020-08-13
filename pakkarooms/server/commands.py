import plugins

@plugins.event
def on_join(clients, con):
    clients.send(f"{clients.clients[con]} joined the room".encode())

@plugins.event
def on_left(clients, con):
    clients.send(f"{clients.clients[con]} left the room".encode())

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
def say(clients, con, msg):
    clients.send(" ".join(msg.args).encode())