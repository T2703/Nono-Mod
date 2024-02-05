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
	public class UilxBallBounce : ModProjectile
	{

        public override void SetDefaults()
		{
            Projectile.width = 18;
            Projectile.height = 18;
            Projectile.damage = 60;
            Projectile.CloneDefaults(ProjectileID.Meowmere);
            Projectile.DamageType = DamageClass.Melee;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.penetrate = -1;
            AIType = ProjectileID.Meowmere;

        }

        public override void AI()
        {
            // Dust & lighting 
            Lighting.AddLight(Projectile.Center, 1f, 0.4f, 0.6f);
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.PinkCrystalShard, 0f, 0f, 100, default, 1f); 

        }


        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item89, Projectile.position);
            for (int i = 0; i < 15; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.PurpleCrystalShard, 0f, 0f, 100, Color.MediumPurple, 2f);
                dust.velocity *= 0.8f;
                dust.noGravity = true;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return base.OnTileCollide(oldVelocity);
        }


    }

}
