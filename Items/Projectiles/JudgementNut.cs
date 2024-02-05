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
	public class JudgementNut : ModProjectile
	{
        // Hehe funny name
        public override void SetDefaults()
        {
            Projectile.width = 1500;
            Projectile.height = 1650;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.aiStyle = 0;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 8;
            Projectile.penetrate = -1;
            Projectile.ignoreWater = true;
            Projectile.friendly = true;
            Projectile.damage = 4200;
            Projectile.scale = 1f;
            DrawOriginOffsetY = -200;
            DrawOffsetX = 45;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Player player = Main.LocalPlayer;
            if (target.CanBeChasedBy())
            {
                player.Heal(50);
            }

        }

        public override void AI()
        {
            Projectile.velocity *= 0.1f;
            Projectile.rotation += JudgementCut.SharedRotation;
        }

        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < 15; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Firework_Blue, 0f, 0f, 100, Color.GhostWhite, 2f);
                dust.velocity *= 2f;
                dust.scale = 1.5f;
                dust.rotation = MathHelper.ToRadians(Main.rand.Next(0, 364));
            }

        }


    }

}
