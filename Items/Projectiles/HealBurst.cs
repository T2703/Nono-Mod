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
	public class HealBurst : ModProjectile
	{
        public override void SetDefaults()
        {
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.aiStyle = 0;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 8;
            Projectile.penetrate = -1;
            Projectile.ignoreWater = true;
            Projectile.friendly = true;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Player player = Main.LocalPlayer;
            Random randomChoice = new Random();
            string[] healthPool = { "1", "2" };

            int randomIndex = randomChoice.Next(healthPool.Length);
            string selectedHealthPool = healthPool[randomIndex];

            switch (selectedHealthPool)
            {
                case "1":
                    player.Heal(1);
                    break;

                case "2":
                    player.Heal(2);
                    break;

                default:
                    break;
            }
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            Player player = Main.LocalPlayer;
            Random randomChoice = new Random();
            string[] healthPool = { "1", "2" };

            int randomIndex = randomChoice.Next(healthPool.Length);
            string selectedHealthPool = healthPool[randomIndex];

            switch (selectedHealthPool)
            {
                case "1":
                    player.Heal(1);
                    break;

                case "2":
                    player.Heal(2);
                    break;

                default:
                    break;
            }
        }

        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < 15; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.HealingPlus, 0f, 0f, 100, Color.Red, 2f);
                dust.velocity *= 1f;
                dust.scale = 1f;

            }

        }


    }

}
