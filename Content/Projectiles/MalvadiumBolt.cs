using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TutorialMod.Content.Projectiles;

namespace TutorialMod.Content.Projectiles
{
    public class MalvadiumBolt : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 14;

            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;

            Projectile.penetrate = 1;
            Projectile.timeLeft = 300;

            //Projectile.scale = .25f;
        }

        public override void AI()
        {
            float maxDetectRadius = 400f;
            float homingStrength = 0.1f;

            NPC target = FindClosestNPC(maxDetectRadius);

            if (target != null)
            {
                Vector2 desiredVelocity =
                    Projectile.DirectionTo(target.Center) * Projectile.velocity.Length();

                Projectile.velocity = Vector2.Lerp(
                    Projectile.velocity,
                    desiredVelocity,
                    homingStrength
                );
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            for (int i = 0; i < 2; i++)
            {
                Vector2 newVelocity = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(30));

                Projectile.NewProjectile(
                    Projectile.GetSource_FromThis(),
                    Projectile.Center,
                    newVelocity,
                    ModContent.ProjectileType<MalvadiumBoltSplit>(),
                    (int)(Projectile.damage * 0.7f),
                    Projectile.knockBack,
                    Projectile.owner
                );
            }
        }

        private NPC FindClosestNPC(float maxDetectDistance)
        {
            NPC closest = null;
            float sqrMaxDist = maxDetectDistance * maxDetectDistance;

            foreach (NPC npc in Main.npc)
            {
                if (npc.CanBeChasedBy(this))
                {
                    float sqrDist = Vector2.DistanceSquared(npc.Center, Projectile.Center);

                    if (sqrDist < sqrMaxDist)
                    {
                        sqrMaxDist = sqrDist;
                        closest = npc;
                    }
                }
            }

            return closest;
        }
    }
}