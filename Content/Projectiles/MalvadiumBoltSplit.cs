using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace TutorialMod.Content.Projectiles
{
    public class MalvadiumBoltSplit : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 10;

            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;

            Projectile.penetrate = 10;
            Projectile.timeLeft = 200;

            Projectile.tileCollide = true;

            //Projectile.scale = .25f;
        }

        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation();
        }
    }
}