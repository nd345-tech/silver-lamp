using Terraria;
using Terraria.ID;
using Terraria.WorldBuilding;
using Terraria.IO;
using TutorialMod.Content.Tiles;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace TutorialMod.Content.WorldGeneration
{
    public class InProgressPass : GenPass
    {
        public InProgressPass(string name, float loadWeight) : base(name, loadWeight)
        {
        }

        // 8. The ApplyPass method is where the actual world generation code is placed.
        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            // 9. Setting a progress message is always a good idea. This is the message the user sees during world generation and can be useful to help users and modders identify passes that are stuck.      
            progress.Message = InProgressSystem.InProgressPassMessage.Value;
            

            for (int i = 100; i < 200; i++)
            {
                for (int j = 200; j < 300; j++)
                {
                    WorldGen.PlaceTile(i, j, ModContent.TileType<TestBlock>(), true);
                }
            }

            for (int k = 0; k < (int)((Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
            {
                // The inside of this for loop corresponds to one single splotch of our Ore.
                // First, we randomly choose any coordinate in the world by choosing a random x and y value.
                int x = WorldGen.genRand.Next(100, 200);
                int y = WorldGen.genRand.Next(200, 300); // WorldGen.worldSurfaceLow is actually the highest surface tile. In practice you might want to use WorldGen.rockLayer or other WorldGen values.

                // Then, we call WorldGen.TileRunner with random "strength" and random "steps", as well as the Tile we wish to place. Feel free to experiment with strength and step to see the shape they generate.
                WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), ModContent.TileType<MalvadiumOre>());
            }

            GenVars.structures.AddProtectedStructure(new Microsoft.Xna.Framework.Rectangle(0, 0, 200, 50));
        }
    }
}
