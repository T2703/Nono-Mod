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
	public class UilxBladeBeam : ModProjectile
	{

        public override void SetDefaults()
		{
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.damage = 15;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 400;
            Projectile.aiStyle = 22;
            Projectile.ignoreWater = true;


        }

        public override void AI()
        {
            Lighting.AddLight(Projectile.Center, 1f, 0.4f, 0.6f);
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Clentaminator_Purple, 0f, 0f, 100, default, 1f);

            if (Projectile.ai[0] >= 30)
            {
                Projectile.tileCollide = true;
                Projectile.ai[0] = 0;
            }
        }

        public override void OnKill(int timeLeft)
        {
            Lighting.AddLight(Projectile.Center, 2f, 2f, 3f);
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.PinkCrystalShard, 0f, 0f, 100, default, 1f);
            SoundEngine.PlaySound(SoundID.Item89, Projectile.position);

            int randomIValue = Main.rand.Next(2, 3);
            for (int i = 0; i < randomIValue; i++)
            {
                float randomX = Main.rand.NextFloat(-31f, 30f);
                float randomY = Main.rand.NextFloat(-31f, 33f);
                Vector2 launchVelocity = new Vector2(randomX, randomY);
                Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, launchVelocity, ModContent.ProjectileType<UilxBallBounce>(), Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
            }
        }



    }

}
