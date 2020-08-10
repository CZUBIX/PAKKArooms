def command(func):
    import commands
    if not hasattr(commands, "commands"):
        commands.commands = {}
    commands.commands[func.__name__] = func
