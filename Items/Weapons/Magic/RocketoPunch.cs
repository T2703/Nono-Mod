using Microsoft.Xna.Framework;
using NonoMod.Items.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Weapons.Magic
{
	public class RocketoPunch : ModItem
	{

        public override void SetDefaults()
		{
            Item.CloneDefaults(ItemID.RainbowRod); // This just makes it work. 
			Item.damage = 56;
			Item.DamageType = DamageClass.Magic;
            Item.useTime = 80;
            Item.useAnimation = 80; 
			Item.width = 32;
			Item.height = 32;
            Item.mana = 7;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 6.8f;
            Item.value = Item.buyPrice(gold: 1);
            Item.rare = 3;
			Item.noMelee = true;
            Item.shootSpeed = 30f;
            Item.UseSound = new SoundStyle($"{nameof(NonoMod)}/Items/Sounds/RocketoPunch1")
            {
                Volume = 1f,
                MaxInstances = 10,
            };
            Item.shoot = ProjectileID.TrueExcalibur;
            Item.noUseGraphic = true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ModContent.ProjectileType<RocketoPunchP>(), damage, knockback, player.whoAmI);
            return false;
        }

        public override void AddRecipes()
        {

        }

    }
}