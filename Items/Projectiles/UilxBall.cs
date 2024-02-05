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
	public class UilxBall : ModProjectile
	{

        public override void SetDefaults()
		{
            Projectile.width = 18;
            Projectile.height = 18;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.penetrate = 1;
            Projectile.aiStyle = -1;
    
        }

        public override void AI()
        {
            // Dust & lighting 
            Lighting.AddLight(Projectile.Center, 2f, 2f, 3f);
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.PinkCrystalShard, 0f, 0f, 100, default, 1f); 

            // Homing
            float maxDetectection = 300f;
            float homingSpeed = 10.5f;

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
            SoundEngine.PlaySound(SoundID.Item89, Projectile.position);
            for (int i = 0; i < 15; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.PurpleCrystalShard, 0f, 0f, 100, Color.MediumPurple, 2f);
                dust.velocity *= 0.8f;
                dust.noGravity = true;
            }
        }


    }

}
