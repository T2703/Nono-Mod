using Microsoft.Xna.Framework;
using NonoMod.PlayerProp;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Accessories
{
	public class BlackHoleCross : ModItem
	{
      
        public override void SetDefaults()
		{
            Item.width = 32;
            Item.height = 32;
            Item.maxStack = 1;
            Item.value = Item.buyPrice(gold: 21, silver: 99);
            Item.rare = ItemRarityID.Yellow;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<PlayerHurtBlackHole>().hasBlackHoleCross = true;
        }
    }
}