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
	public class Guilt : ModProjectile
	{
        private int totalSegments = 8;

        public override void SetDefaults()
		{
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.alpha = 255;
            Projectile.ignoreWater = true;


        }

        public override void AI()
        {
            if (Projectile.ai[1] == 0f)
            {
                Projectile.alpha -= 100;

                if (Projectile.alpha <= 0)
                {
                    Projectile.alpha = 0;
                    Projectile.ai[1] = 1f;
                }

                if (Projectile.ai[0] == 0f) 
                {
                    Projectile.ai[0]++;
                    Projectile.position += Projectile.velocity;
                }

                if (Main.myPlayer == Projectile.owner && Projectile.ai[0] < totalSegments)
                {
                    int segement = Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center + Projectile.velocity, Projectile.velocity, Projectile.type, Projectile.damage, Projectile.knockBack, Projectile.owner, Projectile.ai[0] + 1f);
                    NetMessage.SendData(MessageID.SyncProjectile, -1, -1, null, segement);
                }
            }
            else
            {
                int alphaPerFrame = 8;
                Projectile.alpha += alphaPerFrame;

                if (Projectile.alpha >= 255)
                {
                    Projectile.Kill();
                }
            }
        }

        public override bool ShouldUpdatePosition() => false;



    }

}
