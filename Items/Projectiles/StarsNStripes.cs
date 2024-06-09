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
	public class StarsNStripes : ModProjectile
	{

        public override void SetDefaults()
		{
            Projectile.width = 80;
            Projectile.height = 80;
            Projectile.DamageType = DamageClass.Generic;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 200;
            Projectile.aiStyle = -1;
    
        }

        public override void AI()
        {
            Projectile.velocity *= 1.1f;
            Projectile.rotation = Projectile.velocity.ToRotation();
        }

        public override void OnKill(int timeLeft)
        {
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.position, new Vector2(0, 0), ProjectileID.Fireball, Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
        }


    }

}
