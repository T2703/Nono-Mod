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
	public class Hadoken : ModProjectile
	{

        public override void SetDefaults()
		{
            Projectile.width = 42;
            Projectile.height = 42;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.penetrate = 1;
    
        }

        public override void AI()
        {
            // Dust & lighting 
            Lighting.AddLight(Projectile.Center, 1f, 1f, 1f);

        }


        public override void OnKill(int timeLeft)
        {
            //SoundEngine.PlaySound(SoundID.Item89, Projectile.position);
            for (int i = 0; i < 20; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Firework_Blue, 0f, 0f, 101, Color.Blue, 2f);
                dust.velocity *= 1.8f;
                dust.noGravity = true;
            }
        }


    }

}
