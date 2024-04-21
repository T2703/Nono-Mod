using Microsoft.CodeAnalysis;
using Microsoft.Xna.Framework;
using Mono.Cecil;
using NonoMod.Items.Projectiles;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Weapons.Melee
{
	public class BlackHoleSun : ModItem
	{
        public override void SetDefaults()
		{
			Item.damage = 115;
			Item.DamageType = DamageClass.Melee;
			Item.width = 54;
            Item.height = 54;
			Item.useTime = 17;
			Item.useAnimation = 17;
			Item.useStyle = 1;
			Item.knockBack = 5.5f;
            Item.value = Item.buyPrice(gold: 37);
            Item.rare = ItemRarityID.Yellow;
			Item.autoReuse = true;
            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<SunHole>();
            Item.shootSpeed = 20f;

        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.HallowedWeapons, 0.2f, 0f, 0, default, 1f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].scale = 1f;
        }

        /*public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.TrueExcalibur, 1);
            recipe.AddIngredient(ItemID.BrokenHeroSword, 1);
            recipe.AddIngredient(ItemID.SoulofNight, 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();

        }*/


    }
}