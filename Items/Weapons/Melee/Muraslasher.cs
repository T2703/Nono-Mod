using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NonoMod.Items.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Weapons.Melee
{
	public class Muraslasher : ModItem
	{
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.NonoMod.hjson file.


        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Terragrim);
            Item.damage = 170;
            Item.DamageType = DamageClass.Melee;
            Item.width = 60;
            Item.height = 60;
            Item.useTime = 10;
            Item.useAnimation = 25;
            Item.useStyle = 1;
            Item.knockBack = 4;
            Item.value = Item.buyPrice(gold: 99, silver: 99, copper: 99);
            Item.rare = 10;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<HakSlash>();
            Item.shootSpeed = 50f;

        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.HallowedBar, 35);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 35);
            recipe.AddIngredient(ItemID.SpectreBar, 35);
            recipe.AddIngredient(ItemID.SoulofFright, 25);
            recipe.AddIngredient(ItemID.SoulofMight, 25);
            recipe.AddIngredient(ItemID.SoulofSight, 25);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}

        public override bool MeleePrefix()
        {
            return true;
        }

    }
}