using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent.Drawing;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Microsoft.CodeAnalysis;
using Microsoft.Xna.Framework.Input;

namespace NonoMod.Items.Projectiles
{
	public class RocketoPunchP : ModProjectile
	{
        private float FrameCounter
        {
            get => Projectile.ai[0];
            set => Projectile.ai[0] = value;
        }

        public override void SetDefaults()
		{
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.friendly = true;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 360;
            Projectile.aiStyle = 1;
        }

        public override void AI()
        {
            float maxSpeed = 30f;
            float speedPerPixel = 0.06f; 
            Vector2 direction = Main.MouseWorld - Projectile.Center;

            Projectile.velocity = direction * speedPerPixel;
            Player player = Main.player[Projectile.owner];
            FrameCounter += 1;

            if (Projectile.owner == Main.myPlayer)
            {
                // What is this nonsense?
                // I'm sorry for this garbage code.

                bool stillInUse = player.channel && !player.noItems && !player.CCed;
                if (stillInUse) 
                {
                    if (Projectile.velocity.X > maxSpeed)
                    {
                        Projectile.velocity.X = maxSpeed;
                    }
                    else if (Projectile.velocity.X < -maxSpeed)
                    {
                        Projectile.velocity.X = -maxSpeed;
                    }
                    if (Projectile.velocity.Y > maxSpeed)
                    {
                        Projectile.velocity.Y = maxSpeed;
                    }
                    else if (Projectile.velocity.Y < -maxSpeed)
                    {
                        Projectile.velocity.Y = -maxSpeed;
                    }
                }
                else if (!stillInUse)
                {
                    Projectile.timeLeft = 3;

                    if (player.direction == 1)
                    {
                        Projectile.velocity.X = 101;
                    }
                    else
                    {
                        Projectile.velocity.X = -101;
                    }
         
                }
                
                
            }

        }

        public override void OnKill(int timeLeft)
        {
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.position, new Vector2(0, 0), ProjectileID.Volcano, Projectile.damage, Projectile.knockBack, Projectile.owner);

        }
    }

}
