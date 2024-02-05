using Microsoft.CodeAnalysis;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Projectiles
{
    // This is a copy of the Excalibur's projectile
    public class NumberOneEffects : ModProjectile
    {

        // We could use a vanilla texture if we want instead of supplying our own.
        // public override string Texture => "Terraria/Images/Projectile_" + ProjectileID.Excalibur;

        public override void SetStaticDefaults()
        {
            Main.projFrames[Type] = 4; 
        }

        public override void SetDefaults()
        {
            // The width and height don't really matter here because we have custom collision.
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = 5; // The projectile can hit 3 enemies.
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = -1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.ownerHitCheck = true; // A line of sight check so the projectile can't deal damage through tiles.
            Projectile.ownerHitCheckDistance = 300f; // The maximum range that the projectile can hit a target. 300 pixels is 18.75 tiles.
            Projectile.usesOwnerMeleeHitCD = true; // This will make the projectile apply the standard number of immunity frames as normal melee attacks.
                                                   // Normally, projectiles die after they have hit all the enemies they can.
                                                   // But, for this case, we want the projectile to continue to live so we can have the visuals of the swing.
            Projectile.stopsDealingDamageAfterPenetrateHits = true;

            // We will be using custom AI for this projectile. The original Excalibur uses aiStyle 190.
            //Projectile.aiStyle = -1;
            //Projectile.aiStyle = ProjAIStyleID.NightsEdge; // 190
            // AIType = ProjectileID.Excalibur;

            // If you are using custom AI, add this line. Otherwise, visuals from Flasks will spawn at the center of the projectile instead of around the arc.
            // We will spawn the visuals around the arc ourselves in the AI().
            Projectile.noEnchantmentVisuals = true;
        }

        public override void AI()
        {

            Lighting.AddLight(Projectile.Center, 1f, 0, 0);

            Projectile.localAI[0]++; // Current time that the projectile has been alive.
            Player player = Main.player[Projectile.owner];
            float percentageOfLife = Projectile.localAI[0] / Projectile.ai[1]; // The current time over the max time.
            float direction = Projectile.ai[0];
            float velocityRotation = Projectile.velocity.ToRotation();
            float adjustedRotation = MathHelper.Pi * direction * percentageOfLife + velocityRotation + direction * MathHelper.Pi + player.fullRotation;
            Projectile.rotation = adjustedRotation; // Set the rotation to our to the new rotation we calculated.

            float scaleMulti = 0.5f; // Excalibur, Terra Blade, and The Horseman's Blade is 0.6f; True Excalibur is 1f; default is 0.2f 
            float scaleAdder = 0.8f; // Excalibur, Terra Blade, and The Horseman's Blade is 1f; True Excalibur is 1.2f; default is 1f 

            Projectile.Center = player.RotatedRelativePoint(player.MountedCenter) - Projectile.velocity;
            Projectile.scale = scaleAdder + percentageOfLife * scaleMulti;

            // The other sword projectiles that use AI Style 190 have different effects.
            // This example only includes the Excalibur.
            // Look at AI_190_NightsEdge() in Projectile.cs for the others.

            Projectile.scale *= Projectile.ai[2]; // Set the scale of the projectile to the scale of the item.

            // If the projectile is as old as the max animation time, kill the projectile.
            if (Projectile.localAI[0] >= Projectile.ai[1])
            {
                Projectile.Kill();
            }

            // This for loop spawns the visuals when using Flasks (weapon imbues)
            for (float i = -MathHelper.PiOver4; i <= MathHelper.PiOver4; i += MathHelper.PiOver2)
            {
                Rectangle rectangle = Utils.CenteredRectangle(Projectile.Center + (Projectile.rotation + i).ToRotationVector2() * 70f * Projectile.scale, new Vector2(60f * Projectile.scale, 60f * Projectile.scale));
                Projectile.EmitEnchantmentVisualsAt(rectangle.TopLeft(), rectangle.Width, rectangle.Height);
            }
        }

        // Here is where we have our custom collision.
        // This collision will only run if the projectile is within range of target with the range being Projectile.ownerHitCheckDistance
        // Or if the projectile hasn't already hit all of the targets it can with Projectile.penetrate
        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            // This is how large the circumference is, aka how big the range is. Vanilla uses 94f to match it to the size of the texture.
            float coneLength = 94f * Projectile.scale;
            // This number affects how much the start and end of the collision will be rotated.
            // Bigger Pi numbers will rotate the collision counter clockwise.
            // Smaller Pi numbers will rotate the collision clockwise.
            // (Projectile.ai[0] is the direction)
            float collisionRotation = MathHelper.Pi * 2f / 25f * Projectile.ai[0];
            float maximumAngle = MathHelper.PiOver4; // The maximumAngle is used to limit the rotation to create a dead zone.
            float coneRotation = Projectile.rotation + collisionRotation;

            // Uncomment this line for a visual representation of the cone. The dusts are not perfect, but it gives a general idea.
            // Dust.NewDustPerfect(Projectile.Center + coneRotation.ToRotationVector2() * coneLength, DustID.Pixie, Vector2.Zero);
            // Dust.NewDustPerfect(Projectile.Center, DustID.BlueFairy, new Vector2((float)Math.Cos(maximumAngle) * Projectile.ai[0], (float)Math.Sin(maximumAngle)) * 5f); // Assumes collisionRotation was not changed

            // First, we check to see if our first cone intersects the target.
            if (targetHitbox.IntersectsConeSlowMoreAccurate(Projectile.Center, coneLength, coneRotation, maximumAngle))
            {
                return true;
            }

            // The first cone isn't the entire swinging arc, though, so we need to check a second cone for the back of the arc.
            float backOfTheSwing = Utils.Remap(Projectile.localAI[0], Projectile.ai[1] * 0.3f, Projectile.ai[1] * 0.5f, 1f, 0f);
            if (backOfTheSwing > 0f)
            {
                float coneRotation2 = coneRotation - MathHelper.PiOver4 * Projectile.ai[0] * backOfTheSwing;

                // Uncomment this line for a visual representation of the cone. The dusts are not perfect, but it gives a general idea.
                // Dust.NewDustPerfect(Projectile.Center + coneRotation2.ToRotationVector2() * coneLength, DustID.Enchanted_Pink, Vector2.Zero);
                // Dust.NewDustPerfect(Projectile.Center, DustID.BlueFairy, new Vector2((float)Math.Cos(backOfTheSwing) * -Projectile.ai[0], (float)Math.Sin(backOfTheSwing)) * 5f); // Assumes collisionRotation was not changed

                if (targetHitbox.IntersectsConeSlowMoreAccurate(Projectile.Center, coneLength, coneRotation2, maximumAngle))
                {
                    return true;
                }
            }

            return false;
        }

        public override void CutTiles()
        {
            // Here we calculate where the projectile can destroy grass, pots, Queen Bee Larva, etc.
            Vector2 starting = (Projectile.rotation - MathHelper.PiOver4).ToRotationVector2() * 60f * Projectile.scale;
            Vector2 ending = (Projectile.rotation + MathHelper.PiOver4).ToRotationVector2() * 60f * Projectile.scale;
            float width = 40f * Projectile.scale;
            Utils.PlotTileLine(Projectile.Center + starting, Projectile.Center + ending, width, DelegateMethods.CutTiles);
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            ParticleOrchestrator.RequestParticleSpawn(clientOnly: false, ParticleOrchestraType.NightsEdge,
                new ParticleOrchestraSettings { PositionInWorld = Main.rand.NextVector2FromRectangle(target.Hitbox) },
                Projectile.owner);

            hit.HitDirection = (Main.player[Projectile.owner].Center.X < target.Center.X) ? 1 : (-1);
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            ParticleOrchestrator.RequestParticleSpawn(clientOnly: false, ParticleOrchestraType.NightsEdge,
                new ParticleOrchestraSettings { PositionInWorld = Main.rand.NextVector2FromRectangle(target.Hitbox) },
                Projectile.owner);

            info.HitDirection = (Main.player[Projectile.owner].Center.X < target.Center.X) ? 1 : (-1);
        }

        // Taken from Main.DrawProj_Excalibur()
        // Look at the source code for the other sword types.
        public override bool PreDraw(ref Color lightColor)
        {
            Vector2 position = Projectile.Center - Main.screenPosition;
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            Rectangle sourceRectangle = texture.Frame(1, 4); // The sourceRectangle says which frame to use.
            Vector2 origin = sourceRectangle.Size() / 2f;
            float scale = Projectile.scale * 1.1f;
            SpriteEffects spriteEffects = ((!(Projectile.ai[0] >= 0f)) ? SpriteEffects.FlipVertically : SpriteEffects.None); // Flip the sprite based on the direction it is facing.
            float percentageOfLife = Projectile.localAI[0] / Projectile.ai[1]; // The current time over the max time.
            float lerpTime = Utils.Remap(percentageOfLife, 0f, 0.6f, 0f, 1f) * Utils.Remap(percentageOfLife, 0.6f, 1f, 1f, 0f);
            float lightingColor = Lighting.GetColor(Projectile.Center.ToTileCoordinates()).ToVector3().Length() / (float)Math.Sqrt(3.0);
            lightingColor = Utils.Remap(lightingColor, 0.2f, 1f, 0f, 1f);

            Color backDarkColor = new Color(0, 0, 0); // Black
            Color middleMediumColor = new Color(0, 0, 0); // Black
            Color frontLightColor = new Color(0, 0, 0); // Black

            // Back part
            Main.EntitySpriteDraw(texture, position, sourceRectangle, backDarkColor * lightingColor * lerpTime, Projectile.rotation + Projectile.ai[0] * MathHelper.PiOver4 * -1f * (1f - percentageOfLife), origin, scale, spriteEffects, 0f);
            // Very faint part affected by the light color
            Main.EntitySpriteDraw(texture, position, sourceRectangle, Color.Red * 0.15f, Projectile.rotation + Projectile.ai[0] * 0.01f, origin, scale, spriteEffects, 0f);
            // Middle part
            Main.EntitySpriteDraw(texture, position, sourceRectangle, middleMediumColor * lightingColor * lerpTime * 0.3f, Projectile.rotation, origin, scale, spriteEffects, 0f);
            // Front part
            Main.EntitySpriteDraw(texture, position, sourceRectangle, frontLightColor * lightingColor * lerpTime * 0.5f, Projectile.rotation, origin, scale * 0.975f, spriteEffects, 0f);
            // Thin top line (final frame)
            Main.EntitySpriteDraw(texture, position, texture.Frame(1, 4, 0, 3), Color.Black * 0.6f * lerpTime, Projectile.rotation + Projectile.ai[0] * 0.01f, origin, scale, spriteEffects, 0f);
            // Thin middle line (final frame)
            Main.EntitySpriteDraw(texture, position, texture.Frame(1, 4, 0, 3), Color.Red * 0.5f * lerpTime, Projectile.rotation + Projectile.ai[0] * -0.05f, origin, scale * 0.8f, spriteEffects, 0f);
            // Thin bottom line (final frame)
            Main.EntitySpriteDraw(texture, position, texture.Frame(1, 4, 0, 3), Color.Red * 0.4f * lerpTime, Projectile.rotation + Projectile.ai[0] * -0.1f, origin, scale * 0.6f, spriteEffects, 0f);

            // Uncomment this line for a visual representation of the projectile's size.
            // Main.EntitySpriteDraw(TextureAssets.MagicPixel.Value, position, sourceRectangle, Color.Orange * 0.75f, 0f, origin, scale, spriteEffects);

            return false;
        }

    }
}