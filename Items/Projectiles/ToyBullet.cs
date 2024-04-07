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

namespace NonoMod.Items.Projectiles
{
	public class ToyBullet : ModProjectile
	{

        public override void SetDefaults()
		{
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = false;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 1000;
            Projectile.aiStyle = 1;

        }

        public override void AI()
        {
            Projectile.velocity *= 0.97f;
        }

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item51, Projectile.position);

            Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Dirt, 0f, 0f, 100, Color.Orange, 2f);
            dust.velocity *= 1.1f;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Main.rand.NextFloat() < 0.02f)
            {
                target.AddBuff(BuffID.Confused, 700);
            }
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            if (Main.rand.NextFloat() < 0.02f)
            {
                target.AddBuff(BuffID.Confused, 700);
            }
        }



    }

}
