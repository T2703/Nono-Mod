using Microsoft.Xna.Framework;
using NonoMod.Buffs;
using NonoMod.Items.Projectiles;
using Steamworks;
using System;
using System.Threading;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Weapons.Melee
{
	public class SlightMotivation : ModItem
	{

        public override void SetDefaults()
		{
			Item.damage = 37;
			Item.DamageType = DamageClass.Melee;
            Item.useTime = 12;
            Item.useAnimation = 12;
            Item.useStyle = 1;
			Item.knockBack = 5;
            Item.value = Item.buyPrice(gold: 8, silver: 50, copper: 40);
			Item.rare = 4;
            Item.UseSound = SoundID.Item71;
            Item.autoReuse = true;
            Item.noUseGraphic = true;
            Item.shoot = ProjectileID.TrueExcalibur; // So I can shoot my projectile.
            Item.noMelee = true;

        }


        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {

            Random randomChoice = new Random();
            string[] slashDirection = { "X", "Y", "XY" };
            int randomIndex = randomChoice.Next(slashDirection.Length);
            string selectedDirection = slashDirection[randomIndex];

            float mouseX = Main.MouseWorld.X;
            float mouseY = Main.MouseWorld.Y;

            float randomVelX = (Main.rand.Next(2) == 0) ? -10f : 12f;
            float randomVelY = (Main.rand.Next(2) == 0) ? -10f : 12f;

            if (player.altFunctionUse == 2)
            {
                player.AddBuff(ModContent.BuffType<EdgeCooldown>(), 5555);
                if (player.direction == 1)
                {
                    Projectile.NewProjectile(source, position.X, position.Y, 17f, velocity.Y, ModContent.ProjectileType<Edge>(), damage, knockback, player.whoAmI);
                }
                else if (player.direction == -1)
                {
                    Projectile.NewProjectile(source, position.X, position.Y, -17f, velocity.Y, ModContent.ProjectileType<Edge>(), damage, knockback, player.whoAmI);
                }
            }
            else
            {
                switch (selectedDirection)
                {
                    case "X":
                        Projectile.NewProjectile(source, mouseX, mouseY, randomVelX, 0, ModContent.ProjectileType<SlightyMotivatedSlash>(), damage, knockback, player.whoAmI);
                        break;
                    case "Y":
                        Projectile.NewProjectile(source, mouseX, mouseY, 0, randomVelY, ModContent.ProjectileType<SlightyMotivatedSlash>(), damage, knockback, player.whoAmI);
                        break;
                    case "XY":
                        Projectile.NewProjectile(source, mouseX, mouseY, randomVelX, randomVelY, ModContent.ProjectileType<SlightyMotivatedSlash>(), damage, knockback, player.whoAmI);
                        break;
                    default:
                        break;
                }
            }

            return true;
        }

        public override bool AltFunctionUse(Player player) => true;

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2 && player.HasBuff(ModContent.BuffType<EdgeCooldown>()))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ReplicaOfALegend>(), 1);
            recipe.AddIngredient(ModContent.ItemType<WritingOnTheWall>(), 1);
            recipe.AddIngredient(ModContent.ItemType<LazerKatana>(), 1);
            recipe.AddIngredient(ModContent.ItemType<TheWretchedSpawn>(), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}