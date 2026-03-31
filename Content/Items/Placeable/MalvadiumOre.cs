using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TutorialMod.Content.Items.Placeable
{
    public class MalvadiumOre : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
            ItemID.Sets.SortingPriorityMaterials[Type] = 58;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.MalvadiumOre>());
            Item.width = 12;
            Item.height = 12;
            Item.value = 3000;
        }
    }
}
