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
using NonoMod.Buffs;

namespace NonoMod.Items.Projectiles
{
	public class IceSpray : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 4; // lol
        }

        public override void SetDefaults()
		{
            Projectile.CloneDefaults(ProjectileID.Flames);
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 95;
            Projectile.ignoreWater = true;

        }

        public override void AI()
        {
            // Lighting
            Lighting.AddLight(Projectile.position, 0.2f, 0.2f, 0.5f);
            Lighting.Brightness(10, 10);

            float randomScale = Main.rand.NextFloat(2f, 3.2f);
            Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.IceTorch, 0f, 0f, 10, default, 3f);
            dust.noGravity = true;
            dust.scale = randomScale;

        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Frostburn, 800);
            SoundEngine.PlaySound(SoundID.Item50, Projectile.position);

            if (Main.rand.NextFloat() < 0.20f && !target.HasBuff(ModContent.BuffType<Freeze>()))
            {
                target.AddBuff(ModContent.BuffType<Freeze>(), 250); // For the npcs
            }

        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            target.AddBuff(BuffID.Frostburn, 800);
            SoundEngine.PlaySound(SoundID.Item50, Projectile.position);

            if (Main.rand.NextFloat() < 0.20f && !target.HasBuff(BuffID.Frozen))
            {
                target.AddBuff(BuffID.Frozen, 250); // Cause debuff works on player only.
            }

        }

    }


}

