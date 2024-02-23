using Microsoft.Xna.Framework;
using NonoMod.Items.Projectiles;
using NonoMod.Buffs;
using Steamworks;
using System;
using System.Threading;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using NonoMod.PlayerProp;

namespace NonoMod.Items.Weapons.Melee
{
	public class Forsaken : ModItem
	{

        public float dashVelocity = 25f;

        public int dashDelay = 0;
        public int dashTimer = 0;

        // The Dollar Store Yamato

        public override void SetDefaults()
		{
			Item.damage = 420;
			Item.DamageType = DamageClass.Melee;
            Item.useTime = 5;
            Item.useAnimation = 5;
            Item.useStyle = 1;
			Item.knockBack = 5;
            Item.value = Item.buyPrice(platinum: 5, gold: 99);
			Item.rare = 5;
            Item.UseSound = new SoundStyle($"{nameof(NonoMod)}/Items/Sounds/ForsakenSlashSFX")
            {
                Volume = 0.1f,
                PitchVariance = 0.3f,
                MaxInstances = 10,
            };
            Item.autoReuse = true;
            Item.noUseGraphic = true;
            Item.shoot = ProjectileID.TrueExcalibur; // So I can shoot my projectile.
            Item.noMelee = true;

        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2 && player.HasBuff(ModContent.BuffType<JudgementCutCooldown>()))
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Random randomChoice = new Random();
            string[] slashDirection = { "X", "Y", "XY" };
            int randomIndex = randomChoice.Next(slashDirection.Length);
            string selectedDirection = slashDirection[randomIndex];

            float mouseX = Main.MouseWorld.X;
            float mouseY = Main.MouseWorld.Y;

            float randomVelX = (Main.rand.Next(2) == 0) ? -10f : 10f;
            float randomVelY = (Main.rand.Next(2) == 0) ? -10f : 10f;

            if (player.altFunctionUse == 2 && !player.HasBuff(ModContent.BuffType<JudgementCutCooldown>())) //!player.HasBuff(ModContent.BuffType<SwordDanceCooldown>())
            {
                player.AddBuff(ModContent.BuffType<Motivation>(), 1250);
                player.AddBuff(ModContent.BuffType<JudgementCutCooldown>(), 5000);

                SoundStyle JudgementCutRelease = new SoundStyle($"{nameof(NonoMod)}/Items/Sounds/ForsakenJudgeSFX")
                {
                    Volume = 0.8f,
                    PitchVariance = 0.6f,
                    MaxInstances = 10,
                };

                player.immune = true;
                player.immuneTime = 19;

                SoundEngine.PlaySound(JudgementCutRelease, player.position);

                for (int i = 0; i < 35; i++)
                {
                    Projectile.NewProjectile(source, player.Center.X + Main.rand.Next(-280, 280), player.Center.Y + Main.rand.Next(-280, 280), 0, 0, ModContent.ProjectileType<JudgementCut>(), damage * 100, knockback, player.whoAmI);
                }
                StingerDash(player);



                return false;
            }
            else
            {

                switch (selectedDirection)
                {
                    case "X":
                        Projectile.NewProjectile(source, mouseX, mouseY, randomVelX, 0, ModContent.ProjectileType<ForsakenSlash>(), damage, knockback, player.whoAmI);
                        break;
                    case "Y":
                        Projectile.NewProjectile(source, mouseX, mouseY, 0, randomVelY, ModContent.ProjectileType<ForsakenSlash>(), damage, knockback, player.whoAmI);
                        break;
                    case "XY":
                        Projectile.NewProjectile(source, mouseX, mouseY, randomVelX, randomVelY, ModContent.ProjectileType<ForsakenSlash>(), damage, knockback, player.whoAmI);
                        break;
                    default:
                        break;
                }

                if (Main.rand.NextFloat() < 0.03f)
                {
                    Projectile.NewProjectile(source, mouseX, mouseY, randomVelX, randomVelY, ProjectileID.EnchantedBeam, damage * 2, knockback, player.whoAmI);
                }
            }


            return true;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.WoodenSword, 1);
            recipe.AddIngredient(ModContent.ItemType<ReplicaOfALegend>(), 1);
            recipe.AddIngredient(ModContent.ItemType<WritingOnTheWall>(), 1);
            recipe.AddIngredient(ModContent.ItemType<LazerKatana>(), 1);
            recipe.AddIngredient(ModContent.ItemType<TheWretchedSpawn>(), 1);
            recipe.AddIngredient(ModContent.ItemType<CoffeeAndCream>(), 1);
            recipe.AddIngredient(ModContent.ItemType<NumberOne>(), 1);
            recipe.AddIngredient(ModContent.ItemType<AngelThanatos>(), 1);
            recipe.AddIngredient(ModContent.ItemType<EvilExcalibur>(), 1);

            recipe.AddIngredient(ItemID.FragmentSolar, 15);
            recipe.AddIngredient(ItemID.FragmentNebula, 15);
            recipe.AddIngredient(ItemID.FragmentVortex, 15);
            recipe.AddIngredient(ItemID.FragmentStardust, 15);

            recipe.AddIngredient(ItemID.LunarBar, 30);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();

        }

        public void StingerDash(Player player) 
        {
           Vector2 newVel = player.velocity;
                       
           if (player.direction == 1)
           {
                newVel.X = dashVelocity;
           }
           else if (player.direction == -1)
           {
                newVel.X = -dashVelocity;
           }
           player.velocity = newVel;
            

            if (dashDelay > 0)
            {
                dashDelay--;
            }

            if (dashTimer > 0)
            {
                dashTimer--;
            }
        }

    }
}