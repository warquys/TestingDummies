﻿using CommandSystem;
using PlayerRoles;
using TestingDummies.SpawningHandler;

namespace TestingDummies.Commands;

public class SpawnDummy : ICommand
{
    public string Command => "Spawn";

    public string[] Aliases => ["sp", "new", "spawndummy", "spawndevdummy", "spawndev"];

    public string Description => "Spawns a dummy for development or testing purposes, it has 0 logic.";

    public bool SanitizeResponse => true;

    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        if (arguments.Count != 3)
        {
            response = "Incorrect arguments. Usage: spawndummy [name] [role] ([playerID] or [playerNickname])";
            return false;
        }

        string name = arguments.At(0);
        string roleString = arguments.At(1);
        Player player = Player.Get(arguments.At(2));

        if (!Enum.TryParse(roleString, out RoleTypeId role))
        {
            response = $"Invalid role: {roleString}";
            return false;
        }

        if (player == null)
        {
            response = $"Invalid player with the specified ID or Nickname: {arguments.At(2)}";
            return false;
        }

        if (!Extensions.HasDummyPermissions(player))
        {
            response = "You do not have the needed permissions to run this command! Needed perms: devdummies";
            return false;
        }

        Spawn.SpawnDummy(name, role, player);

        response = $"Spawned dummy with name '{name}', role '{role}', for player '{player.Nickname}'";
        return true;
    }
}
