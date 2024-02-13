using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent.Drawing;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace NonoMod.Items.Projectiles
{
	public class ForgottenEyes : ModProjectile
	{

        public override void SetDefaults()
		{
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.penetrate = 1;
            Projectile.scale = 0.4f;
    
        }

        public override void AI()
        {
            // Penetration chance.
            if (Main.rand.NextFloat() < 0.25f)
            {
                Projectile.penetrate = 2;
            }


            if (Main.rand.NextFloat() < 0.35f)
            {
                Projectile.penetrate = 3;
            }

            // Homing
            float maxDetectection = 360f;
            float homingSpeed = 21f;

            NPC closestNPC = FindClosetNPC(maxDetectection);
            if (closestNPC == null)
            {
                Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X);
            }
            else
            {
                Projectile.velocity = (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * homingSpeed;
                Projectile.rotation = Projectile.velocity.ToRotation();
            }

        }

        public NPC FindClosetNPC(float maxDetectectionDistance)
        {
            // From the example homing code.
            NPC closetNPC = null;
            float sqrMaxDetectDistance = maxDetectectionDistance * maxDetectectionDistance;

            for (int k = 0; k < Main.maxNPCs; k++)
            {
                NPC target = Main.npc[k];
                if (target.CanBeChasedBy())
                {
                    float sqrDistanceToTarget = Vector2.DistanceSquared(target.Center, Projectile.Center);

                    if (sqrDistanceToTarget < sqrMaxDetectDistance)
                    {
                        sqrMaxDetectDistance = sqrDistanceToTarget;
                        closetNPC = target;
                    }
                }
            }

            return closetNPC;
        }


        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < 5; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.SlimeBunny, 0f, 0f, 101, default, 2f);
                dust.velocity *= 1.6f;
                dust.noGravity = true;
            }
        }


    }

}
