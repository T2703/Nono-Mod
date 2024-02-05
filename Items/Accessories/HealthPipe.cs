using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Accessories
{
	public class HealthPipe : ModItem
	{
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.NonoMod.hjson file.

        public override void SetDefaults()
		{
            Item.width = 32;
            Item.height = 32;
            Item.maxStack = 1;
            Item.value = Item.buyPrice(gold: 5, silver: 69);
            Item.rare = 6;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statLifeMax2 += 25;
            player.lifeRegen = 20;
            
        }

    }
}