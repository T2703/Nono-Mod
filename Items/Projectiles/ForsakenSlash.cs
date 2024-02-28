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
	public class ForsakenSlash : ModProjectile
	{
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.NonoMod.hjson file.

        public override void SetDefaults()
		{
            Projectile.CloneDefaults(ProjectileID.Muramasa);
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 25;
            Projectile.ignoreWater = true;
            Projectile.aiStyle = 0;
            Projectile.extraUpdates = 1;
            Projectile.scale = 0.7f;
            Projectile.usesLocalNPCImmunity = true;

        }

        public override void AI()
        {
            // Lighting
            Lighting.AddLight(Projectile.position, 0.2f, 0.2f, 0.2f);
            Lighting.Brightness(12, 12);

            // Dust (in the wind)
            Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.HallowSpray, 0f, 0f, 10, Color.GhostWhite, 2f);
            dust.scale = 0.5f;

            // Homing
            float maxDetectection = 360f;
            float homingSpeed = 15f;

            NPC closestNPC = FindClosetNPC(maxDetectection);
            if (closestNPC == null)
            {
                Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X);
            }
            else
            {
                Projectile.velocity = (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * homingSpeed;
                Projectile.rotation = Projectile.velocity.ToRotation();
            }

            //Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X);
        }

        public NPC FindClosetNPC (float maxDetectectionDistance)
        {
            // From the example homing code.
            NPC closetNPC = null;
            float sqrMaxDetectDistance = maxDetectectionDistance * maxDetectectionDistance;

            for (int k = 0; k < Main.maxNPCs; k++)
            {
                NPC target = Main.npc[k];
                if (target.CanBeChasedBy())
                {
                    float sqrDistanceToTarget = Vector2.DistanceSquared(target.Center, Projectile.Center);

                    if (sqrDistanceToTarget < sqrMaxDetectDistance)
                    {
                        sqrMaxDetectDistance = sqrDistanceToTarget;
                        closetNPC = target;
                    }
                }
            }

            return closetNPC;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Player player = Main.LocalPlayer;
            Random randomChoice = new Random();
            string[] healthPool = { "1", "2", "3", "4", "5" };

            if (Main.rand.NextFloat() < 0.25f && target.CanBeChasedBy())
            {
                int randomIndex = randomChoice.Next(healthPool.Length);
                string selectedHealthPool = healthPool[randomIndex];
                Dust dust = Dust.NewDustDirect(player.position, player.width, player.height, DustID.HealingPlus, 0f, 0f, 5, default, 1f);
                dust.scale = 2f;
                dust.velocity *= 0.8f;

                switch (selectedHealthPool)
                {
                    case "1":
                        player.Heal(1);
                        break;

                    case "2":
                        player.Heal(2);
                        break;

                    case "3":
                        player.Heal(3);
                        break;
                    case "4":
                        player.Heal(4);
                        break;
                    case "5":
                        player.Heal(5);
                        break;
                    default:
                        break;
                }

            }
            ParticleOrchestrator.RequestParticleSpawn(clientOnly: false, ParticleOrchestraType.NightsEdge,
                new ParticleOrchestraSettings { PositionInWorld = Main.rand.NextVector2FromRectangle(target.Hitbox) },
                Projectile.owner);
            hit.HitDirection = (Main.player[Projectile.owner].Center.X < target.Center.X) ? 1 : (-1);

            target.AddBuff(ModContent.BuffType<Unmotivated>(), 420);

            if (Main.rand.NextFloat() < 0.50f)
            {
                Projectile.ResetLocalNPCHitImmunity();
            }

        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            Player player = Main.LocalPlayer;
            Random randomChoice = new Random();
            string[] healthPool = { "1", "2", "3", "4", "5" };

            if (Main.rand.NextFloat() < 0.25f)
            {
                int randomIndex = randomChoice.Next(healthPool.Length);
                string selectedHealthPool = healthPool[randomIndex];
                Dust dust = Dust.NewDustDirect(player.position, player.width, player.height, DustID.HealingPlus, 0f, 0f, 5, default, 1f);
                dust.scale = 2f;
                dust.velocity *= 0.8f;

                switch (selectedHealthPool)
                {
                    case "1":
                        player.Heal(1);
                        break;

                    case "2":
                        player.Heal(2);
                        break;

                    case "3":
                        player.Heal(3);
                        break;
                    case "4":
                        player.Heal(4);
                        break;
                    case "5":
                        player.Heal(5);
                        break;
                    default:
                        break;
                }

            }

            ParticleOrchestrator.RequestParticleSpawn(clientOnly: false, ParticleOrchestraType.NightsEdge,
                new ParticleOrchestraSettings { PositionInWorld = Main.rand.NextVector2FromRectangle(target.Hitbox) },
                Projectile.owner);
            info.HitDirection = (Main.player[Projectile.owner].Center.X < target.Center.X) ? 1 : (-1);

            target.AddBuff(BuffID.ShadowFlame, 150);

            if (Main.rand.NextFloat() < 0.50f)
            {
                Projectile.ResetLocalNPCHitImmunity();
            }
        }

    }


}

