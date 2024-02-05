using Microsoft.CodeAnalysis;
using Microsoft.Xna.Framework;
using Mono.Cecil;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Weapons.Melee
{
	public class LifelessKnife : ModItem
	{
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.NonoMod.hjson file.

        public override void SetDefaults()
		{
			Item.damage = 45;
			Item.DamageType = DamageClass.Melee;
			Item.width = 48;
			Item.height = 48;
			Item.useTime = 14;
			Item.useAnimation = 14;
			Item.useStyle = 1;
			Item.knockBack = 7.5f;
            Item.value = Item.buyPrice(gold: 3, silver: 20, copper: 10);
            Item.rare = 4;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;

        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Dust dust = Dust.NewDustDirect(player.Center, player.width, player.height, DustID.RedTorch, 0f, 0f, 5, default, 1f);
            dust.velocity *= 1f;
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (target.CanBeChasedBy())
            {
                player.Heal(1);
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.CrimtaneBar, 15);
            recipe.AddIngredient(ItemID.TissueSample, 5);
            recipe.AddIngredient(ItemID.SoulofNight, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();

        }
    }
}