using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent.Drawing;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace NonoMod.Items
{
	public class CopperProjectile : ModProjectile
	{
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.NonoMod.hjson file.

        public override void SetDefaults()
		{
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.damage = 15;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 300;
            Projectile.aiStyle = 1;
    

        }

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
            Projectile.aiStyle = 189;

            for (int i = 0; i < 25; i++)
            {   
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Copper, 0f, 0f, 100, default, 2f);
                dust.velocity *= 1.5f;

            }
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            modifiers.FinalDamage += 1;

        }


    }

}
