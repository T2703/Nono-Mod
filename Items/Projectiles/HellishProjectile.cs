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
	public class HellishProjectile : ModProjectile
	{
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.NonoMod.hjson file.

        public override void SetDefaults()
		{
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
            Projectile.penetrate = 3;
            Projectile.timeLeft = 600;
            Projectile.aiStyle = ProjAIStyleID.Beam;

        }

        public override void AI()
        {
            Lighting.AddLight(Projectile.Center, 2f, 0, 0);
        }

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item74, Projectile.position);

            for (int i = 0; i < 25; i++)
            {   
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.InfernoFork, 0f, 0f, 100, default, 2f);
                dust.velocity *= 1.5f;

            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            for (int i = 0; i < 3; i++)
            {
                float randomValue = Main.rand.NextFloat(-20f, 20f);
                float randomX = (float)(5f + (15f * new Random().NextDouble()));
                float posY = target.position.Y - 350f;
                Projectile.NewProjectile(Projectile.InheritSource(Projectile), target.position.X + randomX, posY, randomValue, 50f, ModContent.ProjectileType<HellishBolt>(), Projectile.damage, 1, Projectile.owner);

            }
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            for (int i = 0; i < 3; i++)
            {
                float randomValue = Main.rand.NextFloat(-20f, 20f);
                float randomX = (float)(5f + (15f * new Random().NextDouble()));
                float posY = target.position.Y - 350f;
                Projectile.NewProjectile(Projectile.InheritSource(Projectile), target.position.X + randomX, posY, randomValue, 50f, ModContent.ProjectileType<HellishBolt>(), Projectile.damage, 1, Projectile.owner);

            }
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            target.AddBuff(BuffID.OnFire, 450);
        }

        public override void ModifyHitPlayer(Player target, ref Player.HurtModifiers modifiers)
        {
            target.AddBuff(BuffID.OnFire, 450);
        }


    }

}
