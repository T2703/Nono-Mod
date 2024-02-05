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
	public class UnderTheGraveyard : ModItem
	{

        public override void SetDefaults()
		{
			Item.damage = 55;
			Item.DamageType = DamageClass.Magic;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 13;
            Item.mana = 10;
            Item.useAnimation = 13;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.knockBack = 3f;
            Item.value = Item.buyPrice(gold: 7, silver: 11);
            Item.rare = 4;
			Item.autoReuse = true;
			Item.noMelee = true;
            Item.shootSpeed = 21f;
			Item.UseSound = SoundID.Item21;
            Item.shoot = ProjectileID.TrueExcalibur;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            // From example code
            Vector2 target = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
            float ceilingLimit = target.Y;
            if (ceilingLimit > player.Center.Y - 200f)
            {
                ceilingLimit = player.Center.Y - 200f;
            }
            for (int i = 0; i < 2; i++)
            {
                position = player.Center - new Vector2(Main.rand.NextFloat(40) * player.direction, 500f);
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
                heading.Y += Main.rand.Next(-42, 41) * 0.03f;
                Projectile.NewProjectile(source, position, heading, ModContent.ProjectileType<Tombstone>(), damage, knockback, player.whoAmI, 0f, ceilingLimit);
            }

            return true;
        }

    }
}