using TutorialMod.Content.Items.Placeable;
using TutorialMod.Content.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TutorialMod.Content.Items.Placeable;

namespace TutorialMod.Content.Items.Weapons
{
    public class MalvadiumSword : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 40;
            Item.DamageType = DamageClass.Melee;

            Item.width = 40;
            Item.height = 40;

            Item.useTime = 10;
            Item.useAnimation = 20;

            Item.useStyle = ItemUseStyleID.Swing;

            Item.knockBack = 5;
            Item.value = Item.buyPrice(0, 1, 0, 0);
            Item.rare = ItemRarityID.Orange;

            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;

            Item.shoot = ModContent.ProjectileType<MalvadiumSwordProj>();
            Item.shootSpeed = 10f;

            Item.noMelee = false; // still does melee damage
        }

        public override bool Shoot(Player player,
            Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source,
            Vector2 position, Vector2 velocity,
            int type, int damage, float knockback)
        {
            // spawn projectile slightly in front of player
            Vector2 spawnPos = position + Vector2.Normalize(velocity) * 40f;

            Projectile.NewProjectile(source, spawnPos, velocity, type, damage, knockback, player.whoAmI);

            return false; // prevent duplicate shot
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
