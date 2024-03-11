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
	public class GreenSaber : ModProjectile
	{

        public override void SetDefaults()
		{
            Projectile.width = 50;
            Projectile.height = 50;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 360;
            Projectile.aiStyle = -1;

        }

        public override void AI()
        {
            Projectile.rotation += 0.1f;
            Lighting.AddLight(Projectile.Center, 0f, 1f, 0f);
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            int numberOfProjectiles = 8; 

            for (int i = 0; i < numberOfProjectiles; i++)
            {
                float angle = MathHelper.TwoPi / numberOfProjectiles * i;
                Vector2 direction = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * 10;

                Projectile.NewProjectile(Projectile.InheritSource(Projectile), target.position, direction, ProjectileID.GreenLaser, Projectile.damage, Projectile.knockBack, Projectile.owner);
            }
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            int numberOfProjectiles = 8;

            for (int i = 0; i < numberOfProjectiles; i++)
            {
                float angle = MathHelper.TwoPi / numberOfProjectiles * i;
                Vector2 direction = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * 10;

                Projectile.NewProjectile(Projectile.InheritSource(Projectile), target.position, direction, ProjectileID.GreenLaser, Projectile.damage, Projectile.knockBack, Projectile.owner);
            }
        }



        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item110, Projectile.position);

            for (int i = 0; i < 7; i++)
            {   
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.FireworkFountain_Green, 0f, 0f, 100, default, 2f);
                dust.velocity *= 1.1f;
                dust.scale = 0.8f;
                dust.noGravity = true;

            }
        }


    }

}
