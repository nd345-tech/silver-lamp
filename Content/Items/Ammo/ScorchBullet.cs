using Microsoft.Build.Evaluation;
//using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TutorialMod.Content.Items.Placeable;

namespace TutorialMod.Content.Items.Ammo
{
    public class ScorchBullet : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 12; // The damage for projectiles isn't actually 12, it actually is the damage combined with the projectile and the item together.
            Item.DamageType = DamageClass.Ranged;
            Item.width = 8;
            Item.height = 8;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true; // This marks the item as consumable, making it automatically be consumed when it's used as ammunition, or something else, if possible.
            Item.knockBack = 1.5f;
            Item.value = 10;
            Item.rare = ItemRarityID.Green;
            Item.shoot = ModContent.ProjectileType<Projectiles.ScorchBullet>(); // The projectile that weapons fire when using this item as ammunition.
            Item.shootSpeed = 4.5f; // The speed of the projectile. This value equivalent to Silver Bullet since ExampleBullet's Projectile.extraUpdates is 1.
            Item.ammo = AmmoID.Bullet; // The ammo class this ammo belongs to.
        }

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.DirtBlock, 10)
                .AddIngredient<MalvadiumOre>()
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}
