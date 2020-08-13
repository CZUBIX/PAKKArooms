import commands

def command(func):
    if not hasattr(commands, "commands"):
       commands.commands = {}
    commands.commands[func.__name__] = func

def event(func):
    if not hasattr(commands, "events"):
        commands.events = {}
    commands.events[func.__name__] = func