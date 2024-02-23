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
	public class PriestExecutionThrow : ModProjectile
	{

        public override void SetDefaults()
		{
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.aiStyle = 0;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.penetrate = 3;
            Projectile.timeLeft = 1000;
            Projectile.ignoreWater = false;

        }

        public override void AI()
        {
            Projectile.rotation = 1.0f;
            // Run either the Sticky AI or Normal AI
            // Separating into different methods helps keeps your AI clean
            if (IsStickingToTarget) StickyAI();

        }

        // Are we sticking to a target?
        public bool IsStickingToTarget
        {
            get => Projectile.ai[0] == 1f;
            set => Projectile.ai[0] = value ? 1f : 0f;
        }

        // Index of the current target
        public int TargetWhoAmI
        {
            get => (int)Projectile.ai[1];
            set => Projectile.ai[1] = value;
        }

        private const int MAX_TICKS = 45;
        private const int ALPHA_REDUCTION = 25;
        private const int MAX_STICKY_JAVELINS = 4;
        private readonly Point[] _stickingJavelins = new Point[MAX_STICKY_JAVELINS]; // The point array holding for sticking javelins

        private void StickyAI()
        {
            // These 2 could probably be moved to the ModifyNPCHit hook, but in vanilla they are present in the AI
            Projectile.ignoreWater = true; // Make sure the projectile ignores water
            Projectile.tileCollide = false; // Make sure the projectile doesn't collide with tiles anymore
            const int aiFactor = 15; // Change this factor to change the 'lifetime' of this sticking javelin
            Projectile.localAI[0] += 1f;

            // Every 30 ticks, the javelin will perform a hit effect
            bool hitEffect = Projectile.localAI[0] % 30f == 0f;
            int projTargetIndex = (int)TargetWhoAmI;
            if (Projectile.localAI[0] >= 60 * aiFactor || projTargetIndex < 0 || projTargetIndex >= 200)
            { // If the index is past its limits, kill it
                Projectile.Kill();
            }
            else if (Main.npc[projTargetIndex].active && !Main.npc[projTargetIndex].dontTakeDamage)
            { // If the target is active and can take damage
              // Set the projectile's position relative to the target's center
                Projectile.Center = Main.npc[projTargetIndex].Center - Projectile.velocity * 2f;
                Projectile.gfxOffY = Main.npc[projTargetIndex].gfxOffY;
                if (hitEffect)
                { // Perform a hit effect here
                    Main.npc[projTargetIndex].HitEffect(0, 1.0);
                }
            }
            else
            { // Otherwise, kill the projectile
                Projectile.Kill();
            }
        }


        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            // Inflate some target hitboxes if they are beyond 8,8 size
            if (targetHitbox.Width > 8 && targetHitbox.Height > 8)
            {
                targetHitbox.Inflate(-targetHitbox.Width / 8, -targetHitbox.Height / 8);
            }
            // Return if the hitboxes intersects, which means the javelin collides or not
            return projHitbox.Intersects(targetHitbox);
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            IsStickingToTarget = true; // we are sticking to a target
            TargetWhoAmI = target.whoAmI; // Set the target whoAmI
            Projectile.velocity =
                (target.Center - Projectile.Center) *
                0.75f; // Change velocity based on delta center of targets (difference between entity centers)
            Projectile.netUpdate = true; // netUpdate this javelin
            //target.AddBuff(ModContent.BuffType<Buffs.ExampleJavelin>(), 900); // Adds the ExampleJavelin debuff for a very small DoT

            Projectile.timeLeft = 200;
        }


    }

}
