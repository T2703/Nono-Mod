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
	public class DarkDragon : ModProjectile
	{

        public override void SetDefaults()
		{
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 780;
            Projectile.aiStyle = 0;

        }

        public override void AI()
        {
            Projectile.rotation = 0.8f;
            Lighting.AddLight(Projectile.Center, 0f, 1f, 1f);
        }

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item110, Projectile.position);

            Random random = new Random();
            int numProj = random.Next(3, 6);
            int ranVel = random.Next(2, 4);

            for (int i = 0; i < numProj; i++)
            {
                float angle = MathHelper.TwoPi / numProj * i;
                Vector2 direction = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * ranVel;

                Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.position, direction, ModContent.ProjectileType<DarkSparks>(), Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
            }

            for (int i = 0; i < 15; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.FireworkFountain_Blue, 0f, 0f, 100, Color.Black, 2f);
                dust.velocity *= 1.2f;
                dust.scale = 0.8f;
                dust.noGravity = true;

            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Confused, 520);
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            target.AddBuff(BuffID.Confused, 520);
        }



    }

}
