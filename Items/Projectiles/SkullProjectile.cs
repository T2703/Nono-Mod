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
	public class SkullProjectile : ModProjectile
	{

        public override void SetDefaults()
		{
            Projectile.width = 15;
            Projectile.height = 15;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.friendly = true;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 210;
            Projectile.aiStyle = ProjAIStyleID.Arrow;

        }

        public override void AI()
        {
            Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 10, default, 2f);
            dust.scale = 0.8f;
         
        }

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
            Random rand = new Random();
            int[] fireRand = { ProjectileID.MolotovFire, ProjectileID.MolotovFire2, ProjectileID.MolotovFire3 };

            for (int i = 0; i < 3; i++) {
                int randomIndex = rand.Next(fireRand.Length);
                int selectedFire = fireRand[randomIndex];
                float randomX = (float)(rand.NextDouble() * 20 - 10);
                float randomY = (float)(rand.NextDouble() * 20 - 10);
                Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.position, new Vector2(randomX, randomY), selectedFire, Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
            }

        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            // Bouncing code taken from ExampleMod.
            if (Projectile.velocity.X != oldVelocity.X && Math.Abs(oldVelocity.X) > 1f)
            {
                Projectile.velocity.X = oldVelocity.X * -0.8f;
            }
            if (Projectile.velocity.Y != oldVelocity.Y && Math.Abs(oldVelocity.Y) > 1f)
            {
                Projectile.velocity.Y = oldVelocity.Y * -0.8f;
            }

            return false;
        }

    }

}
