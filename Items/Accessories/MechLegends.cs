using Microsoft.Xna.Framework;
using NonoMod.Items.Weapons.Melee;
using NonoMod.PlayerProp;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Accessories
{
	public class MechLegends : ModItem
	{

        public override void SetDefaults()
		{
            Item.width = 41;
            Item.height = 41;
            Item.maxStack = 1;
            Item.value = Item.buyPrice(gold: 45, silver: 80, copper: 10);
            Item.rare = ItemRarityID.Green;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Generic) += 0.10f;
            player.GetCritChance(DamageClass.Generic) += 0.06f;
            player.GetKnockback(DamageClass.Generic) += 0.12f;
            player.statDefense += 10;
            player.lifeRegen += 5;

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SoulofMight, 25);
            recipe.AddIngredient(ItemID.SoulofFright, 25);
            recipe.AddIngredient(ItemID.SoulofSight, 25);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }

    }
}