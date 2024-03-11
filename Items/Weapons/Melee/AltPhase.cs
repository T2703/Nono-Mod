using Microsoft.Xna.Framework;
using NonoMod.Items.Projectiles;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Weapons.Melee
{
	public class AltPhase : ModItem
	{
        // Here's how this works:
        // White - Does nothing.
        // Purple - Spawns in two purple light sabers upon death or contact.
        // Blue - Homes in on the enemy.
        // Red - Spins around and around when hitting an enemy.
        // Yellow - Inflicts the ichor debuff.
        // Orange - Bounces.
        // Green - Laser party.
		public override void SetDefaults()
		{
			Item.damage = 79;
			Item.DamageType = DamageClass.Melee;
			Item.width = 75;
			Item.height = 75;
			Item.useTime = 16;
			Item.useAnimation = 16;
			Item.useStyle = 1;
			Item.knockBack = 5.6f;
			Item.value = Item.buyPrice(gold: 4, silver: 4);
            Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item15;
			Item.autoReuse = true;

		}

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Lighting.AddLight(player.Center, 2f, 3f, 4f);
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            var source = player.GetSource_ItemUse(Item);
            Vector2 targetVec = new Vector2(target.position.X, target.position.Y);
       
            Vector2 position = player.Center - new Vector2(Main.rand.NextFloat(401) * player.direction, 600f);
            position.Y -= 100;
            Vector2 heading = targetVec - position;

            heading.Normalize();
			heading *= 30;

            string[] saberPool = { "white", "purple", "blue", "red", "yellow", "orange", "green" };
            Random randomChoice = new Random();

            for (int i = 0; i < 2; i++)
            {
                heading.Y += Main.rand.Next(-40, 41) * 0.50f;
                int randomIndex = randomChoice.Next(saberPool.Length);
                string selectedSaberPool = saberPool[randomIndex];

                switch (selectedSaberPool)
                {
                    case "white":
                        Projectile.NewProjectile(source, position, heading, ModContent.ProjectileType<WhiteSaber>(), Item.damage * 2, Item.knockBack, player.whoAmI);
                        break;

                    case "purple":
                        Projectile.NewProjectile(source, position, heading, ModContent.ProjectileType<PurpleSaber>(), Item.damage, Item.knockBack, player.whoAmI);
                        break;

                    case "blue":
                        Projectile.NewProjectile(source, position, heading, ModContent.ProjectileType<BlueSaber>(), Item.damage, Item.knockBack, player.whoAmI);
                        break;

                    case "red":
                        Projectile.NewProjectile(source, position, heading, ModContent.ProjectileType<RedSaber>(), Item.damage, Item.knockBack, player.whoAmI);
                        break;

                    case "yellow":
                        Projectile.NewProjectile(source, position, heading, ModContent.ProjectileType<YellowSaber>(), Item.damage, Item.knockBack, player.whoAmI);
                        break;

                    case "orange":
                        Projectile.NewProjectile(source, position, heading, ModContent.ProjectileType<OrangeSaber>(), Item.damage, Item.knockBack, player.whoAmI);
                        break;

                    case "green":
                        Projectile.NewProjectile(source, position, heading, ModContent.ProjectileType<GreenSaber>(), Item.damage, Item.knockBack, player.whoAmI);
                        break;

                    default:
                        break;
                }
            }

        }

        public override void AddRecipes()
        {
            Recipe recipeBlue = CreateRecipe();
            recipeBlue.AddIngredient(ItemID.BluePhasesaber, 1);
            recipeBlue.AddIngredient(ItemID.SoulofMight, 10);
            recipeBlue.AddIngredient(ItemID.SoulofFright, 10);
            recipeBlue.AddIngredient(ItemID.SoulofSight, 10);
            recipeBlue.AddTile(TileID.MythrilAnvil);
            recipeBlue.Register();

            Recipe recipeGreen = CreateRecipe();
            recipeGreen.AddIngredient(ItemID.GreenPhasesaber, 1);
            recipeGreen.AddIngredient(ItemID.SoulofMight, 10);
            recipeGreen.AddIngredient(ItemID.SoulofFright, 10);
            recipeGreen.AddIngredient(ItemID.SoulofSight, 10);
            recipeGreen.AddTile(TileID.MythrilAnvil);
            recipeGreen.Register();

            Recipe recipeRed = CreateRecipe();
            recipeRed.AddIngredient(ItemID.RedPhasesaber, 1);
            recipeRed.AddIngredient(ItemID.SoulofMight, 10);
            recipeRed.AddIngredient(ItemID.SoulofFright, 10);
            recipeRed.AddIngredient(ItemID.SoulofSight, 10);
            recipeRed.AddTile(TileID.MythrilAnvil);
            recipeRed.Register();

            Recipe recipeOrange = CreateRecipe();
            recipeOrange.AddIngredient(ItemID.OrangePhasesaber, 1);
            recipeOrange.AddIngredient(ItemID.SoulofMight, 10);
            recipeOrange.AddIngredient(ItemID.SoulofFright, 10);
            recipeOrange.AddIngredient(ItemID.SoulofSight, 10);
            recipeOrange.AddTile(TileID.MythrilAnvil);
            recipeOrange.Register();

            Recipe recipeYellow = CreateRecipe();
            recipeYellow.AddIngredient(ItemID.YellowPhasesaber, 1);
            recipeYellow.AddIngredient(ItemID.SoulofMight, 10);
            recipeYellow.AddIngredient(ItemID.SoulofFright, 10);
            recipeYellow.AddIngredient(ItemID.SoulofSight, 10);
            recipeYellow.AddTile(TileID.MythrilAnvil);
            recipeYellow.Register();

            Recipe recipeWhite = CreateRecipe();
            recipeWhite.AddIngredient(ItemID.WhitePhasesaber, 1);
            recipeWhite.AddIngredient(ItemID.SoulofMight, 10);
            recipeWhite.AddIngredient(ItemID.SoulofFright, 10);
            recipeWhite.AddIngredient(ItemID.SoulofSight, 10);
            recipeWhite.AddTile(TileID.MythrilAnvil);
            recipeWhite.Register();

            Recipe recipePurple = CreateRecipe();
            recipePurple.AddIngredient(ItemID.PurplePhasesaber, 1);
            recipePurple.AddIngredient(ItemID.SoulofMight, 10);
            recipePurple.AddIngredient(ItemID.SoulofFright, 10);
            recipePurple.AddIngredient(ItemID.SoulofSight, 10);
            recipePurple.AddTile(TileID.MythrilAnvil);
            recipePurple.Register();

        }


    }
}