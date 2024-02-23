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
	public class StonePickaxe : ModItem
	{

        public override void SetDefaults()
		{
			Item.damage = 5;
			Item.DamageType = DamageClass.Melee;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 11;
			Item.useAnimation = 11;
			Item.useStyle = 1;
			Item.knockBack = 0.8f;
            Item.value = Item.buyPrice(copper: 22);
            Item.rare = 1;
			Item.autoReuse = true;
            Item.UseSound = SoundID.Item1;
            Item.pick = 35;

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.StoneBlock, 12);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();

        }

    }
}