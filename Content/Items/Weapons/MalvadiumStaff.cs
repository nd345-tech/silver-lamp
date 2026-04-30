using TutorialMod.Content.Projectiles;
using TutorialMod.Content.Items.Placeable;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;

namespace TutorialMod.Content.Items.Weapons
{
    public  class MalvadiumStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.staff[Type] = true; // This makes the useStyle animate as a staff instead of as a gun.
        }

        public override void SetDefaults()
        {
            // DefaultToStaff handles setting various Item values that magic staff weapons use.
            // Hover over DefaultToStaff in Visual Studio to read the documentation!
            Item.DefaultToStaff(ModContent.ProjectileType<MalvadiumStaffBeam>(), 16, 25, 12);

            // Customize the UseSound. DefaultToStaff sets UseSound to SoundID.Item43, but we want SoundID.Item20
            Item.UseSound = SoundID.Item20;

            // Set damage and knockBack
            Item.SetWeaponValues(20, 5);

            // Set rarity and value
            Item.SetShopValues(ItemRarityColor.Green2, 10000);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient<MalvadiumBar>(12)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}
