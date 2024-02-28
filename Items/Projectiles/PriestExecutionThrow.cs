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
	public class PriestExecutionThrow : ModProjectile
	{

        public override void SetDefaults()
		{
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.aiStyle = ProjAIStyleID.Beam;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 1000;
            Projectile.ignoreWater = false;

        }

        public override void OnKill(int timeLeft)
        {
            Vector2 launchVelocity = new Vector2(0, 0);
            if (Main.rand.NextFloat() < 0.19f)
            {
                Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, launchVelocity, ProjectileID.Volcano, Projectile.damage, Projectile.knockBack, Projectile.owner);
            }
            else if (Main.rand.NextFloat() < 0.09f)
            {
                Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, launchVelocity, ModContent.ProjectileType<HealBurst>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
            }
            else
            {
                Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, launchVelocity, ModContent.ProjectileType<MagicalBurst>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
            }
        }


    }
}
