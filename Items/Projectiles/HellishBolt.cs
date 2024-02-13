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
	public class HellishBolt : ModProjectile
	{
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.NonoMod.hjson file.

        public override void SetDefaults()
		{
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = 5;
            Projectile.ignoreWater = true;
            Projectile.timeLeft = 250;
            Projectile.aiStyle = 1;
            Lighting.AddLight(Projectile.Center, 1f, 0, 0);

        }

        public override void AI()
        {
            Lighting.AddLight(Projectile.Center, 1f, 0, 0);
        }

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item74, Projectile.position);

            for (int i = 0; i < 5; i++)
            {   
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.InfernoFork, 0f, 0f, 100, default, 2f);
                dust.velocity *= 1.2f;

            }
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            target.AddBuff(BuffID.OnFire, 450);
        }

        public override void ModifyHitPlayer(Player target, ref Player.HurtModifiers modifiers)
        {
            target.AddBuff(BuffID.OnFire, 450);
        }


    }

}
