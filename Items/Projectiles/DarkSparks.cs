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
	public class DarkSparks : ModProjectile
	{

        public override void SetDefaults()
		{
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 350;
            Projectile.aiStyle = 0;

        }

        public override void AI()
        {
            Projectile.velocity *= 0.98f;
            Lighting.AddLight(Projectile.Center, 1f, 1f, 1f);

        }

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item110, Projectile.position);

            for (int i = 0; i < 10; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Shadowflame, 0f, 0f, 100, Color.Black, 2f);
                dust.velocity *= 1.5f;
                dust.scale = 0.4f;
                dust.noGravity = true;

            }
        }


    }

}
