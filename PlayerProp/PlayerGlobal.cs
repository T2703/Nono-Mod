using Microsoft.Xna.Framework;
using NonoMod.Items.Weapons.Magic;
using NonoMod.Items.Weapons.Melee;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.PlayerProp
{
	public class PlayerGlobal : ModPlayer
    {
        public enum DashType
        {
            forsaken = 0,
            dashExample = 1
        }

        public DashType dashType= DashType.forsaken;

        public bool forsaken = false;
        public bool dashEquipped = false;

        public const int dashRight = 2;
        public const int dashLeft = 3;

        public int dashCooldown = 50;
        public int dashDuration = 25;

        public float dashVelocity = 10.5f;

        public int dashDirection = -1;

        public int dashDelay = 0;
        public int dashTimer = 0;

        public override void ResetEffects()
        {
            if (Player.controlRight && Player.releaseRight && Player.doubleTapCardinalTimer[dashRight] < 15)
            {
                dashDirection = dashRight;
            }
            else if (Player.controlLeft && Player.releaseLeft && Player.doubleTapCardinalTimer[dashLeft] < 15)
            {
                dashDirection = dashLeft;
            }
            else
            {
                dashDirection = -1;
            }
        }

        public override void PreUpdate()
        {
            if (CanUseDash() && dashDirection != -1 && dashDelay == 0)
            {
                Vector2 newVel = Player.velocity;
                switch (dashDirection)
                {
                    case dashLeft when Player.velocity.X > -dashVelocity:
                    case dashRight when Player.velocity.X > dashVelocity:
                        {
                            float dashDir = dashDirection + dashVelocity;
                            newVel.X = dashDir + dashVelocity;
                            break;
                        }
                    default:
                        break;
                }

                dashDelay = dashCooldown;
                dashTimer = dashDuration;
                Player.velocity = newVel;
                SoundEngine.PlaySound(SoundID.NPCDeath10, Player.position);
            }

            if (dashDelay > 0)
            {
                dashDelay--; 
            }

            if (dashTimer > 0)
            {
                dashTimer--;
            }

        }

        public bool CanUseDash()
        {
            return dashEquipped && Player.dashType == 0;
        }
    }
}