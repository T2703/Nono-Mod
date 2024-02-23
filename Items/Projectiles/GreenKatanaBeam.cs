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
	public class GreenKatanaBeam : ModProjectile
	{

        public override void SetDefaults()
		{
            Projectile.width = 25;
            Projectile.height = 25;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 200;
            Projectile.aiStyle = 0;

        }

        public override void AI()
        {
            Lighting.AddLight(Projectile.Center, 0f, 1f, 0f);
            Projectile.rotation = 4.5f;
        }

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item70, Projectile.position);

            for (int i = 0; i < 6; i++)
            {   
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.GreenFairy, 0f, 0f, 100, default, 2f);
                dust.velocity *= 1f;
                dust.scale = 0.5f;

            }
        }


    }

}
