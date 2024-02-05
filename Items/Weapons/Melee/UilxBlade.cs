using Microsoft.Xna.Framework;
using NonoMod.Items.Materials;
using NonoMod.Items.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Weapons.Melee
{
	public class UilxBlade : ModItem
	{

		public override void SetDefaults()
		{
			Item.damage = 57;
			Item.DamageType = DamageClass.Melee;
			Item.width = 50;
			Item.height = 50;
			Item.useTime = 18;
			Item.useAnimation = 18;
			Item.useStyle = 1;
			Item.knockBack = 9.4f;
			Item.value = Item.buyPrice(gold: 7, silver: 50, copper: 50);
            Item.rare = 3;
			Item.UseSound = SoundID.Item71;
            Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<UilxBladeBeam>();
			Item.shootSpeed = 15;
			Item.shootsEveryUse = true;

		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 offset = new Vector2(velocity.X * 7, velocity.Y * 1);
            position += offset;
            return true;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
		{
            int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.PurpleCrystalShard, 0f, 0f, 0, default, 2f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].scale *= 0.3f;

            int dust2 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.PinkCrystalShard, 0f, 0f, 0, default, 2f);
            Main.dust[dust2].noGravity = true;
            Main.dust[dust2].scale *= 0.5f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<UilxMatter>(), 30);
            recipe.AddIngredient(ItemID.SoulofLight, 15);
            recipe.AddIngredient(ItemID.CrystalShard, 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }

    }
}