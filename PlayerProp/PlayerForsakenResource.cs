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
	public class PlayerForsakenResource : ModPlayer
    {
        public int customResourceCurrent = 100;
        public const int DefaultCustomResourceMax = 100;
        public int customResourceMax;
        public int customResourceMaxTwo;
        public float customResourceRegenRate;
        internal int customResourceRegenTimer = 0;

        public override void Initialize()
        {
            customResourceMax = DefaultCustomResourceMax;
        }

        public override void ResetEffects()
        {
            customResourceRegenRate = 1f;
            customResourceMaxTwo = customResourceMax;
        }

        public override void UpdateDead()
        {
            customResourceRegenRate = 1f;
            customResourceMaxTwo = customResourceMax;
        }

        public override void PostUpdateMiscEffects()
        {
            customResourceRegenTimer++;

            if (customResourceRegenTimer > 60 / customResourceRegenRate)
            {
                customResourceCurrent += 1;
                customResourceRegenTimer = 0;
            }

            customResourceCurrent = Utils.Clamp(customResourceCurrent, 0, customResourceMaxTwo);

        }
    }
}