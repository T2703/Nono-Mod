using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Vanity
{
    // Funny cat who smokes
    // Credit to xdleviathan for the neco arc head sprite 
    [AutoloadEquip(EquipType.Head)]
    public class NecoArcHeadChaosHead : ModItem
	{

        public override void SetDefaults()
		{
            Item.width = 20; 
            Item.height = 20; 
            Item.value = Item.sellPrice(gold: 4, silver: 20); 
            Item.rare = ItemRarityID.Green; 

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.GoldBar, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

            Recipe recipeAlt = CreateRecipe();
            recipeAlt.AddIngredient(ItemID.PlatinumBar, 1);
            recipeAlt.AddTile(TileID.Anvils);
            recipeAlt.Register();

        }
    }
}