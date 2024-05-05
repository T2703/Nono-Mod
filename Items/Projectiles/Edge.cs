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
	public class Edge : ModProjectile
	{

        public override void SetDefaults()
		{
            Projectile.width = 50;
            Projectile.height = 50;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 400;
            Projectile.aiStyle = -1;

        }

        public override void AI()
        {
            Projectile.rotation += 1f;
            Lighting.AddLight(Projectile.Center, 0f, 0.5f, 1f);

            float maxDetectection = 360f;
            float homingSpeed = 30f;

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

        public override void OnKill(int timeLeft)
        {
            //SoundEngine.PlaySound(SoundID.Item110, Projectile.position);

            for (int i = 0; i < 10; i++)
            {   
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.SpectreStaff, 0f, 0f, 100, default, 2f);
                dust.velocity *= 1.6f;
                dust.scale = 0.5f;

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


    }

}
