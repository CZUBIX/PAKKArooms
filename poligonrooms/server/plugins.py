import commands

class colors:
    BLACK = "\u001b[30m"
    RED = "\u001b[31m"
    GREEN = "\u001b[32m"
    YELLOW = "\u001b[33m"
    BLUE = "\u001b[34m"
    MAGENTA = "\u001b[35m"
    CYAN = "\u001b[36m"
    WHITE = "\u001b[37m"
    RESET = "\u001b[0m"

def command(func):
    if not hasattr(commands, "commands"):
       commands.commands = {}
    commands.commands[func.__name__] = func

def console_command(func):
    if not hasattr(commands, "console_commands"):
        commands.console_commands = {}
    
    if func.__name__.startswith("_"):
        func.__name__ = func.__name__[1:]
    commands.console_commands[func.__name__] = func

def event(func):
    if not hasattr(commands, "events"):
        commands.events = {}
    commands.events[func.__name__] = func