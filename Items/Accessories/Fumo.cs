using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Accessories
{
	public class Fumo : ModItem
	{
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.NonoMod.hjson file.

        public override void SetDefaults()
		{
            Item.width = 60;
            Item.height = 60;
            Item.maxStack = 1;
            Item.value = Item.buyPrice(silver: 20, copper: 69);
            Item.rare = 4;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.luck += 0.09f;
            player.statDefense += 9;
            player.lifeRegen += 9;
            player.GetDamage(DamageClass.Generic) += 0.09f;
            player.GetCritChance(DamageClass.Generic) += 0.09f;
            player.buffImmune[BuffID.Frostburn] = true;
            player.buffImmune[BuffID.Frostburn2] = true;

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Silk, 15);
            recipe.AddIngredient(ItemID.IceBlock, 5);
            recipe.AddIngredient(ItemID.SoulofLight, 1);
            recipe.AddTile(TileID.Loom);
            recipe.Register();
        }

    }
}