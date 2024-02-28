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
	public class PurpleSaber : ModProjectile
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
            Projectile.rotation += 0.8f;
            Lighting.AddLight(Projectile.Center, 1f, 1f, 1f);
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), target.position, new Vector2(20, 0), ModContent.ProjectileType<PurpleSaberBeam>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), target.position, new Vector2(-20, 0), ModContent.ProjectileType<PurpleSaberBeam>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), target.position, new Vector2(20, 0), ModContent.ProjectileType<PurpleSaberBeam>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), target.position, new Vector2(-20, 0), ModContent.ProjectileType<PurpleSaberBeam>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
        }

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item110, Projectile.position);

            for (int i = 0; i < 10; i++)
            {   
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.FireworksRGB, 0f, 0f, 100, Color.Purple, 2f);
                dust.velocity *= 1.2f;
                dust.noGravity = true;

            }
        }


    }

}
