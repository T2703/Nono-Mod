using Microsoft.Xna.Framework;
using NonoMod.Items.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Weapons.Ranged
{
	public class HelicopterGun : ModItem
	{
       
        
        public override void SetDefaults()
		{
			Item.damage = 2;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 50;
			Item.height = 50;
			Item.useTime = 2;
			Item.useAnimation = 2;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 0.3f;
            Item.value = Item.buyPrice(gold: 15);
            Item.rare = 3;
			Item.autoReuse = true;
			Item.noMelee = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 29f;
            Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item41;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int numberProjectiles = 3;
            for (int i = 0; i < numberProjectiles; i++)
            {

                Projectile.NewProjectile(source, position, velocity.RotatedByRandom(MathHelper.ToRadians(7)), type, damage, knockback, player.whoAmI);
            }

            return false;
        }

    }
}