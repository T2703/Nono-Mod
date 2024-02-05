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

namespace NonoMod.Items.Weapons.Melee
{
	public class TheWretchedSpawn : ModItem
	{
        // I think the name explains itself. 

        public override void SetDefaults()
		{
			Item.damage = 39;
			Item.DamageType = DamageClass.Melee;
			Item.width = 50;
			Item.height = 50;
			Item.useTime = 24;
			Item.useAnimation = 24;
			Item.useStyle = 1;
			Item.knockBack = 5.5f;
            Item.value = Item.buyPrice(silver: 70);
            Item.rare = 3;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
			Item.scale = 1.6f;

        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.IceTorch, 0f, 0f, 0, default, 2f);
            Main.dust[dust].noGravity = true;
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            // Cool explosion 
            var source = player.GetSource_ItemUse(Item);

            if (Main.rand.NextFloat() < 0.25f)
            {
                Projectile.NewProjectile(source, target.position.X, target.position.Y, 0, 0, ProjectileID.LunarFlare, Item.damage / 2, 1, player.whoAmI);
            }
        }

        public override void OnHitPvp(Player player, Player target, Player.HurtInfo hurtInfo)
        {
            var source = player.GetSource_ItemUse(Item);

            if (Main.rand.NextFloat() < 0.12f)
            {
                Projectile.NewProjectile(source, target.position.X, target.position.Y, 0, 0, ProjectileID.LunarFlare, Item.damage / 2, 1, player.whoAmI);
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.HellstoneBar, 15);
            recipe.AddIngredient(ItemID.MeteoriteBar, 15);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}