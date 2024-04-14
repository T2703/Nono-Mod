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
	public class Blackholecross : ModProjectile
	{
        // Pretty much the same thing but for the cross accessory I made.
        public override void SetDefaults()
		{
            Projectile.width = 70;
            Projectile.height = 70;
            Projectile.DamageType = DamageClass.Generic;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 140;
            Projectile.aiStyle = -1;

        }

        public override void AI()
        {
            Lighting.AddLight(Projectile.Center, 1f, 1f, 1f);

            // Sucking in (credit to the calmaity mod using that as an understanding)
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                // We need an NPC variable to know our npcs.
                NPC npc = Main.npc[i];
                if (npc.CanBeChasedBy(Projectile, false) && Collision.CanHit(Projectile.Center, 1, 1, npc.Center, 1, 1))
                {
                    // We need these values to know where the center is for the npc.
                    float npcCenterX = npc.position.X + npc.width / 2;
                    float npcCenterY = npc.position.Y + npc.height / 2;
                    float npcDist = Math.Abs(Projectile.position.X + (Projectile.width / 2) - npcCenterX) + Math.Abs(Projectile.position.Y + (Projectile.height / 2) - npcCenterY);

                    // Checks if this is within range.
                    if (npcDist <= 600f)
                    {
                        // Baiscally where the sucking in happens.
                        if (npc.position.X < Projectile.Center.X)
                        {
                            npc.velocity.X += 0.10f;
                        }
                        else
                        {
                            npc.velocity.X -= 0.05f;
                        }

                        if (npc.position.Y < Projectile.Center.Y)
                        {
                            npc.velocity.Y += 0.05f;
                        }
                        else
                        {
                            npc.velocity.Y -= 0.05f;
                        }
                    }
                }
            }
        }
    }
}
