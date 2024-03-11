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
	public class RedSaberSpin : ModProjectile
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
            Projectile.timeLeft = 62;
            Projectile.aiStyle = -1;

        }

        public override void AI()
        {
            Projectile.rotation += 0.7f;
            Lighting.AddLight(Projectile.Center, 1f, 0f, 0f);
        }

        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < 5; i++)
            {   
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.FireworkFountain_Red, 0f, 0f, 100, default, 2f);
                dust.velocity *= 0.5f;
                dust.scale = 0.5f;
                dust.noGravity = true;

            }
        }


    }

}
