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
	public class TsurugiRain : ModProjectile
	{
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.NonoMod.hjson file.

        public override void SetDefaults()
		{
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.damage = 15;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 250;
            Projectile.aiStyle = 27;
            Projectile.ignoreWater = true;
        }

        public override void AI()
        {
            Lighting.AddLight(Projectile.position, 0.7f, 0.7f, 0.6f);
            Lighting.Brightness(15, 15);
            for (int i = 0; i < 1; i++)
            {
                Dust particles = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.DungeonSpirit, 0f, 0f, 5, default, 2f);
                particles.velocity *= 0.2f;
            }

            Projectile.ai[0]++;

            if (Projectile.ai[0] >= 30)
            {
                Projectile.tileCollide = true;
                Projectile.ai[0] = 0;
            }
        }

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item60, Projectile.position);
            Dust particles = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Firework_Blue, 0f, 0f, 5, default, 2f);
            particles.velocity *= 0.7f;

        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Frostburn2, 50);
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            target.AddBuff(BuffID.Frostburn2, 50);
        }

    }

}
