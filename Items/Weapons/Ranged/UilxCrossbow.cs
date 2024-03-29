using Microsoft.Xna.Framework;
using NonoMod.Items.Materials;
using NonoMod.Items.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Weapons.Ranged
{
	public class UilxCrossbow : ModItem
	{
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.NonoMod.hjson file.

        public override void SetDefaults()
		{
			Item.damage = 45;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 50;
			Item.height = 20;
			Item.useTime = 18;
			Item.useAnimation = 18;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 2.3f;
            Item.value = Item.buyPrice(gold: 3, silver: 23);
            Item.rare = ItemRarityID.LightRed;
			Item.autoReuse = true;
			Item.noMelee = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 18f;
            Item.useAmmo = AmmoID.Arrow;
			Item.UseSound = SoundID.Item5;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int numberProjectiles = 2;
            for (int i = 0; i < numberProjectiles; i++)
            {

                Projectile.NewProjectile(source, position, velocity.RotatedByRandom(MathHelper.ToRadians(12)), type, damage, knockback, player.whoAmI);
            }

            Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<UilxOrb>(), damage, knockback, player.whoAmI);

            return false;
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.21f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<UilxMatter>(), 25);
            recipe.AddIngredient(ItemID.SoulofLight, 10);
            recipe.AddIngredient(ItemID.CrystalShard, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}