using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent.Drawing;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace NonoMod.Items.Materials
{
	public class DemonPoints : ModItem
	{

        public override void SetStaticDefaults()
        {
            ItemID.Sets.ItemNoGravity[Item.type] = true;
        }

        public override void SetDefaults()
		{
            Item.width = 30;
            Item.height = 30;
            Item.maxStack = 9999;
            Item.value = Item.buyPrice(silver: 15);
            Item.rare = ItemRarityID.Green;
        }


    }

}
