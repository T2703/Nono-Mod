using Microsoft.Xna.Framework;
using NonoMod.Items.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities.Terraria.Utilities;

namespace NonoMod.Items.Weapons.Ranged
{
	public class Phantom90 : ModItem
	{
        // You could call this a rip off of the P90 from Calamity but I really don't care.
        // P90 in because Solidus and uh fast gun so yeah.
        
        public override void SetDefaults()
		{
			Item.damage = 4;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 3;
			Item.useAnimation = 4;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 1.6f;
            Item.value = Item.buyPrice(gold: 9, silver: 90);
            Item.rare = ItemRarityID.Red;
			Item.autoReuse = true;
			Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<Phantom90Bullet>();
            Item.shootSpeed = 35f;
            Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item41;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5f, 0f);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            for (int i = 0; i < 2; i++)
            {
                Projectile.NewProjectile(source, position, velocity.RotatedByRandom(MathHelper.ToRadians(3)), ModContent.ProjectileType<Phantom90Bullet>(), damage, knockback, player.whoAmI);
            }
            return false;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
			Vector2 muzzleOffset = Vector2.Normalize(velocity) * 6f;
            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(7));

            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0)) {
				position += muzzleOffset;
			}
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            // Chews through ammo fast yeah.
            return Main.rand.NextFloat() >= 0.10f;
        }

    }
}