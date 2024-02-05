using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent.Drawing;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Microsoft.CodeAnalysis;

namespace NonoMod.Items.Projectiles
{
	public class TruestOfTheTrueBoomerangProjectile : ModProjectile
	{

        public override void SetDefaults()
		{
            Projectile.width = 33;
            Projectile.height = 33;
            Projectile.aiStyle = 3;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.penetrate = -1;
            Projectile.extraUpdates = 1;
            Projectile.timeLeft = 300;
            Projectile.ignoreWater = true;

        }

        public override void AI()
        {
            // Dust & lighting 
            Lighting.AddLight(Projectile.Center, 0.6f, 0.6f, 0.6f);
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.HallowedWeapons, 0f, 0f, 101, default, 1f);

        }


    }

}
