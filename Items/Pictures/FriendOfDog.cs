using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent.Drawing;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace NonoMod.Items.Pictures
{
	public class FriendOfDog : ModItem
	{

        public override void SetDefaults()
		{
            Item.width = 80;
            Item.height = 80;
            Item.maxStack = 9999;
            Item.useStyle = 1;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.placeStyle = 3;
            Item.rare = ItemRarityID.Blue;
            Item.createTile = ModContent.TileType<Tiles.WallItems.FriendOfDogPlace>();
            Item.value = Item.buyPrice(silver: 60, copper: 70);

        }

    }

}
