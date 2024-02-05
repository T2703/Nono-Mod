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
	public class JudgementCut : ModProjectile
	{
        public static float SharedRotation;
        public override void SetDefaults()
		{
            Projectile.width = 10;
            Projectile.height = 1650;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 50;
            Projectile.penetrate = -1;
            Projectile.ignoreWater = true;
            Projectile.hostile = false;
            Projectile.friendly = false;
            DrawOriginOffsetY = -200;
            DrawOffsetX = 80;
            Projectile.rotation = MathHelper.ToRadians(Main.rand.Next(0, 364));
            SharedRotation = Projectile.rotation;

        }
        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            IsStickingToTarget = true; // we are sticking to a target
            TargetWhoAmI = target.whoAmI; // Set the target whoAmI
            Projectile.velocity =
                (target.Center - Projectile.Center) *
                0.75f; // Change velocity based on delta center of targets (difference between entity centers)
            Projectile.netUpdate = true; // netUpdate this javelin
            target.AddBuff(BuffID.ShadowFlame, 900); // Adds the ExampleJavelin debuff for a very small DoT

            Projectile.damage = 0; // Makes sure the sticking javelins do not deal damage anymore

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

        bool first = true;
        public override void OnKill(int timeLeft)
        {
            Vector2 usePos = Projectile.position; // Position to use for dusts

            // Please note the usage of MathHelper, please use this!
            // We subtract 90 degrees as radians to the rotation vector to offset the sprite as its default rotation in the sprite isn't aligned properly.
            Vector2 rotVector = (Projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2(); // rotation vector to use for dust velocity
            usePos += rotVector * 16f;
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<JudgementNut>(), Projectile.damage * 3, Projectile.knockBack, Projectile.owner);

            for (int i = 0; i < 20; i++)
            {
                Dust dust = Dust.NewDustDirect(usePos, Projectile.width, Projectile.height, DustID.Cloud, 0f, 0f, 100, Color.GhostWhite, 2f);
                dust.velocity *= 1f;
                dust.scale = 2f;
                dust.rotation = MathHelper.ToRadians(Main.rand.Next(0, 364));
            }

            SoundStyle JudgementCutEnd = new SoundStyle($"{nameof(NonoMod)}/Items/Sounds/ForsakenJudgeEndSFX")
            {
                Volume = 1f,
                PitchVariance = 0.4f,
                MaxInstances = 5,
            };

            SoundEngine.PlaySound(JudgementCutEnd, Projectile.position);

        }


        // Change this number if you want to alter how the alpha changes
        private const int ALPHA_REDUCTION = 25;

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

        public override void AI()
        {
            UpdateAlpha();

            // Mainly here so the it doesn't go flying.
            /*if (IsStickingToTarget)
            {
                StickyAI();
            }*/

        }

        private void UpdateAlpha()
        {
            // Slowly remove alpha as it is present
            if (Projectile.alpha > 0)
            {
                Projectile.alpha -= ALPHA_REDUCTION;
            }

            // If alpha gets lower than 0, set it to 0
            if (Projectile.alpha < 0)
            {
                Projectile.alpha = 0;
            }
        }

    }

}
