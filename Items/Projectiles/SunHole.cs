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
	public class SunHole : ModProjectile
	{

        public override void SetDefaults()
		{
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 400;
            Projectile.aiStyle = 0;

        }

        public override void AI()
        {
            Lighting.AddLight(Projectile.Center, 1f, 2f, 1f);
        }

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item110, Projectile.position);

            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.position, new Vector2(0,0), ModContent.ProjectileType<Blackhole>(), Projectile.damage / 2 , Projectile.knockBack, Projectile.owner);
        }

    }

}
