using Microsoft.Xna.Framework;
using NonoMod.Items.Materials;
using NonoMod.Items.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Weapons.Magic
{
	public class UilxStaff : ModItem
	{
        // The Display Name yeah
        public override void SetStaticDefaults()
        {
            Item.staff[Type] = true;
        }

        public override void SetDefaults()
		{
			Item.damage = 41;
			Item.DamageType = DamageClass.Magic;
			Item.width = 44;
			Item.height = 44;
			Item.useTime = 18;
            Item.mana = 10;
            Item.useAnimation = 18;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 4f;
            Item.value = Item.buyPrice(gold: 7, silver: 50, copper: 50);
            Item.rare = 4;
			Item.autoReuse = true;
			Item.noMelee = true;
            Item.shootSpeed = 12.5f;
			Item.UseSound = SoundID.Item20;
            Item.shoot = ProjectileID.TrueExcalibur;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 offset = new Vector2(velocity.X * 8, velocity.Y * 6);
            position += offset;

            for (int i = 0; i < 4; i++)
            {
                Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(20));
                Projectile.NewProjectile(source, position, perturbedSpeed, ModContent.ProjectileType<UilxBall>(), damage, knockback, player.whoAmI);
            }
            return true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<UilxMatter>(), 25);
            recipe.AddIngredient(ItemID.SoulofLight, 5);
            recipe.AddIngredient(ItemID.CrystalShard, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }

    }
}