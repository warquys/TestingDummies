using CommandSystem;
using TestingDummies.SpawningHandler;

namespace TestingDummies.Commands;

internal class SpawnMe : ICommand
{
    public int nextDummyNameId = 0;

    public string Command => nameof(SpawnMe);

    public string[] Aliases => ["me", "fstspw", "fastspawn"];

    public string Description => "Spawn a dummy with your current role at your position.";

    public bool SanitizeResponse => true;


    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        var playerSender = Player.Get(sender);

        if (playerSender == null)
        {
            response = "You should be a player when executing the command";
            return false;
        }

        if (arguments.Count > 0)
        {
            string group = arguments.At(0);

            if (Plugin.Instance.Config.RolesGroups.TryGetValue(group, out var possibleRole) && possibleRole.Count > 0)
            {
                var role = possibleRole.RandomItem();
                Spawn.SpawnDummy($"id-{nextDummyNameId++}", role, playerSender);
            }
        }

        response = "A dummy has been spawned for you!";

        Spawn.SpawnDummy($"id-{nextDummyNameId++}", playerSender.Role.Type, playerSender);
        return true;
    }
}