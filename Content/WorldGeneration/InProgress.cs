using System;
using Terraria;
using Terraria.Graphics.Capture;
using Terraria.ModLoader;
using TutorialMod.Common.Systems;

namespace TutorialMod.Content.WorldGeneration
{
    public class InProgress : ModBiome
    {
        public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle => ModContent.GetInstance<InProgressBackgroundStyle>();
        public override CaptureBiome.TileColorStyle TileColorStyle => CaptureBiome.TileColorStyle.Crimson;
        // Calculate when the biome is active.
        public override bool IsBiomeActive(Player player)
        {
            // First, we will use the exampleBlockCount from our added ModSystem for our first custom condition
            bool b1 = ModContent.GetInstance<InProgressTileCount>().testBlockCount >= 40;

                    // Finally, we will limit the height at which this biome can be active to above ground (ie sky and surface). Most (if not all) surface biomes will use this condition.
                    bool b3 = player.ZoneSkyHeight || player.ZoneOverworldHeight;
                    return b1 && b3;
                }

        // Declare biome priority. The default is BiomeLow so this is only necessary if it needs a higher priority.
        public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;
    }
}
