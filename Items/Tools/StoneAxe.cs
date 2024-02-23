using Microsoft.CodeAnalysis;
using Microsoft.Xna.Framework;
using Mono.Cecil;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Tools
{
	public class StoneAxe : ModItem
	{

        public override void SetDefaults()
		{
			Item.damage = 4;
			Item.DamageType = DamageClass.Melee;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 13;
			Item.useAnimation = 13;
			Item.useStyle = 1;
			Item.knockBack = 1.2f;
            Item.value = Item.buyPrice(copper: 22);
            Item.rare = 1;
			Item.autoReuse = true;
            Item.UseSound = SoundID.Item1;
            Item.axe = 15;

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.StoneBlock, 8);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();

        }

    }
}