using Microsoft.Xna.Framework;
using NonoMod.Items.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Weapons.Magic
{
	public class MagicGun : ModItem
	{

        public override void SetDefaults()
		{
			Item.damage = 34;
			Item.DamageType = DamageClass.Magic;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 7;
            Item.mana = 6;
            Item.useAnimation = 7;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 4f;
            Item.value = Item.buyPrice(gold: 3, silver: 82, copper: 58);
            Item.rare = 4;
			Item.autoReuse = true;
			Item.noMelee = true;
            Item.shootSpeed = 20f;
			Item.UseSound = SoundID.Item11;
            Item.shoot = ProjectileID.ExplosiveBullet;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 offset = new Vector2(velocity.X * 8, 0);
            position += offset;
            return true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SpellTome, 1);
            recipe.AddIngredient(ItemID.ExplosivePowder, 30);
            recipe.AddTile(TileID.Bookcases);
            recipe.Register();

        }

    }
}