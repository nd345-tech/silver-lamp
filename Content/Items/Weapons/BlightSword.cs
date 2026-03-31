using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
//using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using TutorialMod.Content.Items.Placeable;

namespace TutorialMod.Content.Items.Weapons
{
    public class BlightSword : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 15;
            Item.DamageType = DamageClass.Melee;
            Item.width = 100;
            Item.height = 1000;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 10;
            Item.value = Item.buyPrice(silver: 1);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;

            Item.shoot = ProjectileID.HolyArrow; // ID of the projectiles the sword will shoot
            Item.shootSpeed = 8f; // Speed of the projectiles the sword will shoot
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DirtBlock, 10);
            recipe.AddIngredient<MalvadiumBar>(5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
