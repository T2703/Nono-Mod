using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Accessories
{
	public class NanomachinesSon : ModItem
	{
        // IT HARDENS IN RESPONE TO PHYSICAL TRAUMA!

        public override void SetDefaults()
		{
            Item.width = 32;
            Item.height = 32;
            Item.maxStack = 1;
            Item.value = Item.buyPrice(gold: 2, silver: 50);
            Item.rare = 3;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.lifeRegen = 5;
            player.statDefense += 10;
            player.noKnockback = true;
            
        }

    }
}