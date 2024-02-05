using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items
{
	public class ComedySpoon : ModItem
	{
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.NonoMod.hjson file.

        public override void SetDefaults()
		{
			Item.damage = 21;
			Item.DamageType = DamageClass.Melee;
			Item.width = 64;
			Item.height = 64;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 1;
			Item.knockBack = 15;
            Item.value = Item.buyPrice(silver: 60, copper: 50);
            Item.rare = 3;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
            Item.shoot = Mod.Find<ModProjectile>("SpoonProjectile").Type;
            Item.shootSpeed = 6;

            // I am a silly dude.

        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-30, 5);
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.IronBar, 25);
            recipe.AddIngredient(ItemID.Wood, 15);
            recipe.AddIngredient(ItemID.Chain, 5);
            recipe.AddIngredient(ItemID.ConfettiGun, 5);
            recipe.AddTile(TileID.Anvils);
			recipe.Register();

            Recipe recipeAlt = CreateRecipe();
            recipeAlt.AddIngredient(ItemID.LeadBar, 25);
            recipeAlt.AddIngredient(ItemID.Wood, 15);
            recipeAlt.AddIngredient(ItemID.Chain, 5);
            recipeAlt.AddIngredient(ItemID.ConfettiGun, 5);
            recipeAlt.AddTile(TileID.Anvils);
            recipeAlt.Register();
        }

    }
}