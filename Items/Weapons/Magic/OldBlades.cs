using Microsoft.Xna.Framework;
using NonoMod.Items.Projectiles;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Weapons.Magic
{
	public class OldBlades : ModItem
	{
        public override void SetDefaults()
		{
			Item.damage = 69;
			Item.DamageType = DamageClass.Magic;
			Item.width = 32;
			Item.height = 32;
            Item.mana = 12;
            Item.useTime = 14;
            Item.useAnimation = 14;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 5f;
            Item.value = Item.buyPrice(gold: 5);
            Item.rare = ItemRarityID.LightRed;
			Item.autoReuse = true;
			Item.noMelee = true;
            Item.shootSpeed = 18f;
			Item.UseSound = SoundID.Item20;
            Item.shoot = ProjectileID.TrueExcalibur;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 target = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
            float ceilingLimit = target.Y;

            Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<OldExcalibur>(), damage, knockback, player.whoAmI);

            if (ceilingLimit > player.Center.Y - 200f)
            {
                ceilingLimit = player.Center.Y - 200f;
            }

            for (int i = 0; i < 3; i++)
            {
                position = player.Center - new Vector2(Main.rand.NextFloat(400) * player.direction, 605f);
                position.Y -= 100 * i;
                Vector2 heading = target - position;

                if (heading.Y < 0f)
                {
                    heading.Y *= -1f;
                }

                if (heading.Y < 20f)
                {
                    heading.Y = 20f;
                }

                heading.Normalize();
                heading *= velocity.Length();
                heading.Y += Main.rand.Next(-40, 41) * 0.02f;
                Projectile.NewProjectile(source, position, heading, ModContent.ProjectileType<OldEdge>(), damage, knockback, player.whoAmI, 0f, ceilingLimit);
            }

            return false;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SpellTome, 1);
            recipe.AddIngredient(ItemID.NightsEdge, 1);
            recipe.AddIngredient(ItemID.Excalibur, 1);
            recipe.AddIngredient(ItemID.SoulofMight, 30);
            recipe.AddIngredient(ItemID.SoulofFright, 30);
            recipe.AddIngredient(ItemID.SoulofSight, 30);
            recipe.AddIngredient(ItemID.SoulofLight, 5);
            recipe.AddIngredient(ItemID.SoulofNight, 5);
            recipe.AddTile(TileID.Bookcases);
            recipe.Register();
        }



    }
}