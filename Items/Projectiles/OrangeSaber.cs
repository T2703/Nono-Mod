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
	public class OrangeSaber : ModProjectile
	{

        public override void SetDefaults()
		{
            Projectile.width = 15;
            Projectile.height = 15;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 500;
            Projectile.aiStyle = -1;

        }

        public override void AI()
        {
            Projectile.rotation += 1f;
            Lighting.AddLight(Projectile.Center, 1f, 1f, 1f);
        }

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item110, Projectile.position);

            for (int i = 0; i < 5; i++)
            {   
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.FireworkFountain_Yellow, 0f, 0f, 100, Color.Orange, 2f);
                dust.velocity *= 1f;
                dust.scale = 0.5f;
                dust.noGravity = true;

            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            // Bouncing code taken from ExampleMod.
            if (Projectile.velocity.X != oldVelocity.X && Math.Abs(oldVelocity.X) > 1f)
            {
                Projectile.velocity.X = oldVelocity.X * -0.5f;
            }
            if (Projectile.velocity.Y != oldVelocity.Y && Math.Abs(oldVelocity.Y) > 1f)
            {
                Projectile.velocity.Y = oldVelocity.Y * -0.5f;
            }

            return false;
        }

    }

}
