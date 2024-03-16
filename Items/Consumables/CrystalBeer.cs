using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent.Drawing;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace NonoMod.Items.Consumables
{
	public class CrystalBeer : ModItem
	{

        public override void SetDefaults()
		{
            Item.width = 30;
            Item.height = 30;
            Item.maxStack = 9999;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.UseSound = SoundID.Item3;
            Item.useTurn = true;
            Item.autoReuse = false;
            Item.useAnimation = 10;
            Item.consumable = true;
            Item.value = Item.buyPrice(copper: 60);
            Item.useTime = 10;
            Item.buffType = BuffID.WellFed;
            Item.buffTime = 10800;
            Item.rare = 2;

        }

    }

}
