using Microsoft.Xna.Framework;
using Mono.Cecil;
using NonoMod.Items.Projectiles;
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
	public class PlayerHurtBlackHole : ModPlayer
    {
        public bool hasBlackHoleCross;

        public override void ResetEffects()
        {
            hasBlackHoleCross = false;
        }

        public override void PostHurt(Player.HurtInfo info)
        {
            var source = Player.GetSource_FromThis();
            float blackHoleX;
            if (!hasBlackHoleCross)
            {
                return;
            }
            else
            {
                if (Player.direction == 1)
                {
                    blackHoleX = 5f;
                }
                else
                {
                    blackHoleX = -5f;
                }

                Projectile.NewProjectile(source, Player.Center.X, Player.Center.Y, blackHoleX, 0, ModContent.ProjectileType<Blackholecross>(), 50, 0f, Player.whoAmI);
            }
        }
    }
}