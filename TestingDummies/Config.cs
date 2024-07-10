using System.ComponentModel;
using PlayerRoles;

namespace TestingDummies
{
    public class Config : IConfig
    {
        [Description("Gets or sets if the plugin is enabled.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Gets or sets if the plugins debug is enabled.")]
        public bool Debug { get; set; } = false;

        [Description("Gives and shows a badge on the AI")]
        public bool NPCBadgeEnabled { get; set; } = true;

        [Description("If NPCBadge is enabled, sets the color")]
        public string NPCBadgeColor { get; set; } = "aqua";

        [Description("If NPCBadge is enabled, sets the name")]
        public string NPCBadgeName { get; set; } = "NPC";

        [Description("Gives spawned NPCs AFK Immunity (HIGHLY RECOMMENED TO KEEP TRUE AS NPCS ARE CONSTANTLY AFK)")]
        public bool NPCAFKImmunity { get; set; } = true;

        [Description("Gets or sets if using DevDummy commands require the 'devdummies' permission.")]
        public bool RequirePermission { get; set; } = false;

        [Description("Take a random role of the corresponding group when the group name is added as argument to spawnMe command. Use lower case !")]
        public Dictionary<string, List<RoleTypeId>> RolesGroups { get; set; } = new()
        {
            {
                "human",
                new List<RoleTypeId>()
                {
                    RoleTypeId.ChaosConscript,
                    RoleTypeId.ChaosMarauder,
                    RoleTypeId.ChaosRepressor,
                    RoleTypeId.ChaosRifleman,
                    RoleTypeId.ClassD,
                    RoleTypeId.Scientist,
                    RoleTypeId.FacilityGuard,
                    RoleTypeId.NtfCaptain,
                    RoleTypeId.NtfSergeant,
                    RoleTypeId.NtfSpecialist,
                    RoleTypeId.NtfPrivate
                }
            },
            {
                "scp",
                new List<RoleTypeId>()
                {
                    RoleTypeId.Scp939,
                    RoleTypeId.Scp096,
                    RoleTypeId.Scp173,
                    RoleTypeId.Scp049,
                    RoleTypeId.Scp3114,
                    RoleTypeId.Scp0492,
                }
            }
        };


    }
}
