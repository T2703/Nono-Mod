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
	public class SlightyMotivatedSlash : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 4; // So it's only the dust.
        }

        public override void SetDefaults()
		{
            Projectile.CloneDefaults(ProjectileID.Muramasa);
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 25;
            Projectile.ignoreWater = true;
            Projectile.aiStyle = 0;
            Projectile.scale = 0.6f;
            Projectile.usesLocalNPCImmunity = true;

        }

        public override void AI()
        {
            // Lighting
            Lighting.AddLight(Projectile.position, 0.2f, 0.2f, 0.2f);
            Lighting.Brightness(12, 12);

            Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.SpectreStaff, 0f, 0f, 10, Color.GhostWhite, 2f);
            dust.scale = 0.7f;
            Dust cloudDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Cloud, 0f, 0f, 10, Color.GhostWhite, 2f);
            cloudDust.scale = 1f;

        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            ParticleOrchestrator.RequestParticleSpawn(clientOnly: false, ParticleOrchestraType.NightsEdge,
                new ParticleOrchestraSettings { PositionInWorld = Main.rand.NextVector2FromRectangle(target.Hitbox) },
                Projectile.owner);
            hit.HitDirection = (Main.player[Projectile.owner].Center.X < target.Center.X) ? 1 : (-1);

            target.AddBuff(ModContent.BuffType<Damn>(), 250);

        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {

            ParticleOrchestrator.RequestParticleSpawn(clientOnly: false, ParticleOrchestraType.NightsEdge,
                new ParticleOrchestraSettings { PositionInWorld = Main.rand.NextVector2FromRectangle(target.Hitbox) },
                Projectile.owner);
            info.HitDirection = (Main.player[Projectile.owner].Center.X < target.Center.X) ? 1 : (-1);

            target.AddBuff(ModContent.BuffType<Damn>(), 250);

        }

    }


}

