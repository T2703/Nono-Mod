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
	public class NumberOneProjectile : ModProjectile
	{

        public override void SetDefaults()
		{
            Projectile.width = 87;
            Projectile.height = 160;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 20;
            Projectile.aiStyle = -1;
    
        }

        public override void AI()
        {
            Lighting.AddLight(Projectile.Center, 3f, 0, 0);
            Projectile.rotation = Projectile.velocity.ToRotation();
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.SpectreStaff, 0f, 0f, 100, Color.Red, 1f);
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            ParticleOrchestrator.RequestParticleSpawn(clientOnly: false, ParticleOrchestraType.NightsEdge,
                new ParticleOrchestraSettings { PositionInWorld = Main.rand.NextVector2FromRectangle(target.Hitbox) },
                Projectile.owner);
            hit.HitDirection = (Main.player[Projectile.owner].Center.X < target.Center.X) ? 1 : (-1);
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            ParticleOrchestrator.RequestParticleSpawn(clientOnly: false, ParticleOrchestraType.NightsEdge,
                new ParticleOrchestraSettings { PositionInWorld = Main.rand.NextVector2FromRectangle(target.Hitbox) },
                Projectile.owner);
            info.HitDirection = (Main.player[Projectile.owner].Center.X < target.Center.X) ? 1 : (-1);
        }

        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < 25; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Ghost, 0f, 0f, 100, Color.Black, 2f);
                dust.velocity *= 1.5f;
                dust.noGravity = true;
            }
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            if (Main.rand.NextFloat() < 0.35f)
            {
                Projectile.damage += 5;
            }
            else
            {
                Projectile.damage = 75;
            }
        }

        public override void ModifyHitPlayer(Player target, ref Player.HurtModifiers modifiers)
        {
            if (Main.rand.NextFloat() < 0.35f)
            {
                Projectile.damage += 5;
            }
            else
            {
                Projectile.damage = 75;
            }
        }


    }

}
