using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TutorialMod.Content.Items.Placeable
{
    public class TestBlock : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
            ItemID.Sets.ExtractinatorMode[Type] = Item.type;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.TestBlock>());
            Item.width = 12;
            Item.height = 12;
        }

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes()
        {
            CreateRecipe(10)
                .AddIngredient<MalvadiumBar>()
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}
