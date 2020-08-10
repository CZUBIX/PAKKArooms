def command(func):
    import commands
    commands.commands = {}
    commands.commands[func.__name__] = func