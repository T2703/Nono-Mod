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
	public class RedSaber : ModProjectile
	{

        public override void SetDefaults()
		{
            Projectile.width = 50;
            Projectile.height = 50;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 600;
            Projectile.aiStyle = -1;

        }

        public override void AI()
        {
            Projectile.rotation = 1.8f;
            Lighting.AddLight(Projectile.Center, 1f, 0f, 0f);
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), target.position, new Vector2(0, 0), ModContent.ProjectileType<RedSaberSpin>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), target.position, new Vector2(0, 0), ModContent.ProjectileType<RedSaberSpin>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
        }

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item110, Projectile.position);

            for (int i = 0; i < 12; i++)
            {   
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.FireworkFountain_Red, 0f, 0f, 100, default, 2f);
                dust.velocity *= 1.6f;
                dust.scale = 0.8f;

            }
        }


    }

}
