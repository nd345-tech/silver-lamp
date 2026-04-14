using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TutorialMod.Content.Projectiles;

namespace TutorialMod.Content.Items.Weapons
{
    public class MalvadiumBow : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 25;
            Item.DamageType = DamageClass.Ranged;

            Item.width = 26;
            Item.height = 70;

            Item.useTime = 20;
            Item.useAnimation = 20;

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;

            Item.knockBack = 2;
            Item.value = 10000;
            Item.rare = ItemRarityID.Green;

            Item.UseSound = SoundID.Item5;
            Item.autoReuse = true;

            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.shootSpeed = 10f;
            Item.useAmmo = AmmoID.Arrow;
        }

        public override bool Shoot(Player player,
            Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source,
            Vector2 position, Vector2 velocity,
            int type, int damage, float knockback)
        {
            int numberProjectiles = 3;

            float totalSpread = MathHelper.ToRadians(30f);
            float startAngle = -totalSpread / 2;
            float angleStep = totalSpread / (numberProjectiles - 1);

            for (int i = 0; i < numberProjectiles; i++)
            {
                float angle = startAngle + angleStep * i;

                Vector2 perturbedVelocity = velocity.RotatedBy(angle);

                int projType;
                int projDamage = damage;

                if (i == numberProjectiles / 2) // middle arrow
                {
                    projType = ModContent.ProjectileType<MalvadiumArrowHoming>();
                    projType = type; // uses ammo arrow
                    perturbedVelocity *= 1.75f;
                }
                else
                {
                    projType = ModContent.ProjectileType<MalvadiumArrowHoming>();

                    // optional balance
                    projDamage = (int)(damage * 0.85f);
                }

                Projectile.NewProjectile(source, position, perturbedVelocity, projType, projDamage, knockback, player.whoAmI);
            }

            return false; // stop default shot
        }
    }
}
