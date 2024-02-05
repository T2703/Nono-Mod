using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent.Drawing;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.CodeAnalysis;
using Terraria.Audio;

// Credit to MylesDeGreat for the slash sprites.

namespace NonoMod.Items.Projectiles
{
	public class HakSlash : ModProjectile
	{
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.NonoMod.hjson file.

        public override void SetStaticDefaults()
        {
            Main.projFrames[Type] = 5;
        }

        public override void SetDefaults()
		{
            Projectile.width = 60;
            Projectile.height = 60;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.damage = 150;
            Projectile.friendly = true;
            Projectile.aiStyle = 20;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.soundDelay = int.MaxValue;
            Projectile.scale = 4.5f;

        }

        public override void AI()
        {
            Lighting.AddLight(Projectile.position, 255, 0, 0);
            //Lighting.Brightness(1, 1);
            Projectile.velocity *= 0.30f;
            Projectile.soundDelay = 120;
            SoundEngine.PlaySound(SoundID.Item15, Projectile.position);

            if (++Projectile.frameCounter >= 1)
            {
                Projectile.frameCounter = 0;
                if (++Projectile.frame >= 5)
                {
                    Projectile.frame = 0;

                }
            }

            Projectile.soundDelay = int.MaxValue;

            Projectile.direction = (Projectile.spriteDirection = ((Projectile.velocity.X > 0f) ? 1 : -1));
            Projectile.rotation = Projectile.velocity.ToRotation();

            if (Projectile.velocity.Y > 16f)
            {
                Projectile.velocity.Y = 16f;
            }

            if (Projectile.spriteDirection == -1)
            {
                Projectile.rotation += MathHelper.Pi;
            }
                
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Random randomChoice = new Random();

            string[] fireDebuffs = { "OnFire", "CursedInferno", "Frostburn" };

            if (!target.HasBuff(BuffID.OnFire) && !target.HasBuff(BuffID.CursedInferno) && !target.HasBuff(BuffID.Frostburn))
            {
                int randomIndex = randomChoice.Next(fireDebuffs.Length);
                string selectedDebuff = fireDebuffs[randomIndex];

                switch (selectedDebuff)
                {
                    case "OnFire":
                        target.AddBuff(BuffID.OnFire, 100);
                        break;

                    case "CursedInferno":
                        target.AddBuff(BuffID.CursedInferno, 100);
                        break;

                    case "Frostburn":
                        target.AddBuff(BuffID.Frostburn, 100);
                        break;
                    default:
                        break;
                }
            }
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            Random randomChoice = new Random();

            string[] fireDebuffs = { "OnFire", "CursedInferno", "Frostburn" };

            if (!target.HasBuff(BuffID.OnFire) && !target.HasBuff(BuffID.CursedInferno) && !target.HasBuff(BuffID.Frostburn))
            {
                int randomIndex = randomChoice.Next(fireDebuffs.Length);
                string selectedDebuff = fireDebuffs[randomIndex];

                switch (selectedDebuff)
                {
                    case "OnFire":
                        target.AddBuff(BuffID.OnFire, 100);
                        break;

                    case "CursedInferno":
                        target.AddBuff(BuffID.CursedInferno, 100);
                        break;

                    case "Frostburn":
                        target.AddBuff(BuffID.Frostburn, 100);
                        break;
                    default:
                        break;
                }
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            SpriteEffects spriteEffects = SpriteEffects.None;
            if (Projectile.spriteDirection == -1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
            Texture2D texture = (Texture2D)ModContent.Request<Texture2D>(Texture);
            int frameHeight = texture.Height / Main.projFrames[Projectile.type];
            int startY = frameHeight * Projectile.frame;
            Rectangle sourceRectangle = new Rectangle(0, startY, texture.Width, frameHeight);
            Vector2 origin = sourceRectangle.Size() / 2f;
            origin.X = (float)((Projectile.spriteDirection == 1) ? (sourceRectangle.Width - 25) : 25);
            //origin.X = 50;

            Color drawColor = Projectile.GetAlpha(lightColor);
            Main.spriteBatch.Draw(texture,
            Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY),
            sourceRectangle, drawColor, Projectile.rotation, origin, Projectile.scale, spriteEffects, 0f);

            return false;
        }

    }
}