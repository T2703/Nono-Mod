using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent.Drawing;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items
{
	public class TrueMeleeEffect : ModProjectile
	{
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.NonoMod.hjson file.

        public override void SetStaticDefaults()
        {
            Main.projFrames[Type] = 4;
        }

        public override void SetDefaults()
		{
            Projectile.width = 13;
            Projectile.height = 13;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.damage = 20;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.penetrate = 2;
            Projectile.timeLeft = 420;
            Projectile.aiStyle = 190;

        }

        public override void AI()
        {
    
            Player player = Main.player[Projectile.owner];
            Projectile.localAI[0]++;
            float percentageOfLife = Projectile.localAI[0] / Projectile.ai[1];
            float scaleMulti = 0.8f;
            float scaleAdder = 1f;

            Projectile.Center = player.RotatedRelativePoint(player.MountedCenter) - Projectile.velocity;
            Projectile.scale = scaleAdder + percentageOfLife * scaleMulti;

            for (float i = -MathHelper.PiOver4; i <= MathHelper.PiOver4; i += MathHelper.PiOver2)
            {
                Rectangle rectangle = Utils.CenteredRectangle(Projectile.Center + (Projectile.rotation + i).ToRotationVector2() * 70f * Projectile.scale, new Vector2(60f * Projectile.scale, 60f * Projectile.scale));
                Projectile.EmitEnchantmentVisualsAt(rectangle.TopLeft(), rectangle.Width, rectangle.Height);
            }

        }

        private void DrawLikeTrueMelee (SpriteBatch spriteBatch) {
            Vector2 position = Projectile.Center - Main.screenPosition;
            Texture2D texture = (Texture2D) ModContent.Request<Texture2D>(Texture);
            Rectangle sourceRectangle = texture.Frame(1, Main.projFrames [Type]);
            Vector2 origin = sourceRectangle.Size() / 2f;
            float projectileScale = Projectile.scale * 1.1f;
            SpriteEffects effects = (!(Projectile.ai [0] >= 0f)) ? SpriteEffects.FlipVertically : SpriteEffects.None;
            float percentageOfLife = Projectile.localAI [0] / Projectile.ai [1];
            float lerpTime = Utils.Remap(percentageOfLife, 0f, 0.5f, 0f, 1f) * Utils.Remap(percentageOfLife, 0.5f, 1f, 1f, 0f);
            float lightningValue = Lighting.GetColor(Projectile.Center.ToTileCoordinates()).ToVector3().Length() / (float) Math.Sqrt(3.0);
            lightningValue = Utils.Remap(lightningValue, 0.2f, 1f, 0f, 1f);
            Color value = Color.Lerp(new Color(184, 115, 51, 220), new Color(180, 60, 140, 220), lerpTime);
            spriteBatch.Draw(texture, position, sourceRectangle, value * lightningValue * lerpTime, Projectile.rotation + Projectile.ai [0] * ((float) Math.PI / 4f) * -1f * (1f - percentageOfLife), origin, projectileScale, effects, 0f);
            Color value2 = Color.Lerp(new Color(184, 115, 51, 220), new Color(165, 113, 75, 220), lerpTime) * 1.25f;
            Color color = Color.Lerp(new Color(184, 115, 51, 220), new Color(170, 90, 50, 220), lerpTime) * 1.25f;
            Color value3 = Color.White * lerpTime * 0.5f;
            value3.A = (byte) (value3.A * (1f - lightningValue));
            Color value4 = value3 * lightningValue * 0.5f;
            value4.G = (byte) (value4.G * lightningValue);
            value4.B = (byte) (value4.R * (0.25f + lightningValue * 0.75f));
            spriteBatch.Draw(texture, position, sourceRectangle, value4 * 0.15f, Projectile.rotation + Projectile.ai [0] * 0.01f, origin, projectileScale, effects, 0f);
            spriteBatch.Draw(texture, position, sourceRectangle, color * lightningValue * lerpTime * 0.3f, Projectile.rotation, origin, projectileScale, effects, 0f);
            spriteBatch.Draw(texture, position, sourceRectangle, value2 * lightningValue * lerpTime * 0.5f, Projectile.rotation, origin, projectileScale * 0.975f, effects, 0f);
            spriteBatch.Draw(texture, position, texture.Frame(1, 4, 0, 3), Color.White * 0.6f * lerpTime, Projectile.rotation + Projectile.ai [0] * 0.01f, origin, projectileScale, effects, 0f);
            spriteBatch.Draw(texture, position, texture.Frame(1, 4, 0, 3), Color.White * 0.5f * lerpTime, Projectile.rotation + Projectile.ai [0] * -0.05f, origin, projectileScale * 0.8f, effects, 0f);
            spriteBatch.Draw(texture, position, texture.Frame(1, 4, 0, 3), Color.White * 0.4f * lerpTime, Projectile.rotation + Projectile.ai [0] * -0.1f, origin, projectileScale * 0.6f, effects, 0f);
        }

        public override bool PreDraw(ref Color lightColor)
        {
            SpriteBatch spriteBatch = Main.spriteBatch;
            DrawLikeTrueMelee(spriteBatch);
            return false;
        }

    }
}