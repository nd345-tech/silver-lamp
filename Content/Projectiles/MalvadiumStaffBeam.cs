using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace TutorialMod.Content.Projectiles
{
    public class MalvadiumStaffBeam : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 14;

            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;

            Projectile.penetrate = -1; // don’t die on hit immediately
            Projectile.timeLeft = 300;

            Projectile.tileCollide = true;

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

            // Rotate sprite to match movement
            Projectile.rotation = Projectile.velocity.ToRotation();
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Explode();
        }

        public override void Kill(int timeLeft)
        {
            Explode();
        }

        private void Explode()
        {
            // Increase hitbox for AOE damage
            Projectile.position = Projectile.Center;
            Projectile.width = 80;
            Projectile.height = 80;
            Projectile.Center = Projectile.position;

            // Deal damage in area
            Projectile.damage = (int)(Projectile.damage * 1.2f);
            Projectile.knockBack = 6f;

            Projectile.Damage();

            // Optional: visual effect
            for (int i = 0; i < 10; i++)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 6);
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (Projectile.ai[0] == 0) // first bounce
            {
                Projectile.ai[0] = 1;

                // reflect velocity
                if (Projectile.velocity.X != oldVelocity.X)
                    Projectile.velocity.X = -oldVelocity.X;

                if (Projectile.velocity.Y != oldVelocity.Y)
                    Projectile.velocity.Y = -oldVelocity.Y;

                return false; // don’t kill projectile
            }

            // second collision → explode
            return true;
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