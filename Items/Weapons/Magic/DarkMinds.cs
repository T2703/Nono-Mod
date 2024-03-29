using Microsoft.Xna.Framework;
using NonoMod.Items.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Weapons.Magic
{
	public class DarkMinds : ModItem
	{
        public override void SetDefaults()
		{
			Item.damage = 60;
			Item.DamageType = DamageClass.Magic;
			Item.width = 32;
			Item.height = 32;
            Item.mana = 8;
            Item.useTime = 15;
            Item.useAnimation = 15;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 4.2f;
            Item.value = Item.buyPrice(gold: 6);
            Item.rare = ItemRarityID.LightRed;
			Item.autoReuse = true;
			Item.noMelee = true;
            Item.shootSpeed = 15f;
			Item.UseSound = SoundID.Item20;
            Item.shoot = ModContent.ProjectileType<DarkDragon>();
        }

        //Temporary - Will drop from a blood moon monster when created.
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SpellTome, 1);
            recipe.AddIngredient(ItemID.SoulofNight, 25);
            recipe.AddIngredient(ItemID.CrystalShard, 45);
            recipe.AddTile(TileID.Bookcases);
            recipe.Register();
        }



    }
}