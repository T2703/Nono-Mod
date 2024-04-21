using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent.Drawing;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Mono.Cecil;
using NonoMod.Buffs;

namespace NonoMod.Items.Projectiles
{
	public class Phantom90Bullet : ModProjectile
	{
        // Bullets that phase through
        public override void SetDefaults()
		{
            Projectile.width = 60;
            Projectile.height = 30;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 250;
            Projectile.aiStyle = 0;
            Projectile.scale = 0.6f;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 200;

        }

        public override void AI()
        {
            Projectile.velocity.X += 0.01f; // progressivly get fast
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            ParticleOrchestrator.RequestParticleSpawn(clientOnly: false, ParticleOrchestraType.TrueExcalibur,
                new ParticleOrchestraSettings { PositionInWorld = Main.rand.NextVector2FromRectangle(target.Hitbox) },
                Projectile.owner);
            hit.HitDirection = (Main.player[Projectile.owner].Center.X < target.Center.X) ? 1 : (-1);
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            ParticleOrchestrator.RequestParticleSpawn(clientOnly: false, ParticleOrchestraType.TrueExcalibur,
                new ParticleOrchestraSettings { PositionInWorld = Main.rand.NextVector2FromRectangle(target.Hitbox) },
                Projectile.owner);
            info.HitDirection = (Main.player[Projectile.owner].Center.X < target.Center.X) ? 1 : (-1);
        }



    }

}
