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
	public class HellishFright : ModItem
	{

        public override void SetDefaults()
		{
			Item.damage = 47;
			Item.DamageType = DamageClass.Magic;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 14;
			Item.useAnimation = 14;
            Item.useStyle = 1;
			Item.knockBack = 4;
            Item.value = Item.buyPrice(gold: 8);
            Item.rare = 5;
            Item.mana = 12;
            Item.autoReuse = true;
			Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<HellishProjectile>();
            Item.shootSpeed = 15f;
			Item.UseSound = SoundID.Item1;
        }

        /*public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5f, 2f);
        }*/

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.HellstoneBar, 30);
            recipe.AddIngredient(ItemID.SoulofFright, 25);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }


    }
}