using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NonoMod.Items.Weapons.Ranged
{
	public class Postal : ModItem
	{
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.NonoMod.hjson file.

        public override void SetDefaults()
		{
			Item.damage = 36;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 50;
			Item.height = 30;
			Item.useTime = 12;
			Item.useAnimation = 12;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 7;
            Item.value = Item.buyPrice(gold: 25, silver: 50);
            Item.rare = 5;
			Item.autoReuse = true;
			Item.noMelee = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 16f;
            Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item11;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0f, 5f);
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
			Vector2 muzzleOffset = Vector2.Normalize(velocity) * 2f;

			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0)) {
				position += muzzleOffset;
			}

            if (Main.rand.NextBool(2))
            {
                type = ProjectileID.BulletHighVelocity;
            }
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.50f;
        }

    }
}