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
	public class OldExcalibur : ModProjectile
	{

        public override void SetDefaults()
		{
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 450;
            Projectile.aiStyle = 27;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;

        }

        public override void AI()
        {
            Lighting.AddLight(Projectile.Center, 1f, 1f, 1f);
        }

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item71, Projectile.position);

            for (int i = 0; i < 8; i++)
            {   
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.HallowedWeapons, 0f, 0f, 100, default, 2f);
                dust.velocity *= 0.8f;
                dust.scale = 1f;
                dust.noGravity = true;
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            ParticleOrchestrator.RequestParticleSpawn(clientOnly: false, ParticleOrchestraType.Excalibur,
            new ParticleOrchestraSettings { PositionInWorld = Main.rand.NextVector2FromRectangle(target.Hitbox) },
            Projectile.owner);
            hit.HitDirection = (Main.player[Projectile.owner].Center.X < target.Center.X) ? 1 : (-1);
            target.AddBuff(BuffID.Ichor, 200);
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            target.AddBuff(BuffID.Ichor, 200);
            ParticleOrchestrator.RequestParticleSpawn(clientOnly: false, ParticleOrchestraType.Excalibur,
             new ParticleOrchestraSettings { PositionInWorld = Main.rand.NextVector2FromRectangle(target.Hitbox) },
             Projectile.owner);
            info.HitDirection = (Main.player[Projectile.owner].Center.X < target.Center.X) ? 1 : (-1);
        }
    }

}
