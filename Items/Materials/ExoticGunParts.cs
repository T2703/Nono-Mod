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
	public class ExoticGunParts : ModItem
	{

        public override void SetDefaults()
		{
            Item.width = 32;
            Item.height = 32;
            Item.maxStack = 9999;
            Item.value = Item.buyPrice(gold: 30);
            Item.rare = ItemRarityID.Green; 

        }


    }

}
