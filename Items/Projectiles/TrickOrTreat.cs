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
	public class TrickOrTreat : ModProjectile
	{

        public override void SetDefaults()
		{
            Projectile.width = 87;
            Projectile.height = 160;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 200;
            Projectile.aiStyle = -1;
    
        }

        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation();
        }


    }

}
