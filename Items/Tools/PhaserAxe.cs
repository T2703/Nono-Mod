using Microsoft.CodeAnalysis;
using Microsoft.Xna.Framework;
using Mono.Cecil;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Tools
{
	public class PhaserAxe : ModItem
	{
        // Senjustu has gotta be a favorite Iron Maiden album of mine. Samurai Eddie is badass.	

        public override void SetDefaults()
		{
			Item.damage = 22;
			Item.DamageType = DamageClass.Melee;
			Item.width = 85;
			Item.height = 85;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 1;
			Item.knockBack = 3;
            Item.value = Item.buyPrice(silver: 70);
            Item.rare = 3;
			Item.autoReuse = true;
            Item.UseSound = SoundID.Item15;
            Item.axe = 25;

        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.FireworkFountain_Blue, 0f, 0f, 0, default, 1f);
            Main.dust[dust].noGravity = true;
            Lighting.AddLight(Item.Center, 0f, 0.5f, 1f);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.MeteoriteBar, 15);
            recipe.AddIngredient(ItemID.FallenStar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

        }
    }
}