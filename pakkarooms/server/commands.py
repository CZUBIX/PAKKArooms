import plugins

@plugins.command
def ping(msg):
    msg.con.send("Pong!".encode())

@plugins.command
def say(msg):
    msg.con.send(" ".join(msg.args).encode())