using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Vanity
{
    // GACHA GACHA GACHA!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    // Credit to xdleviathan for the gudako head sprite 
    [AutoloadEquip(EquipType.Head)]
    public class GudakyMask : ModItem
	{

        public override void SetDefaults()
		{
            Item.width = 20; 
            Item.height = 20; 
            Item.value = Item.sellPrice(gold: 5); 
            Item.rare = ItemRarityID.Green; 

        }
    }
}