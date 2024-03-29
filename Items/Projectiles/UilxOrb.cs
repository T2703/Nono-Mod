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
	public class UilxOrb : ModProjectile
	{

        public override void SetDefaults()
		{
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.penetrate = 1;
            Projectile.aiStyle = -1;
            Projectile.timeLeft = 150;
            Projectile.ignoreWater = true;

        }

        public override void AI()
        {
            // Dust & lighting 
            Lighting.AddLight(Projectile.Center, 2f, 2f, 3f);
        }


        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item89, Projectile.position);
            for (int i = 0; i < 20; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.PurpleTorch, 0f, 0f, 100, Color.MediumPurple, 2f);
                dust.velocity *= 0.9f;
                dust.scale = 1f;
                dust.noGravity = true;
            }

            for (int i = 0; i < 6; i++)
            {
                float angle = MathHelper.TwoPi / 6 * i;
                Vector2 direction = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * 8;

                Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.position, direction, ModContent.ProjectileType<UilxBall>(), Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
            }

        }


    }

}
