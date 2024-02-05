using Microsoft.CodeAnalysis;
using Microsoft.Xna.Framework;
using Mono.Cecil;
using NonoMod.Items.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Weapons.Melee
{
	public class TrulyCactusPick : ModItem
	{
        // Silly little joke weapon again and no this is not a pickaxe.

        public override void SetDefaults()
		{
			Item.damage = 73;
			Item.DamageType = DamageClass.Melee;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 11;
			Item.useAnimation = 11;
			Item.useStyle = 1;
			Item.knockBack = 5.5f;
            Item.value = Item.buyPrice(gold: 10, silver: 11);
            Item.rare = 6;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
            Item.noUseGraphic = true;
            Item.shoot = ModContent.ProjectileType<TrulyCactusPickProjectile>();
            Item.shootSpeed = 28f;

        }

        public override bool CanUseItem(Player player)       
        {
            // Code of limiting the usage of boomerang throws. Because this isn't that other boomerang joke weapon.
            for (int i = 0; i < 1000; ++i)
            {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == Item.shoot)
                {
                    return false;
                }
            }
            return true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.CactusPickaxe, 1);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 40);
            recipe.AddIngredient(ItemID.SoulofMight, 5);
            recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.AddIngredient(ItemID.SoulofSight, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();

        }
    }
}