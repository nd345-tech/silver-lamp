//using TutorialMod.Content.Biomes;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TutorialMod.Content.Tiles
{
    public class TestBlock : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;


            AddMapEntry(new Color(200, 200, 200));
        }
    }
}
