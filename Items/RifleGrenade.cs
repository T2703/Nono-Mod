using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent.Drawing;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace NonoMod.Items
{
	public class RifleGrenade : ModItem
	{

        public override void SetDefaults()
		{
            Item.width = 30;
            Item.height = 30;
            Item.damage = 60;
            Item.DamageType = DamageClass.Ranged;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.knockBack = 4.5f;
            Item.value = Item.sellPrice(silver: 15);
            Item.rare = ItemRarityID.Green;
            Item.shoot = ProjectileID.Grenade;
            Item.ammo = Item.type;

        }


    }

}
