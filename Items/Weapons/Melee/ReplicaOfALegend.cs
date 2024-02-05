using Microsoft.Xna.Framework;
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
	public class ReplicaOfALegend : ModItem
	{
        // This time uh really fake or something idk.


        public override void SetDefaults()
		{
			Item.damage = 21;
			Item.DamageType = DamageClass.Melee;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = 1;
			Item.knockBack = 3;
            Item.value = Item.buyPrice(gold: 2, silver: 30, copper: 50);
			Item.rare = 3;
            Item.UseSound = SoundID.Item1;
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

            float randomVelX = (Main.rand.Next(2) == 0) ? -10f : 10f;
            float randomVelY = (Main.rand.Next(2) == 0) ? -10f : 10f;

            switch (selectedDirection)
            {
              case "X":
                Projectile.NewProjectile(source, mouseX, mouseY, randomVelX, 0, ProjectileID.Muramasa, damage, knockback, player.whoAmI);
                break;
              case "Y":
                Projectile.NewProjectile(source, mouseX, mouseY, 0, randomVelY, ProjectileID.Muramasa, damage, knockback, player.whoAmI);
                break;
              case "XY":
                Projectile.NewProjectile(source, mouseX, mouseY, randomVelX, randomVelY, ProjectileID.Muramasa, damage, knockback, player.whoAmI);
                break;
              default:
                break;
            }


            return true;
        }
    }
}