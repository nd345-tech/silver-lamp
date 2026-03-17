using TutorialMod.Content.NPCs;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace TutorialMod.Common.Systems
{
    public class TownNPCRespawnSystem : ModSystem
    {
        // Tracks if ExamplePerson has ever been spawned in this world
        public static bool unlockedExamplePersonSpawn = false;

        // Town NPC rescued in the world would follow a similar implementation, the only difference being how the value is set to true.
        // public static bool savedExamplePerson = false;

        public override void ClearWorld()
        {
            unlockedExamplePersonSpawn = false;
        }

        public override void SaveWorldData(TagCompound tag)
        {
            tag[nameof(unlockedExamplePersonSpawn)] = unlockedExamplePersonSpawn;
        }

        public override void LoadWorldData(TagCompound tag)
        {
            unlockedExamplePersonSpawn = tag.GetBool(nameof(unlockedExamplePersonSpawn));

            // This line sets unlockedExamplePersonSpawn to true if an ExamplePerson is already in the world. This is only needed because unlockedExamplePersonSpawn was added in an update to this mod, meaning that existing users might have unlockedExamplePersonSpawn incorrectly set to false.
            // If you are tracking Town NPC unlocks from your initial mod release, then this isn't necessary.
            unlockedExamplePersonSpawn |= NPC.AnyNPCs(ModContent.NPCType<Marine>());
        }

        public override void NetSend(BinaryWriter writer)
        {
            writer.WriteFlags(unlockedExamplePersonSpawn);
        }

        public override void NetReceive(BinaryReader reader)
        {
            reader.ReadFlags(out unlockedExamplePersonSpawn);
        }
    }
}
