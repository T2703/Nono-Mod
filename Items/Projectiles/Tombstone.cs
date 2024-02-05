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
	public class Tombstone : ModProjectile
	{
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.NonoMod.hjson file.

        public override void SetDefaults()
		{
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.penetrate = 1;
            Projectile.aiStyle = -1;
    

        }

        public override void OnKill(int timeLeft)
        {

            for (int i = 0; i < 10; i++)
            {
                float randomX = Main.rand.NextFloat(-31f, 30f);
                float randomY = Main.rand.NextFloat(-31f, 33f);
                Vector2 launchVelocity = new Vector2(randomX, randomY);
                Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, launchVelocity, ProjectileID.Bone, Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
            }
        }



    }

}
