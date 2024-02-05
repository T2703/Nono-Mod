using Microsoft.Xna.Framework;
using NonoMod.Items.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Weapons.Magic
{
	public class QuarterCircleFwd : ModItem
	{
        // The Display Name yeah

        public override void SetDefaults()
		{
			Item.damage = 25;
			Item.DamageType = DamageClass.Magic;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 16;
            Item.mana = 8;
            Item.useAnimation = 16;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 8f;
            Item.value = Item.buyPrice(silver: 45, copper: 78);
            Item.rare = 2;
			Item.autoReuse = true;
			Item.noMelee = true;
            Item.shootSpeed = 14.5f;
			Item.UseSound = SoundID.Item20;
            Item.shoot = ModContent.ProjectileType<Hadoken>();
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 offset = new Vector2(velocity.X * 8, 0);
            position += offset;
            return true;
        }

        /*public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Wire, 15);
            recipe.AddIngredient(ItemID.Book, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

        }*/ 

    }
}