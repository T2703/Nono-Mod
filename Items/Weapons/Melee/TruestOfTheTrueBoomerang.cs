using Microsoft.CodeAnalysis;
using Microsoft.Xna.Framework;
using Mono.Cecil;
using NonoMod.Items.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Weapons.Melee
{
	public class TruestOfTheTrueBoomerang : ModItem
	{
        // Silly little joke weapon.

        public override void SetDefaults()
		{
			Item.damage = 130;
			Item.DamageType = DamageClass.Melee;
			Item.width = 33;
			Item.height = 33;
			Item.useTime = 4;
			Item.useAnimation = 4;
			Item.useStyle = 1;
			Item.knockBack = 17.5f;
            Item.value = Item.buyPrice(gold: 20, silver: 21, copper: 12);
            Item.rare = 8;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
            Item.noUseGraphic = true;
            Item.shoot = ModContent.ProjectileType<TruestOfTheTrueBoomerangProjectile>();
            Item.shootSpeed = 20f;

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.WoodenBoomerang, 1);
            recipe.AddIngredient(ItemID.HallowedBar, 25);
            recipe.AddIngredient(ItemID.BrokenHeroSword, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();

        }
    }
}