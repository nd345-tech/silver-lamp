using TutorialMod.Content.Tiles;
using System;
using Terraria.ModLoader;

namespace TutorialMod.Common.Systems
{
    public class InProgressTileCount : ModSystem
    {
        public int testBlockCount;

        public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
        {
            testBlockCount = tileCounts[ModContent.TileType<TestBlock>()];
        }
    }
}
