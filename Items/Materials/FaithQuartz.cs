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
	public class FaithQuartz : ModItem
	{
        // Totally not just Saint Quartz and yes it's supposed to look like that.

        public override void SetStaticDefaults()
        {
            ItemID.Sets.ItemNoGravity[Item.type] = true;
        }

        public override void SetDefaults()
		{
            Item.width = 30;
            Item.height = 30;
            Item.maxStack = 9999;
            Item.value = Item.buyPrice(silver: 25, copper: 10);

        }

        public override void PostUpdate()
        {
            Lighting.AddLight(Item.Center, Color.Gold.ToVector3() * 0.35f * Main.essScale);
        }



    }

}
