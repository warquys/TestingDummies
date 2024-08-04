using CommandSystem;

namespace TestingDummies.Commands;

[CommandHandler(typeof(RemoteAdminCommandHandler))]
public class Dummy : ParentCommand
{
    public Dummy() => LoadGeneratedCommands();

    public override string Command { get; } = "devdummy";

    public override string[] Aliases { get; } = ["devd"];

    public override string Description { get; } = "Parent command for handling Dev-Dummies.";

    public override void LoadGeneratedCommands()
    {
        RegisterCommand(new DummyLookAt());
        RegisterCommand(new RemoveDummy());
        RegisterCommand(new SpawnDummy());
        RegisterCommand(new SpawnMe());
    }

    protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        response = "Invalid subcommand! Valid subcommands : LookAt, Stats, Remove, Spawn, SpawnMe";
        return false;
    }
}
