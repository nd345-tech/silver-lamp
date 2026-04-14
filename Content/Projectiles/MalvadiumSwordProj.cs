using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace TutorialMod.Content.Projectiles
{
    public class MalvadiumSwordProj : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 15;
            Projectile.height = 25;

            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;

            Projectile.penetrate = 1;
            Projectile.timeLeft = 250;

            Projectile.tileCollide = true;
            Projectile.scale = .5f;
        }

        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation();

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
