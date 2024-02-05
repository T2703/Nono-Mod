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
	public class SpoonProjectile : ModProjectile
	{
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.NonoMod.hjson file.

        public override void SetDefaults()
		{
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.aiStyle = 1;

        }

        public override void OnKill(int timeLeft)
        {
            Vector2 launchVelocityLeft = new Vector2(-5, 0);
            Vector2 launchVelocityRight = new Vector2(5, 0);
            Vector2 launchVelocityUp = new Vector2(0, 4);
            Vector2 launchVelocityDown = new Vector2(0, -4);

            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, launchVelocityLeft, ProjectileID.PartyBullet, Projectile.damage / 4, Projectile.knockBack, Projectile.owner);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, launchVelocityRight, ProjectileID.PartyBullet, Projectile.damage / 4, Projectile.knockBack, Projectile.owner);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, launchVelocityUp, ProjectileID.PartyBullet, Projectile.damage / 4, Projectile.knockBack, Projectile.owner);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, launchVelocityDown, ProjectileID.PartyBullet, Projectile.damage / 4, Projectile.knockBack, Projectile.owner);
        }
    }

}
