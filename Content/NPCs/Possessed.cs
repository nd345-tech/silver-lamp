using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TutorialMod.Content.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TutorialMod.Content.NPCs
{
    public class Possessed : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.Zombie]; // reuse frames
        }

        public override void SetDefaults()
        {
            NPC.width = 18;
            NPC.height = 40;
            NPC.damage = 14;
            NPC.defense = 10;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath2;
            NPC.value = 60f;
            NPC.knockBackResist = 0.5f;
            NPC.aiStyle = NPCAIStyleID.Fighter; // Fighter AI, important to choose the aiStyle that matches the NPCID that we want to mimic

            AIType = NPCID.Zombie; // Use vanilla zombie's type when executing AI code. (This also means it will try to despawn during daytime)
            AnimationType = NPCID.Zombie; // Use vanilla zombie's type when executing animation code. Important to also match Main.npcFrameCount[NPC.type] in SetStaticDefaults.

        }

        private int shootTimer = 0;

        public override void AI()
        {
            Player player = Main.player[NPC.target];

            // Make sure target is valid
            if (!player.active || player.dead)
            {
                NPC.TargetClosest();
                player = Main.player[NPC.target];
            }

            // Face the player
            NPC.direction = (player.Center.X > NPC.Center.X) ? 1 : -1;

            shootTimer++;

            if (shootTimer >= 120) // shoot every 2 seconds (60 ticks/sec)
            {
                ShootAtPlayer(player);
                shootTimer = 0;
            }
        }

        private void ShootAtPlayer(Player player)
        {
            if (Main.netMode != NetmodeID.MultiplayerClient) // server-side only
            {
                Vector2 direction = player.Center - NPC.Center;
                direction.Normalize();
                direction *= 5f; // projectile speed

                Projectile.NewProjectile(
                    NPC.GetSource_FromAI(),
                    NPC.Center,
                    direction,
                    ModContent.ProjectileType<DemonicSphere>(),
                    15, // damage
                    1f
                );
            }
        }
    }

    /*
     * private int shootTimer = 0;

    public override void AI()
    {
        Player player = Main.player[NPC.target];

        // Make sure target is valid
        if (!player.active || player.dead)
        {
            NPC.TargetClosest();
            player = Main.player[NPC.target];
        }

        // Face the player
        NPC.direction = (player.Center.X > NPC.Center.X) ? 1 : -1;

        float projSpeed = 200f;
        if (Main.expertMode)
        {
            projSpeed = 250f;
        }

        // Calculate Damage
        int projDamage = (int)(NPC.damage * .5f);
        float projKnockback = 3f;
        if (Main.expertMode)
        {
            projDamage += (int)(NPC.damage * .15);
            projKnockback += .5f;
        }

        shootTimer++;

        if (shootTimer >= 120) // shoot every 2 seconds (60 ticks/sec)
        {
            ShootProjectile(player, ModContent.ProjectileType<DemonicSphere>(), projSpeed, projDamage, projKnockback);
            shootTimer = 0;
        }


    }

    private void ShootProjectile(Player player, int type, float speed, int damage, float knockback)
    {
        // Get Target Position
        Vector2 projTarget = new(player.Center.X - NPC.Center.X, player.Center.Y - NPC.Center.Y);
        float projDistance = (float)(projTarget.X * projTarget.X - projTarget.Y * projTarget.Y);
        float projTargetDistance = speed / projDistance;

        // Set Velocity
        Vector2 projVelocity = projTarget * projTargetDistance;

        // Get Spawn Position
        Vector2 projSpawn = NPC.Center + projVelocity * 10f;

        // Handle Network Logic
        if (Main.netMode != NetmodeID.MultiplayerClient)
        {
            int projectileID = Projectile.NewProjectile(NPC.GetSource_FromAI(), projSpawn, projVelocity, type, damage, knockback);
            if (Main.netMode == NetmodeID.Server && projectileID < 200)
            {
                NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, projectileID);
            }
        }
    }
     */
}

