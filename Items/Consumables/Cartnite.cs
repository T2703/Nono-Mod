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
	public class Cartnite : ModItem
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
            Item.value = Item.buyPrice(copper: 40);
            Item.useTime = 10;
            Item.buffType = BuffID.Poisoned;
            Item.buffTime = 8000;
            Item.rare = ItemRarityID.Gray;

        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Smoke, 0.3f, 0f, 0, default, 1f);
            Main.dust[dust].noGravity = true;
        }

    }

}
