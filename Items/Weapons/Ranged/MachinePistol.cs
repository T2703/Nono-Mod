using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Weapons.Ranged
{
	public class MachinePistol : ModItem
	{
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.NonoMod.hjson file.

        public override void SetDefaults()
		{
			Item.damage = 3;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 30;
			Item.useTime = 3;
			Item.useAnimation = 3;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 4;
            Item.value = Item.buyPrice(gold: 5);
            Item.rare = 3;
			Item.autoReuse = true;
			Item.noMelee = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 40f;
            Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item11;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5f, 2f);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.IllegalGunParts, 1);
            recipe.AddIngredient(ItemID.IronBar, 10);
            recipe.AddIngredient(ItemID.Chain, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

            Recipe recipeAlt = CreateRecipe();
            recipeAlt.AddIngredient(ItemID.IllegalGunParts, 1);
            recipeAlt.AddIngredient(ItemID.LeadBar, 10);
            recipeAlt.AddIngredient(ItemID.Chain, 5);
            recipeAlt.AddTile(TileID.Anvils);
            recipeAlt.Register();
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float numberProjectiles = 3 + Main.rand.Next(1);
            float rotation = MathHelper.ToRadians(160);

            position += Vector2.Normalize(velocity) * 65f;

            Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, 1 / (numberProjectiles - 1))) * .2f;
            Projectile.NewProjectile(source, position, perturbedSpeed, type, damage / 2, knockback, player.whoAmI);
            return true;
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.15f;
        }

    }
}