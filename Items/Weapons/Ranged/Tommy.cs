using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Weapons.Ranged
{
	public class Tommy : ModItem
	{
       
        
        public override void SetDefaults()
		{
			Item.damage = 15;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 50;
			Item.height = 45;
			Item.useTime = 11;
			Item.useAnimation = 11;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 1.2f;
            Item.value = Item.buyPrice(gold: 10, silver: 25);
            Item.rare = 3;
			Item.autoReuse = true;
			Item.noMelee = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 13f;
            Item.useAmmo = AmmoID.Bullet;
            Item.UseSound = new SoundStyle($"{nameof(NonoMod)}/Items/Sounds/TommyShootSFX")
            {
                Volume = 0.6f,
                PitchVariance = 0.5f,
                MaxInstances = 10,
            };
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5f, 5f);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Wood, 25);
            recipe.AddIngredient(ItemID.IronBar, 15);
            recipe.AddIngredient(ItemID.IllegalGunParts, 1);
            recipe.Register();

            Recipe recipeAlt = CreateRecipe();
            recipeAlt.AddIngredient(ItemID.Wood, 25);
            recipeAlt.AddIngredient(ItemID.LeadBar, 15);
            recipeAlt.AddIngredient(ItemID.IllegalGunParts, 1);
            recipeAlt.Register();
        }


    }
}