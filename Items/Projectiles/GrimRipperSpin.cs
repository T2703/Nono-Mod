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
	public class GrimRipperSpin : ModProjectile
	{

        public override void SetDefaults()
		{
            Projectile.width = 65;
            Projectile.height = 65;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
    
        }

        public override void AI()
        {
            Projectile.rotation += 0.8f;
            Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 101, default, 2f);
            dust.velocity *= 0.8f;
         
        }


    }

}
