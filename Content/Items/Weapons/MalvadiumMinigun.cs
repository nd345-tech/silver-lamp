using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TutorialMod.Content.Projectiles;

namespace TutorialMod.Content.Items.Weapons
{
    public class MalvadiumMinigun : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 50;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 40;
            Item.height = 20;

            Item.useTime = 6;
            Item.useAnimation = 18;
            Item.reuseDelay = 14; // creates burst + pause feel

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;

            Item.knockBack = 2;
            Item.value = Item.buyPrice(0, 10, 0, 0);
            Item.rare = ItemRarityID.Yellow;

            Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;

            Item.shoot = ProjectileID.Bullet;
            Item.shootSpeed = 12f;
            Item.useAmmo = AmmoID.Bullet;
        }

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            // Slight bullet spread
            float spread = MathHelper.ToRadians(5);

            velocity = velocity.RotatedBy(Main.rand.NextFloat(-spread, spread));

            // Fire normal bullet
            Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);

            // Random chance to fire a rocket
            if (Main.rand.NextBool(4)) // 25% chance
            {
                Vector2 rocketVelocity = velocity * 0.8f;

                Projectile.NewProjectile(
                    source,
                    position,
                    rocketVelocity,
                    ModContent.ProjectileType<MalvadiumRocket>(), // can upgrade later
                    damage * 2,
                    knockback,
                    player.whoAmI
                );
            }

            return false; // prevents default shot (since we handled it)
        }
    }
}
