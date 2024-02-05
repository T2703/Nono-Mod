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
using static Humanizer.In;

namespace NonoMod.Items.Projectiles
{
	public class SwordDance : ModProjectile
	{
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.NonoMod.hjson file.

        public override void SetDefaults()
		{
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 650;
            Projectile.ignoreWater = true;
            Projectile.aiStyle = 0;

        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            Projectile.rotation = Projectile.AngleFrom(player.Center);

            double deg = (double)Projectile.ai[1];
            double rad = deg * (Math.PI / 180);
            double dist = 80;

            Projectile.position.X = player.Center.X - (int)(Math.Cos(rad) * dist) - Projectile.width / 2;
            Projectile.position.Y = player.Center.Y - (int)(Math.Sin(rad) * dist) - Projectile.height / 2;

            Projectile.ai[1] += 1f;

            Lighting.AddLight(Projectile.position, 0f, 0f, 1f);
            Lighting.Brightness(5, 5);
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Player player = Main.LocalPlayer;
            if (target.CanBeChasedBy())
            {
                player.Heal(50);
                Dust dust = Dust.NewDustDirect(player.position, player.width, player.height, DustID.HealingPlus, 0f, 0f, 5, default, 1f);
                dust.scale = 2f;
                dust.velocity *= 0.8f;

            }

            ParticleOrchestrator.RequestParticleSpawn(clientOnly: false, ParticleOrchestraType.NightsEdge,
                new ParticleOrchestraSettings { PositionInWorld = Main.rand.NextVector2FromRectangle(target.Hitbox) },
                Projectile.owner);
            hit.HitDirection = (Main.player[Projectile.owner].Center.X < target.Center.X) ? 1 : (-1);
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            Player player = Main.LocalPlayer;
            player.Heal(50);
            Dust dust = Dust.NewDustDirect(player.position, player.width, player.height, DustID.HealingPlus, 0f, 0f, 5, default, 1f);
            dust.scale = 2f;
            dust.velocity *= 0.8f;

            ParticleOrchestrator.RequestParticleSpawn(clientOnly: false, ParticleOrchestraType.NightsEdge,
                new ParticleOrchestraSettings { PositionInWorld = Main.rand.NextVector2FromRectangle(target.Hitbox) },
                Projectile.owner);
            info.HitDirection = (Main.player[Projectile.owner].Center.X < target.Center.X) ? 1 : (-1);
        }

        public override void OnKill(int timeLeft)
        {
            float randomX = (Main.rand.Next(2) == 0) ? -10f : 10f;
            float randomY = Main.rand.NextFloat(0f, 12f);
            Vector2 launchVelocity = new Vector2(randomX, randomY);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, launchVelocity, ProjectileID.EnchantedBeam, Projectile.damage, Projectile.knockBack, Projectile.owner);
        }

    }


}

