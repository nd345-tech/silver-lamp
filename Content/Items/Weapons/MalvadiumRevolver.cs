using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TutorialMod.Content.Items.Placeable;
using TutorialMod.Content.Projectiles;

namespace TutorialMod.Content.Items.Weapons
{
    public class MalvadiumRevolver : ModItem
    {
        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 25; // Hitbox width of the item.
            Item.height = 18; // Hitbox height of the item.
            Item.rare = ItemRarityID.Green; // The color that the item's name will be in-game.

            // Use Properties
            Item.useTime = 55; // The item's use time in ticks (60 ticks == 1 second.)
            Item.useAnimation = 55; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
            Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.
            Item.UseSound = SoundID.Item36; // The sound that this item plays when used.

            // Weapon Properties
            Item.DamageType = DamageClass.Ranged; // Sets the damage type to ranged.
            Item.damage = 20; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
            Item.knockBack = 6f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
            Item.noMelee = true; // So the item's animation doesn't do damage.

            // Gun Properties
            Item.shoot = ModContent.ProjectileType<ScorchBullet>(); // For some reason, all the guns in the vanilla source have this.
            Item.shootSpeed = 10f; // The speed of the projectile (measured in pixels per frame.)
            Item.useAmmo = AmmoID.Bullet; // The "ammo Id" of the ammo item that this weapon uses. Ammo IDs are magic numbers that usually correspond to the item id of one item that most commonly represent the ammo type.

            Item.scale = 2f;
        }

        public override bool AltFunctionUse(Player player) => true;

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Item.useTime = 90;
                Item.useAnimation = 90;
                Item.shootSpeed = 8f;
            }
            else
            {
                Item.useTime = 30;
                Item.useAnimation = 30;
                Item.shootSpeed = 8f;
            }
            return base.CanUseItem(player);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2)
            {
                Projectile.NewProjectile(source, position + Vector2.Normalize(velocity) * 60f, velocity, ModContent.ProjectileType<MalvadiumRevolverProjectile>(), damage, knockback, player.whoAmI);
            }
            else
            {
                int numBullets = 1;
                for (int index = 0; index < numBullets; index++)
                {
                    float SpeedX = velocity.X + Main.rand.Next(-30, 31) * 0.05f;
                    float SpeedY = velocity.Y + Main.rand.Next(-30, 31) * 0.05f;
                    int proj = Projectile.NewProjectile(source, position.X, position.Y, SpeedX, SpeedY, type == ProjectileID.Bullet ? ModContent.ProjectileType<ScorchBullet>() : type, damage, knockback, player.whoAmI);
                    Main.projectile[proj].extraUpdates += 1;
                }
            }

            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.DirtBlock, 10)
                .AddIngredient<MalvadiumBar>(2)
                .AddTile(TileID.WorkBenches)
                .Register();
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-2f, +7f);
        }
    }
}
